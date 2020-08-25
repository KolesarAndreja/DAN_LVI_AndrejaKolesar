using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAN_LVI
{
    class Program
    {
        public static string ReadHtml(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            response.Close();

            return result;
        }
        static void Main(string[] args)
        {
            string path;
            string input = "";
            Console.WriteLine("Welcome! \nThis application downloads html files and saves them in a folder MyHtmlFiles. \nTo Exit an application enter \"exit\". \nTo zip all downloaded files enter \"zip\".");
            do
            {
                Console.Write("Enter url address: ");
                input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                else
                {
                    try
                    {
                        string html = ReadHtml(input);
                        string m = DateTime.Now.ToLongTimeString();
                        string s = "File_" + m.Replace(':', '-') + ".html";
                        path = "..\\..\\MyHtmlFiles\\" + s;
                        File.WriteAllText(path, html);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid url address.");
                    }
                }
            }
            while (input != "exit");
        }
    }
}
