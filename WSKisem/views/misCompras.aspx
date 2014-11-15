<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="misCompras.aspx.cs" Inherits="views_misCompras" %>
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
            height: 70px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
            border-style:solid;
            border-color:Silver;
            border-width:thin;
        }
        .style7
        {
            width: 80px;
        }
        .style9
        {
            width: 123px;
        }
        .style12
        {
            width: 172px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <table runat="server" ID="tblOpciones" class="subtitulo">
        <tr>
            <td class="style9"></td>
            <td class="style7"></td>
            <td class="style7"></td>
            <td class="style12"><asp:Label ID="lblFechaInicial" runat="server" Text="Fecha Inicial" ForeColor="Gray" /><br /><asp:Label ID="lblFormatoInicial" runat="server" Text="(dd/mm/aaaa)" ForeColor="Gray" Font-Size="Small" /> </td>
            <td class="style12"><asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final" ForeColor="Gray"  /><br /><asp:Label ID="lblFormatoFinal" runat="server" Text="(dd/mm/aaaa)" ForeColor="Gray" Font-Size="Small" /></td>
            <td class="style7"></td>
            <td class="style7"></td>
            <td class="style7"></td>
            <td class="style9"></td>
        </tr>
        <tr>
            <td class="style9"></td>
            <td class="style7" align="center">
            <asp:Button ID="btnPrimero" Text="<<" 
                    runat="server" Width="59px" Height="31px" onclick="btnPrimero_Click" /></td>
            <td class="style7" align="center">
                <asp:Button ID="btnAnterior" Text="<" 
                    runat="server" Width="59px" Height="31px" onclick="btnAnterior_Click" /></td>
            <td class="style12">
                <asp:TextBox ID="txtFechaInicio" runat="server" Width="80px" 
                    Height="22px" />
            <asp:ImageButton ID="imgBtnFechaInicio" runat="server" Width="20px" Height="20px" ImageUrl="~/Imagenes/calendar.jpg" />
            <AjaxControlToolkit:MaskedEditExtender ID="MaskedFechaInicioBusqueda" runat="server" TargetControlID="txtFechaInicio" 
                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="true" CultureName="es-MX" ></AjaxControlToolkit:MaskedEditExtender>
            <AjaxControlToolkit:CalendarExtender ID="cleFechaInicio" runat="server" TargetControlID="txtFechaInicio" 
                PopupButtonID="imgBtnFechaInicio"  Format="d/MM/yyyy" ></AjaxControlToolkit:CalendarExtender></td>
            <td class="style12">
                <asp:TextBox ID="txtFechaFin" runat="server" Width="80px" 
                    Height="20px" />
            <asp:ImageButton ID="imgBtnFechaFin" runat="server" Width="20px" Height="20px" ImageUrl="~/Imagenes/calendar.jpg" />
            <AjaxControlToolkit:MaskedEditExtender ID="MaskedFechaFinBusqueda" runat="server" TargetControlID="txtFechaFin" 
                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="true" CultureName="es-MX" ></AjaxControlToolkit:MaskedEditExtender>
            <AjaxControlToolkit:CalendarExtender ID="cleFechaFin" runat="server" TargetControlID="txtFechaFin" 
                PopupButtonID="imgBtnFechaFin" Format="d/MM/yyyy" ></AjaxControlToolkit:CalendarExtender></td>
            <td class="style7" align="center"><asp:Button ID="btnSiguiente" Text=">" 
                    runat="server" Width="59px" Height="31px" onclick="btnSiguiente_Click" /></td>
            <td class="style7" align="center"><asp:Button ID="btnUltimo" Text=">>" 
                    runat="server" Width="59px" Height="31px" onclick="btnUltimo_Click" /></td>
            <td class="style7" align="center"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" /></td>
            <td class="style9"></td>
        </tr>
        <tr>
            <td colspan="9"></td>
        </tr>
    </table>
    <br />
    <div style="border: 1px solid #1259AA; overflow:auto; width: 818px; height: 400px; ">
    <asp:UpdatePanel ID="pnlGridView" runat="server">
        <ContentTemplate>
            <asp:Table ID="tblGridView" runat="server" Width="800px" CellPadding="2" Font-Size="Small">
                <asp:TableRow>
                    <asp:TableCell HorizontalAlign="Center">
                        <asp:GridView ID="gvdCompras" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                            ForeColor="#333333" GridLines="Vertical" Width="100%" BorderWidth="1" BorderColor="#808080"
                            BorderStyle="Ridge" RowStyle-BorderStyle="Groove" AllowSorting="false"
                            CellPadding="4" HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /> 
                            <Columns>
                                <asp:TemplateField Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtndetalle" runat="server" ImageUrl="~/Imagenes/detalle.jpg" OnClick="imgbtndetalle_Click" Width="20" Height="20" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No. Órden" Visible="true" >
                                    <ItemTemplate >
                                        <asp:Label ID="lblNoOrden" runat="server" Text ='<%#Eval("NumeroOrden")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Orden" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechOrden" runat="server" Text ='<%#Eval("FechaOrden")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Pago" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaPago" runat="server" Text ='<%#Eval("FechaPago")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Puntos" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPuntos" runat="server" Text ='<%#Eval("Puntos")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal" runat="server" Text ='<%#Eval("Total")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pago" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPago" runat="server" Text ='<%#Eval("Pago")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entrega" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEntrega" runat="server" Text ='<%#Eval("Entrega")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Periodo" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriodo" runat="server" Text ='<%#Eval("Periodo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Referencia" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReferencia" runat="server" Text ='<%#Eval("Referencia")%>'></asp:Label>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPopUps" runat="server">
    <asp:UpdatePanel ID="pnlPooUp" runat="server">
        <ContentTemplate>
            <div style="visibility: hidden">
                <asp:Button runat="server" ID="btnHidden" /></div>
            <asp:Panel runat="server" ID="modalPopUpmensaje" CssClass="modal" Height="300px"
                Style="display: none;">
                <div class="popUpMain">
                    <div class="popUpTitle">
                        Mensaje</div>
                    <div class="popUpContent">
                        <asp:Table ID="Table1" runat="server" Width="400px">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3">
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Height="30px">
                                <asp:TableCell ID="cellmensaje" runat="server" ForeColor="Red">
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                    <div class="popUpFooter">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="botonColor" Text="Cerrar" OnClick="click_btnPopUpAceptar" />
                    </div>
                </div>
            </asp:Panel>
            <AjaxControlToolkit:ModalPopupExtender ID="modalMensaje" runat="server" BackgroundCssClass="modal-bg"
                TargetControlID="btnHidden" PopupControlID="modalPopUpmensaje" Drag="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

