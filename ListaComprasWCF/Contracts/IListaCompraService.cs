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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "addLista/{idUsuario};{descricao};{data}")]
        [FaultContract(typeof(FileNotFoundException))]
        bool AddLista(string idUsuario, string descricao, string data);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "getListas/")]
        [FaultContract(typeof(FileNotFoundException))]
        List<listacompra> GetListas();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "getListasUser/{idUsuario}")]
        [FaultContract(typeof(FileNotFoundException))]
        List<listacompra> GetListasUser(string idUsuario);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "updateLista/{idUsuario};{descricao};{data};{idLista}")]
        [FaultContract(typeof(FileNotFoundException))]
        bool UpdateLista(string idUsuario, string descricao, string data, string idLista);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "deleteLista/{idLista}")]
        [FaultContract(typeof(FileNotFoundException))]
        bool DeleteLista(string idLista);
    }
}
