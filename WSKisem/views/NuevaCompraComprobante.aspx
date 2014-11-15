<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="NuevaCompraComprobante.aspx.cs" Inherits="views_NuevaCompraComprobante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../../Style/StyleKisem.css" type="text/css" />
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
            color: #333333;
            vertical-align:top;
            width: 820px;
            height: 350px;
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
    <asp:Table CssClass="subtitulo" runat="server">
        <asp:TableRow>
            <asp:TableCell Width="10%"></asp:TableCell>
            <asp:TableCell Width="50%"></asp:TableCell>
            <asp:TableCell Width="20%"></asp:TableCell>
            <asp:TableCell Width="20%"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell ColumnSpan="3" ID="TCMsjCompra">
                <asp:TextBox ID="litGracias" runat="server" Enabled="false" TextMode="MultiLine" BackColor="White" BorderColor="White" 
                Height="200px" Width="800px" Font-Size="Medium" style="font-family: Arial; resize: none;" BorderStyle="None" ViewStateMode="Disabled" ReadOnly="true" />
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell><asp:TableCell ColumnSpan="3" >
                <asp:Label ID="lblTitlPagos" runat="server" Text="Formas de Pago" Font-Bold="true" />
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblTitlBanco" runat="server" Text="Banco" Font-Bold="true" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblTitlCta" runat="server" Text="Cuenta" Font-Bold="true" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblTitlReferencia" runat="server" Text="Número Referencia" Font-Bold="true" />
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Image ID="imgScotianbank" runat="server" ImageUrl="~/Imagenes/Compras/Scotiabank.png" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblCtaScotian" runat="server" Text="03504208749" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblRefScotian" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Image ID="imgBanorte" runat="server" ImageUrl="~/Imagenes/Compras/Banorte.jpg" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblCtaBanorte" runat="server" Text="0870626045" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblRefBanorte" runat="server" />
            </asp:TableCell></asp:TableRow><asp:TableRow><asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblTitlImporte" runat="server" Text="Importe:" Font-Bold="true" />
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblImporte" runat="server" Font-Bold="true" />
            </asp:TableCell></asp:TableRow><asp:TableRow Height="25px"><asp:TableCell></asp:TableCell><asp:TableCell ColumnSpan="4"></asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                Favor de enviar su ficha de pago al correo:
                <a href="mailto:atencionaclientes@kisem.com.mx">atencionaclientes@kisem.com.mx</a>
                o al fax (442) 222 8507 después de realizar su depósito.
            </asp:TableCell></asp:TableRow></asp:Table></asp:Content>