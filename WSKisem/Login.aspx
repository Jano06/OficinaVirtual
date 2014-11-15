<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/Site.master" CodeFile="Login.aspx.cs" Inherits="views_Login" %>

<asp:Content ID="ContenidoDinamico" runat="server" ContentPlaceHolderID="ContenidoLogin">
    <asp:Table ID="tblTitulo" runat="server" HorizontalAlign="Center" 
    style="text-align: center">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblTitulo" runat="server" Text="KISEM - MÉXICO" Font-Bold="true" style="font-family:Verdana"></asp:Label>
        </asp:TableCell></asp:TableRow>
    </asp:Table>
    <br />
    <br />
    <asp:Table ID="tblDatos" runat="server" HorizontalAlign="Center" BackImageUrl="~/Imagenes/Login.png" Width="42%" Height="60%" style="margin-top: 0px">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <br /><br /><br /><br /><br />
                <asp:Label ID="lblUsuario" runat="server" Text="Número de Asociado" ForeColor="#FFFFFF" Font-Bold="true"></asp:Label>
                <br />  
                <asp:UpdatePanel ID="upUsuario" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtUsuario" runat="server" Width="50%"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br /><br /><br />
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" ForeColor="#FFFFFF" Font-Bold="true"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtPassword" runat="server" Width="50%" MaxLength="20" TextMode="Password"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br /><br /><br />
                 <asp:UpdatePanel ID="upLogin" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnEntrar" runat="server" Width="20%" BackColor="#045FB4" Text="Entrar" ForeColor="#FFFFFF" OnClick="click_BtnEntrar"></asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
            </asp:TableCell></asp:TableRow></asp:Table>
    <asp:UpdatePanel ID="uplMensaje" runat="server">
        <ContentTemplate>
            <asp:Table ID="tblMensaje" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" style="margin-top: 0px" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
