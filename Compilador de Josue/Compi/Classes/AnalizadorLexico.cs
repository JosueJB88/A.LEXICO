using System;

namespace ProyectoJosue.Classes
{
    class AnalizadorLexico
    {







        private void Analilex(String cadenaCodigo)
        {









            char[] delimitadoresChar = { ' ', ',', ';', '\t' };
            char[] delimitadoresCharR = { ',' };



            string[] words = cadenaCodigo.Split(delimitadoresChar);
            System.Console.WriteLine($"{words.Length} words in text:");
            string plabrasR = System.IO.File.ReadAllText("/palabras reservadas.txt");
            String[] palabrasReservadas = plabrasR.Split(delimitadoresCharR);

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");


                foreach (var reservada in palabrasReservadas)
                {

                    if (word == reservada)
                    {
                        //tenemos una palabra reservada


                    }


                }

            }











        }







    }
}
