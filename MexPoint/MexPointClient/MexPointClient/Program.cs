using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MexPointClient.ServiceReference1;

namespace MexPointClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient proxy = new MyMathClient("WSHttpBinding_IMyMath1");
            IAsyncResult result2;
            int result = proxy.Add(12, 2);
            Console.WriteLine("Sum = " + result);
            Console.WriteLine("To end press ENTER");
           
            
            result2 = proxy.BeginWrite("Pupkin", "Vasyl", GetResultCallback, proxy);
            
            Console.ReadLine();
        }
        static void GetResultCallback(IAsyncResult ar)
        {
            Person p = ((MyMathClient)ar.AsyncState).EndWrite(ar);
            Console.WriteLine("Name= " + p.FirstName + " Surname = " + p.LastName);
        }
    }
}
