using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_PopUp_InformacionProspecto : System.Web.UI.Page
{
    private string _idProspecto;
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
            throw new Exception("Error en InformaciónProspecto " + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "INFORMACIÓN PROSPECTO";
            CargaDatos(_idProspecto);
        }
    }

    private void CargaDatos(string idProspecto)
    {
        AltaProspectoAction action = new AltaProspectoAction();
        MisDatosPersonalesModel model = action.DatosProspecto(idProspecto);
        lblNombre.Text = model.Nombre;
        lblFecNac.Text = model.FechaNacimiento.ToString("dd/MMMM/yyyy").ToUpper();
        lblLugarNac.Text = model.LugarNacimiento;
        lblRfc.Text = model.RFC;
        lblCurp.Text = model.Curp;
        lblEdoCivil.Text = model.EdoCivil;
        lblTelef.Text = model.Telefono;
        lblCel.Text = model.Celular;
        lblOtroTel.Text = model.TelOtro;
        lblEmail.Text = model.Email;
        lblCompania.Text = model.Compania;
        lblPais.Text = model.PaisPers;
        lblIdioma.Text = model.Idioma;
        if (model.TipoAsociado.Equals("1"))
            lblTipoProsp.Text = "ASOCIADO";
        else if (model.TipoAsociado.Equals("2"))
            lblTipoProsp.Text = "CONSUMIDOR";
        lblCallePers.Text = model.CallePers;
        lblExtPers.Text = model.NumExtPers;
        lblIntPers.Text = model.NumIntPers;
        lblColPers.Text = model.ColoniaPers;
        lblMpioPers.Text = model.MunicipioPers;
        lblCpPers.Text = model.CpPers;
        lblCiudPers.Text = model.CiudadPers;
        lblEdoPers.Text = model.EdoPers;
        lblCalleEnv.Text = model.CalleEnv;
        lblExtEnv.Text = model.NumExtEnv;
        lblIntEnv.Text = model.NumIntEnv;
        lblColEnv.Text = model.ColoniaEnv;
        lblMpioEnv.Text = model.MunicipioEnv;
        lblCpEnv.Text = model.CpEnv;
        lblCiudEnvio.Text = model.CiudadEnv;
        lblEdoEnv.Text = model.EdoEnv;
    }

    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        string nuevo = "1";
        NavegacionSegura.navega(this, "ArbolColocacion", new string[] { nuevo, "InfoProspecto" });
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "EditaProspecto", new string[] { _idProspecto, "InfoProspecto" });
    }
}