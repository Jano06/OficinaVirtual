<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="misPagos.aspx.cs" Inherits="views_misPagos" %>

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
            vertical-align:top;
            width: 820px;
            height: 500px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
            border-style:solid;
            border-color:Silver;
            border-width:thin;
        }
        .detalleBono
        {
            text-align: justify;
            font-family: Arial;
            font-size: medium;
            font-weight: normal;
            color: Black;
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
            height: 30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <asp:Panel ID="pnlDetalle" runat="server">
        <table id="tblGananciasDetalle" class="subtitulo">
            <tr>
                <td class="style1">
                    <asp:Label ID="lblTitlCorte" runat="server" Text="CORTE: " Font-Bold="true" />
                    <asp:Label ID="lblCorte" runat="server" Font-Bold="false" />&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTitlPeriodo" runat="server" Text="PERIODO: " Font-Bold="true" />
                    <asp:Label ID="lblPeriodo" runat="server" Font-Bold="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <table class="subtitulo" style="border-style:none">
                        <tr style="background-color:#084B8A">
                            <td style="width: 60%;" >
                                <asp:Label ID="lblTitlBono" runat="server" ForeColor="White" Text="Bono" />
                            </td>
                            <td align="center" style="width: 40%;">
                                <asp:Label ID="lblTitlGanancias" runat="server" ForeColor="White" Text="Ganancias" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlExcedente" runat="server" Text="Bono Excedente" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnExcedente" runat="server" 
                                    onclick="lnkBtnExcedente_Click" />
                                <asp:Label ID="lblExcedente" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTitlInscrip" runat="server" Text="Bono Inscripción" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnInscripcion" runat="server" 
                                    onclick="lnkBtnInscripcion_Click" />
                                <asp:Label ID="lblInscripcion" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlInfinito" runat="server" Text="Bono Inscripción Infinito" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnInfinito" runat="server" 
                                    onclick="lnkBtnInfinito_Click" />
                                <asp:Label ID="lblInfinito" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTitlIgualacion" runat="server" Text="Bono Igualación de Volumen" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnIgualacion" runat="server" 
                                    onclick="lnkBtnIgualacion_Click" />
                                <asp:Label ID="lblIgualacion" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlSeguimiento" runat="server" Text="Bono Seguimiento" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnSeguimiento" runat="server" OnClick="lnkBtnSeguimiento_Click" />
                                <asp:Label ID="lblSeguimiento" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTitlBienestar" runat="server" Text="Bono Bienestar" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnBienestar" runat="server" 
                                    onclick="lnkBtnBienestar_Click" />
                                <asp:Label ID="lblBienestar" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlGuia" runat="server" Text="Bono Guía" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnGuia" runat="server" onclick="lnkBtnGuia_Click" />
                                <asp:Label ID="lblGuia" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTitlRed" runat="server" Text="Bono Desarrollo de Red" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnRed" runat="server" onclick="lnkBtnRed_Click" />
                                <asp:Label ID="lblRed" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlNiveles" runat="server" Text="Bono Desarrollo Redes por Niveles" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnNiveles" runat="server" 
                                    onclick="lnkBtnNiveles_Click" />
                                <asp:Label ID="lblNiveles" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTitlRango" runat="server" Text="Bono Avance por Rango" />
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="lnkBtnRango" runat="server" />
                                <asp:Label ID="lblRango" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlSubtotal" runat="server" Text="Subtotal" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSubtotal" runat="server" />
                            </td>
                        </tr>
                        <tr style="background-color: #084B8A;">
                            <td colspan="2">
                                <asp:Label ID="lblTitlImpuestos" runat="server" ForeColor="White" Text="Impuestos" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlIsr" runat="server" Text="Retención ISR" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblIsr" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTitlIva" runat="server" Text="Retención IVA" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblIva" runat="server" Font-Bold="false" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td>
                                <asp:Label ID="lblTitlTotal" runat="server" Text="Total" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTotal" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div style="text-align:center">
            <asp:Button ID="Button1" runat="server" Text="Regresar" 
                        onclick="btnRegresar_Click" />
        </div>
    </asp:Panel>       
    <asp:Panel ID="pnlDetalleBono4" runat="server" Visible="false">
        <table class="detalleBono">
            <tr>
                <td style="text-align: center; font-family: Arial; font-size:x-large; font-weight: bold; color: #2B5076; vertical-align: top; ">
                    <asp:Label ID="Label1" runat="server" Text="Detalle Bono Igualación de Volumen" /><br />
                    <asp:Label ID="lblTitlPorcentaje" runat="server" Text="Pagado al: " />
                    <asp:Label ID="lblPorcentaje" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <table style="font-family: Arial; font-size: medium; color: Black; vertical-align: top; margin-top: 0px; background-position: bottom;
                        background-repeat: no-repeat; border-style: solid; border-color: Silver; border-width: thin;" width="100%">
                        <tr style="background-color:#084B8A">
                            <td align="center" style="width: 40%">
                                <asp:Label ID="lblTitlDescr" runat="server" ForeColor="White" Text="Descripción" Font-Bold="true" />
                            </td>
                            <td align="center" style="width: 30%">
                                <asp:Label ID="lblTitlIzq" runat="server" ForeColor="White" Text="Izquierdos" Font-Bold="true" />
                            </td>
                            <td align="center" style="width: 30%">
                                <asp:Label ID="lblTitlDer" runat="server" ForeColor="White" Text="Derechos" Font-Bold="true" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td align="center">
                                <asp:Label ID="lblIniciales" runat="server" Text="Puntos Iniciales" Font-Bold="true" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblInicIzq" runat="server"/>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblInicDer" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblNuevos" runat="server" Text="Puntos Nuevos" Font-Bold="true" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNvosIzq" runat="server"/>
                                <asp:LinkButton ID="lnkBtnNvosIzq" runat="server" 
                                    onclick="lnkBtnNvosIzq_Click" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNvosDer" runat="server" />
                                <asp:LinkButton ID="lnkBtnNvosDer" runat="server" 
                                    onclick="lnkBtnNvosDer_Click" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td align="center">
                                <asp:Label ID="Label2" runat="server" Text="Subtotal Puntos" Font-Bold="true" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSubIzq" runat="server"/>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblSubDer" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblPagados" runat="server" Text="Puntos Pagados" Font-Bold="true" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblPagIzq" runat="server"/>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblPagDer" runat="server" />
                            </td>
                        </tr>
                        <tr style="background-color: #D8D8D8;">
                            <td align="center">
                                <asp:Label ID="lblFinales" runat="server" Text="Puntos Finales" Font-Bold="true" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblFinIzq" runat="server"/>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblFinDer" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:Button ID="btnRegresaBono4" runat="server" Text="Regresar" OnClick="btnRegresarPagos_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPopUps" runat="server">
    <asp:UpdatePanel ID="pnlPooUp" runat="server">
        <ContentTemplate>
            <div style="visibility: hidden">
                <asp:Button runat="server" ID="btnHidden" />
            </div>
            <asp:Panel runat="server" ID="modalPopUpmensaje" CssClass="modalPagos" Width="900px" Height="600px"
                Style="display: none;">
                <div class="popUpMainPagos">
                    <div class="popUpTitle">
                        <asp:Label ID="lblTituloBono" runat="server" Font-Bold="true" ForeColor= "#434753" />
                    </div>
                    <div class="popUpFooter">
                        <asp:Button ID="btnAceptarPop" runat="server" CssClass="botonColor" Text="Aceptar" OnClick="click_btnPopUpAceptar" />
                    </div>
                    <div class="popUpContentPagos">
                        <asp:Table ID="Table1" runat="server" Width="800px">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3">
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow HorizontalAlign="Center">
                                <asp:TableCell ID="cellmensaje" runat="server" ColumnSpan="3">
                                    <asp:GridView ID="gvdBono1" Visible="false" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Compra" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdCompra" runat="server" Text ='<%#Eval("Compra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonto" runat="server" Text ='<%#Eval("Monto")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono2" Visible="false" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Orden" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrden" runat="server" Text ='<%#Eval("Orden")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono3" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Inscripc" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaInsc" runat="server" Text ='<%#Eval("FechaInsc")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Orden" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrden" runat="server" Text ='<%#Eval("Orden")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Patrocinador" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPatrocinador" runat="server" Text ='<%#Eval("Patrocinador")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono4" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Compra" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompra" runat="server" Text ='<%#Eval("Compra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Volumen" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVolumen" runat="server" Text ='<%#Eval("Volumen")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono5" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px" >
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true" >
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("IdAsociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonto" runat="server" Text ='<%#Eval("Monto")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono6" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Compra" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompra" runat="server" Text ='<%#Eval("Compra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonto" runat="server" Text ='<%#Eval("Monto")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono7" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Compra" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompra" runat="server" Text ='<%#Eval("Compra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonto" runat="server" Text ='<%#Eval("Monto")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono8" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Compra" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompra" runat="server" Text ='<%#Eval("Compra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Monto" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMonto" runat="server" Text ='<%#Eval("Monto")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdBono11" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
                                        ForeColor="#333333" GridLines="None" BorderWidth="0" BorderColor="#808080"
                                        BorderStyle="Ridge" RowStyle-BorderStyle="None" AllowSorting="false"
                                        CellPadding="4" Width="700px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Compra" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblCompra" runat="server" Text ='<%#Eval("Compra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAsociado" runat="server" Text ='<%#Eval("Asociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFecha" runat="server" Text ='<%#Eval("Fecha")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Puntos" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPuntos" runat="server" Text ='<%#Eval("Puntos")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nivel" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNivel" runat="server" Text ='<%#Eval("Nivel")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ganancia" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGanancia" runat="server" Text ='<%#Eval("Ganancia")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
            </asp:Panel>
            <AjaxControlToolkit:ModalPopupExtender ID="modalMensaje" runat="server" BackgroundCssClass="modal-bg"
                TargetControlID="btnHidden" PopupControlID="modalPopUpmensaje" Drag="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>