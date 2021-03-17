using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousMultithread.TaskConsoleApp
{
    internal class Program
    {
        public static void Work(Task<string> data)
        {
            Console.Write("data length:" + data.Result.Length);
        }

        public class Content
        {
            public string Url { get; set; }
            public int Length { get; set; }
        }

        private async static Task Main(string[] args)
        {
            // ContinueWith
            /* 
            var myTask = new HttpClient().GetStringAsync("https://www.google.com/").ContinueWith(Work);

            Console.WriteLine("Some works");

            await myTask;
            */

            //WhenAll - WhenAny - WaitAll - WaitAny
            Console.WriteLine("Main Thread:" + Thread.CurrentThread.ManagedThreadId);
            List<string> urlList = new List<string>()
            {
                "https://www.google.com/",
                "https://www.youtube.com/",
                "https://twitter.com/home",
            };

            List<Task<Content>> taskList = new List<Task<Content>>();

            urlList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            /* WhenAll
            var contents = Task.WhenAll(taskList.ToArray());

            Console.WriteLine("Some works");

            var data = await contents;

            data.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Url} length:{x.Length}");
            });
            */

            /* WhenAny
            var firstData = await Task.WhenAny(taskList);
            Console.WriteLine($"{firstData.Result.Url} - {firstData.Result.Length}");
            */

            /* WaitAll
            Console.WriteLine("Before the WaitAll method");
            bool result = Task.WaitAll(taskList.ToArray(), 2000);
            Console.WriteLine("Is it completed in 2 seconds? - " + result);
            Console.WriteLine("After the WaitAll method");

            Console.WriteLine($"{taskList.First().Result.Url} - {taskList.First().Result.Length}");
            */

            Console.WriteLine("Before the WaitAny method");
            var firstDataIndex = Task.WaitAny(taskList.ToArray());

            Console.WriteLine($"{taskList[firstDataIndex].Result.Url} - {taskList[firstDataIndex].Result.Length}");

        }

        public static async Task<Content> GetContentAsync(string url)
        {
            Content c = new Content();
            var data = await new HttpClient().GetStringAsync(url);
            c.Url = url;
            c.Length = data.Length;
            Console.WriteLine("GetContentAsync thread:" + Thread.CurrentThread.ManagedThreadId);

            return c;
        }
    }
}
