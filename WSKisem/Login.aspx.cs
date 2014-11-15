using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

public partial class views_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetFocus(txtUsuario);
    }

    protected void click_BtnEntrar(object sender, EventArgs e)
    {
        if (txtUsuario.Text.Length.Equals(0) && txtPassword.Text.Length.Equals(0))
        {
            lblMensaje.Text = "Ingrese número de asociado y contraseña";
        }
        else
        {
            string asocKisem = txtUsuario.Text.Trim(); //elimina espacios del usuario y los asigna a asocKisem
            LoginAction action = new LoginAction();
            LoginModel model = new LoginModel();

            model = action.ConsultUser(txtUsuario.Text, txtPassword.Text);

            if (model.Iduser == 0 || model.User == string.Empty)
            {
                lblMensaje.Text = "Usuario o Contraseña Incorrectos";
                this.limpiar();
            }
            else
            {
                Session.Add("User", model.User);
                Session.Add("IdUser", model.Iduser);
                Response.Redirect("~/views/Inicio/Principal.aspx");
            }
        }
    }

    public void limpiar()
    {
        txtUsuario.Text = "";
        txtPassword.Text = "";
    }

}