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
    public partial class consultaCasoDocumentacion : System.Web.UI.Page
    {
        ConexionR c = new ConexionR();
        String Script;
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

        protected void LinqDataSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            try
            {
                DocumentacionDemoLocalEntities contexto = new DocumentacionDemoLocalEntities();
                string rad = string.IsNullOrWhiteSpace(txtRadicado.Text) ? null : txtRadicado.Text;
                string documento = string.IsNullOrWhiteSpace(txtDocumentoDestinatario.Text) ? null : txtDocumentoDestinatario.Text;
                if (rad == null && documento == null)
                {
                    var resultado = from p in contexto.vw_consultaCasoDocumentacion.AsNoTracking()
                                    where p.id == 0
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
                else if (!string.IsNullOrWhiteSpace(rad) && string.IsNullOrWhiteSpace(documento))
                {
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
                else if (string.IsNullOrWhiteSpace(rad) && !string.IsNullOrWhiteSpace(documento))
                {
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
            }
        }
        protected void dgvHistoricoNna_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dgvHistoricoNna.SelectedRow;
                int idSeleccionado = Convert.ToInt32(dgvHistoricoNna.DataKeys[row.RowIndex].Value.ToString());
                Session["idRegistroDetalle"] = idSeleccionado;
                Response.Redirect("~/Modulo/DetalleDocumentacion.aspx", true);
            }
            catch
            {
                panelMensajes.CssClass = "alert alert-danger";
                Label textoError = new Label();
                textoError.Text = "Error: No es posible establecer conexion con el sistema, por favor intente mas tarde.";
                panelMensajes.Controls.Add(textoError);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
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
            }
        }
    }
}