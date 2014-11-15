using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class views_miOrganizacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "MI ORGANIZACIÓN";
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            if (Session["GridViewMiOrganizacion"] != null)
            { ConsultaOrganizacion(); }
            else
            {
                Session["GridViewMiOrganizacion"] = null;
                Session["fechaOrganizacion"] = null;
                Session["statusOrganizacion"] = null;
            }
        }
    }

    protected void ConsultaOrganizacion()
    {
        string fecha;
        OrganizacionAction action = new OrganizacionAction();
        List<OrganizacionModel> lista = new List<OrganizacionModel>();
        txtFecha.Text = Session["fechaOrganizacion"].ToString();
        ddlStatus.SelectedValue = Session["statusOrganizacion"].ToString();
        fecha = txtFecha.Text.Substring(6, 4) + "/" + txtFecha.Text.Substring(3, 2) + "/" + txtFecha.Text.Substring(0, 2);
        lista = action.ConsultaOrganizacion(int.Parse(Session["idUser"].ToString()), fecha, ddlStatus.SelectedValue);
        gvdMiOrganizacion.DataSource = lista;
        gvdMiOrganizacion.DataBind();
        Session.Add("GridViewMiOrganizacion", gvdMiOrganizacion);
        Session.Add("fechaOrganizacion", txtFecha.Text);
        Session.Add("statusOrganizacion", ddlStatus.SelectedValue);
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string msgError = string.Empty;
        msgError = validaCampos();
        if (msgError.Length == 0)
        {
            DateTime fecha = new DateTime();
            OrganizacionAction action = new OrganizacionAction();
            List<OrganizacionModel> ListGetDataOrganization = new List<OrganizacionModel>();

            //fecha = txtFecha.Text.Substring(6, 4) + "/" + txtFecha.Text.Substring(3, 2) + "/" + txtFecha.Text.Substring(0, 2);
            fecha = Convert.ToDateTime(txtFecha.Text);
            ListGetDataOrganization = action.ConsultaOrganizacion(int.Parse(Session["idUser"].ToString()), fecha.ToString("yyyy/MM/dd"), ddlStatus.SelectedValue);

            if (ListGetDataOrganization.Count != 0)
            {
                //Activar boton para exportar a Excel
            }
            gvdMiOrganizacion.DataSource = ListGetDataOrganization;
            gvdMiOrganizacion.PageIndex = 0;
            gvdMiOrganizacion.DataBind();

            Session.Add("GridViewMiOrganizacion", gvdMiOrganizacion);
            Session.Add("fechaOrganizacion", txtFecha.Text);
            Session.Add("statusOrganizacion", ddlStatus.SelectedValue);
        }
        else
        {
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }

    protected string validaCampos()
    {
        string mensaje = string.Empty;
        if (txtFecha.Text.Length < 1)
            mensaje += "Ingresa Fecha";
        return mensaje;
    }
}