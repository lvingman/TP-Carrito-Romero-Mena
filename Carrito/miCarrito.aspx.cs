using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public List<dominio.Articulo> listaCatalogo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        
        {
            if (!IsPostBack)
            {
            listaArticulosCarro = new List<dominio.Articulo>();
            Session.Add("carrito", listaArticulosCarro);
            }
            
            int id;
            int.TryParse(Request.QueryString["id"], out id);

            listaArticulosCarro = (List<Articulo>)Session["carrito"];
            listaCatalogo = (List<Articulo>)Session["catalogo"];
            listaArticulosCarro.Add(listaCatalogo.Find(x => x.ID == id));
            Session.Add("carrito", listaArticulosCarro);
            dgvCarro.DataSource = listaArticulosCarro;
            dgvCarro.DataBind();
            ///Falta corregir que el sitio web no se crashee al cargar la pagina sin mandar ningun ID
            ///Profesores recomendaron verificar que no se genere un nuevo listaArticulos chequeando que ya hay una lista existente
            ///Se podria usar bandera para corregir esto
        }
        
    }
}