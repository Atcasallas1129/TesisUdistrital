using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Linq;
using TesisUdistrital.Models;
using System.Text;
using System.Security.Cryptography;

namespace TesisUdistrital.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                if (UsuarioValido(Email.Text, Password.Text))
                {
                    string usuario = Email.Text;
                    string contrasena = EncriptarContrasena(Password.Text);
                    DocumentacionDemoEntities contexto = new DocumentacionDemoEntities();
                    usuario idusuario = contexto.usuario.SingleOrDefault(X => X.usuarioLogin.Equals(usuario) && X.contrasena.Equals(contrasena));
                    Session["usuarioLogeado"] = idusuario;
                    Response.Redirect("~/Modulo/Home.aspx",false);
                }
                else
                {
                    Session["usuarioLogeado"] = null;
                    PnlMensajes.CssClass = "alert alert-danger";
                    Label textoError = new Label();
                    textoError.Text = "Error: Las credenciales de acceso no son correctas.";
                    PnlMensajes.Controls.Add(textoError);
                }
            }
            catch
            {
                Session["usuarioLogeado"] = null;
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No se ha podido establecer conexion con la base de datos, intente nuevamente";
                PnlMensajes.Controls.Add(textoError);
            }
        }

        public string EncriptarContrasena(string contrasena)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(contrasena);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        private bool UsuarioValido(string usuario, string contrasena)
        {
            try
            {
                DocumentacionDemoEntities contexto = new DocumentacionDemoEntities();
                string contrasenaValida = EncriptarContrasena(contrasena);
                bool valido = false;
                valido = contexto.usuario.Any(X => X.usuarioLogin == usuario && X.contrasena == contrasenaValida);
                return valido;
            }
            catch
            {
                Session["usuarioLogeado"] = null;
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No se ha podido realizar la tarea solicitada, intente nuevamente";
                PnlMensajes.Controls.Add(textoError);
                bool valido = false;
                return valido;
            }

        }
    }
}