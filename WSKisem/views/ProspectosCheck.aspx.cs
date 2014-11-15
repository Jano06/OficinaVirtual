using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_ProspectosCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            ComprasAction action = new ComprasAction();
            if (action.Prospectos(Session["idUser"].ToString()).Equals(0))
            {
                NavegacionSegura.navega(this, "NuevaCompra", new string[] { "ProspectosCheck" });
            }
            else
            {
                lblTitlePrincipal.Text = "TIPO DE COMPRA";
                
            }
            chkInscripcion.Checked = false;
            chkCompra.Checked = false;
        }
    }

    protected void chkResultado_CheckedChange(object sender, EventArgs e)
    {
        if (chkInscripcion.Checked)
        {
            string nuevo = "1";
            NavegacionSegura.navega(this, "ArbolColocacion", new string[] { nuevo, "ProspectosCheck" });
        }
        else if (chkCompra.Checked)
        {
            NavegacionSegura.navega(this, "NuevaCompra", new string[] { "ProspectosCheck" });
        }
    }
}