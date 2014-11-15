<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="miOrganizacion.aspx.cs" Inherits="views_miOrganizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="Stylesheet" href="../Style/StyleKisem.css" type="text/css" />
    <style type="text/css">
    .subtitulo
    {
        text-align: justify;
        font-family: Arial;
        font-size: medium;
        font-weight: normal;
        color:Black;
        vertical-align:top;
        width: 820px;
        height: 50px;
        margin-top: 0px;
        background-position: bottom; 
        background-repeat: no-repeat;
        border-style:solid;
        border-color:Silver;
        border-width:thin;
    }

    .style2
    {
        height: 33px;
        width: 451px;
    }
    .title
    {
        position: relative;
        font-size: 20px;
        height: 30px;
        font-weight: bold;
        color: #2D96FF;
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <asp:Table ID="tblOpciones" runat="server" CssClass="subtitulo">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Label ID="lblFecha" runat="server" Text="Ver mi Organización hasta el día:" />
                <asp:TextBox ID="txtFecha" runat="server" Width="90" />
                <asp:ImageButton ID="imgBtnFecha" runat="server" Width="18px" Height="18px" ImageUrl="~/Imagenes/calendar.jpg" />
                <AjaxControlToolkit:MaskedEditExtender ID="MaskedFechaBusqueda" runat="server" TargetControlID="txtFecha" 
                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="true" CultureName="es-MX" />
                <AjaxControlToolkit:CalendarExtender ID="cleFecha" runat="server" TargetControlID="txtFecha" 
                    PopupButtonID="imgBtnFecha" Format="dd/MM/yyyy" />
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Label ID="lblStatus" runat="server" Text="Status:" />
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="3" Text="TODOS" Selected="True" />
                    <asp:ListItem Value="1" Text="ACTIVOS"  />
                    <asp:ListItem Value="0" Text="INACTIVOS" />
                    <asp:ListItem Value="2" Text="SUSPENDIDOS" />
                </asp:DropDownList>
            </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" onclick="btnBuscar_Click" />
            </asp:TableCell></asp:TableRow></asp:Table><br />
<div style="border-color:Silver; border-width:thin; border-style: solid; overflow:auto; width: 818px; height: 600px; ">
    <asp:UpdatePanel ID="pnlGridView" runat="server">
        <ContentTemplate>
            <asp:Table ID="tblGridView" runat="server" Width="800px" CellPadding="2" Font-Size="Small">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:GridView ID="gvdMiOrganizacion" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información que mostrar."
                            ForeColor="#333333" GridLines="Vertical" BorderWidth="1" BorderColor="#808080"
                            BorderStyle="Ridge" RowStyle-BorderStyle="Groove" AllowSorting="false"
                                CellPadding="4" >
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="" Visible="true" >
                                    <ItemTemplate >
                                        <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("IdAsociado")%>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Izquierdo" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIzquierdo" runat="server" Text ='<%#Eval("Izquierdo")%>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Derecho" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDerecho" runat="server" Text ='<%#Eval("Derecho")%>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Status" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text ='<%#Eval("Status")%>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Rango" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRango" runat="server" Text ='<%#Eval("Rango")%>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Última Compra" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUltCompra" runat="server" Text ='<%#Eval("UltCompra")%>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Periodo" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriodo" runat="server" Text ='<%#Eval("Periodo")%>'></asp:Label></ItemTemplate></asp:TemplateField></Columns></asp:GridView></asp:TableCell></asp:TableRow></asp:Table></ContentTemplate></asp:UpdatePanel></div></asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPopUps" runat="server">
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