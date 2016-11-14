using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace TesisUdistrital.Modulo
{
    public partial class Sincronizacion : System.Web.UI.Page
    {
        ConexionL c = new ConexionL();
        String Script;
        private Int64 idUsuarioLogeado;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idUsuarioLogeado = (Session["usuarioLogeado"] as usuario).id;
                if (!IsPostBack)
                {
                    dgvConsultaCasosDocumentacionLocal.DataBind();
                }
            }
            catch
            {
                Response.Redirect("~/Account/Login.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvConsultaCasosDocumentacionLocal.DataBind();
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
                panelMensajes.Visible = true;
            }
        }

        protected void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Int64> Personas = new List<Int64>();
                DocumentacionDemoLocalEntities contextoL = new DocumentacionDemoLocalEntities();
                var resultado = from p in contextoL.vw_consultaCasoDocumentacion.AsNoTracking()
                                where p.regModificado == true
                                select p;
                foreach (var elemento in resultado)
                {
                    DocumentacionDemoEntities contextoR = new DocumentacionDemoEntities();
                    procesoDocumentacion registro = contextoR.procesoDocumentacion.FirstOrDefault(X => X.uniqueIdentifier == elemento.uniqueIdentifier);
                    //Informacion del caso
                    tipoDocumento TipoDocumento = contextoR.tipoDocumento.FirstOrDefault(X => X.descripcionDocumento == elemento.tipoDocumentoDestinatario);
                    genero Genero = contextoR.genero.FirstOrDefault(X => X.descripcionGenero == elemento.GeneroDestinatario);
                    parentesco Parentesco = contextoR.parentesco.FirstOrDefault(X => X.nombreParentesco == elemento.nombreParentesco);
                    registro.parentesco = Parentesco.idPerentesco;
                    registro.porcentaje = elemento.porcentaje;
                    registro.usuarioModificacion = elemento.usuarioModificacion;
                    registro.fechaModificacion = elemento.fechaModificacion;
                    registro.regModificado = true;
                    //Informacion de la persona
                    registro.persona1.primerNombre = elemento.primerNombreDestinatario;
                    registro.persona1.segundoNombre = elemento.segundoNombreDestinatario;
                    registro.persona1.primerApellido = elemento.primerApellidoDestinatario;
                    registro.persona1.segundoApellido = elemento.segundoApellidoDestinatario;
                    registro.persona1.tipoDocumento = TipoDocumento.idTipoDocumento;
                    registro.persona1.noDocumento = elemento.noDocumentoDestinatario;
                    registro.persona1.fechaNacimiento = elemento.fechaNacimientoDestinatario;
                    registro.persona1.genero = Genero.idGenero;
                    contextoR.SaveChanges();
                }
                foreach(var item in resultado)
                {
                    procesoDocumentacion objeto = contextoL.procesoDocumentacion.FirstOrDefault(X => X.uniqueIdentifier == item.uniqueIdentifier);
                    eliminaregistros(objeto);
                    Personas.Add(objeto.idPersonaDestinatario);
                }
                var personasEliminar = from P in contextoL.persona
                                           where Personas.Contains(P.idPersona)
                                           select P;
                foreach(var item in personasEliminar)
                {
                    persona Persona = contextoL.persona.FirstOrDefault(X => X.idPersona == item.idPersona);
                    Script = "delete from persona where idPersona = '" + Persona.idPersona + "'";
                    c.ConsultaAUX(Script);
                }
                panelMensajes.CssClass = "alert alert-success";
                Label textoError = new Label();
                textoError.Text = "Se ha realizado la migración del caso al sistema remoto y se ha vaciado la informacion de la base local";
                panelMensajes.Controls.Add(textoError);
                panelMensajes.Visible = true;
                dgvConsultaCasosDocumentacionLocal.DataBind();
            }
            catch(SystemException ex)
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: se ha presentado un error durante la sincronizacion con el sistema Remoto, detalle del error: "+ex.ToString();
                panelMensajes.Controls.Add(textoError);
                panelMensajes.Visible = true;
            }
        }
        protected void eliminaregistros(procesoDocumentacion objeto)
        {
            DocumentacionDemoLocalEntities contextoL = new DocumentacionDemoLocalEntities();

            ////Eliminar Caso
            procesoDocumentacion casoPreEliminar = contextoL.procesoDocumentacion.FirstOrDefault(X => X.uniqueIdentifier == objeto.uniqueIdentifier);
            if (casoPreEliminar != null)
            {
                Script = "delete from procesodocumentacion where uniqueidentifier = '" + objeto.uniqueIdentifier.ToString() + "'";
                c.ConsultaAUX(Script);
            }
            ////Eliminar asignacion del caso
            usuarioXradicado asignacionEliminar = contextoL.usuarioXradicado.FirstOrDefault(X => X.rad == objeto.rad && X.proceso == objeto.proceso);
            if (asignacionEliminar != null)
            {
                Script = "delete from usuarioxradicado where rad = '" + objeto.rad.ToString() + "' and proceso = '" + objeto.proceso.ToString() + "'";
                c.ConsultaAUX(Script);
            }
        }

        protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DocumentacionDemoLocalEntities contextoL = new DocumentacionDemoLocalEntities();
                var resultado = from p in contextoL.vw_consultaCasoDocumentacion.AsNoTracking()
                                where p.regModificado == true
                                orderby p.rad
                                select new
                                {
                                    IdRegistro = p.id,
                                    Radicado = p.rad,
                                    Proceso = p.proceso,
                                    HechoVictimizante = p.nombreHechoVictimizante,
                                    NombreDestinatario = p.primerNombreDestinatario.ToString() + " " + p.primerApellidoDestinatario.ToString(),
                                    DocumentoDestinatario = p.noDocumentoDestinatario,
                                    Parentesco = p.nombreParentesco,
                                    Porcentaje = p.porcentaje
                                };
                e.Result = resultado.ToArray();
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
                panelMensajes.Visible = true;
            }
        }
    }
}