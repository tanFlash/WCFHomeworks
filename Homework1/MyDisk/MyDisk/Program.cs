using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace MyDisk
{
    [ServiceContract]
    public interface IMyDiskInfo
    {
        [OperationContract]
        string GetTotalSize(string str);

        [OperationContract]
        string GetFreeSpace(string str);
    }

    public class MyDiskInfo : IMyDiskInfo
    {
        public string GetTotalSize(string str)
        {
            //try
            //{
                string result;
                DriveInfo drive = new DriveInfo((str[0]).ToString());
                result = drive.TotalSize.ToString();
                return result;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("There is no disk " + str[0]);
            //    return str;
            //}
        }

        public string GetFreeSpace(string str)
        {
            
                string result;
                DriveInfo drive = new DriveInfo((str[0]).ToString());
                result = drive.TotalFreeSpace.ToString();
                return result;
            //}
            //catch
            //{
            //    Console.WriteLine("There is no disk " + str[0]);
            //    return str;
            //}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyDiskInfo));
            sh.AddServiceEndpoint(typeof(IMyDiskInfo), new WSHttpBinding(), "http://localhost:8001/MyMath/Ep1");
            sh.Open();
            Console.WriteLine("To end process press ENTER");
            Console.ReadLine();
            sh.Close();
        }
    }
}
