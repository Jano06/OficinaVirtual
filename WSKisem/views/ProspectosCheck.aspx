<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="ProspectosCheck.aspx.cs" Inherits="views_ProspectosCheck" %>
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
            color:Black;
            vertical-align:top;
            width: 820px;
            height: 130px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
            border-style:solid;
            border-color:Silver;
            border-width:thin;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <asp:Table ID="tblContenido" runat="server" CssClass="subtitulo">
        
        <asp:TableRow>
            <asp:TableCell Width="100px"></asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblTitulo" runat="server" Text="Ud. tiene prospectos sin terminar el proceso de Inscripción, ¿Qué desea hacer?" Font-Bold="true" />
            </asp:TableCell>
            <asp:TableCell Width="170px"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell Width="100px"></asp:TableCell>
            <asp:TableCell>
                <asp:RadioButton ID="chkInscripcion" GroupName="compra" AutoPostBack="true" Text="Compra Inscripción del prospecto" runat="server" OnCheckedChanged="chkResultado_CheckedChange" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell Width="100px"></asp:TableCell>
            <asp:TableCell>
                <asp:RadioButton ID="chkCompra" GroupName="compra" AutoPostBack="true" Text="Compra Personal" runat="server" OnCheckedChanged="chkResultado_CheckedChange" />
            </asp:TableCell>
            </asp:TableRow>
    </asp:Table>
</asp:Content>