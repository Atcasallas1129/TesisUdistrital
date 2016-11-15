using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesisUdistrital
{
    public partial class _Default : Page
    {
        private Int64 idUsuarioLogeado;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idUsuarioLogeado = (Session["usuarioLogeado"] as usuario).id;
            }
            catch
            {
                Response.Redirect("~/Account/Login.aspx", false);
            }
        }
    }
}