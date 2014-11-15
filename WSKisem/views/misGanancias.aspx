<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="misGanancias.aspx.cs" Inherits="views_misGanancias" %>
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
            border: thin solid Silver;
            text-align: justify;
            font-family: Arial;
            font-size: medium;
            font-weight: normal;
            color:Black;
            vertical-align:top;
            margin-top: 0px;
        background-position: 50% bottom; 
            background-repeat: no-repeat;
        }
        .style2
        {
            height: 33px;
            width: 451px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <div style="overflow:auto; width: 820px; height: 420px; border-color:#1259AA; border-style:solid; border-width:1px">
    <asp:UpdatePanel ID="pnlGridView" runat="server">
        <ContentTemplate>
            <asp:Table ID="tblGridView" runat="server" Width="820px" CellPadding="2" 
                Font-Size="Small">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                         <asp:GridView ID="gvdGanancias" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                            ForeColor="#333333" GridLines="Vertical" PageSize="10" BorderWidth="1" BorderColor="#808080"
                            BorderStyle="Ridge" RowStyle-BorderStyle="Groove" AllowPaging="true" AllowSorting="false"
                            OnPageIndexChanging="gvdGanancias_PageIndexChanging" CellPadding="4" HorizontalAlign="Center">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="Corte" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate >
                                        <asp:Label ID="lblIdCorte" runat="server" Text ='<%#Eval("IdCorte")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ganancias" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGanancias" runat="server" Text ='<%#Eval("Ganancias")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retención ISR" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRetencionISR" runat="server" Text ='<%#Eval("RetencionISR")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IVA" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIVA" runat="server" Text ='<%#Eval("Iva")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Retención IVA" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRetencionIVA" runat="server" Text ='<%#Eval("RetencionIva")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ganancia Neta" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGananciaNeta" runat="server" Text ='<%#Eval("GananciaNeta")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Periodo Incentivable" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriodo" runat="server" Text ='<%#Eval("Periodo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalle" Visible="true" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtndetalle" runat="server" OnClick="imgBtnDetalle_Click" ImageUrl="~/Imagenes/detalle.jpg" Width="20" Height="20" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>