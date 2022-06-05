using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Carrito
{
    public partial class SiteMaster : MasterPage
    {
        public List<cantArticulo> cantArticulos { get; set; }
        private string carro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string asignarCarro()
        {
            string carro = "Mi Carrito";
            if (Session["cantArt"] == null)
            {
                return carro;
            }
            else
            {
                cantArticulos = (List<cantArticulo>)Session["cantArt"];
                int aContar = 0;
                foreach(var cantArticulo in cantArticulos)
                {
                    aContar += cantArticulo.cant;
                }
                carro = String.Format("Mi Carrito ({0})", aContar);
                return carro;
            }
        }


    }
}