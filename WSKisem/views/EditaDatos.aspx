<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MenuPrincipal.master" CodeFile="EditaDatos.aspx.cs" Inherits="views_EditaDatos" %>
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
        .tabla
        {
            border: thin solid Silver;
            text-align: justify;
            font-family: Arial;
            font-weight: normal;
            font-size: medium;
            color: Black;
            vertical-align:top;
            width: 820px;
            height: 906px;
            margin-top: 0px;
            background-position: 50% bottom; 
            background-repeat: no-repeat;
        }
        textarea
        {
            resize:none;
        }
        .style7
        {
            height: 23px;
            width: 169px;
            text-align: right;
            font-weight: bold;
        }
        .style8
        {
            height: 25px;
            width: 486px;
        }
        .style9
        {
            height: 23px;
            width: 486px;
        }
        .style10
        {
            height: 23px;
            font-size: small;
        }
        .style12
        {
            height: 23px;
            width: 146px;
            text-align: right;
            font-weight: bold;
        }
        .style13
        {
            height: 23px;
            width: 162px;
            text-align: right;
            font-weight: bold;
        }
        .style14
        {
            height: 25px;
            width: 162px;
            text-align: right;
            font-weight: bold;
        }
        .style15
        {
            height: 25px;
            font-size: smaller;
        }
        .style17
        {
            height: 18px;
            width: 350px;
        }
        .style18
        {
            height: 18px;
            width: 162px;
            text-align: right;
            font-weight: bold;
        }
        .style19
        {
            width: 486px;
        }
        .style20
        {
            height: 25px;
            width: 486px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="title">
        <asp:Label ID="lblTitlePrincipal" runat="server"  />
    </div>
    <table class="tabla">
        <tr>
        <td></td>
            <td class="style19">
                Datos Asociado</td>
        </tr>
        <tr>
            <td class="style13">
               <asp:Label ID="lblNombre" runat="server" Text="Nombre(s):" Font-Bold="true" />
            </td>
            <td class="style8">
                <asp:TextBox ID="txtNombre" runat="server" Width="332px" Enabled="False"  />
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblApPaterno" runat="server" Text="Apellido Paterno:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtApPaterno" runat="server" Width="332px" Enabled="False"  />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblApMaterno" runat="server" Text="Apellido Materno:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtApMaterno" runat="server" Width="332px" Enabled="False"  />
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblFechNac" runat="server" Text="Fecha Nacimiento:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtFecNac" runat="server" Width="136px" Enabled="False"  />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstLugarNac" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblLugarNac" runat="server" Text="Lugar Nacimiento:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:DropDownList ID="ddlLugarNacim" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem>
                    <asp:ListItem Value="AGUASCALIENTES" Text="AGUASCALIENTES" />
                    <asp:ListIteM Value="BAJA CALIFORNIA NORTE" Text="BAJA CALIFORNIA NORTE" />
                    <asp:ListIteM Value="BAJA CALIFORNIA SUR" Text="BAJA CALIFORNIA SUR" />
                    <asp:ListIteM Value="CAMPECHE" Text="CAMPECHE" />
                    <asp:ListIteM Value="CHIAPAS" Text="CHIAPAS" />
                    <asp:ListIteM Value="CHIHUAHUA" Text="CHIHUAHUA" />
                    <asp:ListIteM Value="COAHUILA" Text="COAHUILA" />
                    <asp:ListIteM Value="COLIMA" Text="COLIMA" />
                    <asp:ListIteM Value="DF" Text="DF" />
                    <asp:ListIteM Value="DURANGO" Text="DURANGO" />
                    <asp:ListIteM Value="EDO MÉXICO" Text="EDO MÉXICO" />
                    <asp:ListIteM Value="GUANAJUATO" Text="GUANAJUATO" />
                    <asp:ListIteM Value="GUERRERO" Text="GUERRERO" />
                    <asp:ListIteM Value="HIDALGO" Text="HIDALGO" />
                    <asp:ListIteM Value="JALISCO" Text="JALISCO" />
                    <asp:ListIteM Value="MICHOACÁN" Text="MICHOACÁN" />
                    <asp:ListIteM Value="MORELOS" Text="MORELOS" />
                    <asp:ListIteM Value="NAYARIT" Text="NAYARIT" />
                    <asp:ListIteM Value="NUEVO LEÓN" Text="NUEVO LEÓN" />
                    <asp:ListIteM Value="OAXACA" Text="OAXACA" />
                    <asp:ListIteM Value="PUEBLA" Text="PUEBLA" />
                    <asp:ListIteM Value="QUERÉTARO" Text="QUERÉTARO" />
                    <asp:ListIteM Value="QUINTANA ROO" Text="QUINTANA ROO" />
                    <asp:ListIteM Value="SAN LUIS POTOSÍ" Text="SAN LUIS POTOSÍ" />
                    <asp:ListIteM Value="SINALOA" Text="SINALOA" />
                    <asp:ListIteM Value="SONORA" Text="SONORA" />
                    <asp:ListIteM Value="TABASCO" Text="TABASCO" />
                    <asp:ListIteM Value="TAMAULIPAS" Text="TAMAULIPAS" />
                    <asp:ListIteM Value="TLAXCALA" Text="TLAXCALA" />
                    <asp:ListIteM Value="VERACRUZ" Text="VERACRUZ" />
                    <asp:ListIteM Value="YUCATÁN" Text="YUCATÁN" />
                    <asp:ListIteM Value="ZACATECAS" Text="ZACATECAS" />
                    <asp:ListIteM Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstEdoCivil" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblEdoCivil" runat="server" Text="Estado Civil:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:DropDownList ID="ddlEdoCivil" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem>
                    <asp:ListItem Value="SOLTERO" Text="SOLTERO" />
                    <asp:ListItem Value="CASADO" Text="CASADO" />
                    <asp:ListItem Value="DIVORCIADO" Text="DIVORCIADO" />
                    <asp:ListItem Value="VIUDO" Text="VIUDO" />
                    <asp:ListItem Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblRfc" runat="server" Text="RFC:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtRfc" runat="server" Width="332px" MaxLength="13" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblCurp" runat="server" Text="CURP:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCurp" runat="server" Width="332px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblCompania" runat="server" Text="Compañia:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCompania" runat="server" Width="332px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstTelefono" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtTelefLada" runat="server"  Width="34px" MaxLength="3" />
                <asp:TextBox ID="txtTelef" runat="server"  Width="159px" MaxLength="7" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style18"></td>
            <td class="style17" colspan="2"><asp:Label ID="lblTelefLada" runat="server" Width="30px" Text="Lada" Font-Size="Small" ForeColor="Gray" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTelef" runat="server" Width="159px" Text="Teléfono" Font-Size="Small" ForeColor="Gray"  />
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCelular" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCelular" runat="server" Text="Celular:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCelLada" runat="server"  Width="34px" MaxLength="3" />
                <asp:TextBox ID="txtCelTelef" runat="server"  Width="159px" MaxLength="7" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style18"></td>
            <td class="style17" colspan="2"><asp:Label ID="lblCelularLada" runat="server" Width="30px" Text="Lada" Font-Size="Small" ForeColor="Gray" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCelularTelefono" runat="server" Width="159px" Text="Teléfono" Font-Size="Small" ForeColor="Gray"  />
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblOtro" runat="server" Text="Otro:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtOtroTel" runat="server" Width="332px"></asp:TextBox>
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstEmail" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtEmail" runat="server" Width="332px"></asp:TextBox>
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAlias" runat="server" Text="Alias:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtAlias" runat="server" Width="332px" Enabled="False"></asp:TextBox>
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstPais" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblPais" runat="server" Text="Pais:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:DropDownList ID="ddlPais" runat="server"  Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem>
                    <asp:ListItem Value="MEXICO" Text="MÉXICO" />
                    <asp:ListItem Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstIdioma" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblIdioma" runat="server" Text="Idioma:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:DropDownList ID="ddlIdioma" runat="server"  Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem>
                    <asp:ListItem Value="ESPAÑOL" Text="ESPAÑOL" />
                    <asp:ListItem Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
                </td>
            <td class="style10">
                </td>
        </tr>
       <tr>
            <td class="style7" colspan="3">
                </td>
        </tr>
        <tr>
            <td></td>
            <td class="style9">
               Dirección</td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCalle" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCalle" runat="server" Text="Calle:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCalleCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstNum" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblNum" runat="server" Text="Número:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtNumExtCasa" runat="server" Width="79px" /> &nbsp;
                <asp:CheckBox id="chkNumeroCasa" runat="server" Text="S/n" /> 
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblInt" runat="server" Text="Interior:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtNumIntCasa" runat="server" Width="79px" />
                </td>
            <td class="style10"></td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstColonia" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblColonia" runat="server" Text="Colonia:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtColoniaCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCp" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCp" runat="server" Text="Código Postal:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCPCasa" runat="server" Width="79px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstMpio" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblMpio" runat="server" Text="Municipio:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtMpioCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCd" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCiudadCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstEdo" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblEdo" runat="server" Text="Estado:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:DropDownList ID="ddlEdoCasa" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem>
                    <asp:ListItem Value="AGUASCALIENTES" Text="AGUASCALIENTES" />
                    <asp:ListIteM Value="BAJA CALIFORNIA NORTE" Text="BAJA CALIFORNIA NORTE" />
                    <asp:ListIteM Value="BAJA CALIFORNIA SUR" Text="BAJA CALIFORNIA SUR" />
                    <asp:ListIteM Value="CAMPECHE" Text="CAMPECHE" />
                    <asp:ListIteM Value="CHIAPAS" Text="CHIAPAS" />
                    <asp:ListIteM Value="CHIHUAHUA" Text="CHIHUAHUA" />
                    <asp:ListIteM Value="COAHUILA" Text="COAHUILA" />
                    <asp:ListIteM Value="COLIMA" Text="COLIMA" />
                    <asp:ListIteM Value="DF" Text="DF" />
                    <asp:ListIteM Value="DURANGO" Text="DURANGO" />
                    <asp:ListIteM Value="EDO MÉXICO" Text="EDO MÉXICO" />
                    <asp:ListIteM Value="GUANAJUATO" Text="GUANAJUATO" />
                    <asp:ListIteM Value="GUERRERO" Text="GUERRERO" />
                    <asp:ListIteM Value="HIDALGO" Text="HIDALGO" />
                    <asp:ListIteM Value="JALISCO" Text="JALISCO" />
                    <asp:ListIteM Value="MICHOACÁN" Text="MICHOACÁN" />
                    <asp:ListIteM Value="MORELOS" Text="MORELOS" />
                    <asp:ListIteM Value="NAYARIT" Text="NAYARIT" />
                    <asp:ListIteM Value="NUEVO LEÓN" Text="NUEVO LEÓN" />
                    <asp:ListIteM Value="OAXACA" Text="OAXACA" />
                    <asp:ListIteM Value="PUEBLA" Text="PUEBLA" />
                    <asp:ListIteM Value="QUERÉTARO" Text="QUERÉTARO" />
                    <asp:ListIteM Value="QUINTANA ROO" Text="QUINTANA ROO" />
                    <asp:ListIteM Value="SAN LUIS POTOSÍ" Text="SAN LUIS POTOSÍ" />
                    <asp:ListIteM Value="SINALOA" Text="SINALOA" />
                    <asp:ListIteM Value="SONORA" Text="SONORA" />
                    <asp:ListIteM Value="TABASCO" Text="TABASCO" />
                    <asp:ListIteM Value="TAMAULIPAS" Text="TAMAULIPAS" />
                    <asp:ListIteM Value="TLAXCALA" Text="TLAXCALA" />
                    <asp:ListIteM Value="VERACRUZ" Text="VERACRUZ" />
                    <asp:ListIteM Value="YUCATÁN" Text="YUCATÁN" />
                    <asp:ListIteM Value="ZACATECAS" Text="ZACATECAS" />
                    <asp:ListIteM Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblRefCasa" runat="server" Text="Referencia:" Font-Bold="true" /></td>
            <td class="style20">
                <asp:TextBox ID="txtRefCasa" runat="server" TextMode="MultiLine" Width="345px" 
                    Height="60px" style="resize: none;" /></td>
        </tr>
        <tr>
            <td class="style7" colspan="3">
                </td>
        </tr>
       <tr>
            <td></td>
            <td class="style9">
                Dirección de Paquetería
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chkDireccion" runat="server" Text="Misma Dirección" AutoPostBack="true" OnCheckedChanged="chkDirecccion_Changed" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCallePaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCallePaq" runat="server" Text="Calle:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCallePaq" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstNumPaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblNumPaq" runat="server" Text="Número:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtNumExtPaq" runat="server" Width="79px" />&nbsp;
                <asp:CheckBox id="chkNumeroPaq" runat="server" Text="S/n" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblIntPaq" runat="server" Text="Interior:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtNumIntPaq" runat="server" Width="79px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style14">
                <asp:Label ID="lblAstColPaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblColPaq" runat="server" Text="Colonia:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtColoniaPaq" runat="server" Width="332px" />
                </td>
            <td class="style15">
                </td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstCpPaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCpPaq" runat="server" Text="CP:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCPPaq" runat="server" Width="79px" />
                </td>
            <td class="style10">
                </td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstMpioPaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblMpioPaq" runat="server" Text="Municipio:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtMpioPaq" runat="server" Width="332px" />
            </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCdPaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblCdPaq" runat="server" Text="Ciudad:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:TextBox ID="txtCiudadPaq" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstEdoPaq" runat="server" Text="*" ForeColor="Red" />&nbsp;
                <asp:Label ID="lblEdoPaq" runat="server" Text="Estado:" Font-Bold="true" /></td>
            <td class="style8">
                <asp:DropDownList ID="ddlEdoPaq" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem>
                    <asp:ListItem Value="AGUASCALIENTES" Text="AGUASCALIENTES" />
                    <asp:ListIteM Value="BAJA CALIFORNIA NORTE" Text="BAJA CALIFORNIA NORTE" />
                    <asp:ListIteM Value="BAJA CALIFORNIA SUR" Text="BAJA CALIFORNIA SUR" />
                    <asp:ListIteM Value="CAMPECHE" Text="CAMPECHE" />
                    <asp:ListIteM Value="CHIAPAS" Text="CHIAPAS" />
                    <asp:ListIteM Value="CHIHUAHUA" Text="CHIHUAHUA" />
                    <asp:ListIteM Value="COAHUILA" Text="COAHUILA" />
                    <asp:ListIteM Value="COLIMA" Text="COLIMA" />
                    <asp:ListIteM Value="DF" Text="DF" />
                    <asp:ListIteM Value="DURANGO" Text="DURANGO" />
                    <asp:ListIteM Value="EDO MÉXICO" Text="EDO MÉXICO" />
                    <asp:ListIteM Value="GUANAJUATO" Text="GUANAJUATO" />
                    <asp:ListIteM Value="GUERRERO" Text="GUERRERO" />
                    <asp:ListIteM Value="HIDALGO" Text="HIDALGO" />
                    <asp:ListIteM Value="JALISCO" Text="JALISCO" />
                    <asp:ListIteM Value="MICHOACÁN" Text="MICHOACÁN" />
                    <asp:ListIteM Value="MORELOS" Text="MORELOS" />
                    <asp:ListIteM Value="NAYARIT" Text="NAYARIT" />
                    <asp:ListIteM Value="NUEVO LEÓN" Text="NUEVO LEÓN" />
                    <asp:ListIteM Value="OAXACA" Text="OAXACA" />
                    <asp:ListIteM Value="PUEBLA" Text="PUEBLA" />
                    <asp:ListIteM Value="QUERÉTARO" Text="QUERÉTARO" />
                    <asp:ListIteM Value="QUINTANA ROO" Text="QUINTANA ROO" />
                    <asp:ListIteM Value="SAN LUIS POTOSÍ" Text="SAN LUIS POTOSÍ" />
                    <asp:ListIteM Value="SINALOA" Text="SINALOA" />
                    <asp:ListIteM Value="SONORA" Text="SONORA" />
                    <asp:ListIteM Value="TABASCO" Text="TABASCO" />
                    <asp:ListIteM Value="TAMAULIPAS" Text="TAMAULIPAS" />
                    <asp:ListIteM Value="TLAXCALA" Text="TLAXCALA" />
                    <asp:ListIteM Value="VERACRUZ" Text="VERACRUZ" />
                    <asp:ListIteM Value="YUCATÁN" Text="YUCATÁN" />
                    <asp:ListIteM Value="ZACATECAS" Text="ZACATECAS" />
                    <asp:ListIteM Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
            </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblRefPaq" runat="server" Text="Referencia:" Font-Bold="true" /></td>
            <td class="style20">
                <asp:TextBox ID="txtRefPaq" runat="server" TextMode="MultiLine" Width="345px" 
                    Height="60px" style="resize: none;" /></td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td colspan="3" class="style12"></td>
        </tr>
    </table>
    <table style="width: 817px; margin-top: 0px; background-position: 50% bottom; background-repeat: no-repeat;">
        <tr align="center">
            <td align="center">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="106px" 
                    onclick="btnGuardar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Width="106px" 
                    onclick="btnRegresar_Click" />
            </td>
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
