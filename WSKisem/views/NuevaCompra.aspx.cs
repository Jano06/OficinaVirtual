using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using log4net;

public partial class views_NuevaCompra : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_NuevaCompra));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "COMPRAS";
            precioPaquete();
        }
    }

    private void precioPaquete()
    {
        ComprasAction action = new ComprasAction();
        List<string> detalleCompra = new List<string>();
        detalleCompra = action.ConsPrecioPqt("1");
        lblPrecioPqt1.Text = detalleCompra[1];
        lblTitlPqt1.Text = detalleCompra[0].ToUpper();
        detalleCompra = action.ConsPrecioPqt("2");
        lblPrecioPqt2.Text = detalleCompra[1];
        lblTitlPqt2.Text = detalleCompra[0].ToUpper();
        detalleCompra = action.ConsPrecioPqt("3");
        lblPrecioPqt3.Text = detalleCompra[1];
        lblTitlPqt3.Text = detalleCompra[0].ToUpper();
    }

    protected void imgBtnConsumidor_Click(object sender, ImageClickEventArgs e)
    {
        string paquete = "1";
        NavegacionSegura.navega(this, "NuevaCompraDetalle", new string[] { paquete, "NuevaCompra" });
    }

    protected void imgBtnEmprendedor_Click(object sender, ImageClickEventArgs e)
    {
        string paquete = "2";
        NavegacionSegura.navega(this, "NuevaCompraDetalle", new string[] { paquete, "NuevaCompra" });
    }

    protected void imgBtnEmpresarial_Click(object sender, ImageClickEventArgs e)
    {
        string paquete = "3";
        NavegacionSegura.navega(this, "NuevaCompraDetalle", new string[] { paquete, "NuevaCompra" });
    }
}