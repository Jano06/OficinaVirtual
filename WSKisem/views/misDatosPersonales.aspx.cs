using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_misDatosPersonales : System.Web.UI.Page
{
    private int _idAsociado;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "DATOS PERSONALES";
            _idAsociado = int.Parse(Session["idUser"].ToString());
            llenaDatos(_idAsociado);
        }
    }

    private void llenaDatos(int idAsociado)
    {
        MisDatosPersonalesModel datos = new MisDatosPersonalesModel();
        MisDatosPersonalesAction action = new MisDatosPersonalesAction();

        datos = action.ConsultaDatos(idAsociado);
        lblNombre.Text = datos.Nombre + " " + datos.ApPaterno + " " + datos.ApMaterno;
        lblFechaNac.Text = datos.FechaNacimiento.ToString("dd/MMMM/yyyy").ToUpper();
        lblLugarNac.Text = datos.LugarNacimiento;
        lblFechaIngreso.Text = datos.FechaIngreso;
        lblRFC.Text = datos.RFC;
        lblCurp.Text = datos.Curp;
        lblTelefono.Text = datos.Telefono;
        lblCelular.Text = datos.Celular;
        lblOtroTel.Text = datos.TelOtro;
        lblEmail.Text = datos.Email;
        lblRetención.Text = datos.TipoRetencion;
        lblEdoCivil.Text = datos.EdoCivil;
        lblUsuario.Text = datos.IdUsuario;
        lblAlias.Text = datos.Alias;
        lblPassword.Text = datos.Password;
        lblTipoAsoc.Text = datos.TipoAsociado;
        lblPaisPers.Text = datos.PaisPers;
        lblPaisEnv.Text = datos.PaisPers;
        lblCallePers.Text = datos.CallePers;
        lblCalleEnv.Text = datos.CalleEnv;
        lblNumExtPers.Text = datos.NumExtPers;
        lblNumExtEnv.Text = datos.NumExtEnv;
        lblNumIntPers.Text = datos.NumIntPers;
        lblNumIntEnv.Text = datos.NumIntEnv;
        lblColoniaPers.Text = datos.ColoniaPers;
        lblColoniaEnv.Text = datos.ColoniaEnv;
        lblMunicipioPers.Text = datos.MunicipioPers;
        lblMunicipioEnv.Text = datos.MunicipioEnv;
        lblCiudadPers.Text = datos.CiudadPers;
        lblCiudadEnv.Text = datos.CiudadEnv;
        lblEdoPers.Text = datos.EdoPers;
        lblEdoEnv.Text = datos.EdoEnv;
        lblCPPers.Text = datos.CpPers;
        lblCPEnv.Text = datos.CpEnv;
        lblBodega.Text = datos.Bodega;
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        string parameter;
        parameter = Session["idUser"].ToString();
        NavegacionSegura.navega(this, "EditaDatos", new string[] { parameter, "misDatosPersonales" });
    }
}