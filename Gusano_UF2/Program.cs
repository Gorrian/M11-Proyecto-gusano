using System;
using System.IO;

namespace Gusano_UF2
{
    class Program
    {
        //This function reads the file
        private static String ReadFile(String file){
            String Content=File.ReadAllText(file);
            return Content;
        }
        private static String SearchExtension(String File){
            char[]Words=File.ToCharArray();
            bool Insertar=false;
            String Extension="";
            for(int i=0;i<Words.Length;i++){
                if(Insertar){
                    Extension+=Words[i];
                }else{
                    if(Words[i]=='.'){
                        Insertar=true;
                    }
                }
            }
            return Extension;
        }
        private static String SearchName(String File){
            char[]Words=File.ToCharArray();
            bool Insertar=true;
            String Name="";
            for(int i=0;i<Words.Length;i++){
                if(Insertar){
                    if(Words[i]=='.'){
                        Insertar=false;
                    }else{
                        Name+=Words[i];
                    }
                }
            }
            return Name;
        }
        static void Main(string[] args)
        {
            //args= new string[]{"Cuc.txt","5"};
            String Content=ReadFile(args[0]);
            String Name=SearchName(args[0]);
            String Extension=SearchExtension(args[0]);
            StreamWriter writer;
            int Auxiliar=0;
            int Repetir=Int32.Parse(args[1]);
            for(int i=0;i<Repetir;i++){
                while(File.Exists(Name+(i+Auxiliar)+"."+Extension)){
                    Auxiliar++;
                }
                writer=new StreamWriter(Name+(i+Auxiliar)+"."+Extension);
                writer.WriteLine(Content);
                writer.Close();
            }
        }
        
    }
}
