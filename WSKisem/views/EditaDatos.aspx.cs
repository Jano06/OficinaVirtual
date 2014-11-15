using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class views_EditaDatos : System.Web.UI.Page
{
    private string _idAsociado;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string valor = Request.QueryString["id"].ToString();
            _idAsociado = Encriptador.desencriptar(valor);
        }
        catch (Exception ex)
        {
            throw new Exception("Error en EditaDatos " + ex.Message);
        }

        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "EDITAR DATOS";
            CargaDatosAsociado(int.Parse(_idAsociado));
        }
    }

    protected void CargaDatosAsociado(int id)
    {
        MisDatosPersonalesAction actionDetalle = new MisDatosPersonalesAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();

        model = actionDetalle.ConsultaDatos(id);
        txtNombre.Text = model.Nombre;
        txtApPaterno.Text = model.ApPaterno;
        txtApMaterno.Text = model.ApMaterno;
        txtFecNac.Text = model.FechaNacimiento.ToString("dd/MMMM/yyyy").ToUpper();
        
        if (model.LugarNacimiento.ToString().Length > 1)
        {
            ddlLugarNacim.Enabled = false;
            ddlLugarNacim.SelectedValue = model.LugarNacimiento.ToString().ToUpper();
        }
        else
        {
            ddlLugarNacim.Enabled = true;
            ddlLugarNacim.SelectedValue = model.LugarNacimiento.ToString().ToUpper();
        }
        ddlEdoCivil.SelectedValue = model.EdoCivil;
        txtRfc.Text = model.RFC;
        txtCurp.Text = model.Curp;
        txtCompania.Text = model.Compania;
        txtTelefLada.Text = model.Telefono.Substring(0, 3);
        txtTelef.Text = model.Telefono.Substring(3, 7);
        if (model.Celular.Length > 0 && model.Celular != "0")
        {
            txtCelLada.Text = model.Celular.Substring(0, 3);
            txtCelTelef.Text = model.Celular.Substring(3, 7);
        }
        else
        {
            txtCelLada.Text = "";
            txtCelTelef.Text = "";
        }
        txtOtroTel.Text = model.TelOtro;
        txtEmail.Text = model.Email;
        txtAlias.Text = model.Alias;
        txtCalleCasa.Text = model.CallePers;
        txtNumExtCasa.Text = model.NumExtPers;
        txtNumIntCasa.Text = model.NumIntPers;
        txtColoniaCasa.Text = model.ColoniaPers;
        txtCPCasa.Text = model.CpPers;
        ddlPais.SelectedValue = model.PaisPers;
        ddlEdoCasa.SelectedValue = model.EdoPers;
        ddlEdoPaq.SelectedValue = model.EdoEnv;
        ddlIdioma.SelectedValue = model.Idioma;
        txtMpioCasa.Text = model.MunicipioPers;
        txtCiudadCasa.Text = model.CiudadPers;
        txtCallePaq.Text = model.CalleEnv;
        txtNumExtPaq.Text = model.NumExtEnv;
        txtNumIntPaq.Text = model.NumIntEnv;
        txtColoniaPaq.Text = model.ColoniaEnv;
        txtCPPaq.Text = model.CpEnv;
        txtMpioPaq.Text = model.MunicipioEnv;
        txtCiudadPaq.Text = model.CiudadEnv;
        txtRefCasa.Text = model.ReferenciaPers;
        txtRefPaq.Text = model.ReferenciaEnv;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string msgError = string.Empty;
        msgError = validaCampos();
        if (msgError.Length == 0)
        {
            actualizaDatos();
            cellmensaje.ForeColor = System.Drawing.Color.DodgerBlue;
            btnAceptar.BackColor = System.Drawing.Color.DodgerBlue;
            cellmensaje.Text = "Actualizacion correcta.";
            modalMensaje.Show();
        }
        else
        {
            cellmensaje.ForeColor = System.Drawing.Color.Red;
            btnAceptar.BackColor = System.Drawing.Color.Red;
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }
    
    protected string validaCampos()
    {
        string mensaje = string.Empty;
        if (ddlEdoCivil.SelectedValue == "0")
            mensaje = "Selecciona Lugar de Nacimiento.</br>";
        if (ddlEdoCivil.SelectedValue == "0")
            mensaje = "Selecciona Estado Civil.</br>";
        if (ddlPais.SelectedValue == "0")
            mensaje += "Selecciona País.</br>";
        if (ddlIdioma.SelectedValue == "0")
            mensaje += "Selecciona Idioma.</br>";
        if (txtTelef.Text.Length < 2 && txtTelefLada.Text.Length < 6)
            mensaje += "Ingresa Número Telefónico.</br>";
        else
        {
            try
            {
                Convert.ToInt32(txtTelef.Text);
                Convert.ToInt32(txtTelefLada.Text);
            }
            catch (Exception)
            { mensaje += "Formato Incorrecto Telefono.</br>"; }
        }
        if (txtCelLada.Text.Length < 1 && txtCelTelef.Text.Length < 1)
            mensaje += "Ingresa Número Celular.</br>";
        else
        {
            try
            {
                Convert.ToInt32(txtCelLada.Text);
                Convert.ToInt32(txtCelTelef.Text);
            }
            catch (Exception)
            { mensaje += "Formato Incorrecto Celular.</br>"; }
        }
        if (txtEmail.Text.Length < 1)
            mensaje += "Ingresa Correo Electrónico.</br>";
        if (txtEmail.Text.Length > 0)
            if (!validaEmail(txtEmail.Text))
                mensaje += "Formato Incorrecto Correo Electrónico.</br>";
        if (txtCalleCasa.Text.Length < 1)
            mensaje += "Ingresa Calle.</br>";
        if (txtNumExtCasa.Text.Length < 1 && chkNumeroCasa.Checked.Equals(false))
            mensaje += "Ingresa Número Ext Casa.</br>";
        else
        {
            if (txtNumExtCasa.Text.Length > 0 && chkNumeroCasa.Checked.Equals(false))
            try
            { Convert.ToInt32(txtNumExtCasa.Text); }
            catch (Exception)
            { mensaje += "Formato Incorrecto en Num Ext Casa.</br>"; }
        }
        if (txtColoniaCasa.Text.Length < 1)
            mensaje += "Ingresa Colonia.</br>";
        if (txtCPCasa.Text.Length < 1)
            mensaje += "Ingresa Código Postal.</br>";
        try
        { Convert.ToInt32(txtCPCasa.Text); }
        catch (Exception)
        { mensaje += "Formato Incorrecto en CP Casa.</br>"; }
        if (txtMpioCasa.Text.Length < 1)
            mensaje += "Ingresa Municipio.</br>";
        if (txtCiudadCasa.Text.Length < 1)
            mensaje += "Ingresa Ciudad.</br>";
        if (ddlEdoCasa.SelectedValue == "0")
            mensaje += "Ingresa Estado.</br>";
        if (txtCallePaq.Text.Length < 1)
            mensaje += "Ingresa Calle Paqueteria.</br>";
        if (txtNumExtPaq.Text.Length < 1 && chkNumeroPaq.Checked.Equals(false))
            mensaje += "Ingresa Número Paqueteria </br>";
        else
        {
            if (txtNumExtPaq.Text.Length > 0 && chkNumeroPaq.Checked.Equals(false))
            {
                try
                { Convert.ToInt32(txtNumExtPaq.Text); }
                catch (Exception)
                { mensaje += "Formato Incorrecto en Num Ext Paqueteria.</br>"; }
            }
        }
        if (txtColoniaPaq.Text.Length < 1)
            mensaje += "Ingresa Colonia Paqueteria.</br>";
        if (txtCPPaq.Text.Length < 1)
            mensaje += "Ingresa Código Postal Paqueteria.</br>";
        else
        {
            try
            { Convert.ToInt32(txtCPPaq.Text); }
            catch (Exception)
            { mensaje += "Formato Incorrecto en CP Paqueteria.</br>"; }
        }
        if (txtMpioPaq.Text.Length < 1)
            mensaje += "Ingresa Municipio Paqueteria.</br>";
        if (txtCiudadPaq.Text.Length < 1)
            mensaje += "Ingresa Ciudad Paqueteria.</br>";
        if (ddlEdoPaq.SelectedValue == "0")
            mensaje += "Ingresa Estado Paqueteria.</br>";

        return mensaje;
    }

    protected void actualizaDatos()
    {
        MisDatosPersonalesAction actionDetalle = new MisDatosPersonalesAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        
        model.LugarNacimiento = ddlLugarNacim.SelectedValue;
        model.EdoCivil = ddlEdoCivil.SelectedValue;
        model.RFC = txtRfc.Text.ToUpper();
        model.Curp = txtCurp.Text.ToUpper();
        model.Compania = txtCompania.Text.ToUpper();
        model.Telefono = txtTelefLada.Text;
        model.Telefono += txtTelef.Text;
        model.Celular = txtCelLada.Text;
        model.Celular += txtCelTelef.Text;
        model.TelOtro = txtOtroTel.Text;
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
        model.CiudadPers = txtCiudadCasa.Text.ToUpper();
        model.EdoPers = ddlEdoCasa.SelectedValue;
        model.CalleEnv = txtCallePaq.Text.ToUpper();
        if (chkNumeroPaq.Checked.Equals(true))
            model.NumExtEnv = "S/n";
        else if (chkNumeroPaq.Checked.Equals(false))
            model.NumExtEnv = txtNumExtPaq.Text;
        model.NumExtEnv = txtNumExtPaq.Text;
        model.NumIntEnv = txtNumIntPaq.Text;
        model.ColoniaEnv = txtColoniaPaq.Text.ToUpper();
        model.CpEnv = txtCPPaq.Text;
        model.MunicipioEnv = txtMpioPaq.Text.ToUpper();
        model.CiudadEnv = txtCiudadPaq.Text.ToUpper();
        model.EdoEnv = ddlEdoPaq.SelectedValue;
        model.ReferenciaPers = txtRefCasa.Text;
        model.ReferenciaEnv = txtRefPaq.Text;
        model.IdUsuario = _idAsociado;
        actionDetalle.ActualizaDatos(model);
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected void chkDirecccion_Changed(object sender, EventArgs e)
    {
        if (chkDireccion.Checked.Equals(true))
        {
            txtCallePaq.Text = txtCalleCasa.Text;
            txtNumExtPaq.Text = txtNumExtCasa.Text;
            txtNumIntPaq.Text = txtNumIntCasa.Text;
            txtColoniaPaq.Text = txtColoniaCasa.Text;
            txtCPPaq.Text = txtCPCasa.Text;
            txtMpioPaq.Text = txtMpioCasa.Text;
            txtCiudadPaq.Text = txtCiudadCasa.Text;
            txtColoniaCasa.Text = txtCiudadPaq.Text;
            ddlEdoPaq.SelectedValue = ddlEdoCasa.SelectedValue;
            chkNumeroPaq.Checked = chkNumeroCasa.Checked;
            txtRefPaq.Text = txtRefCasa.Text;
            txtCallePaq.Enabled = false;
            txtNumExtPaq.Enabled = false;
            txtNumIntPaq.Enabled = false;
            txtColoniaPaq.Enabled = false;
            txtCPPaq.Enabled = false;
            txtMpioPaq.Enabled = false;
            txtCiudadPaq.Enabled = false;
            ddlEdoPaq.Enabled = false;
            chkNumeroPaq.Enabled = false;
            txtRefPaq.Enabled = false;
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
            txtRefPaq.Enabled = true;
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "misDatosPersonales", new string[] { "EditaDatos" });
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
}