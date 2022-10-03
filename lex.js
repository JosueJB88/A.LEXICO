////  Ahora se declara los elementos que manda el index///////

var Expresion = document.getElementById('Expresion');
var Resultado = document.getElementById('Resultado');
var array = Expresion.innerHTML.split(/\s+/);

for(var i in array) {

     if(/^[a-z]$/.test(array[i])){
        
        Resultado.innerHTML = Resultado.innerHTML + array[i] +"Es una Constante\n";

     }else if (/^[1-9]|[0-9]$/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Numero\n";
     
    }else if (/^(bin)[0-1]+$/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Binario\n";
    
    }else if (/^[*]$/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Multiplicacion\n";

    }else if (/^[+]$/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Suma\n";
    
    }else if (/^[-]$/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Menos\n";

    }else if (/^[/]$/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Division\n";
    
    
    /////////Palabras claves guardadas//////

    
    }else if (/(for|while|if|true|false|else|case|break)/.test(array[i])) {
        Resultado.innerHTML = Resultado.innerHTML + array[i] + "Palabras reservadas o claves\n";
    }
    

}