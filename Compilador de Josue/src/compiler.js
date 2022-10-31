//Aqui se llaman todas las funciones 

import { lexer, parser } from './Lexico.js';
import { transformer } from './semantico.js';
import { generator } from './generator.js';

var SBN = {}

SBN.VERSION = '0.1'
SBN.lexer = lexer
SBN.parser = parser
SBN.transformer = transformer
SBN.generator = generator

SBN.compile = function (code) {
  return this.generator(this.transformer(this.parser(this.lexer(code))))
}

export default SBN
