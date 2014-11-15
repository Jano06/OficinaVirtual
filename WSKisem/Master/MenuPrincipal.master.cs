using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.IO;

public partial class Master_MenuPrincipal : System.Web.UI.MasterPage
{
    private static readonly ILog _Logger = LogManager.GetLogger(typeof(Master_MenuPrincipal));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            _Logger.Error("La sesión de usuario ha caducado");
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }

        if (!IsPostBack)
        {
            try
            {
                string User = Session["User"].ToString();
                int idUsuario = int.Parse(Session["idUser"].ToString());

                lblAsociado.Text = User;
                lblNumAsociado.Text = idUsuario.ToString();
            }
            catch (Exception ex)
            {
                _Logger.Error("Error al construir Master Principal " + ex.Message);
                throw new Exception("Error en Master Page MenuPrincipal" + ex.Message);
            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        Page.Title = "KISEM . Software de Administración";
    }

    protected void click_CerrarSesion(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
