using System;
using System.IO;
using System.Net;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static public void PostRequest()
        {
            string url = "";
            string jsonRequestBody = $"{{}}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.UserAgent = "PostmanRuntime/7.32.3";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(jsonRequestBody);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result.Contains("Вход выполнен успешно"))
                    {
                    }
                    else
                    {
                    }
                }
            }
            catch (WebException ex)
            {
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество потоков:");
            int thred_count = int.Parse(Console.ReadLine());  
            for(int i = 0; i <  thred_count; i++)
            {
                Thread thread = new Thread(new ThreadStart(PostRequest));
                thread.Start();
            }
        }
    }
}
