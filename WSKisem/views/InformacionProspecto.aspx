<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="InformacionProspecto.aspx.cs" Inherits="views_PopUp_InformacionProspecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
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
            height: 556px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
            border-style:solid;
            border-color:Silver;
            border-width:thin;
        }
        .lbls
        {
            font-family: Arial;
            font-size: medium;
            color: Gray;
        }
        
    </style>
    <link rel="stylesheet" href="../../Style/StyleKisem.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <asp:Table CssClass="subtitulo" runat="server">
        <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell ColumnSpan="2">
                <asp:Label ID="lblTitlNombre" runat="server" Font-Bold="true" Text="Nombre: " />
                <asp:Label ID="lblNombre" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell Width="5%"></asp:TableCell><asp:TableCell Width="42.5%">
                <asp:Label ID="lblTitlFecNac" runat="server" Font-Bold="true" Text="Fecha Nacimiento: " />
                <asp:Label ID="lblFecNac" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell Width="42.5%">
                <asp:Label ID="lblTitlTelef" runat="server" Font-Bold="true" Text="Teléfono Local: " />
                <asp:Label ID="lblTelef" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlLugarNac" runat="server" Font-Bold="true" Text="Lugar Nacimiento: " />
                <asp:Label ID="lblLugarNac" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCel" runat="server" Font-Bold="true" Text="Celular: " />
                <asp:Label ID="lblCel" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlRfc" runat="server" Font-Bold="true" Text="RFC: " />
                <asp:Label ID="lblRfc" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlOtroTel" runat="server" Font-Bold="true" Text="Otro Teléfono: " />
                <asp:Label ID="lblOtroTel" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCurp" runat="server" Font-Bold="true" Text="CURP: " />
                <asp:Label ID="lblCurp" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlEmail" runat="server" Font-Bold="true" Text="Email: " />
                <asp:Label ID="lblEmail" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlEdoCivil" runat="server" Font-Bold="true" Text="Estado Civíl: " />
                <asp:Label ID="lblEdoCivil" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCompania" runat="server" Font-Bold="true" Text="Compañia: " />
                <asp:Label ID="lblCompania" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlPais" runat="server" Font-Bold="true" Text="Pais: " />
                <asp:Label ID="lblPais" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlIdioma" runat="server" Font-Bold="true" Text="Idioma: " />
                <asp:Label ID="lblIdioma" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow>
            <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTitlTipoProsp" runat="server" Font-Bold="true" Text="Tipo Prospecto: " />
                <asp:Label ID="lblTipoProsp" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlDirec" runat="server" Font-Bold="true" Text="DIRECCIÓN PERSONAL" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlEnvio" runat="server" Font-Bold="true" Text="DIRECCIÓN ENVÍO" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCallePers" runat="server" Font-Bold="true" Text="Calle: " />
                <asp:Label ID="lblCallePers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCalleEnv" runat="server" Font-Bold="true" Text="Calle: " />
                <asp:Label ID="lblCalleEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlExtPers" runat="server" Font-Bold="true" Text="Número Exterior: " />
                <asp:Label ID="lblExtPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlExtEnv" runat="server" Font-Bold="true" Text="Número Exterior: " />
                <asp:Label ID="lblExtEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlIntPers" runat="server" Font-Bold="true" Text="Interior: " />
                <asp:Label ID="lblIntPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlIntEnv" runat="server" Font-Bold="true" Text="Interior: " />
                <asp:Label ID="lblIntEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlColPers" runat="server" Font-Bold="true" Text="Colonia: " />
                <asp:Label ID="lblColPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlColEnv" runat="server" Font-Bold="true" Text="Colonia: " />
                <asp:Label ID="lblColEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlMpioPers" runat="server" Font-Bold="true" Text="Municipio: " />
                <asp:Label ID="lblMpioPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlMpioEnv" runat="server" Font-Bold="true" Text="Municipio: " />
                <asp:Label ID="lblMpioEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCpPers" runat="server" Font-Bold="true" Text="CP: " />
                <asp:Label ID="lblCpPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCpEnv" runat="server" Font-Bold="true" Text="CP: " />
                <asp:Label ID="lblCpEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCiudPers" runat="server" Font-Bold="true" Text="Ciudad: " />
                <asp:Label ID="lblCiudPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlCiudEnv" runat="server" Font-Bold="true" Text="Ciudad: " />
                <asp:Label ID="lblCiudEnvio" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlEdoPers" runat="server" Font-Bold="true" Text="Estado: " />
                <asp:Label ID="lblEdoPers" CssClass="lbls" runat="server" />
            </asp:TableCell><asp:TableCell>
                <asp:Label ID="lblTitlEdoEnv" runat="server" Font-Bold="true" Text="Estado: " />
                <asp:Label ID="lblEdoEnv" CssClass="lbls" runat="server" />
            </asp:TableCell></asp:TableRow></asp:Table><asp:Table runat="server" Width="820">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnContinuar" Width="70px" runat="server" Text="Continuar" OnClick="btnContinuar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEditar" Width="70px" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>