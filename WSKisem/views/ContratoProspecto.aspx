<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="ContratoProspecto.aspx.cs" Inherits="views_ContratoProspecto" %>
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
            width: 820px;
            height: 50px;
            background-position: bottom; 
            background-repeat: no-repeat;
        }
        .contrato
        {
            font-family:Arial;
            font-size:small;
            text-align:justify;
            color:Black;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <asp:Table ID="tblContenido" runat="server" CssClass="subtitulo" >
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:LinkButton ID="lnkContrato" runat="server" Text="Descarga Contrato en PDF" Font-Size="Small" OnClick="lnkContrato_Click" />
        </asp:TableCell>
    </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTitulo" runat="server" Text="Contrato:" Font-Bold="true" />
            </asp:TableCell></asp:TableRow><asp:TableRow >
            <asp:TableCell>
                <asp:TextBox ID="txtContrato" runat="server" CssClass="contrato" Height="400px" TextMode="MultiLine" Width="816px"
                     ReadOnly="true" style="resize:none;" /> <br />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell>
                <asp:CheckBox ID="chbxAceptar" runat="server" Checked="false" AutoPostBack="true" Text="He leído y acepto los términos y condiciones" OnCheckedChanged="chbxAcepto_CheckedChanged" />
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>