using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace MexPointServer
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
    }
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
        [OperationContract]
        Person Write(string name, string surname);
    }

    public class MyMath : IMyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public Person Write(string name, string surname)
        {
            Person p = new Person ();
            p.FirstName = name;
            p.LastName = surname;
           
            
            //string result = "Name = " + p.FirstName+ " Last name = " + p.LastName;
            return p;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            //sh.AddServiceEndpoint(typeof(IMyMath), new WSHttpBinding(), "http://localhost:8001/MyMath/Ep1");
           // ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            
           // behavior.HttpGetEnabled = true;
            
            //sh.Description.Behaviors.Add(behavior);
            
            //sh.AddServiceEndpoint(
            //typeof(IMetadataExchange),
            //MetadataExchangeBindings.CreateMexHttpBinding(),
            //"mex");
            sh.Open();
            Console.WriteLine("To end process press ENTER");
            Console.ReadLine();
            sh.Close();
        }
    }
}
