using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

public partial class views_DetalleCompra : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_DetalleCompra));
    private string _idCompra; 
    private string _periodo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string ordenCompra = Request.QueryString["idCorte"].ToString();
            _idCompra = Encriptador.desencriptar(ordenCompra);
            string periodoCompra = Request.QueryString["periodo"].ToString();
            _periodo = Encriptador.desencriptar(periodoCompra);
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar idCorte " + ex.Message);
            throw new Exception("Error en DetalleCompra" + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "DETALLE COMPRA";
            CargarDetalleCompra(_idCompra, Session["idUser"].ToString(), _periodo);
        }
    }

    protected void CargarDetalleCompra(string idCompra, string idAsociado, string periodo)
    {
        DetalleCompraModel model = new DetalleCompraModel();
        MisComprasAction action = new MisComprasAction();

        model = action.ConsultaDetalleCompra(int.Parse(idCompra), int.Parse(idAsociado), periodo);
        lblIdOrden.Text = model.IdOrden;
        lblNumDistr.Text = model.NoDistribuidor;
        lblNombre.Text = model.Nombre;
        lblDirecEnvio.Text = model.Direccion;
        lblDireccionEnvio2.Text = model.DireccionColonia;
        lblFechaOrden.Text = model.FechaOrden;
        lblFechaPago.Text = model.FechaPago;
        lblOrigen.Text = model.OrigenOrden;
        lblPeriodo.Text = model.Periodo;
        lblStatus.Text = model.StatusOrden;
        lblOperador.Text = model.Operador;
        lblCodigoArt.Text = model.CodigoArt;
        lblDescripcion.Text = model.DescripcArt;
        lblCantidad.Text = model.CantArt.ToString();
        lblPuntos.Text = model.Puntos.ToString("n0");
        lblPrecioUnit.Text = model.PrecioUnit.ToString("c");
        lblTotal.Text =  model.Total.ToString("c");
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "misCompras", new string[] { "DetalleCompra" });
    }
}