using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TesisUdistrital.Modulo
{
    public partial class Home : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void dgvHistoricoNna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDescarga_Click(object sender, EventArgs e)
        {
            ddlIdCasos.Items.Clear();

            //2. buscar los Id, y retornar los radicados unicos
            //3. Cargar a la base local
            //3.1. tabla persona
            //3.2. tabla documentacion
            //3.3. usuario por radicado
            //4. actualizar tabla usuarioxradicado con los radicados descargados 

            //1. identificar los ids de los casos seleccionados
            foreach (GridViewRow row in dgvHistoricoNna.Rows)
            {
                CheckBox check = row.FindControl("CheckBox1") as CheckBox;
                //1,1. guardar los Id seleccionados en un DropDownList
                if (check.Checked)
                {
                    ListItem Li = new ListItem();
                    Li.Value = Convert.ToString(row.Cells[1].Text);
                    Li.Text = Convert.ToString(row.Cells[2].Text);
                    ddlIdCasos.Items.Add(Li);
                }
            }
            ddlIdCasos.Visible = true;
        }
    }
}