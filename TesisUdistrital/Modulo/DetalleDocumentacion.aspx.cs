using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesisUdistrital.Modulo
{
    public partial class DetalleDocumentacion_aspx : System.Web.UI.Page
    {
        ConexionR c = new ConexionR();
        String Script;
        public Int64 idUsuarioLogeado;
        public Int64 idRegistroSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            idUsuarioLogeado = (Session["usuarioLogeado"] as usuario).id;
            idRegistroSeleccionado = Convert.ToInt64(Session["idRegistroDetalle"].ToString());
            if (!IsPostBack)
            {
                try
                {
                    cargaDatosFormulario();
                }
                catch (SystemException ex)
                {
                    PnlMensajes.CssClass = "alert alert-danger";
                    Label textoError = new Label();
                    textoError.Text = ex.ToString();
                    PnlMensajes.Controls.Add(textoError);
                    //Response.Redirect("~/Account/Login.aspx", false);
                }
            }
        }

        protected void button_Editar_Click(object sender, EventArgs e)
        {
            //Habilitar panel
            pnlInformacionVictimaConsulta.Enabled = false;
            pnlInformacionVictimaConsulta.Visible = false;
            pnlInformacionVictimaEdicion.Visible = true;
        }

        protected void button_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentacionDemoLocalEntities contextoAct = new DocumentacionDemoLocalEntities();
                procesoDocumentacion registro = contextoAct.procesoDocumentacion.Single(X => X.id == idRegistroSeleccionado);
                //crear Variables de actualizacion
                ///persona
                string primerNombre = txtPrimerNombre.Text;
                string segundoNombre = txtSegundoNombre.Text;
                string primerApellido = txtPrimerApellido.Text;
                string segundoApellido = txtSegundoApellido.Text;
                Int64 tipoDocumento = Convert.ToInt64(ddlTipoDocumento.SelectedValue.ToString());
                string noDocumento = txtNoDocumento.Text;
                Int64 genero = Convert.ToInt64(ddlGeneroDestinatario.SelectedValue.ToString());
                DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                ///del caso
                Int64 parentesco = Convert.ToInt64(ddlParentescoDestinatario.SelectedValue.ToString());
                string porcentaje = txtPorcentaje.Text;

                //Actualizacion en la base de datos
                ///de la persona
                registro.persona1.primerNombre = primerNombre.Equals(null) ? "": primerNombre;
                registro.persona1.segundoNombre = segundoNombre.Equals(null) ? "" : segundoNombre;// txtSegundoNombre.Text.ToString();
                registro.persona1.primerApellido = primerApellido.Equals(null) ? "" : primerApellido;// txtPrimerApellido.Text.ToString();
                registro.persona1.segundoApellido = segundoApellido.Equals(null) ? "" : segundoApellido;// txtSegundoApellido.Text.ToString();
                registro.persona1.tipoDocumento = tipoDocumento;
                registro.persona1.noDocumento = noDocumento.Equals(null) ? "" : noDocumento;// txtNoDocumento.Text.ToString();
                registro.persona1.genero = genero; 
                registro.persona1.fechaNacimiento = fechaNacimiento;
                ///del caso
                registro.parentesco = parentesco;
                registro.porcentaje = porcentaje;
                registro.usuarioModificacion = (Session["usuarioLogeado"] as usuario).id;
                registro.fechaModificacion = DateTime.Now;
                registro.regModificado = true;
                //Hacer persistencia de datos en la base
                contextoAct.SaveChanges();
                //mostrar el panel de consulta y generar mensaje de actualizacion
                PnlMensajes.CssClass = "alert alert-success";
                Label textoError = new Label();
                textoError.Text = "Éxito: Actualización exitosa del registro.";
                cargaDatosFormulario();
                pnlInformacionVictimaEdicion.Visible = false;
                pnlInformacionVictimaEdicion.Enabled = false;
                pnlInformacionVictimaConsulta.Enabled = true;
                pnlInformacionVictimaConsulta.Visible = true;
            }
            catch (SystemException ex) 
            {
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error al cargar la información, descripcion del error: "+ex.ToString();
                PnlMensajes.Controls.Add(textoError);
            }
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            pnlInformacionVictimaEdicion.Visible = false;
            pnlInformacionVictimaConsulta.Enabled = true;
            pnlInformacionVictimaConsulta.Visible = true;
        }

        protected void ddlParentescoDestinatario_Init(object sender, EventArgs e)
        {
            try
            {
                DocumentacionDemoLocalEntities contexto = new DocumentacionDemoLocalEntities();
                var parentesco = from p in contexto.parentesco
                                 select new
                                 {
                                     parentescoId = p.idPerentesco,
                                     ParentescoNombre=p.nombreParentesco
                                 };
                ddlParentescoDestinatario.DataSource = parentesco.ToArray();
                ddlParentescoDestinatario.DataBind();
            }
            catch
            {
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error al cargar la información.";
                PnlMensajes.Controls.Add(textoError);
            }
        }

        protected void ddlGeneroDestinatario_Init(object sender, EventArgs e)
        {
            try
            {
                DocumentacionDemoLocalEntities contexto = new DocumentacionDemoLocalEntities();
                var genero = from p in contexto.genero
                                 select new
                                 {
                                     generoId = p.idGenero,
                                     generoNombre = p.descripcionGenero
                                 };
                ddlGeneroDestinatario.DataSource = genero.ToArray();
                ddlGeneroDestinatario.DataBind();
            }
            catch
            {
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error al cargar la información.";
                PnlMensajes.Controls.Add(textoError);
            }
        }

        protected void ddlTipoDocumento_Init(object sender, EventArgs e)
        {
            try
            {
                DocumentacionDemoLocalEntities contexto = new DocumentacionDemoLocalEntities();
                var tipoDocumento = from p in contexto.tipoDocumento
                             select new
                             {
                                 tipoDocumentoId = p.idTipoDocumento,
                                 tipoDocumentoNombre = p.descripcionDocumento
                             };
                ddlTipoDocumento.DataSource = tipoDocumento.ToArray();
                ddlTipoDocumento.DataBind();
            }
            catch
            {
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error al cargar la información.";
                PnlMensajes.Controls.Add(textoError);
            }
        }
        protected void cargaDatosFormulario()
        {
            DocumentacionDemoLocalEntities Contexto = new DocumentacionDemoLocalEntities();
            procesoDocumentacion registro = Contexto.procesoDocumentacion.FirstOrDefault(X => X.id == idRegistroSeleccionado);
            if (registro != null)
            {
                //Se carga la informacion básica del caso
                lblIdRegistro.Text = registro.id.Equals(null) ? "" : registro.id.ToString();
                lblCodUnique.Text = registro.uniqueIdentifier.Equals(null) ? "" : registro.uniqueIdentifier.ToString();
                lblRadicado.Text = registro.rad.Equals(null) ? "" : registro.rad.ToString();
                lblMarcoNormativo.Text = registro.proceso.Equals(null) ? "" : registro.proceso.ToString();
                lblHechoVictimizante.Text = registro.hechoVictimizante1.nombreHechoVictimizante.Equals(null) ? "" : registro.hechoVictimizante1.nombreHechoVictimizante.ToString();
                lblDeptoOcurrenciaHecho.Text = registro.dane.nombreDepto.Equals(null) ? "" : registro.dane.nombreDepto.ToString();
                lblMuniOcurrencia.Text = registro.dane.nombreMunicipio.Equals(null) ? "" : registro.dane.nombreMunicipio.ToString();
                lblFechaOcurrencia.Text = registro.fechaOcurrenciaHecho.Equals(null) ? "" : registro.fechaOcurrenciaHecho.ToString("dd/MM/yyyy");

                // se carga la informacion de la victimas en los labels del panel de consulta
                lblPrimerNombre.Text = registro.persona1.primerNombre.Equals(null) ? "" : registro.persona1.primerNombre.ToString();
                lblSegundoNombre.Text = registro.persona1.segundoNombre.Equals(null) ? "" : registro.persona1.segundoNombre.ToString();
                lblPrimerApellido.Text = registro.persona1.primerApellido.Equals(null) ? "" : registro.persona1.primerApellido.ToString();
                lblSegundoApellido.Text = registro.persona1.segundoApellido.Equals(null) ? "" : registro.persona1.segundoApellido.ToString();
                lblGenero.Text = registro.persona1.genero1.descripcionGenero.Equals(null) ? "" : registro.persona1.genero1.descripcionGenero.ToString();
                lblTipoDocumento.Text = registro.persona1.tipoDocumento1.descripcionDocumento.Equals(null) ? "" : registro.persona1.tipoDocumento1.descripcionDocumento.ToString();
                lblNoDocumento.Text = registro.persona1.noDocumento.Equals(null) ? "" : registro.persona1.noDocumento.ToString();
                lblFechaNacimiento.Text = registro.persona1.fechaNacimiento.Equals(null) ? "" : registro.persona1.fechaNacimiento.ToString("dd/MM/yyyy");
                lblParentesco.Text = registro.parentesco.Equals(null) ? "No Asignado" : registro.parentesco1.nombreParentesco.ToString();
                lblPorcentaje.Text = registro.parentesco.Equals(null) ? "No Asignado" : registro.porcentaje;
                // Se carga la informacion de la victima en los TextBoxes
                //cargar la informacion de los textBox
                txtPrimerNombre.Text = registro.persona1.primerNombre.Equals(null) ? "" : registro.persona1.primerNombre.ToString();
                txtSegundoNombre.Text = registro.persona1.segundoNombre.Equals(null) ? "" : registro.persona1.segundoNombre.ToString();
                txtPrimerApellido.Text = registro.persona1.primerApellido.Equals(null) ? "" : registro.persona1.primerApellido.ToString();
                txtSegundoApellido.Text = registro.persona1.segundoApellido.Equals(null) ? "" : registro.persona1.segundoApellido.ToString();
                ddlGeneroDestinatario.SelectedValue = registro.persona1.genero.ToString();
                ddlTipoDocumento.SelectedValue = registro.persona1.tipoDocumento.Equals(null) ? "" : registro.persona1.tipoDocumento.ToString();
                txtNoDocumento.Text = registro.persona1.noDocumento.Equals(null) ? "" : registro.persona1.noDocumento.ToString();
                txtFechaNacimiento.Text = registro.persona1.fechaNacimiento.Equals(null) ? "": registro.persona1.fechaNacimiento.ToString("dd/MM/yyyy");

                try
                {
                    ddlParentescoDestinatario.SelectedValue = registro.parentesco.ToString();
                }
                catch
                {
                    ddlParentescoDestinatario.SelectedValue = null;
                }
                txtPorcentaje.Text = registro.parentesco.Equals(null) ? "0" : registro.porcentaje;
            }
        }
    }
}