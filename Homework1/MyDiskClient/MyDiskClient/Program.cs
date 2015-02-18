using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyDiskClient
{
    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        string GetTotalSize(string str);
        [OperationContract]
        string GetFreeSpace(string str);
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyDiskInfo> factory = new ChannelFactory<IMyDiskInfo>(
               new WSHttpBinding(),
               new EndpointAddress("http://localhost:8001/MyMath/Ep1"));
            IMyDiskInfo channel = factory.CreateChannel();
            Console.WriteLine("Write the name of the disk");
            string str = Console.ReadLine();
            string result = " ";
            try
            {
                result = "Freespace = " + channel.GetFreeSpace(str).ToString() +
                    "\tTotalspace= " + channel.GetTotalSize(str).ToString();
            }
            catch (Exception e)
            {
                result = "There is no disk " + str[0]; 
            }
            Console.WriteLine(result);
            Console.WriteLine("Press ENTER to end the process");
            Console.ReadLine();
            factory.Close();
        }
    }
}
