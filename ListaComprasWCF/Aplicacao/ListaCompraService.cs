using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ListaComprasWCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "ListaCompraService" no arquivo de código e configuração ao mesmo tempo.
    public class ListaCompraService : IListaCompraService
    {
        public bool AddLista(string idUsuario, string descricao, string data)
        {
            ComprasContext _contexto = new ComprasContext();
            try
            {
                if(idUsuario != null && descricao != null && data != null)
                {
                    listacompra lista = new listacompra();
                    lista.id_usuario = Convert.ToInt32(idUsuario);
                    lista.descricao = descricao;
                    lista.data_lista = Convert.ToDateTime(data);

                    _contexto.listacompras.Add(lista);
                    _contexto.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(FileNotFoundException ex)
            {
                throw new FaultException<FileNotFoundException>(ex);
            }
        }

        public bool DeleteLista(string idLista)
        {
            ComprasContext _contexto = new ComprasContext();

            try
            {
                listacompra lista = new listacompra();
                lista.id = Convert.ToInt32(idLista);
                _contexto.Entry(lista).State = EntityState.Deleted;
                return true;
            }
            catch (FileNotFoundException ex)
            {
                throw new FaultException<FileNotFoundException>(ex);
            }
        }

        public List<listacompra> GetListas()
        {
            ComprasContext _contexto = new ComprasContext();
            List<listacompra> listas = new List<listacompra>();

            try
            {

                var llista = from k in _contexto.listacompras select k;

                foreach(var iten in llista)
                {
                    listacompra lista = new listacompra();
                    lista.id = iten.id;
                    lista.id_usuario = iten.id_usuario;
                    lista.descricao = iten.descricao;
                    lista.data_lista = iten.data_lista;

                    listas.Add(lista);
                }

                return listas;
           
            }
            catch (FileNotFoundException ex)
            {
                throw new FaultException<FileNotFoundException>(ex);
            }
        }

        public List<listacompra> GetListasUser(string idUsuario)
        {
            ComprasContext _contexto = new ComprasContext();
            List<listacompra> listas = new List<listacompra>();
            try
            {
                var llistas = from k in _contexto.listacompras where k.id_usuario == Convert.ToInt32(idUsuario) select k;
                foreach (var item in llistas)
                {
                    listacompra lista = new listacompra();
                    lista.id = item.id;
                    lista.id_usuario = item.id_usuario;
                    lista.descricao = item.descricao;
                    lista.data_lista = item.data_lista;

                    listas.Add(lista);
                }

                return listas;
            }
            catch (FileNotFoundException ex)
            {
                throw new FaultException<FileNotFoundException>(ex);
            }
        }

        public bool UpdateLista(string idUsuario, string descricao, string data, string idLista)
        {
            ComprasContext _contexto = new ComprasContext();
            try
            {
                if (idUsuario != null && descricao != null && data != null)
                {
                    listacompra lista = new listacompra();
                    lista.id_usuario = Convert.ToInt32(idUsuario);
                    lista.descricao = descricao;
                    lista.data_lista = Convert.ToDateTime(data);

                    _contexto.Entry(lista).State = EntityState.Modified;
                    _contexto.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FaultException<FileNotFoundException>(ex);
            }
        }
    }
}
