<%@ Page Language="C#" MasterPageFile="~/Master/MenuPrincipal.master" AutoEventWireup="true" CodeFile="AltaProspecto.aspx.cs" Inherits="views_AltaProspecto" %>
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
            background-position: 50% bottom; 
            background-repeat: no-repeat;
        }
        textarea
        {
            resize:none;
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
            width: 417px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
<div class="title">
    <asp:Label ID="lblTitlePrincipal" runat="server"  />
</div>
<asp:Table ID="tblProspectos" runat="server" CssClass="miniTabla">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="lblMisProspectos" runat="server" Text="Mis Prospectos" />
        </asp:TableCell></asp:TableRow><asp:TableRow>
        <asp:TableCell>
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
                    <asp:TemplateField HeaderText="Editar" Visible="true" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnEditar" runat="server" OnClick="imgBtnEditar_Click" ImageUrl="~/Imagenes/detalle.jpg" Width="20" Height="20" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar" Visible="true" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgbtnEliminar" runat="server" OnClick="imgBtnEliminar_Click" ImageUrl="~/Imagenes/eliminar.jpg" Width="20" Height="20" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:TableCell></asp:TableRow></asp:Table><br />
        <table class="tabla">
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblTitulo" Text="Información del prospecto" runat="server" /> 
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblTipoAsociado" runat="server" Text="Tipo Prospecto:" Font-Bold="true" />
            </td>
            <td>
                <asp:RadioButtonList ID="rbtnTipo" runat="server" RepeatDirection="Horizontal"  >
                    <asp:ListItem Value="1" Text="Asociado" Selected="True" />
                    <asp:ListItem Value="2" Text="Consumidor" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblastEntrega" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblNombre" runat="server" Text="Nombre(s):" Font-Bold="true" />
            </td>
            <td class="style14">
                <asp:TextBox ID="txtNombre" runat="server" Width="332px" />
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstApPaterno" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblApPaterno" runat="server" Text="Apellido Paterno:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtApPaterno" runat="server" Width="332px"  />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstApMaterno" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblApMaterno" runat="server" Text="Apellido Materno:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtApMaterno" runat="server" Width="332px" />
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstFechNac" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblFechNac" runat="server" Text="Fecha Nacimiento:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlDia" runat="server">
                    <asp:ListItem Value="0" Text="DIA" Selected="True" />
                    <asp:ListItem Value="1" Text="1" />
                    <asp:ListItem Value="2" Text="2" />
                    <asp:ListItem Value="3" Text="3" />
                    <asp:ListItem Value="4" Text="4" />
                    <asp:ListItem Value="5" Text="5" />
                    <asp:ListItem Value="6" Text="6" />
                    <asp:ListItem Value="7" Text="7" />
                    <asp:ListItem Value="8" Text="8" />
                    <asp:ListItem Value="9" Text="9" />
                    <asp:ListItem Value="10" Text="10" />
                    <asp:ListItem Value="11" Text="11" />
                    <asp:ListItem Value="12" Text="12" />
                    <asp:ListItem Value="13" Text="13" />
                    <asp:ListItem Value="14" Text="14" />
                    <asp:ListItem Value="15" Text="15" />
                    <asp:ListItem Value="16" Text="16" />
                    <asp:ListItem Value="17" Text="17" />
                    <asp:ListItem Value="18" Text="18" />
                    <asp:ListItem Value="19" Text="19" />
                    <asp:ListItem Value="20" Text="20" />
                    <asp:ListItem Value="21" Text="21" />
                    <asp:ListItem Value="22" Text="22" />
                    <asp:ListItem Value="23" Text="23" />
                    <asp:ListItem Value="24" Text="24" />
                    <asp:ListItem Value="25" Text="25" />
                    <asp:ListItem Value="26" Text="26" />
                    <asp:ListItem Value="27" Text="27" />
                    <asp:ListItem Value="28" Text="28" />
                    <asp:ListItem Value="29" Text="29" />
                    <asp:ListItem Value="30" Text="30" />
                    <asp:ListItem Value="31" Text="31" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMes" runat="server">
                    <asp:ListItem Value="0" Text="MES" Selected="True" />
                    <asp:ListItem Value="01" Text="ENERO" />
                    <asp:ListItem Value="02" Text="FEBRERO" />
                    <asp:ListItem Value="03" Text="MARZO" />
                    <asp:ListItem Value="04" Text="ABRIL" />
                    <asp:ListItem Value="05" Text="MAYO" />
                    <asp:ListItem Value="06" Text="JUNIO" />
                    <asp:ListItem Value="07" Text="JULIO" />
                    <asp:ListItem Value="08" Text="AGOSTO" />
                    <asp:ListItem Value="09" Text="SEPTIEMBRE" />
                    <asp:ListItem Value="10" Text="OCTUBRE" />
                    <asp:ListItem Value="11" Text="NOVIEMBRE" />
                    <asp:ListItem Value="12" Text="DICIEMBRE" />
                </asp:DropDownList>
                <asp:TextBox ID="txtAnio" runat="server" Width="59px" MaxLength="4" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstLugarNac" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblLugarNac" runat="server" Text="Lugar Nacimiento:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlLugarNacimiento" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem><asp:ListItem Value="AGUASCALIENTES" Text="AGUASCALIENTES" />
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
                <asp:Label ID="lblAstEdoCivil" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblEdoCivil" runat="server" Text="Estado Civil:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlEdoCivil" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem><asp:ListItem Value="SOLTERO" Text="SOLTERO" />
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
            <td class="style14">
                <asp:TextBox ID="txtRfc" runat="server" Width="332px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblCurp" runat="server" Text="CURP:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCurp" runat="server" Width="332px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblCompania" runat="server" Text="Compañia:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCompania" runat="server" Width="332px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstTelefono" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtTelefLada" runat="server"  Width="34px" MaxLength="3" />
                <asp:TextBox ID="txtTelef" runat="server"  Width="159px" MaxLength="7" />
                </td>
            <td class="style10" />
        </tr>
        <tr>
            <td class="style18" />
            <td class="style17" colspan="2"><asp:Label ID="lblTelefLada" runat="server" Width="30px" Text="Lada" Font-Size="Small" ForeColor="Gray" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblTelef" runat="server" Width="159px" Text="Teléfono" Font-Size="Small" ForeColor="Gray"  />
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCelular" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCelular" runat="server" Text="Celular:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCelLada" runat="server"  Width="34px" MaxLength="3" />
                <asp:TextBox ID="txtCelTelef" runat="server"  Width="159px" MaxLength="7" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style18" />
            <td class="style17" colspan="2"><asp:Label ID="lblCelLada" runat="server" Width="30px" Text="Lada" Font-Size="Small" ForeColor="Gray" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblCelTel" runat="server" Width="159px" Text="Teléfono" Font-Size="Small" ForeColor="Gray"  />
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblOtro" runat="server" Text="Otro:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtOtroLada" runat="server"  Width="34px" MaxLength="3" />
                <asp:TextBox ID="txtOtroTel" runat="server"  Width="159px" MaxLength="7" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style18" />
            <td class="style17" colspan="2"><asp:Label ID="lblLadaOtro" runat="server" Width="30px" Text="Lada" Font-Size="Small" ForeColor="Gray" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblTelOtro" runat="server" Width="159px" Text="Teléfono" Font-Size="Small" ForeColor="Gray"  />
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstEmail" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtEmail" runat="server" Width="332px"></asp:TextBox></td><td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstConfEmail" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblConfEmail" runat="server" Text="Confirma Email:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtConfEmail" runat="server" Width="332px"></asp:TextBox></td><td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstPais" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblPais" runat="server" Text="Pais:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlPais" runat="server"  Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem><asp:ListItem Value="MEXICO" Text="MÉXICO" />
                    <asp:ListItem Value="OTRO" Text="OTRO" />
                </asp:DropDownList>
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstIdioma" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblIdioma" runat="server" Text="Idioma:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlIdioma" runat="server"  Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem><asp:ListItem Value="ESPAÑOL" Text="ESPAÑOL" />
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
            <td class="style9">Dirección</td></tr><tr>
            <td class="style13">
                <asp:Label ID="lblAstCalle" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCalle" runat="server" Text="Calle:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCalleCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstNum" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblNum" runat="server" Text="Número:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtNumExtCasa" runat="server" Width="79px" />&nbsp; <asp:CheckBox id="chkNumeroCasa" runat="server" Text="S/n" /> 
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblInt" runat="server" Text="Interior:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtNumIntCasa" runat="server" Width="79px" />
                </td>
            <td class="style10"></td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstColonia" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblColonia" runat="server" Text="Colonia:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtColoniaCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCp" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCp" runat="server" Text="CP:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCPCasa" runat="server" Width="79px" MaxLength="5" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstMpio" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblMpio" runat="server" Text="Municipio:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtMpioCasa" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
         <tr>
            <td class="style13">
                <asp:Label ID="lblAstCd" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCiudad" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstEdo" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblEdo" runat="server" Text="Estado:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlEdoCasa" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem><asp:ListItem Value="AGUASCALIENTES" Text="AGUASCALIENTES" />
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
            <td class="style14">
                <asp:TextBox ID="txtRefCasa" runat="server" TextMode="MultiLine" Width="338px" MaxLength="250" Height="50px" style=" overflow:auto;" /></td>
        </tr>
        <tr>
            <td class="style7" colspan="3">
                </td>
        </tr>
       <tr>
            <td>
            </td>
            <td>
                Dirección Paquetería&nbsp;&nbsp; <asp:CheckBox ID="chkDireccion" runat="server" Text="Misma Dirección" AutoPostBack="true" OnCheckedChanged="chkDireccion_CheckedChanged"/> 
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstCallePaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCallePaq" runat="server" Text="Calle:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCallePaq" runat="server" Width="332px" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstNumPaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblNumPaq" runat="server" Text="Número:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtNumExtPaq" runat="server" Width="79px" />&nbsp; <asp:CheckBox id="chkNumeroPaq" runat="server" Text="S/n" />
                </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblIntPaq" runat="server" Text="Interior:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtNumIntPaq" runat="server" Width="79px" />
                </td>
            <td class="style10"></td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Label ID="lblAstColPaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblColPaq" runat="server" Text="Colonia:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtColoniaPaq" runat="server" Width="332px" />
                </td>
            <td class="style15">
                </td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstCpPaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCpPaq" runat="server" Text="CP:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCPPaq" runat="server" Width="79px" />
                </td>
            <td class="style10">
                </td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstMpioPaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblMpioPaq" runat="server" Text="Municipio:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtMpioPaq" runat="server" Width="332px" />
            </td>
            <td class="style10">
                </td>
        </tr>
         <tr>
            <td class="style13">
                <asp:Label ID="lblAstCdPaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblCiudadPaq" runat="server" Text="Ciudad:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:TextBox ID="txtCiudadPaq" runat="server" Width="332px" />
                </td>
            <td class="style15">
                </td>
        </tr>
       <tr>
            <td class="style13">
                <asp:Label ID="lblAstEdoPaq" runat="server" Text="*" ForeColor="Red" />&nbsp; <asp:Label ID="lblEdoPaq" runat="server" Text="Estado:" Font-Bold="true" /></td>
            <td class="style14">
                <asp:DropDownList ID="ddlEdoPaq" runat="server" Width="338px">
                    <asp:ListItem Value="0">SELECCIONA UNA OPCIÓN</asp:ListItem><asp:ListItem Value="AGUASCALIENTES" Text="AGUASCALIENTES" />
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
            <td class="style14">
                <asp:TextBox ID="txtRefPaq" runat="server" TextMode="MultiLine" Width="338px" Height="50px" MaxLength="250" /></td>
        </tr>
        <tr>
            <td colspan="3" class="style12"></td>
        </tr>
        </table>
    <table style="width: 819px">
        <tr>
            <td align="center" class="style8">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="106px" 
                    onclick="btnGuardar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Width="106px" 
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

