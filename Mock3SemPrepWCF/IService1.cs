using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Mock3SemPrepWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Catch/")]
        List<Catch> GetCatches();

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Catch/{id}")]
        Catch GetOneCatch(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Catch/")]
        Catch AddCatch(Catch newCatch);

        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Catch/{id}")]
        Catch UpdateCatch(string id, Catch udcatch);

        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Catch/{id}")]
        void DeleteCatch(string id);

    }
    [DataContract]
    public class Catch
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Navn { get; set; }
        [DataMember]
        public string Art { get; set; }
        [DataMember]
        public double Vaegt { get; set; }
        [DataMember]
        public string Sted { get; set; }
        [DataMember]
        public int Uge { get; set; }
    }
}
