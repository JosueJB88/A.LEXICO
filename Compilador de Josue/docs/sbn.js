//se llaman las funciones 
(function (global, factory) {
  typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
  typeof define === 'function' && define.amd ? define(factory) :
  (global.sbn = factory());
}(this, (function () { 'use strict';

// \s : coincide con cualquier carácter de espacio en blanco (igual a [\r\n\t\f\v ])
//  + : coincida con la condición anterior por una vez e ilimitadas veces
function lexer (code) {
  //se resibe los datos den analizador lexico
  var _tokens = code
                  .replace(/[\n\r]/g, ' *nl* ')
                  .replace(/\[/g, ' *ob* ')
                  .replace(/\]/g, ' *cb* ')
                  .replace(/\{/g, ' *ocb* ')
                  .replace(/\}/g, ' *ccb* ')
                  .split(/[\t\f\v ]+/)
  var tokens = []
  for (var i = 0; i < _tokens.length; i++) {
    var t = _tokens[i]
    if(t.length <= 0 || isNaN(t)) {
      if (t === '*nl*') {
        tokens.push({type: 'newline'})
      } else if (t === '*ob*') {
        tokens.push({type: 'ob'})
      } else if (t === '*cb*') {
        tokens.push({type: 'cb'})
      } else if (t === '*ocb*') {
        tokens.push({type: 'ocb'})
      } else if (t === '*ccb*') {
        tokens.push({type: 'ccb'})
      } else if(t.length > 0) {
        tokens.push({type: 'word', value: t})
      }
    } else {
      tokens.push({type: 'number', value: t})
    }
  }

  if (tokens.length < 1) {
    throw 'No se encontraron tokens. Prueba "Papel 10"'
  }

  return tokens
}
// se recibe el analizaor sintactico y se genera el arbol
function parser (tokens) {
  function expectedTypeCheck (type, expect) {
    if(Array.isArray(expect)) {
      var i = expect.indexOf(type)
      return i >= 0
    }
    return type === expect
  }

  function createDot (current_token, currentPosition, node) {
    var expectedType = ['ob', 'number', 'number', 'cb']
    var expectedLength = 4
    currentPosition = currentPosition || 0
    node = node || {type: 'dot'}

    if (currentPosition < expectedLength - 1) {
      if (expectedTypeCheck(current_token.type, expectedType[currentPosition])){
        if(currentPosition === 1) {
          node.x = current_token.value
        }
        if(currentPosition === 2) {
          node.y = current_token.value
        }
        currentPosition++
        createDot(tokens.shift(), currentPosition, node)
      } else {
        throw 'Expected ' + expectedType[currentPosition] + ' but found ' + current_token.type + '.'
      }
    }
    return node
  }

  function findArguments(command, expectedLength, expectedType, currentPosition, currentList) {
    currentPosition = currentPosition || 0
    currentList = currentList || []
    while (expectedLength > currentPosition) {
      var token = tokens.shift()
      if (!token) {
        throw command + ' takes ' + expectedLength + ' argument(s). '
      }

      if (expectedType){
        var expected = expectedTypeCheck(token.type, expectedType[currentPosition])
        if (!expected) {
          throw command + ' takes ' + JSON.stringify(expectedType[currentPosition]) + ' as argument ' + (currentPosition + 1) + '. ' + (token ? 'Instead found a ' + token.type + ' '+ (token.value || '') + '.' : '')
        }
        if (token.type === 'number' && (token.value < 0 || token.value > 100)){
          throw 'Found value ' + token.value + ' for ' + command + '. Value must be between 0 - 100.'
        }
      }

      var arg = {
        type: token.type,
        value: token.value
      }
      if (token.type === 'ob') {
        arg = createDot(token)
      }
      currentList.push(arg)
      currentPosition++
    }
    return currentList
  }

  var AST = {
    type: 'Drawing',
    body: []
  }
  var paper = false
  var pen = false

  while (tokens.length > 0) {
    var current_token = tokens.shift()
    if (current_token.type === 'word') {
      switch (current_token.value) {
        case '{' :
          var block = {
            type: 'Block Start'
          }
          AST.body.push(block)
          break
        case '}' :
          var block = {
            type: 'Block End'
          }
          AST.body.push(block)
          break
        case '//' :
          var expression = {
            type: 'CommentExpression',
            value: ''
          }
          var next = tokens.shift()
          while (next.type !== 'newline') {
            expression.value += next.value + ' '
            next = tokens.shift()
          }
          AST.body.push(expression)
          break
        case 'Paper' :
          if (paper) {
            throw 'No se puede definir Papel más de una vez'
          }
          var expression = {
            type: 'CallExpression',
            name: 'Paper',
            arguments: []
          }
          var args = findArguments('Paper', 1)
          expression.arguments = expression.arguments.concat(args)
          AST.body.push(expression)
          paper = true
          break
        case 'Pen' :
          var expression = {
            type: 'CallExpression',
            name: 'Pen',
            arguments: []
          }
          var args = findArguments('Pen', 1)
          expression.arguments = expression.arguments.concat(args)
          AST.body.push(expression)
          pen = true
          break
        case 'Line':
          if(!paper) {
            // lanzar 'Por favor, haga el papel primero'
            // TODO: no hay mensaje de error 'Debes hacer papel primero'
          }
          if(!pen) {
            // throw 'Por favor, defina Pen 1st'
            // TODO: no hay mensaje de error 'Primero debe configurar el color de la Pen'
          }
          var expression = {
            type: 'CallExpression',
            name: 'Line',
            arguments: []
          }
          var args = findArguments('Line', 4)
          expression.arguments = expression.arguments.concat(args)
          AST.body.push(expression)
          break
        case 'Set':
          var args = findArguments('Set', 2, [['word', 'ob'], 'number'])
          var obj = {}
          if (args[0].type === 'dot') {
            AST.body.push({
              type: 'CallExpression',
              name: 'Pen',
              arguments:[args[1]]
            })
            obj.type = 'CallExpression',
            obj.name = 'Line',
            obj.arguments = [
              { type: 'number', value: args[0].x},
              { type: 'number', value: args[0].y},
              { type: 'number', value: args[0].x},
              { type: 'number', value: args[0].y}
            ]
          } else {
            obj.type = 'VariableDeclaration'
            obj.name = 'Set'
            obj.identifier = args[0]
            obj.value = args[1]
          }

          AST.body.push(obj)
          break
        default:
          throw current_token.value + ' is not a valid command'
      }
    } else if (['newline', 'ocb', 'ccb'].indexOf[current_token.type] < 0 ) {
      throw 'Tipo de token inesperado : ' + current_token.type
    }
  }

  return AST
}

function transformer (ast) {

  function makeColor (level) {
    if (typeof level === 'undefined') {
      level = 100
    }
    level = 100 - parseInt(level, 10) // flip
    return 'rgb(' + level + '%, ' + level + '%, ' + level + '%)'
  }

  function findParamValue (p) {
    if (p.type === 'word') {
      return variables[p.value]
    }
    return p.value
  }

  var elements = {
    'Line' : function (param, pen_color_value) {
      return {
        tag: 'line',
        attr: {
          x1: findParamValue(param[0]),
          y1: 100 - findParamValue(param[1]),
          x2: findParamValue(param[2]),
          y2: 100 - findParamValue(param[3]),
          stroke: makeColor(pen_color_value),
          'stroke-linecap': 'round'
        },
        body: []
      }
    },
    'Paper' : function (param) {
      return {
        tag : 'rect',
        attr : {
          x: 0,
          y: 0,
          width: 100,
          height:100,
          fill: makeColor(findParamValue(param[0]))
        },
        body : []
      }
    }
  }

  var newAST = {
    tag : 'svg',
    attr: {
      width: 100,
      height: 100,
      viewBox: '0 0 100 100',
      xmlns: 'http://www.w3.org/2000/svg',
      version: '1.1'
    },
    body:[]
  }

  var current_pen_color
  // TODO : advertencia cuando el papel y la Pen son del mismo color

  var variables = {}

  while (ast.body.length > 0) {
    var node = ast.body.shift()
    if(node.type === 'CallExpression' || node.type === 'VariableDeclaration') {
      if(node.name === 'Pen') {
        current_pen_color = findParamValue(node.arguments[0])
      } else if (node.name === 'Set') {
        variables[node.identifier.value] = node.value.value
      } else {
        var el = elements[node.name]
        if (!el) {
          throw node.name + ' no es un comando válido.'
        }
        if (typeof !current_pen_color === 'undefined') {
          // throw 'Defina pen antes de dibujar Línea.'
          // TODO : mensaje 'Debe definir Pen antes de dibujar Línea'
        }
        newAST.body.push(el(node.arguments, current_pen_color))
      }
    }
  }

  return newAST
}
// se llama el generador de codigo
function generator (ast) {

  function traverseSvgAst(obj, parent, rest, text) {
    parent = parent || []
    rest = rest || []
    text = text || ''
    if (!Array.isArray(obj)) {
      obj = [obj]
    }

    while (obj.length > 0) {
      var currentNode = obj.shift()
      var body = currentNode.body || ''
      var attr = Object.keys(currentNode.attr).map(function (key){
        return key + '="' + currentNode.attr[key] + '"'
      }).join(' ')

      text += parent.map(function(){return '\t'}).join('') + '<' + currentNode.tag + ' ' + attr + '>'

      if (currentNode.body && Array.isArray(currentNode.body) && currentNode.body.length > 0) {
        text += '\n'
        parent.push(currentNode.tag)
        rest.push(obj)
        return traverseSvgAst(currentNode.body, parent, rest, text)
      }

      text += body + '</'+ currentNode.tag +'>\n'
    }

    while (rest.length > 0) {
      var next = rest.pop()
      var tag = parent.pop()
      text += parent.map(function(){return '\t'}).join('') + '</'+ tag +'>\n'
      if (next.length > 0) {
        traverseSvgAst(next, parent, rest, text)
      }
    }

    return text
  }

  return traverseSvgAst(ast)
}

var SBN = {}

SBN.VERSION = '0.1'
SBN.lexer = lexer
SBN.parser = parser
SBN.transformer = transformer
SBN.generator = generator

SBN.compile = function (code) {
  return this.generator(this.transformer(this.parser(this.lexer(code))))
}

return SBN;

})));
