using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using log4net;

public partial class views_EditaProspecto : System.Web.UI.Page
{
    private string _idProspecto;
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_EditaProspecto));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string idProspecto = Request.QueryString["prospecto"].ToString();
            _idProspecto = Encriptador.desencriptar(idProspecto);
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar variables " + ex.Message);
            throw new Exception("Error en EditaProspecto" + ex.Message);
        }

        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "EDITAR PROSPECTO";
            CargaDatos(_idProspecto);
        }
    }

    private void CargaDatos(string idProspecto)
    {
        AltaProspectoAction action = new AltaProspectoAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        model = action.ProspectoDatos(idProspecto);
        txtNombre.Text = model.Nombre;
        txtApPaterno.Text = model.ApPaterno;
        txtApMaterno.Text = model.ApMaterno;
        rbtnTipo.SelectedValue = model.TipoAsociado;
        ddlDia.SelectedValue = model.FechaNacimiento.Day.ToString();
        ddlMes.SelectedValue = model.FechaNacimiento.ToString("MM");
        txtAnio.Text = model.FechaNacimiento.Year.ToString();
        ddlLugarNacimiento.SelectedValue = model.LugarNacimiento;
        ddlEdoCivil.SelectedValue = model.EdoCivil;
        txtRfc.Text = model.RFC;
        txtCurp.Text = model.Curp;
        txtCompania.Text = model.Compania;
        txtEmail.Text = model.Email;
        txtTelefLada.Text = model.Telefono.Substring(0, 3);
        txtTelef.Text = model.Telefono.Substring(3);
        txtCelLada.Text = model.Celular.Substring(0, 3);
        txtCelTelef.Text = model.Celular.Substring(3);
        if (model.TelOtro.Length > 0)
        {
            txtOtroLada.Text = model.TelOtro.Substring(0, 3);
            txtOtroTel.Text = model.TelOtro.Substring(3);
        }
        ddlPais.SelectedValue = model.PaisPers;
        ddlIdioma.SelectedValue = model.Idioma;
        txtCalleCasa.Text = model.CallePers;
        if (model.NumExtPers.Equals("S/n"))
            chkNumeroCasa.Checked = true;
        else
        {
            chkNumeroCasa.Checked = false;
            txtNumExtCasa.Text = model.NumExtPers;
        }
        txtNumIntCasa.Text = model.NumIntPers;
        txtColoniaCasa.Text = model.ColoniaPers;
        txtCPCasa.Text = model.CpPers;
        txtMpioCasa.Text = model.MunicipioPers;
        txtCiudad.Text = model.CiudadPers;
        ddlEdoCasa.Text = model.EdoPers;
        txtRefCasa.Text = model.ReferenciaPers;
        txtCallePaq.Text = model.CalleEnv;
        if (model.NumExtEnv.Equals("S/n"))
            chkNumeroPaq.Checked = true;
        else
        {
            chkNumeroPaq.Checked = false;
            txtNumExtPaq.Text = model.NumExtEnv;
        }
        txtNumIntPaq.Text = model.NumIntEnv;
        txtColoniaPaq.Text = model.ColoniaEnv;
        txtCPPaq.Text = model.CpEnv;
        txtMpioPaq.Text = model.MunicipioEnv;
        txtCiudadPaq.Text = model.CiudadEnv;
        ddlEdoPaq.Text = model.EdoEnv;
        txtRefPaq.Text = model.ReferenciaEnv;
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected string validaDatos()
    {
        string msgError = string.Empty;
        if (txtNombre.Text.Length < 1)
            msgError += "Ingresar Nombre.</br>";
        if (txtApPaterno.Text.Length < 1)
            msgError += "Ingresar Apellido Paterno.</br>";
        if (txtApMaterno.Text.Length < 1)
            msgError += "Ingresar Apellido Materno.</br>";
        if (ddlDia.SelectedIndex == 0)
            msgError += "Seleccionar Día Nacimiento.</br>";
        if (ddlMes.SelectedIndex == 0)
            msgError += "Seleccionar Mes Nacimiento.</br>";
        if (txtAnio.Text.Length < 1)
            msgError += "Ingresar Año Nacimiento(yyyy).</br>";
        else
        {
            if (!(IsNumeric(txtAnio.Text)))
                msgError += "Formato Incorrecto Año Nacimiento.</br>";
        }
        if (ddlLugarNacimiento.SelectedIndex == 0)
            msgError += "Seleccionar Lugar Nacimiento.</br>";
        if (ddlEdoCivil.SelectedIndex == 0)
            msgError += "Seleccionar Estado Civil.</br>";
        if (txtTelefLada.Text.Length < 3 && txtTelef.Text.Length < 7)
            msgError += "Ingresar Lada Teléfono.</br>";
        else if (!(IsNumeric(txtTelef.Text)) && (!(IsNumeric(txtTelefLada.Text))))
            msgError += "Formato Incorrecto Teléfono Local.</br>";
        if (txtCelLada.Text.Length < 3 && txtCelTelef.Text.Length < 7)
            msgError += "Ingresar Lada Celular.</br>";
        else if (!(IsNumeric(txtCelLada.Text)) && (!(IsNumeric(txtCelTelef.Text))))
            msgError += "Formato Incorrecto Celular.</br>";
        if ((txtOtroLada.Text.Length > 0 && !(IsNumeric(txtOtroLada.Text))) && (txtOtroTel.Text.Length > 0 && !(IsNumeric(txtTelefLada.Text))))
            msgError += "Formato Incorrecto Otro Teléfono.</br>";
        if (txtEmail.Text.Length < 1)
            msgError += "Ingresar Email.</br>";
        else
        {
            if (!validaEmail(txtEmail.Text))
                msgError += "Formato Incorrecto Correo Electrónico.</br>";
        }
        if (ddlPais.SelectedIndex == 0)
            msgError += "Seleccionar País.</br>";
        if (ddlIdioma.SelectedIndex == 0)
            msgError += "Seleccionar Idioma.</br>";
        if (txtCalleCasa.Text.Length < 1)
            msgError += "Ingresar Calle.</br>";
        if (txtCallePaq.Text.Length < 1)
            msgError += "Ingresar Calle Paquetería.</br>";
        if (txtNumExtCasa.Text.Length < 1 && chkNumeroCasa.Checked.Equals(false))
            msgError += "Ingresar Número Dirección.</br>";
        else
            if (txtNumExtCasa.Text.Length > 0 && chkNumeroCasa.Checked.Equals(false))
            {
                if (!(IsNumeric(txtNumExtCasa.Text)))
                    msgError += "Formato Incorrecto Número Dirección.</br>";
            }
        if (txtNumExtPaq.Text.Length < 1 && chkNumeroPaq.Checked.Equals(false))
            msgError += "Ingresar Número Paquetería.</br>";
        else
            if (txtNumExtPaq.Text.Length > 0 && chkNumeroPaq.Checked.Equals(false))
            {
                if (!(IsNumeric(txtNumExtPaq.Text)))
                    msgError += "Formato Incorrecto Número Paquetería.</br>";
            }
        if (txtColoniaCasa.Text.Length < 1)
            msgError += "Ingresar Colonia Dirección.</br>";
        if (txtColoniaPaq.Text.Length < 1)
            msgError += "Ingresar Colonia Paquetería.</br>";
        if (txtCPCasa.Text.Length < 1)
            msgError += "Ingresar Código Postal Dirección.</br>";
        else if (!(IsNumeric(txtCPCasa.Text)))
            msgError += "Verificar Código Postal Dirección.</br>";
        if (txtCPPaq.Text.Length < 1)
            msgError += "Ingresar Código Postal Paquetería.</br>";
        else if (!(IsNumeric(txtCPPaq.Text)))
            msgError += "Verificar Código Postal Paquetería.</br>";
        if (txtMpioCasa.Text.Length < 1)
            msgError += "Ingresar Municipio Domicilio.</br>";
        if (txtMpioPaq.Text.Length < 1)
            msgError += "Ingresar Municipio Paquetería.</br>";
        if (txtCiudad.Text.Length < 1)
            msgError += "Ingresar Ciudad Domicilio.</br>";
        if (txtCiudadPaq.Text.Length < 1)
            msgError += "Ingresar Ciudad Paquetería.</br>";
        if (ddlEdoCasa.SelectedIndex == 0)
            msgError += "Seleccionar Estado Domicilio.</br>";
        if (ddlEdoPaq.SelectedIndex == 0)
            msgError += "Seleccionar Estado Paquetería.</br>";

        return msgError;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string msgError = string.Empty;
        msgError = validaDatos();
        if (msgError.Length == 0)
        {
            editarDatos(_idProspecto);
            NavegacionSegura.navega(this, "InfoProspecto", new string[] { _idProspecto, "EditaDatos" });
        }
        else
        {
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }

    private void editarDatos(string idProspecto)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        AltaProspectoAction action = new AltaProspectoAction();
        model.IdUsuario = Session["idUser"].ToString();
        model.Nombre = txtNombre.Text.ToUpper();
        model.ApPaterno = txtApPaterno.Text.ToUpper();
        model.ApMaterno = txtApMaterno.Text.ToUpper();
        model.FechaNacimiento = Convert.ToDateTime(ddlDia.SelectedValue.ToString() + "/" + ddlMes.SelectedValue.ToString() + "/" + txtAnio.Text.ToString());
        model.LugarNacimiento = ddlLugarNacimiento.SelectedValue.ToUpper();
        model.EdoCivil = ddlEdoCivil.SelectedValue;
        model.RFC = txtRfc.Text.ToUpper();
        model.Curp = txtCurp.Text.ToUpper();
        model.Compania = txtCompania.Text.ToUpper();
        model.Telefono = txtTelefLada.Text + txtTelef.Text;
        model.Celular = txtCelLada.Text + txtCelTelef.Text;
        model.TelOtro = txtOtroLada.Text + txtOtroTel.Text;
        model.Email = txtEmail.Text.ToLower();
        model.PaisPers = ddlPais.SelectedValue;
        model.Idioma = ddlIdioma.SelectedValue;
        model.CallePers = txtCalleCasa.Text.ToUpper();
        if (chkNumeroCasa.Checked.Equals(true))
            model.NumExtPers = "S/n";
        else if (chkNumeroCasa.Checked.Equals(false))
            model.NumExtPers = txtNumExtCasa.Text;
        model.NumIntPers = txtNumIntCasa.Text;
        model.ColoniaPers = txtColoniaCasa.Text.ToUpper();
        model.CpPers = txtCPCasa.Text;
        model.MunicipioPers = txtMpioCasa.Text.ToUpper();
        model.CiudadPers = txtCiudad.Text.ToUpper();
        model.EdoPers = ddlEdoCasa.SelectedValue;
        model.ReferenciaPers = txtRefCasa.Text;
        model.CalleEnv = txtCallePaq.Text.ToUpper();
        if (chkNumeroPaq.Checked.Equals(true))
            model.NumExtEnv = "S/n";
        else if (chkNumeroPaq.Checked.Equals(false))
            model.NumExtEnv = txtNumExtPaq.Text;
        model.NumIntEnv = txtNumIntPaq.Text;
        model.ColoniaEnv = txtColoniaPaq.Text.ToUpper();
        model.CpEnv = txtCPPaq.Text;
        model.MunicipioEnv = txtMpioPaq.Text.ToUpper();
        model.CiudadEnv = txtCiudadPaq.Text.ToUpper();
        model.EdoEnv = ddlEdoPaq.SelectedValue;
        model.ReferenciaEnv = txtRefPaq.Text;
        model.TipoAsociado = rbtnTipo.SelectedValue;
        action.EditaProspecto(model, idProspecto);
    }

    protected void chkDireccion_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDireccion.Checked.Equals(true))
        {
            txtCallePaq.Text = txtCalleCasa.Text;
            txtNumExtPaq.Text = txtNumExtCasa.Text;
            txtNumIntPaq.Text = txtNumIntCasa.Text;
            txtColoniaPaq.Text = txtColoniaCasa.Text;
            txtCPPaq.Text = txtCPCasa.Text;
            txtMpioPaq.Text = txtMpioCasa.Text;
            txtCiudadPaq.Text = txtCiudad.Text;
            txtColoniaCasa.Text = txtCiudadPaq.Text;
            ddlEdoPaq.SelectedValue = ddlEdoCasa.SelectedValue;
            chkNumeroPaq.Checked = chkNumeroCasa.Checked;
            txtCallePaq.Enabled = false;
            txtNumExtPaq.Enabled = false;
            txtNumIntPaq.Enabled = false;
            txtColoniaPaq.Enabled = false;
            txtCPPaq.Enabled = false;
            txtMpioPaq.Enabled = false;
            txtCiudadPaq.Enabled = false;
            ddlEdoPaq.Enabled = false;
            chkNumeroPaq.Enabled = false;
        }
        else
        {
            txtCallePaq.Enabled = true;
            txtNumExtPaq.Enabled = true;
            txtNumIntPaq.Enabled = true;
            txtColoniaPaq.Enabled = true;
            txtCPPaq.Enabled = true;
            txtMpioPaq.Enabled = true;
            txtCiudadPaq.Enabled = true;
            ddlEdoPaq.Enabled = true;
            chkNumeroPaq.Enabled = true;
            chkNumeroPaq.Checked = false;
        }
    }

    private Boolean IsNumeric(string num)
    {
        try
        {
            double x = Convert.ToDouble(num);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    protected Boolean validaEmail(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "InfoProspecto", new string[] { _idProspecto, "EditaDatos" });
    }
}