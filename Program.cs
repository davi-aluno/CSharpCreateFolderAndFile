using System;
using System.IO;
using System.Text;

namespace Directory
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDirectory();
            CreateFile();
            ReadFile();
        }

        private static void CreateDirectory()
        {
            DirectoryInfo di = new DirectoryInfo(@"files");

            try
            {
                if (di.Exists)
                {
                    Console.WriteLine("Diretorio já existe!");
                }
                else
                {
                    di.Create();
                    Console.WriteLine("Diretorio criado!");
                }
                Console.WriteLine("Diretorio > " + di.Name);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CreateFile()
        {
            string filename = @"files/AulaFapen.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write("Estamos utilizando a classe StreamWriter para escrever este código!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " | " + e.StackTrace);
            }
        }

        private static void ReadFile()
        {
            string filename = @"files/AulaFapen.txt";
            StringBuilder sb = new StringBuilder();

            if (File.Exists(filename))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        string linha;

                        while ((linha = sr.ReadLine()) != null)
                        {
                            sb.AppendLine(linha);
                        }
                        Console.WriteLine(sb.ToString());
                    }
                }
                catch (Exception e)
                {   
                    throw new Exception("Erro ao ler o arquivo" + e.Message);
                }
            }
        }
    }
}
