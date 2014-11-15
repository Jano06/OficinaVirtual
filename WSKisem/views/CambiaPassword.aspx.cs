using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_CambiaPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "CAMBIO DE CONTRASEÑA";
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        CambiaPasswordAction action = new CambiaPasswordAction();
        string msgError = validaCampos();
        if (msgError.Length == 0)
        {
            if (action.ActualizaPassword(txtContrasenaRepetir.Text, Session["idUser"].ToString()))
            {
                cellmensaje.ForeColor = System.Drawing.Color.DodgerBlue;
                btnAceptar.BackColor = System.Drawing.Color.DodgerBlue;
                cellmensaje.Text = "Contraseña Actualizada";
                modalMensaje.Show();
            }
            else
            {
                cellmensaje.ForeColor = System.Drawing.Color.Red;
                cellmensaje.Text = "Error al actualizar Contraseña";
                modalMensaje.Show();
            }
        }
        else
        {
            cellmensaje.ForeColor = System.Drawing.Color.Red;
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }

    private string validaCampos()
    {
        string mensaje = string.Empty;
        string contraseñaAnterior = txtContrasenaAnterior.Text.Trim();
        CambiaPasswordAction action = new CambiaPasswordAction();
        if (!(action.ChecaPassword(Session["idUser"].ToString()).Equals(contraseñaAnterior)))
        {
            mensaje += "Contraseña anterior incorrecta.<br />";
        }
        
        if (!(txtContrasenaNueva.Text.Equals(txtContrasenaRepetir.Text)))
        {
            mensaje += "Comprobar contraseña.<br />";
        }
        return mensaje;
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }
}