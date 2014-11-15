<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="CambiaPassword.aspx.cs" Inherits="views_CambiaPassword" %>
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
            height: 100px;
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
            <asp:TableCell Width="200px" HorizontalAlign="Right">
                <asp:Label ID="lblTitlContraAnt" runat="server" Text="Contraseña Anterior:" />
            </asp:TableCell><asp:TableCell Width="200px">
                <asp:TextBox ID="txtContrasenaAnterior" runat="server" Width="150px" MaxLength="10" TextMode="Password"  />
            </asp:TableCell><asp:TableCell Width="300px"></asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Right"><asp:Label ID="lblTitlContraNva" runat="server" Text="Nueva Contraseña:" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="txtContrasenaNueva" runat="server" Width="150px" MaxLength="10" TextMode="Password" />
            </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Right">
                <asp:Label ID="lblTitlRepContra" runat="server" Text="Repetir Contraseña Nueva:" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="txtContrasenaRepetir" runat="server" Width="150px" MaxLength="10" TextMode="Password" />
            </asp:TableCell></asp:TableRow></asp:Table><asp:Table runat="server" style="text-align: justify; font-family: Arial; font-size: medium; font-weight: normal; color:Black; vertical-align:top;"
        width="820px">
        <asp:TableRow>
            <asp:TableCell Width="100px"></asp:TableCell><asp:TableCell Width="200px"></asp:TableCell><asp:TableCell><asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPopUps" runat="server">
<asp:UpdatePanel ID="pnlPooUp" runat="server">
        <ContentTemplate>
            <div style="visibility: hidden">
                <asp:Button runat="server" ID="btnHidden" /></div>
            <asp:Panel runat="server" ID="modalPopUpmensaje" CssClass="modal" Height="300px"
                Style="display: none;">
                <div class="popUpMain">
                    <div class="popUpTitle">
                        Mensaje</div><div class="popUpContent">
                        <asp:Table ID="Table1" runat="server" Width="400px">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3"> </asp:TableCell></asp:TableRow><asp:TableRow Height="30px">
                                <asp:TableCell ID="cellmensaje" runat="server" ForeColor="Red"> </asp:TableCell></asp:TableRow></asp:Table></div><div class="popUpFooter">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="botonColor" Text="Cerrar" OnClick="click_btnPopUpAceptar" />
                    </div>
                </div>
            </asp:Panel>
            <AjaxControlToolkit:ModalPopupExtender ID="modalMensaje" runat="server" BackgroundCssClass="modal-bg"
                TargetControlID="btnHidden" PopupControlID="modalPopUpmensaje" Drag="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>