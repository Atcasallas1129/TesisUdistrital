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
    public partial class Home : System.Web.UI.Page
    {
        ConexionR c = new ConexionR();
        String Script;
        private Int64 idUsuarioLogeado;
        protected void Page_Load(object sender, EventArgs e)
        {
            PnlMensajes.Visible = false;
            try
            {
                idUsuarioLogeado = (Session["usuarioLogeado"] as usuario).id;
                try
                {
                    DocumentacionDemoLocalEntities contextoL = new DocumentacionDemoLocalEntities();
                    usuario usuarioL = contextoL.usuario.FirstOrDefault(X => X.id == idUsuarioLogeado);
                    if (usuarioL == null)
                    {
                        DocumentacionDemoEntities contextoR = new DocumentacionDemoEntities();
                        usuario usuarioR = contextoR.usuario.FirstOrDefault(X => X.id == idUsuarioLogeado);
                        usuario nvoUsuarioL = new usuario();
                        nvoUsuarioL.id = usuarioR.id;
                        nvoUsuarioL.primerNombre = usuarioR.primerNombre;
                        nvoUsuarioL.segundoNombre = usuarioR.segundoNombre;
                        nvoUsuarioL.primerApellido = usuarioR.primerApellido;
                        nvoUsuarioL.segundoApellido = usuarioR.segundoApellido;
                        nvoUsuarioL.tipoDocumento = usuarioR.tipoDocumento;
                        nvoUsuarioL.noDocumento = usuarioR.noDocumento;
                        nvoUsuarioL.usuarioLogin = usuarioR.usuarioLogin;
                        nvoUsuarioL.contrasena = usuarioR.contrasena;
                        contextoL.usuario.Add(nvoUsuarioL);
                        contextoL.SaveChanges();
                    }
                }
                catch (SystemException ex)
                {
                    PnlMensajes.CssClass = "alert alert-danger";
                    Label textoError = new Label();
                    textoError.Text = "Error en la creación del usuario en sistema local, descripcion del mensaje: "+ex.ToString();
                    PnlMensajes.Controls.Add(textoError);
                    PnlMensajes.Visible = true;
                }
            }
            catch
            {
                Response.Redirect("~/Account/Login.aspx", false);
            }
        }
        protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DocumentacionDemoEntities contexto = new DocumentacionDemoEntities();
                string rad = string.IsNullOrWhiteSpace(txtRadicado.Text) ? null : txtRadicado.Text;
                string documento = string.IsNullOrWhiteSpace(txtDocumentoDestinatario.Text) ? null : txtDocumentoDestinatario.Text;
                if(rad == null && documento == null)
                {
                    btnDescarga.Visible = false;
                    var resultado = from p in contexto.vw_consultaCasoDocumentacion.AsNoTracking()
                                    where p.id == 0
                                    orderby p.rad
                                    select new
                                    {
                                        IdRegistro = p.id,
                                        Radicado = p.rad,
                                        Proceso = p.proceso,
                                        NombreVictima = p.primerNombreVictima.ToString() + " "+ p.primerApellidoVictima.ToString(),
                                        DocumentoVictima = p.noDocumentoVictima,
                                        HechoVictimizante = p.nombreHechoVictimizante,
                                        NombreDestinatario = p.primerNombreDestinatario.ToString() + " "+ p.primerApellidoDestinatario.ToString(),
                                        DocumentoDestinatario = p.noDocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (!string.IsNullOrWhiteSpace(rad) && string.IsNullOrWhiteSpace(documento))
                {
                    btnDescarga.Visible = true;
                    var resultado = from p in contexto.vw_consultaCasoDocumentacion.AsNoTracking()
                                    where p.rad == rad
                                    orderby p.rad
                                    select new
                                    {
                                        IdRegistro = p.id,
                                        Radicado = p.rad,
                                        Proceso = p.proceso,
                                        NombreVictima = p.primerNombreVictima.ToString() + " " + p.primerApellidoVictima.ToString(),
                                        DocumentoVictima = p.noDocumentoVictima,
                                        HechoVictimizante = p.nombreHechoVictimizante,
                                        NombreDestinatario = p.primerNombreDestinatario.ToString() + " " + p.primerApellidoDestinatario.ToString(),
                                        DocumentoDestinatario = p.noDocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if(string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(documento))
                {
                    btnDescarga.Visible = true;
                    var resultado = from p in contexto.vw_consultaCasoDocumentacion.AsNoTracking()
                                    where p.noDocumentoDestinatario == documento
                                    orderby p.rad
                                    select new
                                    {
                                        IdRegistro = p.id,
                                        Radicado = p.rad,
                                        Proceso = p.proceso,
                                        NombreVictima = p.primerNombreVictima.ToString() + " " + p.primerApellidoVictima.ToString(),
                                        DocumentoVictima = p.noDocumentoVictima,
                                        HechoVictimizante = p.nombreHechoVictimizante,
                                        NombreDestinatario = p.primerNombreDestinatario.ToString() + " " + p.primerApellidoDestinatario.ToString(),
                                        DocumentoDestinatario = p.noDocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
                else if (!string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(documento))
                {
                    btnDescarga.Visible = true;
                    var resultado = from p in contexto.vw_consultaCasoDocumentacion.AsNoTracking()
                                    where p.rad == rad && p.noDocumentoDestinatario == documento
                                    orderby p.rad
                                    select new
                                    {
                                        IdRegistro = p.id,
                                        Radicado = p.rad,
                                        Proceso = p.proceso,
                                        NombreVictima = p.primerNombreVictima.ToString() + " " + p.primerApellidoVictima.ToString(),
                                        DocumentoVictima = p.noDocumentoVictima,
                                        HechoVictimizante = p.nombreHechoVictimizante,
                                        NombreDestinatario = p.primerNombreDestinatario.ToString() + " " + p.primerApellidoDestinatario.ToString(),
                                        DocumentoDestinatario = p.noDocumentoDestinatario
                                    };
                    e.Result = resultado.ToArray();
                }
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
                PnlMensajes.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PnlMensajes.Visible = false;
            try
            {
                dgvHistoricoNna.DataBind();
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
                PnlMensajes.Visible = true;
            }
        }
        protected void dgvHistoricoNna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> caso = new List<string>();
                //1. identificar los ids de los casos seleccionados
                foreach (GridViewRow row in dgvHistoricoNna.Rows)
                {
                    CheckBox check = row.FindControl("CheckBox1") as CheckBox;
                    //1,1. guardar los Id seleccionados en un DropDownList
                    if (check.Checked)
                    {
                        string proceso = Convert.ToString(row.Cells[3].Text);
                        string radicado = Convert.ToString(row.Cells[2].Text);
                        caso.Add(proceso + '/' + radicado);
                    }
                }
                //1.2 validar casos repetidos
                var consulta = (from p in caso select p).Distinct();
                List<string> rads = new List<string>();
                foreach (var item in consulta)
                {
                    rads.Add(item);
                }
                //2 insercion en base Local
                ///2.1. Personas
                ////obtener todos los idPersona de todos los radicados
                List<string> idPersona = new List<string>();
                foreach (var item in rads)
                {
                    string[] radicado = item.Split('/');
                    Script = "select distinct p.idPersonaDestinatario from procesoDocumentacion p where p.rad = '" + radicado[1].ToString() + "' and p.proceso = '" + radicado[0].ToString() + "'";
                    DataTable DT = c.ConsultaAUX(Script);
                    if (DT.Rows.Count > 0)
                    {
                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            DataRow DR = DT.Rows[i];
                            idPersona.Add(DR.ItemArray[0].ToString());
                        }
                    }
                }
                ////insertar las personas en la base Local
                DocumentacionDemoEntities contextoR = new DocumentacionDemoEntities();
                var personaInsertar = from p in contextoR.persona
                                      where idPersona.Contains(p.idPersona.ToString())
                                      select p;
                foreach(var personaR in personaInsertar)
                {
                    DocumentacionDemoLocalEntities contextoL = new DocumentacionDemoLocalEntities();
                    persona prePersona = contextoL.persona.FirstOrDefault(X => X.idPersona == personaR.idPersona);
                    if(prePersona == null)
                    {
                        persona nvaPersona = new persona();
                        nvaPersona.idPersona = personaR.idPersona;
                        nvaPersona.idPersonaUnique = personaR.idPersonaUnique;
                        nvaPersona.primerNombre = personaR.primerNombre;
                        nvaPersona.segundoNombre = personaR.segundoNombre;
                        nvaPersona.primerApellido = personaR.primerApellido;
                        nvaPersona.segundoApellido = personaR.segundoApellido;
                        nvaPersona.tipoDocumento = personaR.tipoDocumento;
                        nvaPersona.noDocumento = personaR.noDocumento;
                        nvaPersona.fechaNacimiento = personaR.fechaNacimiento;
                        nvaPersona.genero = personaR.genero;
                        contextoL.persona.Add(nvaPersona);
                        contextoL.SaveChanges();
                    }
                }
                ////buscar todos los registros en la base de datos de los radicados seleccionados
                /////insertar los casos en la base Local
                foreach(var radicadoR in rads)
                {
                    string[] radR = radicadoR.Split('/');
                    string procesoR = radR[0].ToString();
                    string radrR = radR[1].ToString();
                    var casoInsertar = from p in contextoR.procesoDocumentacion
                                       where p.proceso == procesoR && p.rad == radrR
                                       select p;
                    foreach (var registroInsertar in casoInsertar)
                    {
                        DocumentacionDemoLocalEntities contextoL = new DocumentacionDemoLocalEntities();
                        procesoDocumentacion preCargueRegistro = contextoL.procesoDocumentacion.FirstOrDefault(X => X.uniqueIdentifier == registroInsertar.uniqueIdentifier);
                        if (preCargueRegistro == null)
                        {
                            procesoDocumentacion nvoRegistro = new procesoDocumentacion();
                            nvoRegistro.uniqueIdentifier = registroInsertar.uniqueIdentifier;
                            nvoRegistro.rad = registroInsertar.rad;
                            nvoRegistro.proceso = registroInsertar.proceso;
                            nvoRegistro.hechoVictimizante = registroInsertar.hechoVictimizante;
                            nvoRegistro.daneOcurrenciaHecho = registroInsertar.daneOcurrenciaHecho;
                            nvoRegistro.fechaOcurrenciaHecho = registroInsertar.fechaOcurrenciaHecho;
                            nvoRegistro.parentesco = registroInsertar.parentesco;
                            nvoRegistro.porcentaje = registroInsertar.porcentaje;
                            nvoRegistro.usuarioModificacion = (Session["usuarioLogeado"] as usuario).id;
                            nvoRegistro.fechaModificacion = DateTime.Now;
                            nvoRegistro.idPersonaVictima = registroInsertar.idPersonaVictima;
                            nvoRegistro.idPersonaDestinatario = registroInsertar.idPersonaDestinatario;
                            nvoRegistro.regModificado = false;
                            contextoL.procesoDocumentacion.Add(nvoRegistro);
                            usuarioXradicado NvaAsignacionLocal = new usuarioXradicado();
                            NvaAsignacionLocal.rad = registroInsertar.rad;
                            NvaAsignacionLocal.proceso = registroInsertar.proceso;
                            NvaAsignacionLocal.idusuario = (Session["usuarioLogeado"] as usuario).id;
                            NvaAsignacionLocal.estado = true;
                            NvaAsignacionLocal.fechaAsignacion = DateTime.Now;
                            contextoL.usuarioXradicado.Add(NvaAsignacionLocal);
                            contextoL.SaveChanges();
                        }
                    }
                    usuarioXradicado nvaAsignacion = new usuarioXradicado();
                    nvaAsignacion.rad = radicadoR;
                    nvaAsignacion.proceso = procesoR;
                    nvaAsignacion.idusuario = (Session["usuarioLogeado"] as usuario).id;
                    nvaAsignacion.estado = true;
                    nvaAsignacion.fechaAsignacion = DateTime.Now;
                    contextoR.usuarioXradicado.Add(nvaAsignacion);
                    contextoR.SaveChanges();
                }
                PnlMensajes.CssClass = "alert alert-success";
                Label textoError = new Label();
                textoError.Text = "Ha culminado la migración de datos al sistema Local, ahora puede acceder a ellos desde el sistema local";
                PnlMensajes.Controls.Add(textoError);
                PnlMensajes.Visible = true;
            }
            catch(SystemException ex)
            {
                PnlMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = ex.ToString();
                PnlMensajes.Controls.Add(textoError);
                PnlMensajes.Visible = true;
            }            
            //2. buscar los Id, y retornar los radicados unicos
            //3. Cargar a la base local
            //3.1. tabla persona
            //3.2. tabla documentacion
            //3.3. usuario por radicado
            //4. actualizar tabla usuarioxradicado con los radicados descargados
        }
    }
}