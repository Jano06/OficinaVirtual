using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using log4net;


public partial class views_NuevaCompraComprobante : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_NuevaCompraComprobante));
    private string _referencia;
    private string _total;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string referencia = Request.QueryString["referencia"].ToString();
            _referencia = Encriptador.desencriptar(referencia);
            string total = Request.QueryString["total"].ToString();
            _total = Encriptador.desencriptar(total);
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar Referencia " + ex.Message);
            throw new Exception("Error en NuevaCompraComprobante" + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "COMPROBANTE COMPRA";
            lblRefBanorte.Text = _referencia;
            lblRefScotian.Text = _referencia;
            lblImporte.Text = Convert.ToDouble(_total).ToString("c");
            MuestraMensajeCompra();
        }
    }

    private void MuestraMensajeCompra()
    {
        EmailAction action = new EmailAction();
        string msj = action.ConsMensajeCompra();
        litGracias.Text = msj;
    }
}