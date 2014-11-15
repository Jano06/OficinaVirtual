<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="NuevaCompra.aspx.cs" Inherits="views_NuevaCompra" %>
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
            color: #333333;
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
        .style1
        {
            height: 155px;
        }
        .style2
        {
            height: 52px;
        }
        .style3
        {
            height: 28px;
        }
    </style>
    <link rel="stylesheet" href="../../Style/StyleKisem.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <table ID="tblCompras" runat="server" class="subtitulo">
        <tr>
            <td colspan="3" class="style3">
                <asp:Label ID="lblInstrucc" runat="server" Text="Seleccione el paquete que desa comprar: " ForeColor="#084B8A" />
            </td>
        </tr>
        <tr class="style2" align="center">
            <td>
                <asp:Label ID="lblTitlPqt1" runat="server" Text="Paquete Consumidor" Font-Bold="true" ForeColor="#084B8A" />
            </td>
            <td>
                <asp:Label ID="lblTitlPqt2" runat="server" Text="Paquete Emprendedor" Font-Bold="true" ForeColor="#084B8A" />
            </td>
            <td>
                <asp:Label ID="lblTitlPqt3" runat="server" Text="Paquete Empresarial" Font-Bold="true" ForeColor="#084B8A" />
            </td>
        </tr>
        <tr align="center">
            <td class="style1">
                <asp:ImageButton ID="imgBtnConsumidor" runat="server" 
                    ImageUrl="~/Imagenes/Compras/Pqt1.png" ToolTip="Clic para Comprar" onclick="imgBtnConsumidor_Click" 
                      />
            </td>
            <td class="style1">
                <asp:ImageButton ID="imgBtnEmprendedor" runat="server" 
                    ImageUrl="~/Imagenes/Compras/Pqt2.jpg" ToolTip="Clic para Comprar" onclick="imgBtnEmprendedor_Click" 
                     />
            </td>
            <td class="style1">
                <asp:ImageButton ID="imgBtnEmpresarial" runat="server" 
                    ImageUrl="~/Imagenes/Compras/Pqt3.jpg" ToolTip="Clic para Comprar" onclick="imgBtnEmpresarial_Click" 
                     />
            </td>
        </tr>
        <tr class="style2" align="center">
            <td>
                <asp:Label ID="lblPrecioPqt1" runat="server" Font-Bold="true" />
            </td>
            <td>
                <asp:Label ID="lblPrecioPqt2" runat="server" Font-Bold="true" />
            </td>
            <td>
                <asp:Label ID="lblPrecioPqt3" runat="server" Font-Bold="true" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
    </table>
</asp:Content>