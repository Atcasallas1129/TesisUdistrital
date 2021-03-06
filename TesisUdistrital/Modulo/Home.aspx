﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TesisUdistrital.Modulo.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PnlMensajes" runat="server">
    </asp:Panel>
    <div class="row">
        <h2>Módulo de Descarga de Información</h2>
        <div class="col-lg-12">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="true">
                        <asp:Panel ID="panelMensajes" runat="server"></asp:Panel>
            </asp:PlaceHolder>
            <div class="panel-group">
                <div class="panel panel-default" style="margin-top:10px;">
                    <div>
                        <h4 class="panel-title" style="margin-top:20px; margin-left:10px; font-family:Helvetica Neue, Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold;">Busqueda</h4>
                        <hr />
                        <div class="panel-body">
                            <div class="col-md-4">
                                    <div class="form-group-sm">
                                        <label>Radicado</label>
                                        <asp:TextBox ID="txtRadicado" runat="server" CssClass="input-sm form-control"></asp:TextBox>
                                    </div>
                            </div>
                            <div class="col-md-4">
                                <div class="input-group">
                                    <label>Documento Destinatario</label>
                                    <div class="input-group">
                                    <asp:TextBox ID="txtDocumentoDestinatario" runat="server" CssClass="input-sm form-control"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-danger btn-sm" Text="Buscar" OnClick="btnBuscar_Click"/>
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
                <div class="col-lg-12" style="margin-top:15px; margin-bottom:15px; top: -1px; left: 0px;">
                    <asp:Button ID="btnDescarga" runat="server" CssClass="btn btn-success btn-sm" Text="Descargar" OnClick="btnDescarga_Click"/>
                    <asp:DropDownList ID="ddlIdCasos" runat="server" Visible =" false"></asp:DropDownList>
                </div>
                <div class="col-lg-12" style="margin-top:15px; margin-bottom:15px;">
                    <asp:GridView ID="dgvHistoricoNna" runat="server" DataKeyNames="IdRegistro" CssClass="table table-hover table-condensed" AllowPaging="True" DataSourceID="LinqDataSource" AutoGenerateColumns="False" PageSize="25" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" EmptyDataText="No hay resultados de la búsqueda. Por favor ingrese parámetros de búsqueda." OnSelectedIndexChanged="dgvHistoricoNna_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" />
                            <asp:BoundField DataField="Radicado" HeaderText="Radicado" />
                            <asp:BoundField DataField="Proceso" HeaderText="Proceso" />
                            <asp:BoundField DataField="NombreVictima" HeaderText="NombreVictima" />
                            <asp:BoundField DataField="DocumentoVictima" HeaderText="DocumentoVictima" />
                            <asp:BoundField DataField="HechoVictimizante" HeaderText="HechoVictimizante" />
                            <asp:BoundField DataField="NombreDestinatario" HeaderText="NombreDestinatario" />
                            <asp:BoundField DataField="DocumentoDestinatario" HeaderText="DocumentoDestinatario" />
                        </Columns>
                    </asp:GridView>
                    <asp:LinqDataSource ID="LinqDataSource" runat="server" OnSelecting="LinqDataSource_Selecting"></asp:LinqDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
