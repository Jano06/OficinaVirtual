using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using log4net;

public partial class views_NuevaCompraDetalle : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_NuevaCompraDetalle));
    private string _paquete;

    ComprasModel compra = new ComprasModel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string corte = Request.QueryString["paquete"].ToString();
            _paquete = Encriptador.desencriptar(corte);
            Session["CompraPaquete"] = _paquete;
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar Paquete " + ex.Message);
            throw new Exception("Error en NuevaCompraDetalle" + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "DETALLE COMPRA";
            LlenaDatos(Session["idUser"].ToString());
            btnContinuar.Enabled = true;
            ddlEntrega.Enabled = true;
        }
    }

    protected void LlenaDatos(string idUser)
    {
        ComprasAction action = new ComprasAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        model = action.consDatos(idUser);
        lblId.Text = model.IdUsuario;
        lblNombre.Text = model.Nombre;
        lblDomicilio.Text = model.CallePers + " #" + model.NumExtPers;
        lblColonia.Text = model.ColoniaPers;
        lblCP.Text = model.CpPers;
        lblMpio.Text = model.MunicipioPers;
        lblEdo.Text = model.EdoPers;
        lblTitulo.Text = "Verifica tus datos y selecciona el modo de entrega";
        btnContinuar.Enabled = true;
        ddlEntrega.Enabled = true;
        pnlDetalleCompra.Visible = false;
        pnlConfirma.Visible = false;
    }

    protected void LlenaDatosDomicilio(string idUser)
    {
        ComprasAction action = new ComprasAction();
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        model = action.consDatosDomicilio(idUser);
        lblId.Text = model.IdUsuario;
        lblNombre.Text = model.Nombre;
        lblDomicilio.Text = model.CalleEnv + " #" + model.NumExtEnv;
        lblColonia.Text = model.ColoniaEnv;
        lblCP.Text = model.CpEnv;
        lblMpio.Text = model.MunicipioEnv;
        lblEdo.Text = model.EdoEnv;
        lblTitulo.Text = "Verifica tus datos de envío de paquetería y selecciona el modo de entrega";
        btnContinuar.Enabled = true;
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
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
            else if(ddlEntrega.SelectedValue.Equals("DOMICILIO"))
            {
                trEnvio.Visible = true;
                LlenaDatosDomicilio(Session["idUser"].ToString());
                lblTitulo.Text = "Verifica datos de domicilio de envío y el detalle de la compra";
                LlenaDetalleEnvio(_paquete);
            }
            pnlDetalleCompra.Visible = true;
            pnlConfirma.Visible = false;
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

    private string validaCampos()
    {
        string error = string.Empty;
        if (ddlEntrega.SelectedValue.Equals("0"))
        {
            error = "Selecciona el tipo de Entrega";
        }
        return error;
    }

    private void LlenaDetalleCompra(string paquete)
    {
        ComprasAction action = new ComprasAction();
        List<string> detalle = new List<string>();
        detalle = action.DetallePaq(paquete);
        lblPaquete.Text = detalle[0];
        lblPUnit.Text = Convert.ToDouble(detalle[1]).ToString("c");
        lblMonto.Text = Convert.ToDouble(detalle[1]).ToString("n2");
        lblSubTotal.Text = Convert.ToDouble(detalle[1]).ToString("n2");
        lblIva.Text = "0.00";
        lblTotal.Text = Convert.ToDouble(detalle[1]).ToString("n2");
    }

    private void LlenaDetalleEnvio(string paquete)
    {
        ComprasAction action = new ComprasAction();
        List<string> detalle = new List<string>();
        detalle = action.DetallePaq(paquete);
        lblPaquete.Text = detalle[0];
        lblPUnit.Text = Convert.ToDouble(detalle[1]).ToString("c");
        lblMonto.Text = Convert.ToDouble(detalle[1]).ToString("n2");
        lblEnvio.Text = "Envio";
        double costoEnvio = action.DetalleEnvio();
        double envioSinIva = (costoEnvio / Convert.ToDouble(ConfigurationManager.AppSettings["ivaDesgloce"].ToString()));
        lblPUnitEnvio.Text = envioSinIva.ToString("c");
        lblTotalEnvio.Text = envioSinIva.ToString("n");
        double subTotal = (Convert.ToDouble(detalle[1]) + envioSinIva);
        lblSubTotal.Text = subTotal.ToString("n");
        double ivaDesglozado = (envioSinIva * Convert.ToDouble(ConfigurationManager.AppSettings["iva"].ToString()));
        lblIva.Text = ivaDesglozado.ToString("n");
        lblTotal.Text = (ivaDesglozado + subTotal).ToString("n");
    }

    protected void btnCancelar1_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "NuevaCompra", new string[] { "NuevaCompraDetalle" });
    }

    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        pnlDetalleCompra.Visible = false;
        btnContinuar.Visible = true;
        txtObesrvac.Enabled = true;
        ddlEntrega.Enabled = true;
        btnCancelar1.Visible = true;
        ddlEntrega.SelectedValue = "0";
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        ProcesaCompra(Session["idUser"].ToString());
        rbtnTipoCompra.ClearSelection();
    }

    private void ProcesaCompra(string idAsociado)
    {
        ComprasAction action = new ComprasAction();
        EmailAction email = new EmailAction();

        compra = new ComprasModel();
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
        compra.StatusEntrega = "PENDIENTE";
        if (ddlEntrega.SelectedValue.Equals("DOMICILIO"))
        {
            compra.Envio = Convert.ToDouble(lblTotalEnvio.Text);
            compra.Iva = Convert.ToDouble(lblIva.Text);
        }
        
        proxCompraModel model = action.ConsSemanaActivacion(idAsociado);

        if(model.Status.Equals("ACTIVO"))
        {
            if (DateTime.Today >= model.RangoDesde && DateTime.Today <= model.RangoHasta) //Semana de Activacion
            {
                if (DateTime.Today >= model.Calificacion) //Tomar en automático la compra como activación
                {
                    if (model.Status.Equals("ACTIVO")) //Compra excedente
                    {
                        action.insertaCompraActivo(compra, 0, 1, null, 0);
                        action.InsertaDetalleCompra(compra);
                        email.CorreoCompra(compra);
                        NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
                    }
                    else
                    {
                        action.insertaCompraActivo(compra, 1, 0, model, 0); //Compra Activación
                        action.InsertaDetalleCompra(compra);
                        email.CorreoCompra(compra);
                        NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
                    }
                }
                else //(Excedente / Activacion)
                {
                    pnlConfirma.Visible = true;
                    pnlDatos.Visible = false;
                }
            }
            else //Compra excedente
            {
                action.insertaCompraActivo(compra, 0, 1, null, 0);
                action.InsertaDetalleCompra(compra);
                email.CorreoCompra(compra);
                NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
            }
        }
        else if(model.Status.Equals("INACTIVO"))
        {
            if (DateTime.Today >= model.RangoDesde && DateTime.Today <= model.RangoHasta) //Semana de activación
            {
                model = action.ConsRangoFechasInactivoMasUno(model.DiaCalif, model.Calificacion, DateTime.Today);
                action.insertaCompraInactivo(compra, model);
                action.InsertaDetalleCompra(compra);
                email.CorreoCompra(compra);
                NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
            }
            else 
            {
                model = action.ConsRangoFechasInactivo(model.DiaCalif);
                action.insertaCompraInactivo(compra, model);
                action.InsertaDetalleCompra(compra);
                email.CorreoCompra(compra);
                NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
            }
        }
    }

    protected void btnTipoCompra_Click(object sender, EventArgs e)
    {
        EmailAction email = new EmailAction();
        string msgError = string.Empty;
        msgError = validaTipoCompra();
        if (msgError.Length == 0)
        {
            ComprasAction action = new ComprasAction();
            proxCompraModel model = action.ConsSemanaActivacion(Session["idUser"].ToString());
            compra = new ComprasModel();
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

            if (ddlEntrega.SelectedValue.Equals("DOMICILIO"))
            {
                compra.Envio = Convert.ToDouble(lblTotalEnvio.Text);
                compra.Iva = Convert.ToDouble(lblIva.Text);
                compra.StatusEntrega = "PENDIENTE";
            }
            else
            { compra.StatusEntrega = "ENTREGADO"; }

            string sel = rbtnTipoCompra.SelectedValue;
            switch (sel)
            {
                case "Excedente":
                    action.insertaCompraActivo(compra, 0, 1, null, 0);
                    action.InsertaDetalleCompra(compra);
                    email.CorreoCompra(compra);
                    NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
                    break;
                case "Activacion":
                    model = action.ConsSemanaActivacion(Session["idUser"].ToString());
                    action.insertaCompraActivo(compra, 1, 0, model, 1);
                    action.InsertaDetalleCompra(compra);
                    email.CorreoCompra(compra);
                    NavegacionSegura.navega(this, "NuevaCompraComprobante", new string[] { compra.Referencia, compra.Total.ToString(), "NuevaCompraDetalle" });
                    break;
            }
        }
        else
        {
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }

    private string validaTipoCompra()
    {
        string error = string.Empty;
        if (rbtnTipoCompra.SelectedIndex.Equals(-1))
        {
            error = "Selecciona una opción";
        }
        return error;
    }

}