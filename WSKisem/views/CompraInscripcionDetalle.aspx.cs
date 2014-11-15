using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using log4net;

public partial class views_CompraInscripcionDetalle : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_CompraInscripcionDetalle));
    private string _paquete;
    private string _padre;
    private string _lado;
    private string _idProspecto;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string padre = Request.QueryString["padre"].ToString();
            _padre = Encriptador.desencriptar(padre);
            string lado = Request.QueryString["lado"].ToString();
            _lado = Encriptador.desencriptar(lado);
            string paquete = Request.QueryString["paquete"].ToString();
            _paquete = Encriptador.desencriptar(paquete);
            string idProspecto = Request.QueryString["idProsp"].ToString();
            _idProspecto = Encriptador.desencriptar(idProspecto);
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar Paquete " + ex.Message);
            throw new Exception("Error en NuevaCompraDetalle" + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "DETALLE COMPRA";
            LlenaDatos(_idProspecto);
            btnContinuar.Enabled = true;
            ddlEntrega.Enabled = true;
        }
    }

    protected void LlenaDatos(string idUser)
    {
        ComprasAction action = new ComprasAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        model = action.consDatosProspecto(idUser);
        //lblId.Text = model.IdUsuario;
        lblNombre.Text = model.Nombre;
        lblDomicilio.Text = model.CallePers + " # " + model.NumExtPers;
        lblColonia.Text = model.ColoniaPers;
        lblCP.Text = model.CpPers;
        lblMpio.Text = model.MunicipioPers;
        lblEdo.Text = model.EdoPers;
        lblTitulo.Text = "Verifica datos prospecto y selecciona el modo de entrega";
        btnContinuar.Enabled = true;
        ddlEntrega.Enabled = true;
        pnlDetalleCompra.Visible = false;
    }

    protected void LlenaDatosDomicilio(string idUser)
    {
        ComprasAction action = new ComprasAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        model = action.consDatosDomProsp(idUser);
        //lblId.Text = model.IdUsuario;
        lblNombre.Text = model.Nombre;
        lblDomicilio.Text = model.CalleEnv + " #" + model.NumExtEnv;
        lblColonia.Text = model.ColoniaEnv;
        lblCP.Text = model.CpEnv;
        lblMpio.Text = model.MunicipioEnv;
        lblEdo.Text = model.EdoEnv;
        lblTitulo.Text = "Verifica datos de envío de paquetería del prospecto y selecciona el modo de entrega";
        btnContinuar.Enabled = true;
    }

    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        string msgError = string.Empty;
        msgError = validaCampos();
        if (msgError.Length == 0)
        {
            lblTitulo.Text = "Verifica el detalle de la compra";

            if (ddlEntrega.SelectedValue.Equals("MOSTRADOR"))
            {
                trEnvio.Visible = false;
                LlenaDetalleCompra(_paquete);
            }
            else if (ddlEntrega.SelectedValue.Equals("DOMICILIO"))
            {
                trEnvio.Visible = true;
                LlenaDatosDomicilio(_idProspecto);
                lblTitulo.Text = "Verifica datos de domicilio de envío y el detalle de la compra";
                LlenaDetalleEnvio(_paquete);
            }
            pnlDetalleCompra.Visible = true;
            btnContinuar.Visible = false;
            btnCancelar1.Visible = false;
            ddlEntrega.Enabled = false;
            txtObesrvac.Enabled = false;
        }
        else
        {
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }

    private void LlenaDetalleCompra(string paquete)
    {
        ComprasAction action = new ComprasAction();
        List<string> detallePaq = new List<string>();
        List<string> detalleInsc = new List<string>();
        detallePaq = action.DetallePaq(paquete);
        detalleInsc = action.DetalleInscr();
        lblPaquete.Text = detallePaq[0];
        lblPUnit.Text = Convert.ToDouble(detallePaq[1]).ToString("c");
        lblMonto.Text = Convert.ToDouble(detallePaq[1]).ToString("n2");

        lblInscripcion.Text = detalleInsc[0];
        double costoInscr = Convert.ToDouble(detalleInsc[1]);
        double inscrSinIva = (costoInscr / Convert.ToDouble(ConfigurationManager.AppSettings["ivaDesgloce"].ToString()));
        lblPUnitInscr.Text = inscrSinIva.ToString("c");
        lblMontoInscr.Text = inscrSinIva.ToString("n2");
        double subTotal = (Convert.ToDouble(detallePaq[1]) + inscrSinIva);
        lblSubTotal.Text = subTotal.ToString("n2");
        double ivaDesglozado = (inscrSinIva * Convert.ToDouble(ConfigurationManager.AppSettings["iva"].ToString()));
        lblIva.Text = ivaDesglozado.ToString("n2");
        lblTotal.Text = (ivaDesglozado + subTotal).ToString("n2");
    }

    private void LlenaDetalleEnvio(string paquete)
    {
        ComprasAction action = new ComprasAction();
        List<string> detallePaq = new List<string>();
        List<string> detalleInsc = new List<string>();
        detallePaq = action.DetallePaq(paquete);
        detalleInsc = action.DetalleInscr();
        lblPaquete.Text = detallePaq[0];
        lblPUnit.Text = Convert.ToDouble(detallePaq[1]).ToString("c");
        lblMonto.Text = Convert.ToDouble(detallePaq[1]).ToString("n2");
        //Llena Inscripcion
        lblInscripcion.Text = detalleInsc[0];
        double costoEnvio = Convert.ToDouble(detalleInsc[1]);
        double inscrSinIva = (costoEnvio / Convert.ToDouble(ConfigurationManager.AppSettings["ivaDesgloce"].ToString()));
        lblPUnitInscr.Text = inscrSinIva.ToString("c");
        lblMontoInscr.Text = inscrSinIva.ToString("n2");
        //Llena Envio
        lblEnvio.Text = "Envio";
        double costoInscr = action.DetalleEnvio();
        double envioSinIva = (costoInscr / Convert.ToDouble(ConfigurationManager.AppSettings["ivaDesgloce"].ToString()));
        lblPUnitEnvio.Text = envioSinIva.ToString("c");
        lblTotalEnvio.Text = envioSinIva.ToString("n2");
        //Sumas
        double subTotal = (Convert.ToDouble(detallePaq[1]) + envioSinIva + inscrSinIva);
        lblSubTotal.Text = subTotal.ToString("n2");
        double ivaDesglozado = (envioSinIva * Convert.ToDouble(ConfigurationManager.AppSettings["iva"].ToString()) + inscrSinIva * Convert.ToDouble(ConfigurationManager.AppSettings["iva"].ToString()));
        lblIva.Text = ivaDesglozado.ToString("n2");
        lblTotal.Text = (ivaDesglozado + subTotal).ToString("n2");
    }

    private string validaCampos()
    {
        string error = string.Empty;
        if (ddlEntrega.SelectedValue.Equals("0"))
        {
            error = "Selecciona el tipo de Entrega";
        }
        return error;
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected void btnCancelar1_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "CompraInscripcion", new string[] { _padre, _lado, "CompraInscrDetalle" });
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        ProcesaCompra(Session["idUser"].ToString());
    }

    private void ProcesaCompra(string idAsociado)
    {
        ComprasAction action = new ComprasAction();
        EmailAction email = new EmailAction();
        AltaProspectoAction actualiza = new AltaProspectoAction();
        double inscripcion = 0;
        ComprasModel compra = new ComprasModel();
        compra.Asociado = Session["idUser"].ToString();
        compra.Paquete = Convert.ToInt32(_paquete);
        compra.Total = Convert.ToDouble(lblTotal.Text);
        compra.StatusPago = "PENDIENTE";
        compra.TipoPago = "DEPÓSITO BANCARIO";
        compra.FechaOrden = DateTime.Today;
        compra.TipoEntrega = ddlEntrega.SelectedValue;
        compra.Autor = "OV";
        compra.Cantidad = 1;
        compra.InicioActivacion = DateTime.Today;
        compra.Costo = Convert.ToDouble(lblMonto.Text);
        compra.Observacion = txtObesrvac.Text.ToUpper();
        compra.Iva = Convert.ToDouble(lblIva.Text);
        inscripcion = Convert.ToDouble(lblMontoInscr.Text);
        compra.StatusEntrega = "PENDIENTE";
        if (ddlEntrega.SelectedValue.Equals("DOMICILIO"))
        {
            compra.Envio = Convert.ToDouble(lblTotalEnvio.Text);
        }

        action.insertaCompraProspecto(compra, _idProspecto);
        action.InsertaDetalleCompraProsp(compra, inscripcion);
        email.CorreoCompraProspecto(compra,_idProspecto);
        actualiza.actualizaProspecto(_idProspecto, _padre, _lado);
        NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
    }

    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        pnlDetalleCompra.Visible = false;
        btnContinuar.Visible = true;
        ddlEntrega.Enabled = true;
        btnCancelar1.Visible = true;
        txtObesrvac.Enabled = true;
        ddlEntrega.SelectedValue = "0";
    }
}