using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyClient1
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }

    class Program
    {
        
    
        static void Main(string[] args)
        {
            ChannelFactory<IMyMath> factory = new ChannelFactory<IMyMath>(
                new WSHttpBinding(),
                new EndpointAddress("http://localhost:8001/MyMath/Ep1"));
            IMyMath channel = factory.CreateChannel();
            int result = channel.Add(35, 38);
            Console.WriteLine("Result = " + result);
            Console.WriteLine("Press ENTER to end the process");
            Console.ReadLine();
            factory.Close();
        }
    }
}
