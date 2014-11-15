<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="CompraInscripcion.aspx.cs" Inherits="views_CompraInscripcion" %>

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
        .miniTabla
        {
            border: thin solid Silver;
            text-align: justify;
            font-family: Arial;
            font-weight: normal;
            font-size: medium;
            color: Black;
            vertical-align:top;
            width: 820px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
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
    <asp:Table ID="tblProspectos" runat="server" CssClass="miniTabla">
    <asp:TableRow Height="10px">
                    <asp:TableCell></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblMisProspectos" runat="server" Text="Selecciona el prospecto:" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell ColumnSpan="3">
            <asp:GridView ID="gvdProspectos" runat="server" AutoGenerateColumns="false" EmptyDataText="No tiene prospectos registrados."
                ForeColor="#333333" GridLines="Vertical" BorderWidth="1" BorderColor="#808080"
                BorderStyle="Ridge" RowStyle-BorderStyle="Groove" AllowSorting="false"
                CellPadding="4" Width="800px" HorizontalAlign="Center">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate >
                            <asp:Label ID="lblIdProspecto" runat="server" Text ='<%#Eval("IdProspecto")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre" Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate >
                            <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido Paterno" Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblApPaterno" runat="server" Text ='<%#Eval("ApPaterno")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido Materno" Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblApMaterno" runat="server" Text ='<%#Eval("ApMaterno")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Celular" Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="Celular" runat="server" Text ='<%#Eval("Celular")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" Visible="true" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="Email" runat="server" Text ='<%#Eval("Email")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="true" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCompra" AutoPostBack="true" runat="server" ValidationGroup="compra" OnCheckedChanged="chkCompra_CheckedChange" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:TableCell></asp:TableRow><asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <asp:Button ID="btnCambiar" runat="server" Text="Cambiar" OnClick="btnCambiar_Click" />
            </asp:TableCell></asp:TableRow></asp:Table>
            <asp:Panel ID="pnlCompra" runat="server">
            <asp:Table ID="tblCompra" runat="server" CssClass="subtitulo">
            <asp:TableRow Height="20px">
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="3">
                    <asp:Label ID="lblTitlCompra" runat="server" Text="Seleccione el paquete que desa comprar: " ForeColor="#084B8A" />
                </asp:TableCell></asp:TableRow>
                <asp:TableRow Height="20px">
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <asp:Label ID="lblNombrePqt1" runat="server"  Font-Bold="true" ForeColor="#084B8A" Text="Pqt1" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="lblNombrePqt2" runat="server"  Font-Bold="true" ForeColor="#084B8A" Text="Pqt2" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="lblNombrePqt3" runat="server" Font-Bold="true" ForeColor="#084B8A" Text="Pqt3" />
                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <asp:ImageButton ID="imgBtnPqt1" runat="server" 
                        ImageUrl="~/Imagenes/Compras/Pqt1.jpg" ToolTip="Clic para Comprar" onclick="imgBtnPqt1_Click" />
                </asp:TableCell><asp:TableCell>
                    <asp:ImageButton ID="imgBtnPqt2" runat="server" 
                        ImageUrl="~/Imagenes/Compras/Pqt2.jpg" ToolTip="Clic para Comprar" onclick="imgBtnPqt2_Click" />
                </asp:TableCell><asp:TableCell>
                    <asp:ImageButton ID="imgBtnPqt3" runat="server" 
                        ImageUrl="~/Imagenes/Compras/Pqt3.jpg" ToolTip="Clic para Comprar" onclick="imgBtnPqt3_Click" />
                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
                <asp:TableCell>
                    <asp:Label ID="lblPrecioPqt1" runat="server" Font-Bold="true" Text="$" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="lblPrecioPqt2" runat="server" Font-Bold="true" Text="$" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="lblPrecioPqt3" runat="server" Font-Bold="true" Text="$" />
                </asp:TableCell></asp:TableRow>
                <asp:TableRow Height="50px">
                    <asp:TableCell></asp:TableCell>
                </asp:TableRow>
                </asp:Table></asp:Panel></asp:Content>