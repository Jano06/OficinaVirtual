<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="ArbolColocacion.aspx.cs" Inherits="views_ArbolColocacion" %>
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
        .posicion2
        {
	        width:100px; 
	        height:100px; 
	        background-color:#fff; 
	        float:right;
	        text-align:center;
	        vertical-align:bottom;
	    }
        .posicion3
        {
	        width:100px; 
	        height:100px; 
	        background-color:#fff; 
	        float:left;
	        text-align:center;
	        vertical-align:bottom;
        }
        .textonuevo
        {
            text-align:right;
            font-family:Arial;
            font-size:medium;
            font-weight:bold;
            color:Gray;
            vertical-align:top;
        }
        .topecentro
        {
	         width:300px; 
	         height:150px; 
	         background-color:#fff; 
	         float:left; 
	         text-align:center;
	         vertical-align:bottom;
        }
        .topeizq
        {
	         width:250px; 
	         height:100px; 
	         background-color: #fff; 
	         float: left;
	         text-align: left;
	         vertical-align: bottom;
	    }
        .topeder
        {
	         width:250px; 
	         height:100px; 
	         background-color:#fff; 
	         float:right;
	         text-align:right;
	         vertical-align:bottom;
        }
        .topecentro1
        {
	         width:300px; 
	         height:150px; 
	         background-color:#fff; 
	         float:left; 
	         text-align:center;
	         vertical-align:bottom;
        }
        .topeizq1 
        {
	        width:250px; 
	        height:150px; 
	        background-color:#fff; 
	        float:left;
	        vertical-align:bottom;
        }
        .topeder1
        {
	         width:250px; 
	         height:150px; 
	         background-color:#fff; 
	         float:right;
	         text-align:right;
	         vertical-align:bottom;
        }
        .renglon1
        {
	        width:800px; 
	        height:150px; 
	        background-color:#fff;
	        vertical-align:bottom;
	
        }
        .renglon
        {
	        width:800px; 
	        height:100px; 
	        background-color:#fff;
	        vertical-align:bottom;
	    }
        .doble
        {
	        width:100px;
	        background-color:#fff;
	        border:#fff;
	        float:left;
	        text-align:center;
	        height:100px;
	        vertical-align:bottom;
        }
        .doblemitad
        {
	        width:50px;
	        background-color:#fff;
	        border:#fff;
	        float:left;
	        text-align:center;
	        height:100px;
	        vertical-align:bottom;
        }
        .individual
        {
	        width:50px;
	        background-color:#fff;
	        border:#fff;
	        float:left;
	        text-align:center;
	        height:100px;
	        vertical-align:bottom;
	    }
        .individualcorto
        {
	        width:50px;
	        background-color:#fff;
	        border:#fff;
	        float:left;
	        text-align:center;
	        height:100px;
	        vertical-align:bottom;
        }
        .individualmitadcorto
        {
	        width:25px;
	        background-color:#fff;
	        border:#fff;
	        float:left;
	        text-align:center;
	        height:100px;
	        vertical-align:bottom;
        }
        .individualmitad
        {
	        width:25px;
	        background-color:#fff;
	        border:#fff;
	        float:left;
	        text-align:center;
	        height:100px;
	        vertical-align:bottom;
        }
        .celdaMarco
        {
            border-style:solid;
            border-color:Silver;
            border-width:thin;
        }
        .textochico
        {
            text-align:justify;
            font-family:Arial;
            font-size:x-small;
            color:black;
            vertical-align:bottom;
        }
        .style1
        {
            width: 825px;
        }
        .style2
        {
            width: 100%;
            height: 100%;
        }
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 439px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <table class="style1">
        <tr>
            <td align="center">
                <asp:Panel ID="PnlNuevo" runat="server" Visible="false">
                    <asp:Label ID="lblMnsaje" runat="server" CssClass="titulobienvenida" Text="Ubica la posición donde colocaras tu prospecto, haciendo click en " /> <br />
                    <asp:Image ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/Rangos/0.png" Width="30px" Height="50px" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="celdaMarco">
                <table style="height: 775px; width: 98%" >
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Image ID="imgTituloRango" runat="server" ImageUrl="~/Imagenes/Arbol/rangostitulo.png" Width="321px" Height="35px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" />
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Image ID="imgRangos" runat="server" 
                                ImageUrl="~/Imagenes/Rangos/lineaderangos.png"/>
                        </td>
                    </tr>
                    <tr>
                        <td />
                        <td />
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <table width="825px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div class="renglon1">
                                            <div class="topeizq1">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="imgLetreroPtsIzq" runat="server" ImageUrl="~/Imagenes/Arbol/puntosizquierdos.png" Width="240px" Height="35" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblPuntosIzq" runat="server" CssClass="titulobienvenida" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="topecentro">
                                                <asp:ImageButton ID="imgBtn0" runat="server" ImageUrl="~/Imagenes/Rangos/1.png" /><br />
                                                <asp:Label ID="lblAlias0" Width="40px" runat="server" Font-Size="X-Small" Text="ALI000" />
                                            </div>
                                            <div class="topeder1">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="imgTituloPtsDerechos" runat="server" ImageUrl="~/Imagenes/Arbol/puntosderechos.png" Width="240px" Height="35" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblPuntosDer" runat="server" CssClass="titulobienvenida" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="renglon">
                                            <div class="topeizq">
                                                <div class="posicion2">
                                                    <table cellpadding="0" cellspacing="0" class="style2" >
                                                        <tr>
                                                            <td valign="bottom" style="background:url('imagenes/arbol/Rangos/lineader.jpg');">
                                                                <asp:ImageButton ID="imgBtn1" runat="server" ImageUrl="~/Imagenes/arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                                <br />
                                                                <asp:Label ID="lblAlias1" runat="server" Font-Size="X-Small" Width="40px" Text="ALI000" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:ImageButton ID="imgFondoIzq" runat="server" 
                                                    ImageUrl="~/Imagenes/Arbol/fondoizq.png" ToolTip="Ir al Fondo de la Izquierda" 
                                                    onclick="imgFondoIzq_Click" />
                                            </div>
                                            <div class="topecentro">
                                                <img alt="" src="../Imagenes/Arbol/Rangos/r1.jpg" style="width: 300px; height: 100px" />
                                            </div>
                                            <div class="topeder">
                                                <div class="posicion3">
                                                    <table cellpadding="0" cellspacing="0" class="style2">
                                                        <tr>
                                                            <td valign="bottom" style="background-image:url('Imagenes/Arbol/Rangos/lineaizq.jpg'); background-repeat: no-repeat;" >
                                                                <asp:ImageButton ID="imgBtn2" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                                <br />
                                                                <asp:Label ID="lblAlias2" runat="server" Font-Size="X-Small" Width="40px" Text="ALI000" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:ImageButton ID="imgFondoDer" runat="server" 
                                                    ImageUrl="~/Imagenes/Arbol/fondoder.png" ToolTip="Ir al Fondo de la Derecha" 
                                                    onclick="imgFondoDer_Click" />
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="renglon">
                                            <div class="doblemitad"></div>
                                            <div class="doble">
                                                <table cellpadding="0" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td valign="bottom" style="background-image: url('Imagenes/Arbol/lineader.jpg'); background-repeat:no-repeat">
                                                            <asp:ImageButton ID="imgBtn3" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias3" runat="server" Width="40px" Text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="doble">
                                                <img alt="" src="../Imagenes/Arbol/Rangos/r2.jpg" style="width: 100px" />
                                            </div>
                                            <div class="doble">
                                                <table cellpadding="0" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td valign="bottom" style="background-image:url('Imagenes/Arbol/lineader.jpg'); background-repeat:no-repeat;">
                                                            <asp:ImageButton ID="imgBtn4" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias4" runat="server" Width="40px" Text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="doble"></div>
                                            <div class="doble">
                                                <table cellpadding="0" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td valign="bottom" style="background-image:url('Imagenes/Arbol/lineader.jpg'); background-repeat:no-repeat;">
                                                            <asp:ImageButton ID="imgBtn5" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias5" runat="server" Width="40px" Text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="doble">
                                                <img alt="" src="../Imagenes/Arbol/Rangos/r2.jpg" style="width:100px; height:100px" />
                                            </div>
                                            <div class="doble">
                                                <table cellpadding="0" cellspacing="0" class="style2">
                                                    <tr>
                                                        <td valign="bottom" style="background-image:url('Imagenes/Arbol/lineaizq.jpg'); background-repeat:no-repeat;">
                                                            <asp:ImageButton ID="imgBtn6" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias6" runat="server" Width="40px" Text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="doblemitad"></div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="renglon">
        	                                <div class="individualmitadcorto"></div>
                                            <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn7" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias7" width="40px" text="ALI000" Font-Size="X-Small" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto">
                                            <img alt="" src="../Imagenes/Arbol/Rangos/r3.jpg" style="width: 50px; height: 100px" />
                                        </div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn8" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias8" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto"></div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn9" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias9" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto">
                                            <img alt="" src="../Imagenes/Arbol/Rangos/r3.jpg" style="width: 50px; height: 100px" />
                                        </div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn10" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias10" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto"></div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn11" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias11" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto">
                                            <img alt="" src="../Imagenes/Arbol/Rangos/r3.jpg" style="width: 50px; height: 100px" />
                                        </div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn12" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias12" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto"></div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn13" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias13" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualcorto">
                                            <img alt="" src="../Imagenes/Arbol/Rangos/r3.jpg" style="width: 50px; height: 100px" />
                                        </div>
                                        <div class="individualcorto">
                                            <table cellpadding="0" cellspacing="0" class="style2">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:ImageButton ID="imgBtn14" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                        <br />
                                                        <asp:Label ID="lblAlias14" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="individualmitadcorto"></div>
                                    </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="renglon">
        	                                <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn15" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias15" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I1" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D1" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn16" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias16" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I2" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D2" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn17" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias17" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I3" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D3" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn18" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias18" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I4" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D4" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn19" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias19" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I5" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D5" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn20" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias20" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I6" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D6" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn21" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias21" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I7" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D7" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn22" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias22" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I8" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D8" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn23" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias23" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I9" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D9" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn24" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias24" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I10" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D10" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn25" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias25" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I11" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D11" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn26" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias26" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I12" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D12" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn27" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias27" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I13" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D13" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn28" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias28" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I14" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D14" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn29" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias29" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I15" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D15" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="individual">
                                                <table width="100%" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" valign="top">
                                                            <asp:ImageButton ID="imgBtn30" runat="server" ImageUrl="~/Imagenes/Arbol/Rangos/0.png" OnClick="imgBtn_Click" />
                                                            <br />
                                                            <asp:Label ID="lblAlias30" runat="server" width="40px" text="ALI000" Font-Size="X-Small" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="I16" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoizq.png" OnClick="Izq_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="D16" runat="server" ImageUrl="~/Imagenes/Arbol/bajaunoder.png" OnClick="Der_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="center" class="style4">
                            <asp:ImageButton ID="btnInicio" runat="server" 
                                ImageUrl="~/Imagenes/Arbol/inicio.png" ToolTip="Ir a Inicio de Árbol" 
                                onclick="btnInicio_Click" />
                            <asp:ImageButton ID="btnSubir1" runat="server" 
                                ImageUrl="~/Imagenes/Arbol/subir1.png" ToolTip="Subir Un Nivel" 
                                onclick="btnSubir1_Click" />
                            <asp:ImageButton ID="btnSubir2" runat="server" 
                                ImageUrl="~/Imagenes/Arbol/subir2.png" ToolTip="Subir Dos Niveles" 
                                onclick="btnSubir2_Click" />
                            <asp:ImageButton ID="btnSubir3" runat="server" 
                                ImageUrl="~/Imagenes/Arbol/subir3.png" ToolTip="Subir Tres Niveles" 
                                onclick="btnSubir3_Click" />
                            <asp:ImageButton ID="btnSubir4" runat="server" 
                                ImageUrl="~/Imagenes/Arbol/subir4.png" ToolTip="Subir Cuatro Niveles" 
                                onclick="btnSubir4_Click" />
                        </td>
                        <td>
                            <span class="textonuevo">Número Asociado</span>
                            <asp:TextBox ID="txtIdAsociado" runat="server" />
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                onclick="btnBuscar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 827px; height: 56px">
        <tr>
            <td></td>
        </tr>
    </table>
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