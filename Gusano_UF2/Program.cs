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
                    if(Words[i]=='/'){
                            Extension="";
                            Insertar=false;
                        }
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
                if(Words[i]=='/'){
                    Name="";
                    Insertar=true;
                }
            }
            return Name;
        }
        private static String SearchDirection(String File){
            char[]words=File.ToCharArray();
            bool Insertar=false;
            String Direction="";
            for(int i=words.Length-1;0<=i;i--){
                if(Insertar){
                    Direction+=words[i];
                }else if(words[i]=='/'){
                    Insertar=true;
                    Direction+=words[i];
                }
                
            }
            words=Direction.ToCharArray();
            Direction="";
            for(int i=words.Length-1;0<=i;i--){
                Direction+=words[i];
                
            }
            return Direction;
        }
        static void Main(string[] args)
        {
            //args= new string[]{"../Gusano_UF2/Proyect.txt","10"};
            String Content=ReadFile(args[0]);
            String Name=SearchName(args[0]);
            String Extension=SearchExtension(args[0]);
            String Direction=SearchDirection(args[0]);
            StreamWriter writer;
            int Auxiliar=0;
            int Repetir=Int32.Parse(args[1]);
            for(int i=0;i<Repetir;i++){
                while(File.Exists(Direction+Name+(i+Auxiliar)+"."+Extension)){
                    Auxiliar++;
                }
                
                writer=new StreamWriter(Direction+Name+(i+Auxiliar)+"."+Extension);
                writer.WriteLine(Content);
                writer.Close();
            }
        }
        
    }
}
