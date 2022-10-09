//inicia la funcion
window.onload = function(){
	//se declran las funcion para el error y la salda
	var ERROR = false;
	var HASTA = null;
	
	//se guardan los numero, varibles, simbolos, signos y condiciones y la guarda en una array que son letras
	D = [0,1,2,3,4,5,6,7,8,9];
	L = ['a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'];
	O = ['&&','||'];
	S = ['>','<','>=','<=','==',,'!=','==='];
	Q = ["+","-","*","/"];
	
	/*
	A -> while(BH
	B -> VOF
	V -> NSI | ISN
	O -> && | ||
	F -> VG
	G -> OF | ){
	H -> M | }
	M -> R;H
	R -> I=K
	K -> NQJ
	J -> KJ|N
	N -> DN'
	N'-> DN'|e
	I -> LI'
	I'-> LI'|e
	*/

	// funcion de error se verifica qque todo cumpla con lo guardado y que sea un while
	function error(){
	  log("<strong>### Error</strong>");
	  if(!ERROR){
	  	 alert("No cumple con la estructura");
		 HASTA = document.getElementById("result").innerHTML;
	 	 ERROR = true;
	  }
	}
	
	// se comprueba s todo funciona y si es asi corre el compilador y saca los resultados
	function exito(){
		if(!ERROR){
     		log("<strong>!!! ÉXITO</strong>");
	  		alert("ÉXITO!");
		}
	}
	// analiza el resultado y detecta los saltos de linea 
	function log(text){
	 var pas = document.getElementById("result").innerHTML;
	 pas+=text + '<br/>';
		document.getElementById("result").innerHTML = pas;
	}
	
	//verifica si la funcion es un while
	function a(input){
		log("Empezando ...");
		log("INPUT : " + input);
		
		if(input.substring(0,6) == "while("){
			var index = 0;
			input = input.substring(6,input.length);
			log("While detectado");
			index+=b(input);
			if(!ERROR)index+=h(input.substring(index,input.length));
		}else{
			alert("ERROR");
		}
	}
	
	// H -> M | }
	function h(input){
		log("------------------- Entro a H ...");
		log("INPUT : " + input);
		
		var index = 0;
		
		if(input[0] != '}'){
			index+=m(input);
			log("Salió de M : " + input.substring(index,input.length));
		}else if(input[0] == '}'){
			exito();
		}else{
			error();
		}
		
		return index;
	}
	
	// M -> R;H
	function m(input){
		log("------------------- Entro a M ...");
		log("INPUT : " + input);
		
		var index=0;
		index+=r(input);
		
		if(!ERROR){
			if(input[index] == ';'){
				index++;
				index+=h(input.substring(index,input.length));   
				log("Salió de H : " + input.substring(index,input.length));
			}else{
				error();
				return false;
			}
		}
		
		return index;
	}
	
	// R -> I=K
	function r(input){
		log("------------------- Entro a R ...");
		log("INPUT : " + input);
		
		var index=0;
		index+=i(input);
		
		if(!ERROR){
			if(input[index] == '='){
				 index++;
				 index+=k(input.substring(index,input.length));  
				log("Salió de K : " + input.substring(index,input.length));
			}else{
				error();
				return false;
			}
		}
		
		return index;
	}
	
	// K -> NQJ
	function k(input){
		log("------------------- Entro a K ...");
		log("INPUT : " + input);
		
		var index=0;
		
		index+=n(input);
		
		if(!ERROR){
			if(input[index] == ";"){
				log("Pasó N");
			}else{
				index+=q(input.substring(index,input.length));
				log(input.substring(index,input.length));
				if(!ERROR)index+=j(input.substring(index,input.length));
				log("Salió de j : " + input.substring(index,input.length));
			}
		}
		return index;
	}
	
	//J -> KJ|N
	function j(input){
		log("------------------- Entro a J ...");
		log("INPUT : " + input);
		
		var index = 0;
		index+=k(input);
		
		if(!ERROR){
			if(index == 0){		
				index+=n(input.substring(index,input.length));	
			}else{
				index+=j(input.substring(index,input.length));
			}
		}
		
		return index;
	}
	
	//B -> VOF
	
	function b(input){
		log("------------------- Entro a B ...");
		log("INPUT : " + input);
	   
		// V
		var index = 0;
		index+=v(input);
		
		if(!ERROR){
			if(input[index] + input[index+1] == '){'){
				index+=2;
				index+=h(input.substring(index,input.length)); 
			}else{
				// O
				var p = index;
				index+=o(input.substring(index,input.length));
				// F
				if(!ERROR)index+=f(input.substring(index,input.length));
			}
		}
		
		return index;   
	}
	
	//F -> VG
	
	function f(input){
		log("------------------- Entro a F ...");
		log("INPUT : " + input);
		
		var index=0;
		
		index+=v(input);
		
		if(!ERROR){
			if(index == 0){
				error();
				return false;
			}else{
				index+=g(input.substring(index,input.length));
			}
		}
		
		return index;
	}
	
	//G -> OF | ){
	
	function g(input){
	   log("------------------- Entro a G ...");
	   log("INPUT : " + input);
		
	   var index=0;
	
	   var test = input[0] +  input[1];
	   if(test == '){'){
		   //log("Válido en G : ){");
		   index+=2;  
	   }else{ 
		   index+=o(input);
		   if(!ERROR)index+=f(input.substring(index,input.length));
	   }
	   return index;
	}
	
	// O -> && | ||
	
	function o(input){
		log("------------------- Entro a O ...");
		log("INPUT : " + input);
		var index = 0;
		var test = input[0] + input[1];
		
		for(var i in O){
			if(test == O[i]){
				index+=2;
				log("Válido en O : " + test);
				break;   
			}
		}
		
		
		return index;
	}
	
	// V -> NSI | ISN
	
	function v(input){
		log("------------------- Entro a V ...");
		log("INPUT : " + input);  
		
		var index = 0;
		
		// NSI
		index+=n(input);
		
		if(index == 0){
			// ISN
			index+=i(input);
			if(!ERROR)index+=s(input.substring(index,input.length));
			var past = index;
			log("INDEX : " + index);
			if(!ERROR)index+=n(input.substring(index,input.length));
			log("INDEX : " + index);
			if(past == index)error();
		}else{
			index+=s(input.substring(index,input.length));
			var past = index;
			if(!ERROR)index+=i(input.substring(index,input.length));
			if(past == index)error();
		}
	
		return index;
	}
	
	// N -> DN'
	
	function n(input){
		log("------------------- Entro a N ...");
		log("INPUT : " + input);
		var pass = false;
		var index = 0;
		
		for(var i in D){
			if(input[index] == D[i]){
				pass = true;
				break;
			}
		};
		
		if(pass){
			//log("Siguiente de B es número: " + input[index]);
			index++;
			var next;
			while((next = n_(input[index])) == true){
				//log("Pasó siguiente cifra : " + input[index]);
				index++;
				break;
			}
		}
		
		return index;
	};
	
	// N' -> DN'|e
	
	function n_(input){
		var pass = false;
		
		for(var i in D){
			if(input == D[i]){
				pass = true;
				break;
			}
		};
		
		return pass;
	};
	
	// I -> LI'
	function i(input){
		log("------------------- Entro a I ...");
		log("INPUT : " + input);
		
		var pass = false;
		var index = 0;
		
		for(var i in L){
			if(input[index] == L[i]){
				pass = true;
				break;
			}
		};
		
		if(pass){
			//log("Siguiente de B es letra :" + input[index]);
			index++;
			var next;
			while((next = i_(input[index])) == true){
				//log("Pasó siguiente letra : " + input[index]);
				index++; 
			}
		}
		
		// Tiene siguiente ?
		return index;
	};
	
	// I' -> LI'|e
	
	function i_(input){
		var pass = false;
		
		for(var i in L){
			if(input == L[i]){
				pass = true;
				break;
			}
		};
		
		return pass;
	};
	
	function q(input){
		log("------------------- Entro a Q ...");
		log("INPUT : " + input);
		var index = 0;
		
		
		for(var i in Q){
			log(input[0] + " -> " + Q[i]);
			if(Q[i] == input[0]){
				index++;
				break;
			}
		} 
		
		return index;
	}
	
	function s(input){
		log("------------------- Entro a S ...");
		log("INPUT : " + input);
		
		var pass = false;
		var index = 0;
		
		for(var i in S){
			if(S[i].length >= 2){
				var test = input[index] + input[index+1];
				if(test == S[i]){
					pass = true;
					index+=2;
					break;
				}
			}
		}
		
		if(!pass){
			for(var i in S){
				if(input[index] == S[i]){
					  pass = true;
					  index++;
					  break; 
				}
			}
		}
		
		return index;
	}
	
	
	// se verifica que todo cumple las condiciones.
	
	document.getElementById("test").addEventListener("click",function(){
	   ERROR = false;
	   HASTA = null;
	   var input = document.getElementById("codigo").value;
	   document.getElementById("result").innerHTML = "";
	   a(input);
	   if(HASTA != null){
		    document.getElementById("result").innerHTML = "";
	   		log(HASTA);
	   }
	},false);
}
