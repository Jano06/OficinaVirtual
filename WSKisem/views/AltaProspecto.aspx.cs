using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class views_AltaProspecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "ALTA PROSPECTO";
            CargaGrid();
        }
    }

    private void CargaGrid()
    {
        AltaProspectoAction action = new AltaProspectoAction();
        List<MiProspectoModel> lista = action.cargaProspectos(Session["idUser"].ToString());
        gvdProspectos.DataSource = lista;
        gvdProspectos.DataBind();
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        AltaProspectoAction action = new AltaProspectoAction();

        string error = validaDatos();

        if (error.Length == 0)
        {
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
                model.NumExtPers = chkNumeroCasa.Text;
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
                model.NumExtEnv = chkNumeroPaq.Text;
            else if(chkNumeroPaq.Checked.Equals(false))
                model.NumExtEnv = txtNumExtPaq.Text;
            model.NumIntEnv = txtNumIntPaq.Text;
            model.ColoniaEnv = txtColoniaPaq.Text.ToUpper();
            model.CpEnv = txtCPPaq.Text;
            model.MunicipioEnv = txtMpioPaq.Text.ToUpper();
            model.CiudadEnv = txtCiudadPaq.Text.ToUpper();
            model.EdoEnv = ddlEdoPaq.SelectedValue;
            model.ReferenciaEnv = txtRefPaq.Text;
            model.TipoAsociado = rbtnTipo.SelectedValue;
            string idProspecto = action.InsertaProspecto(model);
            NavegacionSegura.navega(this, "InfoProspecto", new string[] { idProspecto, "AltaProspecto" });
        }
        else
        {
            cellmensaje.Text = error;
            modalMensaje.Show();
        }
       
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
        if (txtConfEmail.Text.Length < 1)
            msgError += "Confirmación correo.</br>";
        if (!(txtEmail.Text.Trim() == txtConfEmail.Text.Trim()))
            msgError += "No coinciden correos.</br>";
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
            chkNumeroPaq.Checked = false;
            txtRefPaq.Enabled = true;
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
        Response.Redirect("~/views/ContratoProspecto.aspx");
    }

    protected void imgBtnEditar_Click(object sender, EventArgs e)
    {
        ImageButton imgbtnEditar;
        GridViewRow gvdProsp;
        Label lblIdProspecto;
        string idProspecto;

        imgbtnEditar = (ImageButton)sender;
        gvdProsp = (GridViewRow)imgbtnEditar.Parent.Parent;
        lblIdProspecto = (Label)gvdProsp.FindControl("lblIdProspecto");
        idProspecto = lblIdProspecto.Text.Trim();
        NavegacionSegura.navega(this, "EditaProspecto", new string[] { idProspecto, "Prospecto" });
    }

    protected void imgBtnEliminar_Click(object sender, EventArgs e)
    {
        ImageButton ImgEliminar;
        GridViewRow gvdProsp;
        Label lblIdProspecto;
        string idProspecto;
        
        ImgEliminar = (ImageButton)sender;
        gvdProsp = (GridViewRow)ImgEliminar.Parent.Parent;
        lblIdProspecto = (Label)gvdProsp.FindControl("lblIdProspecto");
        idProspecto = lblIdProspecto.Text.Trim();
        AltaProspectoAction action = new AltaProspectoAction();
        action.EliminaProspecto(idProspecto);
        cellmensaje.Text = "Prospecto Eliminado";
        modalMensaje.Show();
        CargaGrid();
    }
}