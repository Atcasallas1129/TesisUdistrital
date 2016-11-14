<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sincronizacion.aspx.cs" Inherits="TesisUdistrital.Modulo.Sincronizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-lg-12">
                <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="true">
                    <asp:Panel ID="panel1" runat="server"></asp:Panel>
                </asp:PlaceHolder>
            </div>
    </div>
    <div class="row">
        <h2>Módulo de Sincronización</h2>
        <div class="col-lg-12">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="true">
                        <asp:Panel ID="panelMensajes" runat="server"></asp:Panel>
            </asp:PlaceHolder>
            <div class="panel-group">
                <div class="panel panel-default" style="margin-top:10px;">
                    <div>
                        <hr />
                        <div class="panel-body">
                            <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-danger btn-sm" Text="Consultar" ToolTip="Consultar los casos que estan aptos para la sincronizacion con el sistema remoto" OnClick="btnBuscar_Click"/>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <asp:Button ID="btnSincronizar" runat="server" CssClass="btn btn-success btn-sm" Text="Consultar" ToolTip="Sincronizar los casos que estan aptos para la sincronizacion con el sistema remoto" OnClick="btnSincronizar_Click"/>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default" style="margin-top:10px;">
                <div>
                    <h4 class="panel-title" style="margin-top:20px; margin-left:10px; font-family:Helvetica Neue, Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold;">Resultado de la busqueda:</h4>
                </div>
                <div class="col-lg-12" style="margin-top:15px; margin-bottom:15px;">
                    <asp:GridView ID="dgvConsultaCasosDocumentacionLocal" runat="server" DataKeyNames="IdRegistro" CssClass="table table-hover table-condensed" AllowPaging="True" DataSourceID="LinqDataSource" AutoGenerateColumns="False" PageSize="25" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" EmptyDataText="No hay resultados de la búsqueda. Por favor ingrese parámetros de búsqueda.">
                        <Columns>
                            <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" />
                            <asp:BoundField DataField="Radicado" HeaderText="Radicado" />
                            <asp:BoundField DataField="Proceso" HeaderText="Proceso" />
                            <asp:BoundField DataField="HechoVictimizante" HeaderText="HechoVictimizante" />
                            <asp:BoundField DataField="NombreDestinatario" HeaderText="NombreDestinatario" />
                            <asp:BoundField DataField="DocumentoDestinatario" HeaderText="DocumentoDestinatario" />
                            <asp:BoundField DataField="Parentesco" HeaderText="Parentesco" />
                            <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource" runat="server" OnSelecting="LinqDataSource_Selecting"></asp:LinqDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
