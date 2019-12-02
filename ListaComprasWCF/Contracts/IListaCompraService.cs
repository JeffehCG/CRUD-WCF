using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ListaComprasWCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IListaCompraService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IListaCompraService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "addLista/")]
        [FaultContract(typeof(FileNotFoundException))]
        bool AddLista(listacompra lista);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getListas/")]
        [FaultContract(typeof(FileNotFoundException))]
        List<listacompra> GetListas();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getListasUser/{idUsuario}")]
        [FaultContract(typeof(FileNotFoundException))]
        List<listacompra> GetListasUser(string idUsuario);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "updateLista/")]
        [FaultContract(typeof(FileNotFoundException))]
        bool UpdateLista(listacompra lista);

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "deleteLista/{idLista}")]
        [FaultContract(typeof(FileNotFoundException))]
        bool DeleteLista(string idLista);
    }
}
