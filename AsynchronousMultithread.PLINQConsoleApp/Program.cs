using AsynchronousMultithread.PLINQConsoleApp.Models;
using System;
using System.Linq;
using System.Threading;

namespace AsynchronousMultithread.PLINQConsoleApp
{
    class Program
    {
        private static void GetLog(Product p)
        {
            Console.WriteLine(p.Name + "log saved");
        }

        static void Main(string[] args)
        {
            //var array = Enumerable.Range(1, 100).ToList();

            //var arrayList = array.AsParallel().Where(x => x % 2 == 0);

            //arrayList.ToList().ForEach(x =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine(x);
            //});

            // PLINQ - ForAll
            //arrayList.ForAll(x =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine(x);
            //});


            /* ---------------------------------- */

            AdventureWorks2017Context context = new AdventureWorks2017Context();

            // If we want to query over an existing array
            //var product = (from p in context.Product.AsParallel()
            //               where p.ListPrice > 10M
            //               select p).Take(10);

            //product.ForAll(x =>
            //{
            //    Console.WriteLine(x.Name);
            //});

            context.Product.AsParallel().ForAll(p =>
            {
                GetLog(p);
            });

            // AsOrdered - maintains the order in the array

            //context.Product.AsParallel().AsOrdered().Where(p => p.ListPrice > 10M).ToList().ForEach(x =>
            //{
            //    Console.WriteLine($"{x.Name} - {x.ListPrice}");
            //});
        }
    }
}
