using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using log4net;

public partial class views_misPagos : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_misPagos));
    private string _idCorte;
    private string _periodo;
    private string _isr;
    private string _iva;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        try
        {
            string corte = Request.QueryString["idCorte"].ToString();
            _idCorte = Encriptador.desencriptar(corte);
            string periodo = Request.QueryString["periodo"].ToString();
            _periodo = Encriptador.desencriptar(periodo);
            string isr = Request.QueryString["isr"].ToString();
            _isr = Encriptador.desencriptar(isr);
            string iva = Request.QueryString["iva"].ToString();
            _iva = Encriptador.desencriptar(iva);
            Session["BonoDetalleCorte"] = _idCorte;
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar idCorte " + ex.Message);
            throw new Exception("Error en misPagos" + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "DETALLE GANANCIAS";
            CargaDetalleGanancias(_idCorte, Session["idUser"].ToString(), _periodo, _isr, _iva);
        }
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected void btnRegresarPagos_Click(object sender, EventArgs e)
    {
        pnlDetalle.Visible = true;
        pnlDetalleBono4.Visible = false;
    }

    protected void CargaDetalleGanancias(string idCorte, string idAsociado, string periodo, string isr, string iva)
    {
        lblCorte.Text = idCorte;
        lblPeriodo.Text = periodo;
        //CalculaCompras(idCorte);
        CalculaComision(idCorte, isr, iva);
    }

    protected void CalculaCompras(string idCorte)
    {
        MisPagosAction action = new MisPagosAction();
        double total = action.ConsultaCompras(Session["idUser"].ToString(), idCorte);
    }

    protected void CalculaComision(string idCorte, string isr, string iva)
    {
        MisPagosAction action = new MisPagosAction();
        BonosModel model = new BonosModel();
        model = action.CalculaComisiones(Session["idUser"].ToString(), idCorte);
        if (model.Bono1 > 0)
            lnkBtnExcedente.Text = model.Bono1.ToString("c");
        else
            lblExcedente.Text = model.Bono1.ToString("c");
        if (model.Bono2 > 0)
            lnkBtnInscripcion.Text = model.Bono2.ToString("c");
        else
            lblInscripcion.Text = model.Bono2.ToString("c");
        if (model.Bono3 > 0)
            lnkBtnInfinito.Text = model.Bono3.ToString("c");
        else
            lblInfinito.Text = model.Bono3.ToString("c");
        if (model.Bono4 > 0)
            lnkBtnIgualacion.Text = model.Bono4.ToString("c");
        else
            lblIgualacion.Text = model.Bono4.ToString("c");
        if (model.Bono5 > 0)
            lnkBtnSeguimiento.Text = model.Bono5.ToString("c");
        else
            lblSeguimiento.Text = model.Bono5.ToString("c");
        if (model.Bono6 > 0)
            lnkBtnBienestar.Text = model.Bono6.ToString("c");
        else
            lblBienestar.Text = model.Bono6.ToString("c");
        if (model.Bono7 > 0)
            lnkBtnGuia.Text = model.Bono7.ToString("c");
        else
            lblGuia.Text = model.Bono7.ToString("c");
        if (model.Bono8 > 0)
            lnkBtnRed.Text = model.Bono8.ToString("c");
        else
            lblRed.Text = model.Bono8.ToString("c");
        if (model.Bono9 > 0)
        {
            lblRango.Text = model.Bono9.ToString("c");
            lblRango.ForeColor = System.Drawing.Color.Blue;
            lblRango.Font.Bold = true;
        }
        else
        {
            lblRango.Text = model.Bono9.ToString("c");
            lblRango.ForeColor = System.Drawing.Color.Black;
            lblRango.Font.Bold = false;
        }
        if (model.Bono11 > 0)
            lnkBtnNiveles.Text = model.Bono11.ToString("c");
        else
            lblNiveles.Text = model.Bono11.ToString("c");

        lblSubtotal.Text = (model.Bono1 + model.Bono2 + model.Bono3 + model.Bono4 + model.Bono5 + model.Bono6 + model.Bono7 + model.Bono8 + model.Bono9 + model.Bono11).ToString("c");
        lblIsr.Text = Convert.ToDouble(isr).ToString("c");
        lblIva.Text = Convert.ToDouble(iva).ToString("c");
        lblTotal.Text = (Convert.ToDouble(lblSubtotal.Text.Trim(new Char[] { ' ', '$' })) - (Convert.ToDouble(isr) + Convert.ToDouble(iva))).ToString("c");

    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        NavegacionSegura.navega(this, "misGanancias", new string[] { "DetalleGanancias" });
    }

    protected void AbreVentana(string ventana)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "newWindow", string.Format("<script>window.open('{0}', 'Detalle Bono', '"
                                    + "resizable=no, height=600, width=800, position=center, modal=yes, toolbar=no, directories=no, status=no, "
                                    + "menubar=no, scrollbars=yes');</script>", ventana));
    }
    
    protected void lnkBtnExcedente_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono1.aspx");
        cargaBono1(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO EXCEDENTE";
        modalMensaje.Show();
    }

    protected void cargaBono1(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono1Model> lista = new List<Bono1Model>();
        lista = action.ConsBono1(corte, asociado);
        gvdBono1.DataSource = lista;
        gvdBono1.DataBind();
        gvdBono1.Visible = true;
    }

    protected void lnkBtnInscripcion_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono2.aspx");
        cargaBono2(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO INSCRIPCIÓN";
        modalMensaje.Show();
    }

    protected void cargaBono2(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono2Model> lista = new List<Bono2Model>();
        lista = action.ConsBono2(corte, asociado);
        gvdBono2.Visible = true;
        gvdBono2.DataSource = lista;
        gvdBono2.DataBind();
    }

    protected void lnkBtnInfinito_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono3.aspx");
        cargaBono3(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO INSCRIPCIÓN INFINITO";
        modalMensaje.Show();
    }

    protected void cargaBono3(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono3Model> lista = new List<Bono3Model>();
        lista = action.ConsBono3(corte, asociado);
        gvdBono3.Visible = true;
        gvdBono3.DataSource = lista;
        gvdBono3.DataBind();
    }

    protected void lnkBtnIgualacion_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono4.aspx");
        cargaBono4Detalle(_idCorte, Session["idUser"].ToString());
    }

    protected void cargaBono4Detalle(string corte, string asociado)
    {
        pnlDetalleBono4.Visible = true;
        pnlDetalle.Visible = false;
        BonosAction action = new BonosAction();
        Bono4DetalleModel model = new Bono4DetalleModel();
        model = action.ConsBono4Detalle(corte, asociado);
        lblInicIzq.Text = model.InicialesIzq.ToString("n0");
        lblInicDer.Text = model.InicialesDer.ToString("n0");
        if (model.NuevosIzq > 0)
            lnkBtnNvosIzq.Text = model.NuevosIzq.ToString("n0");
        else
            lblNvosIzq.Text = model.NuevosIzq.ToString("n0");
        if (model.NuevosDer > 0)
            lnkBtnNvosDer.Text = model.NuevosDer.ToString("n0");
        else
            lblNvosDer.Text = model.NuevosDer.ToString("n0");
        lblPorcentaje.Text = model.Porcentaje + "%";
        lblSubIzq.Text = (model.InicialesIzq + model.NuevosIzq).ToString("n0");
        lblSubDer.Text = (model.InicialesDer + model.NuevosDer).ToString("n0");
        lblPagIzq.Text = model.Pagados.ToString("n0");
        lblPagDer.Text = model.Pagados.ToString("n0");
        lblFinIzq.Text = ((model.InicialesIzq + model.NuevosIzq) - model.Pagados).ToString("n0");
        lblFinDer.Text = ((model.InicialesDer + model.NuevosDer) - model.Pagados).ToString("n0");
    }

    protected void lnkBtnNvosIzq_Click(object sender, EventArgs e)
    {
        llenaComprasVolumen("I");
        lblTituloBono.Text = "BONO IGUALACIÓN DE VOLUMEN";
        modalMensaje.Show();
    }

    protected void lnkBtnNvosDer_Click(object sender, EventArgs e)
    {
        llenaComprasVolumen("D");
        lblTituloBono.Text = "BONO IGUALACIÓN DE VOLUMEN";
        modalMensaje.Show();
    }

    protected void llenaComprasVolumen(string lado)
    {
        if (lado == "I")
        {
            lblTituloBono.Text = "Compras lado Izquierdo";
        }
        else if (lado == "D")
        {
            lblTituloBono.Text = "Compras lado Derecho";
        }
        BonosAction action = new BonosAction();
        List<Bono4Model> lista = new List<Bono4Model>();
        lista = action.ConsBono4(Session["BonoDetalleCorte"].ToString(), Session["idUser"].ToString(), lado);
        gvdBono4.Visible = true;
        gvdBono4.DataSource = lista;
        gvdBono4.DataBind();
    }

    protected void lnkBtnSeguimiento_Click(object sender, EventArgs e)
    {
        cargaBono5(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO SEGUIMIENTO";
        modalMensaje.Show();
        //AbreVentana("PopUp/Bono5.aspx");
    }

    protected void cargaBono5(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono5Model> lista = new List<Bono5Model>();
        lista = action.ConsBono5(corte, asociado);
        gvdBono5.Visible = true;
        gvdBono5.DataSource = lista;
        gvdBono5.DataBind();
    }

    protected void lnkBtnBienestar_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono6.aspx");
        cargaBono6(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO BIENESTAR";
        modalMensaje.Show();
    }

    protected void cargaBono6(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono6Model> lista = new List<Bono6Model>();
        lista = action.ConsBono6(corte, asociado);
        gvdBono6.Visible = true;
        gvdBono6.DataSource = lista;
        gvdBono6.DataBind();
    }

    protected void lnkBtnGuia_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono7.aspx");
        cargaBono7(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO GUIA";
        modalMensaje.Show();
    }

    protected void cargaBono7(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono7Model> lista = new List<Bono7Model>();
        lista = action.ConsBono7(corte, asociado);
        gvdBono7.Visible = true;
        gvdBono7.DataSource = lista;
        gvdBono7.DataBind();
    }

    protected void lnkBtnRed_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono8.aspx");
        cargaBono8(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO DESARROLLO DE RED";
        modalMensaje.Show();
    }

    protected void cargaBono8(string corte, string asociado)
    {
        BonosAction action = new BonosAction();
        List<Bono8Model> lista = new List<Bono8Model>();
        lista = action.ConsBono8(corte, asociado);
        gvdBono8.Visible = true;
        gvdBono8.DataSource = lista;
        gvdBono8.DataBind();
    }

    protected void lnkBtnNiveles_Click(object sender, EventArgs e)
    {
        //AbreVentana("PopUp/Bono11.aspx");
        cargaBono11(_idCorte, Session["idUser"].ToString());
        lblTituloBono.Text = "BONO DESARROLLO REDES POR NIVELES";
        modalMensaje.Show();
    }

    protected void cargaBono11(string idCorte, string idAsociado)
    {
        BonosAction action = new BonosAction();
        List<Bono11Model> lista = new List<Bono11Model>();
        lista = action.ConsBono11(idCorte, idAsociado);
        gvdBono11.Visible = true;
        gvdBono11.DataSource = lista;
        gvdBono11.DataBind();
    }
    
}