using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace DAN_LVI
{
    class Program
    {
        /// <summary>
        /// Read html for given url
        /// </summary>
        /// <param name="Url">Url path</param>
        /// <returns>html as string</returns>
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
        /// <summary>
        /// Application for downloading html files and zipping this files
        /// </summary>
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
                //zip
                else if(input == "zip")
                {
                    try
                    {
                        File.Delete("..\\..\\MyZipedHtmlFiles.zip");
                        ZipFile.CreateFromDirectory("..\\..\\MyHtmlFiles\\", "..\\..\\MyZipedHtmlFiles.zip");
                        Console.WriteLine("Files are zipped");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Zipping failed.");
                    }
                    
                }
                //download html
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
