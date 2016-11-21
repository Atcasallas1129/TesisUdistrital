<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleDocumentacion.aspx.cs" Inherits="TesisUdistrital.Modulo.DetalleDocumentacion_aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PnlMensajes" runat="server">
    </asp:Panel>
    <div class="row">
        <h3>Información hecho victimizante</h3>
        <div class="col-md-12">
                <div class="col-md-6">
                    <fieldset>
                        <legend>Información Básica</legend>
                        <div class="form-group">
                                <label>Id Registro</label>
                                <asp:Label ID="lblIdRegistro" runat="server"></asp:Label>
                            </div>
                        <div class="form-group">
                                <label>Código Caso</label>
                                <asp:Label ID="lblCodUnique" runat="server"></asp:Label>
                            </div>
                        <div class="form-group">
                                <label>N° Radicado</label>
                                <asp:Label ID="lblRadicado" runat="server"></asp:Label>
                            </div>
                        <div class="form-group">
                                <label>Marco Normativo</label>
                                <asp:Label ID="lblMarcoNormativo" runat="server"></asp:Label>
                            </div>
                    </fieldset>
                </div>
                <div class="col-md-6">
                    <fieldset>
                        <legend>Información Hecho</legend>
                        <div class="form-group">
                            <label>Hecho Victimizante</label>
                            <asp:Label ID="lblHechoVictimizante" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Depto. Ocurrencia</label>
                            <asp:Label ID="lblDeptoOcurrenciaHecho" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Muni. Ocurrencia</label>
                            <asp:Label ID="lblMuniOcurrencia" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Fecha Ocurrencia</label>
                            <asp:Label ID="lblFechaOcurrencia" runat="server"></asp:Label>
                        </div>
                    </fieldset>
                </div>
        </div>
    </div>
    <div class="row">
        <h3>Información sobre la víctima</h3>
        <asp:Panel ID="pnlInformacionVictimaConsulta" runat="server" Visible =" true">
            <div class="col-md-12">
                <div class="contenedorBotonAcciones">
                    <asp:button ID="button_Editar" runat="server" Native="true" CssClass="btn btn-sm btn-warning" Text="Editar" OnClick="button_Editar_Click"></asp:button>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <fieldset>
                        <legend>.</legend>
                        <div class="form-group">
                            <label>Primer Nombre</label>
                            <asp:Label ID="lblPrimerNombre" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Segundo Nombre</label>
                            <asp:Label ID="lblSegundoNombre" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Primer Apellido</label>
                            <asp:Label ID="lblPrimerApellido" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Segundo Apellido</label>
                            <asp:Label ID="lblSegundoApellido" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Tipo Documento</label>
                            <asp:Label ID="lblTipoDocumento" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>N° Documento</label>
                            <asp:Label ID="lblNoDocumento" runat="server"></asp:Label>
                        </div>
                    </fieldset>
                </div>
                <div class="col-md-6">
                    <fieldset>
                        <legend>.</legend>
                        <div class="form-group">
                            <label>Fecha Nacimiento</label>
                            <asp:Label ID="lblFechaNacimiento" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Genero</label>
                            <asp:Label ID="lblGenero" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Parentesco con el Declarante</label>
                            <asp:Label ID="lblParentesco" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Porcentaje de la Indemnizacion</label>
                            <asp:Label ID="lblPorcentaje" runat="server"></asp:Label>
                        </div>
                    </fieldset>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlInformacionVictimaEdicion" runat="server" Visible ="false">
            <div class="col-md-12">
                <div class="contenedorBotonAcciones">
                    <asp:button ID="button_Guardar" runat="server" Native="true" CssClass="btn btn-sm btn-success" Text="Guardar" OnClick="button_Guardar_Click"></asp:button>
                    <asp:button ID="button_Cancelar" runat="server" Native="true" CssClass="btn btn-sm btn-danger" Text="Cancelar" OnClick="button_Cancelar_Click"></asp:button>
                </div>
            </div>
            <div class="col-md-12">
                <div class="col-md-6">
                    <fieldset>
                        <legend>.</legend>
                        <div class="form-group">
                            <label>Primer Nombre</label>
                            <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Segundo Nombre</label>
                            <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Primer Apellido</label>
                            <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Segundo Apellido</label>
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Tipo Documento</label>
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" DataValueField ="tipoDocumentoId" CssClass="form-control" Width="50%" DataTextField ="tipoDocumentoNombre" OnInit="ddlTipoDocumento_Init"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>N° Documento</label>
                            <asp:TextBox ID="txtNoDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
                <div class="col-md-6">
                    <fieldset>
                        <legend>.</legend>
                        <div class="form-group">
                            <label>Fecha Nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" Width ="50%" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Genero</label>
                            <asp:DropDownList id="ddlGeneroDestinatario" runat="server" CssClass="form-control" Width="50%" DataValueField="generoId" DataTextField ="generoNombre" OnInit="ddlGeneroDestinatario_Init"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Parentesco con el Declarante</label>
                            <asp:DropDownList id="ddlParentescoDestinatario" runat="server" CssClass="form-control" Width="50%" DataValueField="parentescoId" DataTextField ="ParentescoNombre" OnInit="ddlParentescoDestinatario_Init"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>Porcentaje de la Indemnizacion</label>
                            <asp:TextBox ID ="txtPorcentaje" runat="server" Width ="50%" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="row">
        <h3>Soportes Asociados al caso</h3>
        <div class="col-lg-12" style="margin-top:15px; margin-bottom:15px;">
            <div class="col-md-4">
                <div class="input-group">
                    <label>Cargar Soporte</label>
                    <div class="input-group">
                        <asp:DropDownList ID="ddltipoSoporte" runat="server" DataValueField ="soporteId" CssClass="form-control" Width="100%" DataTextField ="tipoSoporteNombre" OnInit="ddltipoSoporte_Init"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="input-group">
                    <label>Cargar Soporte</label>
                    <div class="input-group">
                        <asp:FileUpload ID="fUloadSoportes" runat="server" CssClass ="input-sm form-control" Width="100%"/>
                        <span class="input-group-btn">
                            <asp:Button ID="btnCargarSoportes" runat="server" CssClass="btn btn-success btn-sm" Text="Cargar" OnClick="btnCargarSoportes_Click"/>
                        </span>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridViewArchivosXRadicado" runat="server" DataSourceID="linqDataSourceArchivosXRadicado" DataKeyNames="idSoportePersona" AllowPaging="True" CssClass="table" AutoGenerateColumns="False" PageSize="10" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" EmptyDataText="No existen soportes asociados al radicado"  OnRowCommand="GridViewArchivosXRadicado_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="idSoportePersona" HeaderText="idSoportePersona" ReadOnly="True" Visible="false" />
                            <asp:BoundField DataField="idSoporte" HeaderText="Tipo Soporte" ReadOnly="True" />
                            <asp:BoundField DataField="rad" HeaderText="Radicado" ReadOnly="True" />
                            <asp:BoundField DataField="rutaSoporte" HeaderText="Dirección" ReadOnly="True" />
                            <asp:BoundField DataField="fechaCreacionSoporte" HeaderText="Fecha Creación" ReadOnly="True" />
                            <asp:ButtonField HeaderText="Descargar" CommandName="descargar" ButtonType="Button" Text="Descargar" ControlStyle-CssClass="btn btn-xs btn-primary" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#EEEEEE" Font-Bold="True" ForeColor="#333333" Font-Size="Smaller" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <RowStyle Font-Size="Smaller" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                    <asp:LinqDataSource ID="linqDataSourceArchivosXRadicado" runat="server" OnSelecting="linqDataSourceArchivosXRadicado_Selecting" OrderBy="idSoportePersona"></asp:LinqDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
