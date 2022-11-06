using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ProyectoJosue
{




    public partial class Form1 : Form
    {

        public int xClick = 0, yClick = 0;
        public Form1()
        {
            InitializeComponent();
           // Colorearletras.Enabled = true;
            // ActualizarAnalisis.Enabled = true;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string palabraanteriorsemantica = "";


        string si1 = "";
        string si2 = "";
        string si3 = "";


        void semantica(string palabra, string tipo)
        {
            // vamos a empezar a capturar errores semanticos
            if (tipo == "variable") { }
            if (tipo == "valor numerico") { }
            if (palabra == "+") { }




        }

        int cont = 0;
        Boolean comentario = false;
        string concatenaComentario = "";

        //void traslate(string palabra, string ) { }
        int asignarcadena = 0;
        private void analiLex()
        {
            palabraanteriorRe = "";
            si = false;
            palabraanteriorsi = "";
            richSi.Text = "";
            si1 = "";
             si2 = "";
             si3 = "";
            CCCode.Text = "";

            asignarcadena = 0;
            varcadasig.Text = "";
            varecha = false;
             cont = 0;
             comentario = false;
             concatenaComentario = "";
            puntos = 0;

            valoresenteros = 0;
             declaradorentero = 0;
             asignaciones = 0;
             comparaciones = 0;
             sumas = 0;
             restas = 0;
             divisiones = 0;
             valornumericos = 0;
             separador = 0;


             incremento = 0;
             solo = 0;
             declaracioncadenas = 0;
             cierretextoliterales = 0;

             repsn = false;

             aperturatextoliterales = 0;
             cierreoperaciones = 0;
             com = 0;
             variables = 0;
             palabraanterior = "";
             tipoanterior = "";
             inicio = 1;
             cierreinicio = false;

             pr = false;

             vr = false;

             igr = false;

             vnr = false;

             sr = false;

             vr2 = false;

             compr = false;

             vanu = false;

             sp2r = false;

             vafr = false;

             incr = false;
             ciclo1 = false;
             dospuntos = 2;
             variablesrep = 5;
             numeros = 2;

             aesperadeSolo = 0;

             hayinicio = 0;
             exsi = 0;
             esperandocadena = 0;
             variablestring = "";
             concatenacadena = "";
             esperandovalor = 0;
             esperavarconsint = false;
             esperavarint = false;
             e = 0;




            s = false;

             aperturaComparacion = false;

             ComparacionCerrada = false;


            amoc = false;
             vae = false;
             vaes = false;
             vaest = false;
             concate = "";

             ifon = false;

             paif = false;


            cierresi = 0;
            esperandovalor = 0;
            richErroresSintac.Text = "";
            richsemantica.Text = "";
            erroresSemanticos.Text = "";
            varnumasig.Text = "";
            richcadenas.Text = "";
            richenteras.Text = "";
            System.IO.File.Delete("variablesINT.txt");
            System.IO.File.Delete("variableString.txt");


            int llavesnecesarias = 0;
            int parentesisnecesarios = 0;
            int llavesnecesariasSi = 0;
            //int parentesisnecesariossi = 0;
            //int variablesnecesariassi = 0;
            //int operadoresnecesarios = 0;
            valoresenteros = 0;
            declaradorentero = 0;
            asignaciones = 0;
            comparaciones = 0;
            sumas = 0;
            restas = 0;
            divisiones = 0;
            valornumericos = 0;
            separador = 0;
            //asignador = 0;
            incremento = 0;
            solo = 0;
            declaracioncadenas = 0;
            cierretextoliterales = 0;
            repsn = false;
            aperturatextoliterales = 0;
            cierreoperaciones = 0;
            com = 0;
            variables = 0;
            palabraanterior = "";
            tipoanterior = "";
            inicio = 1;
            cierreinicio = false;
            pr = false;
            vr = false;
            igr = false;
            vnr = false;
            sr = false;
            vr2 = false;
            compr = false;
            vanu = false;
            sp2r = false;
            vafr = false;
            incr = false;
            ciclo1 = false;
            dospuntos = 2;
            variablesrep = 5;
            numeros = 2;
            aesperadeSolo = 0;
            hayinicio =




               valoresenteros = 0;
            declaradorentero = 0;
            asignaciones = 0;
            comparaciones = 0;
            sumas = 0;
            restas = 0;
            repsn = false;
            cont = 0;
            divisiones = 0;
            valornumericos = 0;
            declaracioncadenas = 0;
            cierretextoliterales = 0;
            aperturatextoliterales = 0;
            cierreoperaciones = 0;
            com = 0;
            variables = 0;
            palabraanterior = "";
            inicio = 1;
            cierreinicio = false;
            hayinicio = 0;
            comentario = false;
            exsi = 0;

            char[] delimitadoresChar = { ' ', '\n' };
            char[] delimitadoresCharR = { ',' };

            string concatenatext = "";

            string[] words = CodigoMeedCompyTxt.Text.Split(delimitadoresChar);
            int numero = 0;
            string plabrasR = System.IO.File.ReadAllText("palabras reservadas.txt");
            String[] palabrasReservadas = plabrasR.Split(delimitadoresCharR);

            foreach (string word in words)
            {


                string tipo = "";
                System.Console.WriteLine($"<{word}>");


                if (word == "//") { comentario = true; }

                if (comentario == false)
                {
                    concatenatext += " " + word;


                    if (word == "inicio" |

                      word == "si" |
                      word == "pantalla" |


                      word == "solo" |
                      word == "" |

                      word == "ciclo")

                    {


                        




                        if (word != "")
                        {
                            //se jodio
                            pantalla(word,tipo);
                            MandarPalabraReservada(word);
                            tipo = "palabra reservada"; AnalalisisSintactico(word, tipo); traducir(word, tipo); ciclo(word, tipo);
                            semantica(word, tipo);
                            sintactica(word , tipo);
                            cierres(word, tipo);
                        }





                    }
                    else if (word.ToLower() == "sino")
                    {
                        tipo = "sino"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo);

                    }
                    else if (word == "=" |
                      word == "==" |
                       word == "<" |
                        word == ">" |
                      word == "solo" |
                      word == "+" |
                      word == "," |
                      word == ":" |
                      word == "++" |
                      word == "-" |
                      word == "|" |
                      word == "/" |
                       word == ";" |
                        word == "?" |
                        word == "<<" |
                        word == ">>" |
                        word == "com" |
                         word == "@" |
                      word == "!"

                     )
                    {

                        MandarSigno(word);
                        if (word == "=") { tipo = "asignacion"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == ",") { tipo = "separador"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "|") { tipo = "separ"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }

                        if (word == "<") { tipo = "comparacion"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == ">") { tipo = "comparacion"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }


                        if (word == "==") { tipo = "comparacion"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "+") { tipo = "suma"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "++") { tipo = "incremento"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "-") { tipo = "resta"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "/") { tipo = "divicion"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == ";") { tipo = "cierre operacion"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "!") { tipo = "declaracion entero"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "@") { tipo = "declaracion cadena"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == ":") { tipo = "dosdot"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "<<") { tipo = "apertura textoliteral"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == ">>") { tipo = "cierre textoliteral"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "com") { tipo = "com"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "solo") { cierresolo += 1; tipo = "solo"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }
                        if (word == "?") { tipo = "cierresi"; AnalalisisSintactico(word, tipo); traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo); }


                    }



                    else if (word == "//")
                    {
                        comentario = true;




                        RIchTxLexico.Text = RIchTxLexico.Text + "comando de comentario: " + word + "\n";


                    }
                    else if (word == "(" | word == ")" | word == "{" | word == "}" | word == "};")
                    {


                        if (word != "};")
                        {
                            RIchTxLexico.Text = RIchTxLexico.Text + "Signo de agrupación: " + word + "\n";

                            if (word == "(")
                            {

                                tipo = "apertura parentesis";
                                AnalalisisSintactico(word, tipo);
                                traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo);
                                pantalla(word, tipo);

                            }
                            else if (word == ")")
                            {

                                tipo = "cierre de parentesis";
                                AnalalisisSintactico(word, tipo);
                                traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo);


                            }
                            else if (word == "{")
                            {

                                tipo = "apertura de llave";
                                AnalalisisSintactico(word, tipo);
                                traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo);


                            }
                            else if (word == "}")
                            {

                                tipo = "cierre de llave";
                                AnalalisisSintactico(word, tipo);
                                traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo);


                            }


                        }
                        else
                        {



                            RIchTxLexico.Text = RIchTxLexico.Text + "cierre de agrupación principal inicio: " + word + "\n";
                            tipo = "cierre inicio";
                            AnalalisisSintactico(word, tipo);
                            traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo); pantalla(word, tipo);

                        }


                    }
                    else
                    {
                        if (int.TryParse(word, out numero))
                        {

                            tipo = "valor numerico";


                            RIchTxLexico.Text = RIchTxLexico.Text + "Valor constante: " + word + "\n";
                            AnalalisisSintactico(word, tipo);
                            traducir(word, tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo);
                            pantalla(word, tipo);


                        }
                        else if (word != null)
                        {
                            tipo = "variable";
                            // aqui es probable que en ejemplo se escriba de esta manera un if "  si(numero1==numero2)com  " lo reconocera
                            // de esta forma "Variable local: si(numero1==numero2)com"
                            // por lo que tendria que traer la cadena o la word que viene y analizar letra por letra en busca
                            //de palabras reservadas
                            //... dos opciones o busco la forma de que funcione el analizar el word y sepa cuando hay palabras reservadas
                            //o solo hago que el compy se trate de dejar los espacios

                            RIchTxLexico.Text = RIchTxLexico.Text + "Variable local: " + word + "\n";
                            AnalalisisSintactico(word, tipo);
                            traducir(word , tipo); sintactica(word, tipo); cierres(word, tipo); ciclo(word, tipo);
                            pantalla(word, tipo);



                        }
                    }

                }
                else
                {
                    // todo lo que aparezca aqui es comentario hasta que se encuentre un //
                    cont += 1;

                    concatenaComentario += " " + word;

                    if (word == "///")
                    {
                        RIchTxLexico.Text += concatenaComentario + "\n";
                        // aqui termina el comentario
                        RIchTxLexico.Text += "terninó el comentario\n";
                        comentario = false;

                        string ne = concatenaComentario + "";
                        concatenaComentario = "";


                    }



                    // int index = CodigoMeedCompyTxt.SelectionStart;
                    // int sta = (concatenaComentario.Length - concatenatext.Length)*-1;
                    //// MessageBox.Show("la resta de " + concatenaComentario.Length.ToString() + " Y " + concatenatext.Length.ToString() + " es: " + sta.ToString());

                    // CodigoMeedCompyTxt.Select(concatenatext.Length, concatenaComentario.Length + concatenatext.Length);
                    // CodigoMeedCompyTxt.SelectionColor = Color.Green;
                    // CodigoMeedCompyTxt.SelectionStart = index;
                    // CodigoMeedCompyTxt.Font = new Font(CodigoMeedCompyTxt.Font, FontStyle.Bold);

                    // CodigoMeedCompyTxt.SelectionColor = Color.White;












                }






            }
            // aqui se daran los errores sintacticos






            //if (hayinicio == 1) { analisisSin.Text += "Funcion principal inicio encontrada\n"; }
            //if (hayinicio > 1) { richErroresSintac.Text += "Error solo puede haber un inicio\n"; }

            if (llavesnecesarias == 0)
            {
                if (cierreinicio == false)
                { richErroresSintac.Text += "Error se esperaba }; cierre de inicio\n"; }
                else { analisisSin.Text += "no se encontraron errores en las llaves usadas\n"; }
            }
            else
            { richErroresSintac.Text += "verifica si usas las llaves correctamente\n"; }
            if (inicio == 1)
            {
                richErroresSintac.Text += "No se encuentra la funcion principal inicio\n";
            }
            if (llavesnecesariasSi == 0) { analisisSin.Text += "las llaves del si son correctas \n"; }

            if (parentesisnecesarios == 0)
            {
                analisisSin.Text += "no se encontraron errores en las parentesis usados\n";
            }
            else
            { richErroresSintac.Text += "verifica si usas los parentesis correctamente\n"; }
            if (variables == 0)
            {
                analisisSin.Text += "se han utilizado un numero correcto de variables \n";
            }
            else if (variables == 1)
            {
                if (valoresenteros == 0) { analisisSin.Text += "se han utilizado un numero correcto de variables y valores enteros\n"; }
            }
            else if (valoresenteros == 1)
            {


                analisisSin.Text += "se pude estar usando una estructura de ciclo\n";
            }
            //else
            //{

            //    richErroresSintac.Text += "verifica si usas un expresion de (variable == variable) o (variable == constante)\n";

            //}
            //if (comparaciones == 0) { analisisSin.Text += "el numero de comparadores es correcto \n"; }
            //else { richErroresSintac.Text += "Error comparadores en <<si ( variable comparador variable_constante )>> puedes tener uno de más o puede que te falte uno \n"; }
            //if (com == 0) { analisisSin.Text += "el numero de palabras com coincide con el numero de si \n"; }
            //else
            //{
            //    richErroresSintac.Text += "Error falta o sobra un <<com>>\n";

            //}


            pintar();

            /////////////////////////////////////////////////////// aqui viene el analisis sintactico del SI //////////////////  
            //llavesnecesarias = 2;
            //parentesisnecesarios = 2;
            //variables = 2;
            //valoresenteros = 1;
            //comparaciones = 1;




            //parentesisnecesarios = 2;
            //separador = 3;
            //solo = 1;
            //asignaciones = 1;
            //variables = 5;
            //valornumericos = 3;
            //comparaciones = 1;
            //MessageBox.Show("el valor de richsi es: " + richSi.Text);
            //if (richSi.Text != "si ( variable == variable2 ) com { ") { richErroresSintac.Text += "Error se detectaron errores en la estructura de <<si>>"; }
            if (cierresi > 0 ) {
                richErroresSintac.Text += "se esperaba un <<?>> para el cierre de un <<si>>";

            }
            if (cierresolo > 0) {
                richErroresSintac.Text += "se esperaba un <<solo>> para el cierre de un <<ciclo>>";




            }





        }
        string palabraanteriorsi = "";
        int cierresi = 0;
        int cierresolo = 0;
        string palabraanteriorRe = "";


        void ciclo(string palabra, string tipo) {


            if (palabra == "ciclo") { analisisSin.Text += "Se ha detectado un <<ciclo>>"; richRepetir.Text += "ciclo "; palabraanteriorRe = palabra;}
            else if (palabra == "(" && palabraanteriorRe == "ciclo") {
                palabraanteriorRe = "(";
                richRepetir.Text += "( ";

            }

        }

        Boolean varecha = false;
        Boolean si = false;
        Boolean esperartexto = false;
        string conca = "";


        void pantalla(string palabra, string tipo) {


            if (palabra == "pantalla" | esperartexto ==  true) {

                esperartexto = true;
                if (tipo == "variable" | tipo == "valor numerico") {
                    conca += palabra + " ";



                }
                else if(palabra  == "|"){

                    esperartexto = false;

                }
                    palabraanterior =  palabra;
            }




        }

        void pedir(string palabra  , string tipo) {





        }



        void sintactica(string palabra, string tipo) {




            /// rehaciendo la sintactica, empezamos por el si //////
            /// 
            
            if (palabra == "si" /*&& richSi.Text != null */){

                if (richSi.Text == null)
                {
                    analisisSin.Text += "Se ha detectado un <<si>>"; richSi.Text += "si "; palabraanteriorsi = palabra;


                }
                else {

            
                    if (richSi.Text == "si ( variable == variable2 ) com { ")
                    {
                     

                        analisisSin.Text += "Se detecto un estructura correcta de <<si>> esperando <<?>>";
                        richSi.Text = "si ";
                    }
                    analisisSin.Text += "Se ha detectado un <<si>>"; richSi.Text += "si "; palabraanteriorsi = palabra;

                }
                richSi.Text = "si ";
                si = true;
     


            }

            if (si == true)
            {

                if (palabra == "(")
                {
                    if (richSi.Text == "si ")
                    {
                 

                        richSi.Text += "( "; palabraanteriorsi = palabra;

                    }
                    //else
                    //{
                   
                    //    richErroresSintac.Text += "se ha detectado un error en un <<si>> o <<ciclo>> \n";
                    //}

                }
                else if (tipo == "variable")
                {

                    if (richSi.Text == "si ( ")
                    {
                      
                        varecha = true;
                        richSi.Text += "variable "; palabraanteriorsi = palabra;
                    }
                    else if (varecha == false)
                    {
            
                        richErroresSintac.Text += "se ha detectado un error en un deberia haber un <<(>> antes de una variable \n";


                    }


                }
                else if (richSi.Text == "si ( variable " && palabra == "==")
                {
                    richSi.Text += "== "; palabraanteriorsi = palabra;
                }
                else if (richSi.Text == "si ( variable == " && tipo == "variable")
                {
                    richSi.Text += "variable2 "; palabraanteriorsi = palabra;
                }
                else if (richSi.Text == "si ( variable == variable2 " && palabra == ")")
                {
                    richSi.Text += ") "; palabraanteriorsi = palabra;
                }
                else if (richSi.Text == "si ( variable == variable2 ) " && palabra == "com")
                {
                    if (palabraanteriorsi == ")")
                    {
                        richSi.Text += "com "; palabraanteriorsi = palabra; analisisSin.Text += "<<com colocado correctamente>>\n";
                    }
                    else
                    {
                        richErroresSintac.Text += "ERROR en una estructura <<si>> solo puede haber un <<)>> antes de un com\n";
                        palabraanteriorsi = palabra;
                    }   ////////////////////// aqui validamos que si la palabra anterior es un parentesis el com es correcto
                }
                else if (richSi.Text == "si ( variable == variable2 ) com " && palabra == "{")
                {

                    cierresi += 1;
                    richSi.Text += "{ ";
                    palabraanteriorsi = palabra;
                    analisisSin.Text = "se ha completado un <<si>> correctamente";
                    si = false;
                }


            }



            if (tipo == "variable")
            {
                tipoanterior = tipo;
                variables += 1;
                if (palabraanterior == "!")
                {

                    variables -= 1;
                    using (StreamWriter agregar = new StreamWriter("variablesINT.txt", true))
                    {
                        agregar.Write(palabra);
                        richenteras.Text += palabra + ","; agregar.Write(",");

                        // para com   QUE NO SE PUEDAN ciclo LAS VARIABLES DEL MISMO TIPO com QUI UN FOREACH

                        varnumasig.Text += palabra;
                    }

                    analisisSin.Text = "se ha declarado como entero la variable: " + palabra + " \n";
                    palabraanterior = palabra;
                    esperandovalor += 1;

                }
                /////////////////////////
                else if (palabraanterior == "@")
                {
                    using (StreamWriter agregar = new StreamWriter("variableString.txt", true))
                    {

                        agregar.Write(palabra); richcadenas.Text += palabra + ","; agregar.Write(",");
                        variablestring = palabra;
                    }
                    analisisSin.Text += "se ha declarado como candena la variable: " + palabra + " pero se espera su asignación\n";
                    asignarcadena += 1;


                }
                else
                {
                    Boolean cadena = false;
                    Boolean entero = false;
                    char[] delimitadoresCharR = { ',' };
                    string[] wordscadenas = richcadenas.Text.Split(delimitadoresCharR);

                    string[] wordsenteros = richenteras.Text.Split(delimitadoresCharR);
                    foreach (string word in wordscadenas)
                    {
                        if (word == palabra)
                        {
                            cadena = true;
                        }
                    }
                    foreach (string word in wordsenteros)
                    {
                        if (word == palabra)
                        {
                            entero = true;
                        }
                    }
                    if (cadena == true && entero == true)
                    {

                        richErroresSintac.Text += "Error, la variable " + palabra + " se repite como cadena y como numero";

                    }
                    else if (cadena == true && entero == false)
                    {

                        analisisSin.Text += "se encontro " + palabra + " como variable de tipo CADENA\n";

                    }
                    else if (cadena == false && entero == true)
                    {

                        analisisSin.Text += "se encontro " + palabra + " como variable de tipo ENTERO\n";

                    }
                    //else { richErroresSintac.Text += "Error la variable " + palabra + " no se ha declarado\n"; }
                }




                palabraanterior = "variable";


            }




        }

        void cierres(string palabra, string tipo) {

            if (palabra == "?" ) {
                cierresi -= 1;
                analisisSin.Text += "se ha cerrado la estructura de un if";

            }
            if (palabra == "solo")
            {
                cierresolo -= 1;
                analisisSin.Text += "se ha cerrado la estructura de un ciclo";

            }


        }










        private void ThreadSafe(Action callback, Form form)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (obj, e) =>
            {
                if (form.InvokeRequired)
                    form.Invoke(callback);
                else
                    callback();
            };
            worker.RunWorkerAsync();
        }



        void pintar()
        {

            ThreadSafe(() =>
            {
                string modelo = "";
                string[] palabras = { "si", "solo", "se", "ciclo", "@", "!", "inicio", "com", "solo", "//", "ProyectoJosue" , "MeedMusic", "Meedot",
                "sino", "pantalla", "Meed", "kevin del cid", "<<" , ">>","|","<",">"};

                foreach (var a in palabras)
                {
                    modelo += a + "|";
                }
                Regex r = new Regex(modelo);
                int index = CodigoMeedCompyTxt.SelectionStart;
                foreach (Match m in r.Matches(CodigoMeedCompyTxt.Text))
                {
                    CodigoMeedCompyTxt.Select(m.Index, m.Value.Length);
                    CodigoMeedCompyTxt.SelectionColor = Color.Orange;
                    CodigoMeedCompyTxt.SelectionStart = index;
                    CodigoMeedCompyTxt.Font = new Font(CodigoMeedCompyTxt.Font, FontStyle.Bold);
                }
                CodigoMeedCompyTxt.SelectionColor = Color.White;

            }, this);



        }





        private void ActualizarAnalisis_Tick(object sender, EventArgs e)
        {
            Thread pai = new Thread(pintar);
            pai.Start();
            // richTextBox1.Text = CodigoMeedCompyTxt.Text; 


        }
        void MandarPalabraReservada(string pReservada)
        {



            RIchTxLexico.Text = RIchTxLexico.Text + "Palabra reservada: " + pReservada + "\n";


        }
        void MandarSigno(string sReservada)
        {

            RIchTxLexico.Text = RIchTxLexico.Text + "Signo operador o delimitador: " + sReservada + "\n";


        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

            string newtext = "";
            newtext = RIchTxLexico.Text;
            RIchTxLexico.Text = "";

            string newtexterro = "";
            newtexterro = richErroresSintac.Text;
            richErroresSintac.Text = "";


            analiLex();
            // ErroresSintacticos();



        }

        int llavesnecesarias = 0;
        int parentesisnecesarios = 0;

        int llavesnecesariasSi = 0;

        int valoresenteros = 0;
        int declaradorentero = 0;
        int asignaciones = 0;
        int comparaciones = 0;
        int sumas = 0;
        int restas = 0;
        int divisiones = 0;
        int valornumericos = 0;
        int separador = 0;


        int incremento = 0;
        int solo = 0;
        int declaracioncadenas = 0;
        int cierretextoliterales = 0;

        Boolean repsn = false;

        int aperturatextoliterales = 0;
        int cierreoperaciones = 0;
        int com = 0;
        int variables = 0;
        string palabraanterior = "";
        string tipoanterior = "";
        int inicio = 1;
        Boolean cierreinicio = false;

        Boolean pr = false;

        Boolean vr = false;

        Boolean igr = false;

        Boolean vnr = false;

        Boolean sr = false;

        Boolean vr2 = false;

        Boolean compr = false;

        Boolean vanu = false;

        Boolean sp2r = false;

        Boolean vafr = false;

        Boolean incr = false;
        Boolean ciclo1 = false;
        int dospuntos = 2;
        int variablesrep = 5;
        int numeros = 2;

        int aesperadeSolo = 0;

        int hayinicio = 0;
        int exsi = 0;
        int esperandocadena = 0;
        string variablestring = "";
        string concatenacadena = "";
        int esperandovalor = 0;
        Boolean esperavarconsint = false;
        Boolean esperavarint = false;
        int e = 0;
        void AnalalisisSintactico(string palabra, string tipo)
        {
          
            if (esperavarconsint == true) {
                // entrando aqui sabemos que tenemos una estrucctura de comparacion pero solo podemos comparar con un valor del mismo 
                // tipo 
                if (palabraanterior != "==" )
                {


                   // richErroresSintac.Text += "no se encontró el dato esperado ERRROR\n";
                }
                else {
                    if (tipo == "variable") {
                        // se detectó una estructura correcta realizando analisis semántico
                        // debo buscar lo que se encuentra en plabra en el richtextboxenteros 
                        // si existe esta variable alli saabremos que todo esta semantica y sintacticamente correcto
                        string cadenarnteras = varnumasig.Text;


                        char[] delimitadoresChar = { ' ', ',' };


                        string concatenatext = "";

                        string[] words = varnumasig.Text.Split(delimitadoresChar);
                        int numero = 0;

                        Boolean siay = false;
                        foreach (string word in words)
                        {
                            if (word == palabra) {
                                // aqui se que se encontró la variable de tipo entero

                                siay = true;
                                break;
                            }

                        }
                        if (siay == true) {
                            richsemantica.Text += "la expresioon coinside en tipos enteros\n";

                        } else { erroresSemanticos.Text += "error no se encontró la variable de tipoo entero verifique si la ha declarado anteriormente o que los valores son del mismo tipo\n"; }


                        } else if (tipo == "valor numerico") {

                        richsemantica.Text += "los valores coinciden en tipo\n";

                    }


                }


            }



            cierreinicio = false;
            if (palabra == "};")
            {

                cierreinicio = true;

            }
            if (asignarcadena > 0 && palabra != "<<") {

                richErroresSintac.Text += "no se esta asignando un valor a la variable @\n";         


            }

            if (esperandocadena > 0) {

                if (palabra == ">>")
                {

                    esperandocadena -= 1;
                    varcadasig.Text += variablestring +": " + concatenacadena + ",";
                    richsemantica.Text += "a la variable de tipo @ se le han asignado datos correctos\n";



                }
                else if(tipo == "variable"| e == 0){

                    concatenacadena +=" " +palabra;
                    tipo = "";
                    palabra = "";

                }




            }

            if (esperandovalor > 0)
            {
                // se ha declarado una variable y ahora deberia asignarse un numero a ella si no se 
                //recibe el numero esto será un error 
                //nota com lo mismo para asignar valores de cadenas
                if (tipo == "valor numerico")
                {

                    varnumasig.Text += " " + palabra + ",";
                    esperandovalor -= 1;

                    variables += 1;
                    // si entramos aqui quiere decir que todo marcha bien, se ha asignado el valor de palabra
                    // a la variable que se encuentra en la palabraanterior
                    // necesito guardar en algun lado la variable y su valor
                    richsemantica.Text += "el valor asignado a las variables ! es correcto\n";

                }
                else
                {


                    richErroresSintac.Text = "Error verifica si has asignado correctamente tu variable de tipo ! entero\n";
                    erroresSemanticos.Text += "Error verifica si has asignado correctamente tu variable de tipo ! entero\n";
                }





            }

            if (tipo == "palabra reservada")
            {



                if (palabra == "inicio")
                {
                    hayinicio += 1;
                    //if (hayinicio >= 2) {
                    //    richErroresSintac.Text = "no pueden existir dos funciones pricipales inicio";

                    //}

                    palabraanterior = palabra;
                    inicio = 0;
                    llavesnecesarias = 1;

                }

                if (palabra == "si")
                {
                    if (exsi == 0)
                    {

                        palabraanterior = palabra;
                        llavesnecesarias = 2;
                        parentesisnecesarios = 2;
                        variables = 2;
                        valornumericos = 1;
                        comparaciones = 1;
                        com = 1;
                        exsi = 1;

                    }
                    else if (exsi == 1 && llavesnecesarias == 1)
                    {


                        palabraanterior = palabra;
                        llavesnecesarias = 2 + exsi;
                        parentesisnecesarios = 2;
                        variables = 2;
                        valornumericos = 1;
                        comparaciones = 1;
                        com = 1;
                        exsi += 1;


                    }
                    else
                  if (exsi > 0 && llavesnecesarias == 0)
                    {


                        palabraanterior = palabra;
                        llavesnecesarias = 2;
                        parentesisnecesarios = 2;
                        variables = 2;
                        valornumericos = 1;
                        comparaciones = 1;
                        com = 1;
                        exsi += 1;


                    }






                }
                else if (palabra == "si" && exsi != 0 && llavesnecesarias == 0)
                {
                    palabraanterior = palabra;
                    llavesnecesarias = 2;
                    parentesisnecesarios = 2;
                    variables = 2;
                    valornumericos = 1;
                    comparaciones = 1;
                    com = 1;
                    exsi += 1;
                }
                else
                {

                    //palabraanterior = palabra;
                    //llavesnecesarias = 2;
                    //parentesisnecesarios = 2;
                    //variables = 2;
                    //valornumericos = 1;
                    //comparaciones = 1;
                    //com = 1;
                    //exsi += 1;
                }
                if (palabra == "com")
                {
                    palabraanterior = palabra;
                }
                if (palabra == "solo")
                {
                    solo--;
                    palabraanterior = palabra;
                }
                if (palabra == "ciclo")
                {
                    // ciclo : variable numerovar , variable numerovar , variable numerovar :
                    // utilizadas
                    dospuntos = 2;
                    variablesrep = 5;
                    numeros = 2;

                    separador = 2;
                    incremento = 1;
                    ciclo1 = true;

                    palabraanterior = palabra;
                    tipoanterior = tipo;




                }



            }
            else if (ciclo1 == true)
            {

                if (tipo == "variable" && palabra == ":") // aqui unicamente reconocemos los 2 puntos
                {

                    if (palabraanterior == "ciclo")
                    { // aqui tenemos los dos puntos iniciables y restamos uno 
                        dospuntos -= 1;
                        tipoanterior = tipo;

                     
                    }
                    else if (palabra == ":" && palabraanterior == "++")
                    {


                        analisisSin.Text = "se termino la expresion de <<ciclo>> con << : >> se espera un <<solo>>";
                        solo++;


                    }
                    else if (palabraanterior == "++")
                    {
                        // aqui tenemos los dos puntos que cierran la expresion
                        analisisSin.Text += "se han agregado : para iniciar el <<ciclo>> \n";
                        dospuntos -= 1;
                        tipoanterior = tipo;
                    }
                    else
                    {
                        richErroresSintac.Text += "Error, verifica donde colocas los << : >>\n";
                    }

                }
                else if (palabra == "++")
                {
                    palabraanterior = palabra;
                    tipoanterior = tipo;
                    incremento -= 1;

                

                }
                else if (tipo == "valor numerico")
                {
                    // aqui si la palaba es uun numero
                    tipoanterior = tipo;
                }
                else if (palabra == ",")
                {


                    // aqui tenemos una , asi que hacemos la resta de recurso 
                    if (tipoanterior == "variable" | tipoanterior == "valor numerico")
                    {
                        separador -= 1;
                        palabraanterior = palabra;
                        tipoanterior = tipo;
                        // si el tipo anteriro es una variable la , estará bien colocada
                        analisisSin.Text += "una si hay una variable o constante antes de la << , >> Correcto\n";

                    }
                    else
                    {
                        richErroresSintac.Text += "ERROR verifica la posicion de las << , >>\n";

                    }


                }
                else
                {
                    // aqqui sabemos que es una variable 

                    if (palabraanterior == ":")
                    {
                        palabraanterior = palabra;
                        tipoanterior = tipo;
                        analisisSin.Text += "la variable " + palabra + " se ha agregado a la expresion del <<ciclo>> ";
                        // aqui todo iria bien aqui tendriamos que llevar de la estructura de ciclo
                        // ciclo : variable1

                        variablesrep -= 1;
                    }
                    //

                }




            }
            else
            {



                if (tipo == "apertura de llave") { llavesnecesarias = llavesnecesarias - 1; if (palabraanterior == "se" | palabraanterior == "inicio" | palabraanterior == "com") { analisisSin.Text = "sin errores entre inicio o com\n"; } else { richErroresSintac.Text = "verifica no tener palabras entre inicio o com y sus llaves\n"; } }
                if (tipo == "se") { if (palabraanterior != "cierre de llave") { richErroresSintac.Text = "Error la palabra <<se>> no esta siendo utilizada correctamente\n"; } else { analisisSin.Text = "sino situado correctamente\n"; } }

                if (tipo == "cierre de llave") { llavesnecesarias -= 1; palabraanterior = tipo; }

                if (tipo == "cierre inicio") { cierreinicio = true; }// una  vez se cerro el inicio ya nada debe ser funcional
                if (tipo == "apertura parentesis")
                {
                    parentesisnecesarios -= 1;
                    if (palabraanterior == "si" | palabraanterior == "ciclo")
                    {

                        /////////// unicamente me falta saber por que el ciclo no logra com que los datps entren a los de aqui a decrementarse
                        analisisSin.Text = "sin errores entre si o ciclo\n";
                    }
                    else
                    {
                        //richErroresSintac.Text = "verifica no tener palabras entre palabras si o ciclo que no sean <<(>> \n";
                    }
                    palabraanterior = "apertura parentesis";
                }
                if (tipo == "cierre de parentesis")
                {
                    if (tipoanterior == "variable" | tipoanterior == "valor numerico")
                    {
                        analisisSin.Text += "se ha cerrado el parentesis correctamente\n";


                    }
                    else {

                        richErroresSintac.Text += "antes de el cierre de parentesis debe haber una variable o un numero\n";


                    }
                }
                if (tipo == "declaracion entero") { declaradorentero -= 1; palabraanterior = "!"; }
                if (tipo == "asignacion") { asignaciones -= 1; palabraanterior = "="; }
                if (tipo == "comparacion") { comparaciones -= 1;





                    if (tipoanterior == "variable")
                    {
                        analisisSin.Text += "se detectó structura variable == se espera valor numerico variable o constante entera\n";
                        esperavarconsint = true;
                    }
                    else if (tipoanterior == "valor numerico") {
                        analisisSin.Text += "se detectó structura numero == se espera una variable de tipo entero\n";

                        esperavarint = true;


                    }



                    palabraanterior = "==";





                }
                if (tipo == "suma") { sumas -= 1; palabraanterior = "+"; }
                if (tipo == "incremento") { sumas -= 1; palabraanterior = "++"; }
                if (tipo == "resta") { restas -= 1; palabraanterior = "-"; }
                if (tipo == "division") { divisiones -= 1; palabraanterior = "/"; }
                if (tipo == "cierre operacion") { cierreoperaciones -= 1; palabraanterior = ";"; }
                if (tipo == "declaracion cadena") { declaracioncadenas -= 1; palabraanterior = "@"; }
                if (tipo == "apertura textoliteral") { aperturatextoliterales -= 1; palabraanterior = "<<"; esperandocadena += 1; asignarcadena -= 1; }
                if (tipo == "cierre textoliteral") { cierretextoliterales -= 1; palabraanterior = ">>"; }
                if (tipo == "valor numerico") { valornumericos -= 1; palabraanterior = palabra;

                    tipoanterior = tipo;


                }
                if (tipo == "variable")
                {
                    tipoanterior = tipo;
                    variables += 1;
                    if (palabraanterior == "!")
                    {

                       variables -= 1; 
                        using (StreamWriter agregar = new StreamWriter("variablesINT.txt", true))
                        {
                            agregar.Write(palabra);
                            richenteras.Text += palabra + ","; agregar.Write(",");

                            // para com   QUE NO SE PUEDAN ciclo LAS VARIABLES DEL MISMO TIPO com QUI UN FOREACH

                            varnumasig.Text += palabra;
                        }

                        analisisSin.Text = "se ha declarado como entero la variable: " + palabra + " \n";
                        palabraanterior = palabra;
                        esperandovalor += 1;

                    }
                    /////////////////////////
                    else if (palabraanterior == "@") {
                        using (StreamWriter agregar = new StreamWriter("variableString.txt", true)) {

                            agregar.Write(palabra); richcadenas.Text += palabra + ","; agregar.Write(",");
                            variablestring = palabra;
                        }
                        analisisSin.Text += "se ha declarado como candena la variable: " + palabra + " pero se espera su asignación\n";
                        asignarcadena += 1;

                       
                    }
                    else
                    {
                        Boolean cadena = false;
                        Boolean entero = false;
                        char[] delimitadoresCharR = { ',' };
                        string[] wordscadenas = richcadenas.Text.Split(delimitadoresCharR);

                        string[] wordsenteros = richenteras.Text.Split(delimitadoresCharR);
                        foreach (string word in wordscadenas) {
                            if (word == palabra) { cadena = true;
                            }
                        }
                        foreach (string word in wordsenteros) {
                            if (word == palabra) {
                                entero = true;
                            }
                         }
                        if (cadena == true && entero == true)
                        {

                            richErroresSintac.Text += "Error, la variable " + palabra + " se repite como cadena y como numero";

                        }
                        else if (cadena == true && entero == false)
                        {

                            analisisSin.Text += "se encontro " + palabra + " como variable de tipo CADENA\n";

                        }
                        else if (cadena == false && entero == true)
                        {

                            analisisSin.Text += "se encontro " + palabra + " como variable de tipo ENTERO\n";

                        }
                        else { richErroresSintac.Text += "Error la variable " + palabra + " no se ha declarado\n"; }
                    }




                    palabraanterior = "variable";


                }
                if (tipo == "com") { com -= 1; palabraanterior = "com"; }
                ////////
                if (tipo == "separador") { separador -= 1; palabraanterior = ","; }
                if (tipo == "solo") { solo -= 1; palabraanterior = "solo"; }



            }




        }



        Boolean s = false;

        Boolean aperturaComparacion = false;

        Boolean ComparacionCerrada = false;


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }


        void ErroresSintacticos()
        {

            //if (llavesnecesarias == 0)
            //{
            //    richErroresSintac.Text += "el numero de llaves es correcto llaves vale: " + llavesnecesarias.ToString();


            //}
            //else
            //{


            //    richErroresSintac.Text += "verifica si estan todas las llaves";
            //}


        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }




        Boolean amoc = false;
        Boolean vae = false;
        Boolean vaes = false;
        Boolean vaest = false;
        string concate = "";

        Boolean ifon = false;

        Boolean paif = false;

        Boolean dec = false;
        int puntos = 0;
        string con = "";


        void traducir(string palabra, string tipo)
        {
            char[] delimitadoresChar = { ' ', '\n' };
            string[] words = CodigoMeedCompyTxt.Text.Split(delimitadoresChar);
            int ciers = 0;


          

          
                if (palabra != "//" && palabra != "///")
                {
                /////////////// aqui sabemos que no estamos comentando las cosas ///////////////////////////
                ///
                    if (palabra == "<") { CCCode.Text += "<"; }
                    if (palabra == ">") { CCCode.Text += ">"; }
                    if (palabra == "sino") { CCCode.Text += "else "; }
                    if (palabra == "|") { CCCode.Text += "\" ; "; }
                    if (palabra == "pantalla") { CCCode.Text += "\ncout << \" "; }
                    if (palabra == "@") { CCCode.Text += "\nstring ";  }
                    if (palabra == "?") { CCCode.Text += "\n}"; }
                    if (palabra == "!") { CCCode.Text += "\nint "; dec = true; }
                    if (tipo == "separador") {CCCode.Text += ";"; }
                    if (palabra == "inicio") { CCCode.Text += "!include <iostream>\nusing namespace std;\nint main()\n"; }
                    if (palabra == "};") { CCCode.Text += "\nreturn 0 ;\n}"; }
                    if (palabra == "{") { CCCode.Text += palabra + "\n"; }
                    if (palabra == "}") { CCCode.Text += palabra + "\n"; }
                    if (tipo == "dosdot") {CCCode.Text += "){\n";}
                    if (palabra == "=") { CCCode.Text += " = "; }
                    if (palabra == "solo") { CCCode.Text += "}\n"; }
                    if (palabra == "==" ) { CCCode.Text += " == "; }
                    if (palabra == "++") { CCCode.Text += "++ "; }
                if (palabra == "+") { CCCode.Text += "+ "; }
                if (palabra == "("){ CCCode.Text += "( "; }
                    if (palabra == ")") { CCCode.Text += " )"; }
                    if (palabra == "ciclo") { CCCode.Text += "for";  }
                    if (palabra == "si") { CCCode.Text += "if"; }
                    if (tipo == "valor numerico") { if (dec == true) { CCCode.Text += " = " + palabra + ";\n "; dec = false; } else { CCCode.Text += palabra; }}
                    if (palabra == "<<") { CCCode.Text += " = \" "; }
                    if (palabra == ">>") { CCCode.Text += "\";\n"; }
                    if (tipo == "variable") { CCCode.Text += ""+palabra+" "; }
                    if (tipo =="=") { CCCode.Text += " " + palabra + " "; }
                }
                else
                {
                    ////////////////////  aqui sabemos que se incio un comentario /////////////
                    //commmm = true;
                    //if (palabra == "///") { commmm = false; }





                }

            
        }





        private void PictureBox8_Click(object sender, EventArgs e)
        {
            CCCode.Text = "";
            Ccode.Text = "";
            amoc = false;
            vae = false;
            vaes = false;
            vaest = false;
            ifon = false;
            paif = false;

            char[] delimitadoresChar = { ' ', '\n' };
            char[] delimitadoresCharR = { ',' };
            int numero = 0;
            string wo = "";
            Boolean cier = false;
            Boolean siact = false;
            Boolean amoact = false;
            Boolean commmm = false;
            Boolean ci = false;
            Boolean foract = false;
            string[] words = CodigoMeedCompyTxt.Text.Split(delimitadoresChar);
            int ciers = 0;




            foreach (string word in words)
            {
                wo = word;


                if (word != "//" && word != "///")
                {

                    if (wo == "se" && commmm == false)
                    {

                        CCCode.Text += " el";


                    }
                    if (siact == true && commmm == false && word == "ciclo") { CCCode.Text += "for"; foract = false; }
                    if (word == "solo" && commmm == false) { CCCode.Text += "}"; foract = false; }
                    if (word == "," && commmm == false) { CCCode.Text += ";"; }
                    if (foract == true && commmm == false) { wo = "ciclo"; }
                    if (siact == true && commmm == false) { wo = "si"; }
                    if (amoact == true && commmm == false) { wo = "inicio"; }



                    if (word == "{" && commmm == false ) { CCCode.Text += wo; }

                    if (word == "}" && commmm == false)
                    {
                        CCCode.Text += "\n } 2";
                        
                    }


                    if (word == "};" && commmm == false)
                    {
                        CCCode.Text += "\n\n return 0 ; \n }";


                        cier = true;

                    }
                    else if (commmm == false)
                    {
                        cier = false;

                    }
                    switch (wo)
                    {

                        case "inicio":
                            amoact = true;
                            if (word == "inicio" | amoc == true && cier == false && commmm == false)
                            {

                                amoc = true;
                               
                                    CCCode.Text += "!include <iostream>\n using namespace std;\nint main()\n";
                                    amoc = false;
                                    amoact = false;
                                
                            }

                            ///////////////////////////////////////// encabezado y cierre concluidos ///////////

                            break;
                        case "si":


                            if (word == "com" && commmm == false) { }
                            else
                            if (word == "si" && commmm == false) { CCCode.Text += "\nif"; siact = true; }
                            else
                            if (word == "(" && commmm == false) { CCCode.Text += " ( "; }
                            else
                            if (word != "inicio" && commmm == false | word != "}" | word != "{" | word != "};" | word != "(" | word != ")" | word != "solo" | word != "com" | word != "si" | word != "se" | word != "ciclo" | word != "," | word != "<<" | word != ">>" | word != "" | word != ":" | word != "//" | word != "///" | word != "++" | word != "==" && cier == false) { CCCode.Text += word; if (palabraanterior == "==") { siact = false; } }
                            else
                            if (word == "==" && commmm == false) { CCCode.Text += " == "; }
                            else
                            if (int.TryParse(word, out numero) && commmm == false) { CCCode.Text += word; if (palabraanterior == "==") { siact = false; } }
                            else
                            if (word == ")" && commmm == false) { CCCode.Text += " )"; }
                            else
                            
                            if (word == "se" && commmm == false)
                            {

                                CCCode.Text += " ";


                            }






                            break;



                        case "ciclo":

                            if (word == "ciclo" && commmm == false) { CCCode.Text += "for"; foract = true;

                            }
                            else
                                if (word == ":" && commmm == false)
                            {
                                if (ci == true)
                                {
                                    CCCode.Text += "){";
                                    ci = false;
                                    foract = false;
                                }
                                else
                                {

                                    ci = true;
                                    CCCode.Text += "(";
                                }
                            }
                            else
                                if (word != "inicio" && commmm == false | word != "}" | word != "{" | word != "};" | word != "(" | word != ")" | word != "solo" | word != "com" | word != "si" | word != "se" | word != "ciclo" | word != "," | word != "<<" | word != ">>" | word != "" | word != ":" | word != "//" | word != "///" | word != "++" | word != "==")
                            {


                                if (int.TryParse(word, out numero) && commmm == false)
                                {



                                    CCCode.Text += "=" + word;
                                }
                                else
                                {


                                    if (word == ",") { }
                                    else
                                    {

                                        CCCode.Text += word;



                                    }



                                }



                            }
                            else
                                if (word == "==") { CCCode.Text += "=="; }
                            else
                            if (word == "++") { CCCode.Text += "++"; ci = true; }





                            break;




                    }





                    if (word == "!" | vae == true && cier == false && commmm == false)
                    {



                        if (word == "!" && cier == false && commmm == false) { CCCode.Text += "int"; vae = true; }
                        else




                        if (int.TryParse(word, out numero) && cier == false && commmm == false)
                        {
                            CCCode.Text += word + ";\n";
                            vae = false;
                        }
                        else

                            if (word != "inicio" |
                                word != "}" |
                                word != "{" |
                                word != "};" |
                                word != "(" |
                                word != ")" |
                                word != "solo" |
                                word != "com" |
                                word != "," |
                                  word != "si" |
                                word != "sino" |
                                word != "ciclo" |
                                word != "" |
                                word != ":" |
                                word != "<<" |
                                word != ">>" |
                                word != "//" |
                                word != "///" |
                                word != "++" |
                                word != "==" && cier == false && commmm == false)
                        {
                            CCCode.Text += " " + word + " = ";

                            vaest = false;
                            vaes = false;
                            concate = "";


                        }
                        

                    }

                    if (word == "@" | vaes == true && cier == false && commmm == false)
                    {



                        if (word == "@" && cier == false && commmm == false) { CCCode.Text += "string"; vaes = true; }
                        else



                        if (word == "<<" | vaest == true && cier == false && commmm == false)
                        {

                            vaest = true;
                            if (word == "<<" && cier == false && commmm == false)
                            {



                                CCCode.Text += " \"";

                            }
                            else if (word == ">>" && cier == false && commmm == false)
                            {


                                CCCode.Text += concate + "\";\n";
                                vaest = false;
                                vaes = false;
                                concate = "";
                            }
                            else
                            {

                                concate += " " + word;



                            }




                            // se esta iniciando la cadena de texto



                        }
                        else


                            if (word != "inicio" |
                                word != "}" |
                                word != "{" |
                                word != "};" |
                                word != "(" |
                                word != ")" |
                                word != "solo" |
                                word != "com" |
                                  word != "si" |
                                word != "se" |
                                word != "ciclo" |
                                word != "," |
                                word != "<<" |
                                word != ">>" |
                                word != "" |
                                word != ":" |
                                word != "//" |
                                word != "///" |
                                word != "++" |
                                word != "==" && cier == false && commmm == false)
                        {
                            CCCode.Text += " " + word + " = ";




                        }








                    }
                    ////////////////////// declaracion de variables concluida /////////////////////
                    ///

















                } else { commmm = true;
                    if (word == "///") { commmm = false; }
            }


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "documento de texto|*.txt";
            guardar.Title = "GUARDAR";
            guardar.FileName = "Sin titulo";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter pantalla = new StreamWriter(guardar.FileName);
                foreach (object line in CodigoMeedCompyTxt.Lines)
                {
                    pantalla.WriteLine(line);
                }
                pantalla.Close();
            }
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "documento de texto|*.txt";
            abrir.Title = "Abrir";
            abrir.FileName = "Sin titulo";
            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                CodigoMeedCompyTxt.Text = leer.ReadToEnd();


                leer.Close();
            }
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {

            StreamReader leer = new StreamReader("si.txt");
            CodigoMeedCompyTxt.Text = leer.ReadToEnd();


        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            StreamReader leer = new StreamReader("bucle.txt");
            CodigoMeedCompyTxt.Text = leer.ReadToEnd();
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            StreamReader leer = new StreamReader("programafinal.txt");
            CodigoMeedCompyTxt.Text = leer.ReadToEnd();
        }

        private void RIchTxLexico_TextChanged(object sender, EventArgs e)
        {

        }

        private void CCCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
           
        }
        private void AnalisisSintactico(object sender, EventArgs e)
        {







        }
    }
}
