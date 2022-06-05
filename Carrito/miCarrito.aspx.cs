using System;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Carrito
{
    public partial class About : Page
    {
        public List<dominio.Articulo> listaArticulosCarro { get; set; }

        public List<int> cantidadArticulos { get; set; }

        public List<dominio.Articulo> listaCatalogo { get; set; }
        public class cantArticulo
        {
            public int id { get; set; }
            public int cant { get; set; }

            public cantArticulo(int a, int b)
            {
                id = a;
                cant = b;
            }
        }

        public List<cantArticulo> cantArticulos { get; set; }


        protected void Page_Load(object sender, EventArgs e) {



            if (Session["carrito"] == null || Session["cantArt"] == null)
            {
                listaArticulosCarro = new List<dominio.Articulo>();
                Session.Add("carrito", listaArticulosCarro);
                cantArticulos = new List<cantArticulo>();
                Session.Add("cantArt", cantArticulos);
            }

            int id;
            if (Request.QueryString["id"]!=null )
            {
                int.TryParse(Request.QueryString["id"], out id);
                {
                    asignarCantidadArticulos(id, generarCantidad(id));
                    /*
                    listaArticulosCarro = (List<Articulo>)Session["carrito"];
                    listaCatalogo = (List<Articulo>)Session["catalogo"];
                    */
                    

                }
                

            }
            if (Request.QueryString["idelim"]!=null)
            {
                int.TryParse(Request.QueryString["idelim"], out id);
                {
                    eliminarArticulo(id);
                }
            }

            if (Request.QueryString["idmas"] != null)
            {
                int.TryParse(Request.QueryString["idmas"], out id);
                {
                    aumentarArticulo(id);
                }
            }

            if (Request.QueryString["idmenos"] != null)
            {
                int.TryParse(Request.QueryString["idmenos"], out id);
                {
                    reducirArticulo(id);
                }
            }


            listaArticulosCarro = (List<Articulo>)Session["carrito"];
            cantArticulos = (List<cantArticulo>)Session["cantArt"];

        }

        public void asignarCantidadArticulos(int id, bool check)
        {
            cantArticulos = (List<cantArticulo>)Session["cantArt"];
            if (check)
            {
                cantArticulo aAgregar = cantArticulos.Find(x => x.id == id);
                cantArticulos.Remove(aAgregar);
                aAgregar.cant++;
                cantArticulos.Add(aAgregar);
                Session.Add("cantArt", cantArticulos);
            }
            else
            {
                cantArticulo test = new cantArticulo(id, 1);
                cantArticulos.Add(test);
                Session.Add("cantArt", cantArticulos);
            }
        }

        public bool generarCantidad(int id)
        {
            listaArticulosCarro = (List<Articulo>)Session["carrito"];
            listaCatalogo = (List<Articulo>)Session["catalogo"];

                if (listaArticulosCarro.Find(y => y.ID == id) == null)
                {
                    listaArticulosCarro.Add(listaCatalogo.Find(x => x.ID == id));
                    Session.Add("carrito", listaArticulosCarro);
                    return false;
                    
                }
                else if (listaArticulosCarro.Find(y => y.ID == id).ID == listaCatalogo.Find(x => x.ID == id).ID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public void eliminarArticulo(int id)
        {
            listaArticulosCarro = (List<Articulo>)Session["carrito"];
            cantArticulos = (List<cantArticulo>)Session["cantArt"];
            Articulo aEliminar = listaArticulosCarro.Find(y => y.ID == id);
            listaArticulosCarro.Remove(aEliminar);
            cantArticulo aBorrar = cantArticulos.Find(y => y.id == id);
            cantArticulos.Remove(aBorrar);

            Session.Add("carrito", listaArticulosCarro);
            Session.Add("cantArt", cantArticulos);
        }

        public void reducirArticulo(int id)
        {
            cantArticulos = (List<cantArticulo>)Session["cantArt"];
            cantArticulo aReducir = cantArticulos.Find(y => y.id == id);
            cantArticulos.Remove(aReducir);
            aReducir.cant--;
            if (aReducir.cant < 1)
            {
                eliminarArticulo(id);
            }
            else
            {
                cantArticulos.Add(aReducir);
                Session.Add("cantArt", cantArticulos);
            }
           
        }

        public void aumentarArticulo(int id)
        {
            cantArticulos = (List<cantArticulo>)Session["cantArt"];
            cantArticulo aAumentar = cantArticulos.Find(y => y.id == id);
            cantArticulos.Remove(aAumentar);
            aAumentar.cant++;
            cantArticulos.Add(aAumentar);
            Session.Add("cantArt", cantArticulos);
            

        }

        public decimal obtenerPrecioTotal()
        {
            decimal pTotal = 0;
            listaArticulosCarro = (List<Articulo>)Session["carrito"];
            cantArticulos = (List<cantArticulo>)Session["cantArt"];
            foreach(Articulo item in listaArticulosCarro)
            {
                pTotal += item.Precio * cantArticulos.Find(x => x.id == item.ID).cant;
            }
            return pTotal;
        }



        protected void dgvCarro_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvCarro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }


    }
}