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
        protected void Page_Load(object sender, EventArgs e)
        
        {
            int id;
            int.TryParse(Request.QueryString["id"], out id);

            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulosCarro = negocio.buscarPorID(id);
            dgvCarro.DataSource = listaArticulosCarro;
            dgvCarro.DataBind();



        }
        
    }
}