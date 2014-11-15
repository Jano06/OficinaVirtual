<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="Principal.aspx.cs" Inherits="views_Inicio_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <style type="text/css">
        .title
        {
        	position: relative;
        	height: 50px;
        	font-size: 20px;
        	font-weight: bold;
        	color: #2D96FF;
        	text-align: center;
        }
        .textogrid
        {
            text-align:center;
            font-family:Arial;
            font-size:smaller;
            color:black;
            vertical-align:bottom;
            margin-left: 13px;
        }
        
        .titulobienvenidacentrado
        {
            text-align:center;
            font-family:AvantGarde LT Book;
            font-size:x-large;
            font-weight:bold;
            color:#2b5076;
            vertical-align:top;
        }
        .subtitulo
        {
            text-align:justify;
            font-family:Arial;
            font-size:medium;
            font-weight:bold;
            color:Black;
            vertical-align:top;
            width: 820px;
            height: 556px;
            margin-top: 0px;
            background-position: bottom; 
            background-repeat: no-repeat;
        }
        #tblInfo
        {
            height: 537px;
            width: 823px;
        }
        .style29
        {
            height: 31px;
        }
        .style31
        {
            height: 74px;
        }
        .style33
        {
            height: 74px;
            width: 55px;
        }
        .style42
        {
            height: 32px;
        }
        .style44
        {
            width: 13px;
        }
        .style45
        {
            width: 6px;
        }
        .style50
        {
            height: 19px;
            width: 483px;
        }
        .style51
        {
            height: 130px;
        }
        .style52
        {
            width: 160px;
        }
        .style53
        {
            width: 195px;
        }
        .style54
        {
            height: 20px;
        }
        .style56
        {
            height: 21px;
        }
        .style57
        {
            height: 12px;
        }
        .style59
        {
            width: 419px;
        }
        .style63
        {
            height: 122px;
        }
        .style64
        {
            height: 122px;
            width: 55px;
        }
        .style65
        {
            height: 99px;
            width: 55px;
        }
        .style68
        {
            width: 84px;
        }
        .style69
        {
            width: auto;
            height: 35px;
        }
        .style70
        {
            width: 57px;
        }
        .style74
        {
            height: 5px;
            width: 84px;
        }
        .style75
        {
            height: 5px;
            width: 45px;
        }
        .style76
        {
            height: 5px;
        }
        .style77
        {
            height: 9px;
            width: 84px;
        }
        .style79
        {
            height: 9px;
        }
        .style80
        {
            height: 4px;
        }
        .style81
        {
            height: 9px;
            width: 45px;
        }
        </style>
    <link rel="stylesheet" href="../../Style/StyleKisem.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <asp:Panel ID="pnlBotones" runat="server">
        <asp:table ID="tblBotones" runat= "server" height= "60px" width= "820px">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:ImageButton ID="infoPcpal" runat="server" ImageUrl="~/Imagenes/Barras/barra-inicio_01.jpg" OnClick="click_InfoPrincipal" />
                    <asp:ImageButton ID="proxCompra" runat="server" ImageUrl="~/Imagenes/Barras/barra-inicio_02.jpg" OnClick="click_ProxCompra" />
                    <asp:ImageButton ID="organizac" runat="server" ImageUrl="~/Imagenes/Barras/barra-inicio_03.jpg" OnClick="click_MiOrganizacion"/>
                    <asp:ImageButton ID="logros" runat="server" ImageUrl="~/Imagenes/Barras/barra-inicio_04.jpg" OnClick="click_Logros" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:table>
    </asp:Panel>
    <%--<asp:Panel ID="pnlAvisos" runat="server" Height="556px" Width="820px">
        <asp:Table ID="tblInicio" runat="server" Height="556px" Width="820px">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:ImageMap ID="avisosOportunos" runat="server" ImageUrl="~/Imagenes/Avisos/AvisoOportuno.jpg">
                        <asp:RectangleHotSpot AlternateText="Descarga Manual Empresarial" Bottom="392" HotSpotMode="Navigate" Left="280"
                                NavigateUrl="~/Documents/Manual_Empresarial.pdf" Right="392" Top="264" Target="_blank" />
                        <asp:RectangleHotSpot AlternateText="Descarga Manual Empresarial" Bottom="392" HotSpotMode="Navigate" Left="292"
                                NavigateUrl="~/Documents/Triptico_X-tracel.pdf" Right="520" Top="264" Target="_blank" />    
                    </asp:ImageMap> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>--%>
    <asp:Panel ID="pnlInformacion" runat="server" Height="556px" Width="820px">
        <table id="tblInformacion" cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-image: url('../../Imagenes/Fondos/infoprincipal.jpg'); background-position:bottom; background-repeat:no-repeat;">
                    <table class="subtitulo">
                        <tr>
                            <td class="style5">
                            </td><td class="style44" colspan="3" align="center">
                                <img runat="server" alt="" src="~/Imagenes/Letreros/Bienvenida.png" style="height: 30px; width: 762px; " />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td class="style5">
                            </td>
                            <td class="style50">
                                &nbsp;<asp:Label ID="lblNombreAsociado" runat="server" />
                            </td>
                            <td class="style13" colspan="2">
                                Número de Socio: 
                                <asp:Label ID="lblIdAsociado" runat="server" />
                            </td>
                        </tr>
                         <tr>
                            <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td class="style51" colspan="4" align="center" style="font-family: Arial; font-size: large;" >
                                Te invitamos a conocer las herramientas con las que cuentas para seguir 
                                el desarrollo de tu negocio.
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <table style="width: 503px; margin-top: 0px; height: 281px;" >
                                    <tr>
                                        <td colspan="2" valign="bottom" class="style45">
                                            <img alt="" src="../../Imagenes/Letreros/Importancia.png"
                                                style="width: 334px; height: 71px " />
                                        </td>
                                        <td class="style26">
                                            <asp:Image ID="imgRangoMax" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="style52" valign="bottom">
                                            Rango Actual:
                                        </td>
                                        <td class="style53" valign="bottom">
                                            <asp:Label ID="lblRangoActual" runat="server" />
                                        </td>
                                        <td class="style26" rowspan="2">
                                            <asp:Image ID="imgRangoActual" runat="server" />
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="style52" valign="middle">
                                            Máximo Rango Alcanzado: </td>
                                        <td class="style53" valign="middle">
                                            <asp:Label ID="lblRangoMaximo" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style52">
                                            Tu Patrocinador es: </td>
                                        <td class="style24" colspan="2">
                                            <asp:Label ID="lblPatrocinador" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style52">
                                            Tu Status es: &nbsp;</td>
                                        <td class="style23" colspan="2">
                                            <asp:Label ID="lblEstado" runat="server" />&nbsp;
                                            <asp:Label ID="lblInactividad" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlCompras" runat="server" Height="556px" Width="820px" Visible="false">
        <table id="tblCompras" cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-image: url('../../Imagenes/Fondos/proxCompra.jpg'); background-position:bottom; background-repeat:no-repeat;">
                    <table class="subtitulo">
                        <tr>
                            <td align="center" colspan="2" class="style69">
                                PRÓXIMA COMPRA
                            </td>
                        </tr>
                        <tr>
                            <td class="style54" colspan="2"></td>
                        </tr>
                        <tr>
                        <td class="style70"></td>
                            <td class="style11" colspan="2">Día de Calificación:
                                <asp:Label ID="lblCalificacion" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style56" colspan="2"></td>
                        </tr>
                        <tr>
                        <td class="style70"></td>
                            <td class="style13" colspan="2">Periodo Correspondiente: Del
                                <asp:Label ID="lblPeriodoDe" runat="server" />&nbsp;al
                                <asp:Label ID="lblPeriodoHasta" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style56"></td>
                        </tr>
                        <tr>
                            <td class="style70"></td>
                            <td class="style22">
                                <asp:Calendar ID="CalendCompras" DayNameFormat="Short" runat="server" 
                                    Width="312px" SelectionMode="None" FirstDayOfWeek="Saturday" 
                                    OtherMonthDayStyle-ForeColor="Gray" NextMonthText="" PrevMonthText="" >
                                    <DayHeaderStyle ForeColor="#ff0000" />
                                    <TodayDayStyle BackColor="#58ACFA" />
                                    <SelectedDayStyle BackColor="#0000FF" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" colspan="2"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlMiOrganizacion" runat="server"  Height="556px" Width="820px" Visible="false">
        <table id="tblMiOrganizacion" cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-image: url('../../Imagenes/Fondos/miorganizacion.jpg'); background-position:bottom; background-repeat:no-repeat;">
                    <table class="subtitulo">
                        <tr>
                            <td align="center" colspan="3" class="style80">
                                MI ORGANIZACIÓN
                            </td>
                        </tr>
                        <tr>
                            <td class="style57" colspan="3"></td>
                        </tr>
                        <tr>
                        <td class="style74"></td>
                            <td class="style75">
                                <asp:Label ID="lblPatrocinIzq" runat="server" Text="0" />
                                </td>
                            <td class="style76">
                                Invitados Directos activos de lado Izquierdo
                            </td>
                        </tr>
                        <tr>
                            <td class="style77"></td>
                            <td class="style81">
                                <asp:Label ID="lblPatrocinDer" runat="server" Text="0" /> 
                                </td>
                            <td class="style79">
                                Invitados Directos activos de lado Derecho
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="style77"></td>
                            <td class="style81">
                                <asp:Label ID="lblAsocIzq" runat="server" Text="0" /> 
                                </td>
                            <td class="style79">
                                Asociados en Binario activos de lado Izquierdo
                            </td>
                        </tr>
                        <tr>
                            <td class="style77"></td>
                            <td class="style81">
                                <asp:Label ID="lblAsocDer" runat="server" Text="0" /> 
                                </td>
                            <td class="style79">
                                Asociados en Binario activos de lado Derecho
                            </td>
                        </tr>
                        <tr>
                            <td class="style68"></td>
                            <td class="style42" colspan="2">
                                <asp:UpdatePanel ID="UpDateTimer1" runat="server">
                                    <ContentTemplate>
                                        <asp:Timer ID="timer1" runat="server" Interval="1000" ontick="timer1_Tick1" />Faltan:
                                        <asp:Label ID="lblDias" runat="server" />&nbsp;Dia(s),<br />
                                        <asp:Label ID="lblHoras" runat="server" />&nbsp;Hora(s)
                                        <asp:Label ID="lblMinutos" runat="server" />&nbsp;Minuto(s)<br />&nbsp;para cierre semanal.
                                        <!--<asp:Label ID="lblSegundos" runat="server" />&nbsp;Segundo(s)-->
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlLogros" runat="server"  Height="556px" Width="820px" Visible="false">
        <table id="tblLogros" cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-image: url('../../Imagenes/Fondos/misLogros.jpg'); background-position:bottom; background-repeat:no-repeat;">
                    &nbsp;<table class="subtitulo">
                        <tr>
                            <td colspan="2" align="center" class="style29">MIS LOGROS ALCANZADOS</td>
                        </tr>
                        <tr>
                            <td class="style33"></td>
                            <td class="style31">
                                <asp:UpdatePanel ID="UpdateTimer2" runat="server">
                                    <ContentTemplate>
                                        <asp:Timer ID="timer2" runat="server" Interval="1000" ontick="timer2_Tick" />Faltan:&nbsp;
                                        <asp:Label ID="lblDiasCiclo" runat="server" />&nbsp;días,&nbsp;
                                        <asp:Label ID="lblHorasCiclo" runat="server" />&nbsp;horas,&nbsp;<br />
                                        <asp:Label ID="lblMinutosCiclo" runat="server" />&nbsp;minutos,&nbsp;
                                        <asp:Label ID="lblSegundosCiclo" runat="server" />&nbsp;segundos<br /> para el cierre del ciclo de calificación
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style64"></td>
                            <td class="style63">
                                <table>
                                    <tr>
                                        <td valign="top" class="style59">
                                            <table style="border: thin solid Silver; font-family: Arial; font-size: medium; color: Black; vertical-align: top; margin-top: 0px; background-position: 50% bottom;
                                        background-repeat: no-repeat; width: 100%;">
                                                <tr style="background-color:#084B8A">
                                                    <td align="center" style="width: 70%;"></td>
                                                    <td align="center" style="width: 30%;">
                                                        <asp:Label ID="lblTitlPtos" runat="server" ForeColor="White" Text="Total" Font-Bold="true" />
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #D8D8D8;">
                                                    <td align="center"">
                                                        <asp:Label ID="lblTitlPtsIzq" runat="server" Text="Puntos Izquierdos" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblPtsIzq" runat="server"/>
                                                        <asp:LinkButton ID="lnkPtsIzq" runat="server" OnClick="lnkPtsIzq_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblTitlPtsDer" runat="server" Text="Puntos Derechos" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblPtsDer" runat="server"/>
                                                        <asp:LinkButton ID="lnkPtsDer" runat="server" OnClick="lnkPtsDer_Click"/>
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #D8D8D8;">
                                                    <td align="center">
                                                        <asp:Label ID="lblTitlPtsTotales" runat="server" Text="Puntos Totales" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblPtsTotales" runat="server"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblTitlEmprIzq" runat="server" Text="Empresarios/Emprendedores Izquierdos" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblEmprIzq" runat="server" />
                                                        <asp:LinkButton ID="lnkEmprIzq" runat="server" OnClick="lnkEmprIzq_Clik" />
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #D8D8D8;">
                                                    <td align="center">
                                                        <asp:Label ID="lblTitlEmprDer" runat="server" Text="Empresarios/Emprendedores Derechos" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblEmprDer" runat="server" />
                                                        <asp:LinkButton ID="lnkEmprDer" runat="server" OnClick="lnkEmprDer_Clik" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblTitlInactIzq" runat="server" Text="Inactivos Izquierdos" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblInactIzq" runat="server" />
                                                        <asp:LinkButton ID="lnkInactIzq" runat="server" OnClick="lnkInactIzq_Clik" />
                                                    </td>
                                                </tr>
                                                <tr style="background-color: #D8D8D8;">
                                                    <td align="center">
                                                        <asp:Label ID="lblTitlInactDer" runat="server" Text="Inactivos Derechos" Font-Bold="true" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="lblInactDer" runat="server" />
                                                        <asp:LinkButton ID="lnkInactDer" runat="server" OnClick="lnkInactDer_Clik" />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style65"></td>
                            <td class="style36">
                                <asp:Label ID="lblRango" runat="server" Text="REQUISITOS PARA ALCANZAR SIGUIENTE RANGO" Font-Bold="true" />
                                <br />
                                <asp:Label ID="lblTitlSigRango" runat="server" Text="Siguiente Rango: " Font-Bold="true" />
                                <asp:Label ID="lblSigRango" runat="server" Font-Bold="true" />
                                <br />
                                <asp:Label ID="lblEmprendedoresLado" runat="server" Font-Bold="true" />
                                <br />
                                <asp:Label ID="lblActivosLado" runat="server" Font-Bold="true" />
                                <br />
                                <asp:Label ID="lblpuntajeOrganiz" runat="server" Font-Bold="true" />
                                <br />
                                <asp:Label ID="lblactivosOrganiz" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                    </table>
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
                                    <asp:GridView ID="gvdDetalleLogros" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
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
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("IdAsociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Inicio Activación" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIniActiva" runat="server" Text ='<%#Eval("InicioActivacion")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fin Activación" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFinActiva" runat="server" Text ='<%#Eval("FinActivacion")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Puntos" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPuntos" runat="server" Text ='<%#Eval("ptosMes")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="gvdDetallePuntos" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay información a mostrar."
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
                                            <asp:TemplateField HeaderText="Asociado" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate >
                                                    <asp:Label ID="lblIdAsociado" runat="server" Text ='<%#Eval("IdAsociado")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombre" runat="server" Text ='<%#Eval("Nombre")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Órden" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdCompra" runat="server" Text ='<%#Eval("IdCompra")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha Pago" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaPago" runat="server" Text ='<%#Eval("FechaPago")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Puntos" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPuntos" runat="server" Text ='<%#Eval("Puntos")%>'></asp:Label>
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