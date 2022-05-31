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
        public List<dominio.Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            dgvCarro.DataSource = listaArticulos;
            dgvCarro.DataBind();


        }
        
    }
}