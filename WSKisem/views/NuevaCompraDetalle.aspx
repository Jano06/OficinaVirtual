<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="NuevaCompraDetalle.aspx.cs" Inherits="views_NuevaCompraDetalle" %>
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
        .miniTabla
        {
            text-align: justify;
            font-family: Arial;
            font-size: medium;
            font-weight: normal;
            color: #333333;
            vertical-align: top;
            width: 820px;
            height: 300px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
            border-width:thin;
        }
        .Confirma
        {
            text-align: justify;
            font-family: Arial;
            font-size: medium;
            font-weight: normal;
            color: #333333;
            vertical-align: top;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
            border-style:solid;
            border-color:Silver;
            border-width:thin;
        }
        .izquierda
        {
            text-align: left;
        }
        .derecha
        {
            text-align: right;
        }
        .style1
        {
            height: 25px;    
        }
        .style2
        {
            height: 31px;
        }
        .style5
        {
            width: 120px;
        }
        .style6
        {
            width: 356px;
        }
        .style8
        {
            width: 161px;
        }
        .style10
        {
            height: 50px;
        }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <asp:Panel ID="pnlDatos" runat="server" >
        <table class="subtitulo">
            <tr>
                <td colspan="2" class="style2">
                    <asp:Label ID="lblTitulo" runat="server" Text="Verifica tus datos y selecciona el modo de entrega" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlId" runat="server" Text="Asociado:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblId" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlNombre" runat="server" Text="Nombre:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblNombre" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlDomicilio" runat="server" Text="Domicilio:" Font-Bold="true" />
                </td>
                <td class="style20">
                    <asp:Label ID="lblDomicilio" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlColonia" runat="server" Text="Colonia:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblColonia" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlCP" runat="server" Text="CP:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblCP" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlMpio" runat="server" Text="Municipio:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblMpio" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlEdo" runat="server" Text="Estado:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblEdo" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblTitlPago" runat="server" Text="Forma de Pago:" Font-Bold="true" />
                </td>
                <td>
                    <asp:Label ID="lblPago" runat="server" Text="DEPÓSITO BANCARIO" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblastEntrega" runat="server" Text="*" ForeColor="Red" />&nbsp;
                    <asp:Label ID="lblTitlEntrega" runat="server" Text="Entrega:"  Font-Bold="true"/>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEntrega" runat="server" >
                        <asp:ListItem Value="0" Text="Selecciona una opción" ></asp:ListItem>
                        <asp:ListItem Value="MOSTRADOR" Text="MOSTRADOR" ></asp:ListItem>
                        <asp:ListItem Value="DOMICILIO" Text="DOMICILIO" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td align="right" class="style1">
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:" Font-Bold="true" />
                </td>
                <td>
                    <asp:TextBox ID="txtObesrvac" runat="server" TextMode="MultiLine" Height="50px" 
                        Width="374px" style="resize: none;" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="style1">
                    <asp:Button ID="btnContinuar" runat="server" Text="Continuar" 
                        onclick="btnContinuar_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancelar1" runat="server" Text="Cancelar" 
                        onclick="btnCancelar1_Click" />
                    </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="pnlDetalleCompra" runat="server" Visible="false">
                        <asp:Table ID="tblDetalleCompra" runat="server" Width="809px">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="4" HorizontalAlign="Center">
                                    <asp:Label ID="lblDetalleCompra" runat="server" Text="Detalle de la compra" Font-Bold="true" />
                                </asp:TableCell></asp:TableRow><asp:TableRow>
                                <asp:TableCell Width="15%"></asp:TableCell><asp:TableCell Width="50%"></asp:TableCell><asp:TableCell Width="23%"></asp:TableCell><asp:TableCell Width="2%"></asp:TableCell><asp:TableCell Width="10%"></asp:TableCell></asp:TableRow><asp:TableRow BackColor="#084B8A" HorizontalAlign="Center">
                                <asp:TableCell>
                                    <asp:Label ID="lblTitlCantidad" runat="server" ForeColor="White" Text="Cantidad" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblTitlIzq" runat="server" ForeColor="White" Text="Paquete" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblTitlDer" runat="server" ForeColor="White" Text="Precio Unitario" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell ColumnSpan="2">
                                    <asp:Label ID="lblTitlMonto" runat="server" ForeColor="White" Text="Monto" Font-Bold="true" />
                                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
                                <asp:TableCell>
                                    <asp:Label ID="lblCantidad" runat="server" Text="1" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPaquete" runat="server" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPUnit" runat="server" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPrecioMonto" runat="server" Text="$" />
                                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblMonto" runat="server" />
                                </asp:TableCell></asp:TableRow><asp:TableRow ID="trEnvio" HorizontalAlign="Center">
                                <asp:TableCell>
                                    <asp:Label ID="lblCantEnvio" runat="server" Text="1" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblEnvio" runat="server" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPUnitEnvio" runat="server" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPrecioEnvio" runat="server" Text="$" />
                                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblTotalEnvio" runat="server" />
                                </asp:TableCell></asp:TableRow><asp:TableRow  HorizontalAlign="Center">
                                <asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblTitlSubTotal" runat="server" Text="Subtotal:" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPrecioSubTotal" runat="server" Text="$" />
                                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblSubTotal" runat="server" />
                                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
                                <asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblTitlIva" runat="server" Text="IVA:" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="lblPrecioIva" runat="server" Text="$" />
                                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblIva" runat="server" />
                                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Center">
                                <asp:TableCell></asp:TableCell><asp:TableCell></asp:TableCell><asp:TableCell  HorizontalAlign="Right">
                                    <asp:Label ID="lblTitlTotal" runat="server" Text="Total:" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell>
                                    <asp:Label ID="Label1" runat="server" Text="$" Font-Bold="true" />
                                </asp:TableCell><asp:TableCell HorizontalAlign="Right">
                                    <asp:Label ID="lblTotal" runat="server" Font-Bold="true" />
                                </asp:TableCell></asp:TableRow></asp:Table><asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" onclick="btnConfirmar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnCancelar2" runat="server" Text="Regresar" onclick="btnCancelar2_Click" />
                </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlConfirma" runat="server" Visible="false">
        <asp:Table ID="tblConfirma" runat="server" Width="814px" CssClass="Confirma">
            <asp:TableRow>
                <asp:TableCell></asp:TableCell></asp:TableRow><asp:TableRow  HorizontalAlign="Center">
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTitlConfirma" runat="server" Text="¿Qué desea hacer con su compra?" Font-Bold="true" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell Width="300px"></asp:TableCell><asp:TableCell>
                    <asp:RadioButtonList ID="rbtnTipoCompra" runat="server" RepeatLayout="Flow">
                        <asp:ListItem Value="Excedente" Text="Compra Excedente" />
                        <asp:ListItem Value="Activacion" Text="Activarse Siguiente Periodo" />
                    </asp:RadioButtonList>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button ID="btnTipoCompra" runat="server" Text="Confirmar" OnClick="btnTipoCompra_Click" />&nbsp;&nbsp;&nbsp;
                </asp:TableCell></asp:TableRow></asp:Table></asp:Panel></asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="ContenidoPopUps" runat="server">
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
                                <asp:TableCell ColumnSpan="3"></asp:TableCell></asp:TableRow><asp:TableRow Height="30px">
                                <asp:TableCell ID="cellmensaje" runat="server" ForeColor="Red"> </asp:TableCell></asp:TableRow></asp:Table></div><div class="popUpFooter">
                        <asp:Button ID="btnAceptarPop" runat="server" CssClass="botonColor" Text="Aceptar" OnClick="click_btnPopUpAceptar" />
                    </div>
                </div>
            </asp:Panel>
            <AjaxControlToolkit:ModalPopupExtender ID="modalMensaje" runat="server" BackgroundCssClass="modal-bg"
                TargetControlID="btnHidden" PopupControlID="modalPopUpmensaje" Drag="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>