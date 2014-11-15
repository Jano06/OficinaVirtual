<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="misDatosPersonales.aspx.cs" Inherits="views_misDatosPersonales" %>

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
        .subtitulo
        {
            text-align: justify;
            font-family: Arial;
            font-size: medium;
            font-weight: normal;
            color:Black;
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
        
        
        .style4
        {
            height: 21px;
            width: 378px;
        }
                
        
        .style6
        {
            width: 17px;
            height: 21px;
        }
        
        
        .style7
        {
            width: 411px;
        }
        
        
        .style8
        {
            width: 873px;
        }
        
        
    </style>
    <link rel="stylesheet" href="../../Style/StyleKisem.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <table class="subtitulo">
        <tr align="center">
            <td class="style4" colspan="3" style="font-size: large;  font-weight: bold;" >
                INFORMACIÓN DEL ASOCIADO
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2" ><asp:Label ID="lblTitlNombre" runat="server" Text="Nombre:" Font-Bold="true" />
                <asp:Label ID="lblNombre" runat="server" ForeColor="Gray" />
            </td>
            
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlFechNac" runat="server" Text="Fecha Nacimiento:" Font-Bold="true" />
                <asp:Label ID="lblFechaNac" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlTelLocal" runat="server" Text="Teléfono Local:" Font-Bold="true" />
                <asp:Label ID="lblTelefono" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlLugarNac" runat="server" Text="Lugar Nacimiento:" Font-Bold="true" />
                <asp:Label ID="lblLugarNac" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlCelular" runat="server" Text="Celular:" Font-Bold="true" />
                <asp:Label ID="lblCelular" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlFecIngreso" runat="server" Text="Fecha Ingreso:" Font-Bold="true" />
                <asp:Label ID="lblFechaIngreso" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlOtrTel" runat="server" Text="Otro Telefono:" Font-Bold="true" />
                <asp:Label ID="lblOtroTel" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlRFC" runat="server" Text="RFC:" Font-Bold="true" />
                <asp:Label ID="lblRFC" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlEmail" runat="server" Text="Email:" Font-Bold="true" />
                <asp:Label ID="lblEmail" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlCURP" runat="server" Text="CURP:" Font-Bold="true" />
                <asp:Label ID="lblCurp" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlRetencion" runat="server" Text="Tipo Retención:" Font-Bold="true" />
                <asp:Label ID="lblRetención" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2"><asp:Label ID="lblTitlEdoCivil" runat="server" Text="Estado Civil:" Font-Bold="true" />
                <asp:Label ID="lblEdoCivil" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2" ><asp:Label ID="lblTitlUsuario" runat="server" Text="Usuario:" Font-Bold="true" />
                <asp:Label ID="lblUsuario" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2" ><asp:Label ID="lblTitlAlias" runat="server" Text="Alias:" Font-Bold="true" />
                <asp:Label ID="lblAlias" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2" ><asp:Label ID="lblTitlPassword" runat="server" Text="Contraseña:" Font-Bold="true" />
                <asp:Label ID="lblPassword" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2" ><asp:Label ID="lblTitlTipoAsoc" runat="server" Text="Tipo Asociado:" Font-Bold="true" />
                <asp:Label ID="lblTipoAsoc" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="3" />
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" style="font-size: large; font-weight: bold; ">
                DIRECCIÓN PERSONAL</td>
            <td class="style7" style="font-size: large; font-weight: bold;">
                DIRECCIÓN ENVIO</td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlPaisPers" runat="server" Text="País:" Font-Bold="true" />
                <asp:Label ID="lblPaisPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlPaisEnv" runat="server" Text="País:" Font-Bold="true" />
                <asp:Label ID="lblPaisEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlCallePers" runat="server" Text="Calle:" Font-Bold="true" />
                <asp:Label ID="lblCallePers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlCalleEnv" runat="server" Text="Calle:" Font-Bold="true" />
                <asp:Label ID="lblCalleEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlNumExtPers" runat="server" Text="Núm Exterior:" Font-Bold="true" />
                <asp:Label ID="lblNumExtPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlNumExtEnv" runat="server" Text="Núm Exterior:" Font-Bold="true" />
                <asp:Label ID="lblNumExtEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlNumIntPer" runat="server" Text="Núm Interior:" Font-Bold="true" />
                <asp:Label ID="lblNumIntPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlNumIntEnv" runat="server" Text="Núm Interior:" Font-Bold="true" />
                <asp:Label ID="lblNumIntEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlColoniaPers" runat="server" Text="Colonia:" Font-Bold="true" />
                <asp:Label ID="lblColoniaPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlColoniaEnv" runat="server" Text="Colonia:" Font-Bold="true" />
                <asp:Label ID="lblColoniaEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlMpioPers" runat="server" Text="Municipio:" Font-Bold="true" />
                <asp:Label ID="lblMunicipioPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlMpioEnv" runat="server" Text="Municipio:" Font-Bold="true" />
                <asp:Label ID="lblMunicipioEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlCiudadPers" runat="server" Text="Ciudad:" Font-Bold="true" />
                <asp:Label ID="lblCiudadPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlCiudadPaq" runat="server" Text="Ciudad:" Font-Bold="true" />
                <asp:Label ID="lblCiudadEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlEdoPers" runat="server" Text="Estado:" Font-Bold="true" />
                <asp:Label ID="lblEdoPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlEdoEnv" runat="server" Text="Estado:" Font-Bold="true" />
                <asp:Label ID="lblEdoEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" ><asp:Label ID="lblTitlCPPers" runat="server" Text="C.P:" Font-Bold="true" />
                <asp:Label ID="lblCPPers" runat="server" ForeColor="Gray" />
            </td>
            <td class="style7" ><asp:Label ID="lblTitlCPEnv" runat="server" Text="C.P:" Font-Bold="true" />
                <asp:Label ID="lblCPEnv" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td class="style6" colspan="3" />
        </tr>
        <tr>
            <td class="style6" />
            <td class="style7" colspan="2" ><asp:Label ID="lblTitlBodega" runat="server" Text="Bodega:" Font-Bold="true" />
                <asp:Label ID="lblBodega" runat="server" ForeColor="Gray" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        </table>
        <table>
        <tr align="center">
            <td class="style8" colspan="2"  align="center">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" 
                    onclick="btnEditar_Click" Width="102px" />
            </td>
        </tr>
        
    </table>
</asp:Content>
    