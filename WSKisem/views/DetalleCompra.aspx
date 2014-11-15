<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="DetalleCompra.aspx.cs" Inherits="views_DetalleCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="Stylesheet" href="../Style/StyleKisem.css" type="text/css" />
<style type="text/css">
    .title
    {
        position: relative;
        font-size: 20px;
        height: 30px;
        font-weight: bold;
        color: #2D96FF;
        text-align: center;
    }
    .subtitulo
    {
        text-align: justify;
        font-family: Arial;
        font-size: medium;
        font-weight: normal;
        color: Black;
        vertical-align:top;
        width: 820px;
        height: 70px;
        margin-top: 0px;
        background-position: bottom; 
        background-repeat: no-repeat;
        border-style:solid;
        border-color:Silver;
        border-width:thin;
    }
     .style1
    {
        width: 162px;
        height: 36px;
    }
    .style2
    {
        width: 317px;
        height: 36px;
    }
     .style3
    {
        width: 812px;
    }
     .style4
    {
        height: 36px;
    }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <table runat="server" ID="tblOpciones" class="subtitulo">
        <tr>
            <td class="style2"><asp:Label ID="lblInfoPersonal" runat="server" Text="INFORMACIÓN PERSONAL" Font-Bold="true" /></td>
            <td class="style1"><asp:Label ID="lblOrden" runat="server" Text="ORDEN:" Font-Bold="true" />&nbsp;<asp:Label ID="lblIdOrden" runat="server" ForeColor="Gray" /></td>
            <td class="style4"><asp:Label ID="lblArticulos" runat="server" Text="ARTÍCULOS" Font-Bold="true" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblTitlNumDistr" runat="server" Text="Asociado:" Font-Bold="true" />&nbsp;<asp:Label ID="lblNumDistr" runat="server" ForeColor="Gray" /></td>
            <td><asp:Label ID="lblTitlCodigoArt" runat="server" Text="Código:" Font-Bold="true" />&nbsp;<asp:Label ID="lblCodigoArt" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblTitlNombre" runat="server" Text="Nombre:" Font-Bold="true" />&nbsp;<asp:Label ID="lblNombre" runat="server" ForeColor="Gray" /></td>
            <td><asp:Label ID="lblTitlDescripc" runat="server" Text="Descripción:" Font-Bold="true" />&nbsp;<asp:Label ID="lblDescripcion" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblTitlDirecEnvio" runat="server" Text="Dirección Envío:" Font-Bold="true" />&nbsp;<asp:Label ID="lblDirecEnvio" runat="server" ForeColor="Gray" /></td>
            <td><asp:Label ID="lblTitlCantArt" runat="server" Text="Cantidad:" Font-Bold="true" />&nbsp;<asp:Label ID="lblCantidad" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblDireccionEnvio2" runat="server" ForeColor="Gray" /></td>
            <td><asp:Label ID="lblTitlPuntosArt" runat="server" Text="Puntos:" Font-Bold="true" />&nbsp;<asp:Label ID="lblPuntos" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblTitlFechaOrden" runat="server" Text="Fecha Orden:" Font-Bold="true" />&nbsp;<asp:Label ID="lblFechaOrden" runat="server" ForeColor="Gray" /></td>
            <td><asp:Label ID="lblTitlPrecioUnit" runat="server" Text="Precio Unitario:" Font-Bold="true" />&nbsp;<asp:Label ID="lblPrecioUnit" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblTitlFechaPago" runat="server" Text="Fecha Pago:" Font-Bold="true" />&nbsp;<asp:Label ID="lblFechaPago" runat="server" ForeColor="Gray" /></td>
            <td><asp:Label ID="lblTitlTotal" runat="server" Text="Total:" Font-Bold="true" />&nbsp;<asp:Label ID="lblTotal" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Label ID="lblTitlOrigenOrden" runat="server" Text="Origen de la Orden:" Font-Bold="true" />&nbsp;<asp:Label ID="lblOrigen" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Label ID="lblTitlPeriocoIncentivable" runat="server" Text="Período Incentivable:" Font-Bold="true" />&nbsp;<asp:Label ID="lblPeriodo" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Label ID="lblTitlEstatusOrden" runat="server" Text="Estatus Orden:" Font-Bold="true" />&nbsp;<asp:Label ID="lblStatus" runat="server" ForeColor="Gray" /></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Label ID="lblTitlOperador" runat="server" Text="Operador:" Font-Bold="true" />&nbsp;<asp:Label ID="lblOperador" runat="server" ForeColor="Gray" /></td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="style3" align="center"><asp:Button ID="btnRegresar" Text="Regresar" 
                    runat="server" onclick="btnRegresar_Click" /></td>
        </tr>
    </table>
</asp:Content>