using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;

public partial class views_Inicio_Principal : System.Web.UI.Page
{
    public static DateTime fechaCierre;
    private static DateTime sabado;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            InformacionPcpal();
        }
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
        timer2.Enabled = true;
    }

    protected void click_InfoPrincipal(object sender, EventArgs e)
    {
        InformacionPcpal();
    }

    public void InformacionPcpal()
    {
        pnlInformacion.Visible = true;
        pnlCompras.Visible = false;
        pnlMiOrganizacion.Visible = false;
        pnlLogros.Visible = false;

        PrincipalAction action = new PrincipalAction();
        InfoPcpalModel model = new InfoPcpalModel();
        model = action.ConsInfoPrincipal(int.Parse(Session["idUser"].ToString()));
        lblRangoActual.Text = model.RangoActual;
        lblRangoMaximo.Text = model.MaxRango;
        lblPatrocinador.Text = model.Patrocinador;
        lblEstado.Text = model.Status;
        lblNombreAsociado.Text = model.NombreUsuario;
        lblIdAsociado.Text = model.IdUsuario.ToString();
        lblInactividad.Text = model.FechaActivacion.ToString();
        imgRangoMax.ImageUrl = "~/Imagenes/Rangos/" + model.IdMaxRango + ".png";
        imgRangoActual.ImageUrl = "~/Imagenes/Rangos/" + model.IdRangoActual + ".png";
    }

    protected void click_ProxCompra(object sender, EventArgs e)
    {
        pnlInformacion.Visible = false;
        pnlCompras.Visible = true;
        pnlMiOrganizacion.Visible = false;
        pnlLogros.Visible = false;

        PrincipalAction action = new PrincipalAction();
        proxCompraModel model = new proxCompraModel();
        model = action.ConsProxCompra(int.Parse(Session["idUser"].ToString()));

        lblCalificacion.Text = model.Calificacion.ToString("dd/MMMM/yyyy").ToUpperInvariant();
        lblPeriodoDe.Text = model.RangoDesde.ToString("dd/MMMM/yyyy").ToUpperInvariant();
        lblPeriodoHasta.Text = model.RangoHasta.ToString("dd/MMMM/yyyy").ToUpperInvariant();
        
        SelectedDatesCollection rango = CalendCompras.SelectedDates;
        rango.Clear();

        for (int i = 0; i < 7; i++)
        {
            rango.Add(model.RangoDesde.AddDays(i));
        }
        CalendCompras.VisibleDate = DateTime.Today;
    }

    protected void click_MiOrganizacion(object sender, EventArgs e)
    {
        pnlCompras.Visible = false;
        pnlInformacion.Visible = false;
        pnlMiOrganizacion.Visible = true;
        pnlLogros.Visible = false;

        PrincipalAction action = new PrincipalAction();
        miOrganizacionModel modelo = new miOrganizacionModel();
        modelo = action.ConsMiOrganizacion(int.Parse(Session["idUser"].ToString()));
        lblPatrocinDer.Text = modelo.PatrocinLadoDer.ToString();
        lblPatrocinIzq.Text = modelo.PatrocinLadoIzq.ToString();
        lblAsocDer.Text = modelo.AsocLadoDer.ToString();
        lblAsocIzq.Text = modelo.AsocLadoIzq.ToString();
        sabado = proxSabado();
    }

    protected void click_Logros(object sender, EventArgs e)
    {
        pnlCompras.Visible = false;
        pnlInformacion.Visible = false;
        pnlMiOrganizacion.Visible = false;
        pnlLogros.Visible = true;

        timer2.Enabled = true;
        PrincipalAction action = new PrincipalAction();
        
        fechaCierre = cierreCalif();
        LogrosAction logros = new LogrosAction();
        LogrosModel model = logros.ConsLogros(Session["idUser"].ToString());
        if (model.PuntosIzq > 0)
        {
            lnkPtsIzq.Text = model.PuntosIzq.ToString("n0");
            lblPtsIzq.Visible = false;
        }
        else
        {
            lblPtsIzq.Text = model.PuntosIzq.ToString("n0");
            lnkPtsIzq.Visible = false;
        }
        if (model.PuntosDer > 0)
        {
            lnkPtsDer.Text = model.PuntosDer.ToString("n0");
            lblPtsDer.Visible = false;
        }
        else
        {
            lblPtsDer.Text = model.PuntosDer.ToString("n0");
            lnkPtsDer.Visible = false;
        }
        lblPtsTotales.Text = model.PuntoTotales.ToString("n0");
        if (model.EmpreIzq > 0)
        {
            lnkEmprIzq.Text = model.EmpreIzq.ToString("n0");
            lblEmprIzq.Visible = false;
        }
        else
        {
            lblEmprIzq.Text = model.EmpreIzq.ToString("n0");
            lnkEmprIzq.Visible = false;
        }
        if (model.EmpreDer > 0)
        {
            lnkEmprDer.Text = model.EmpreDer.ToString("n0");
            lblEmprDer.Visible = false;
        }
        else
        {
            lblEmprDer.Text = model.EmpreDer.ToString("n0");
            lnkEmprDer.Visible = false;
        }
        if (model.InactIzq > 0)
        {
            lnkInactIzq.Text = model.InactIzq.ToString("n0");
            lblInactIzq.Visible = false;
        }
        else
        {
            lblInactIzq.Text = model.InactIzq.ToString("n0");
            lnkInactIzq.Visible = false;
        }
        if (model.InactDer > 0)
        {
            lnkInactDer.Text = model.InactDer.ToString("n0");
            lblInactDer.Visible = false;
        }
        else
        {
            lblInactDer.Text = model.InactDer.ToString("n0");
            lblInactDer.Visible = false;
        }

        int rango = model.Rango;
        List<string> descRangos = new List<string>();
        descRangos = action.SiguienteRango(rango + 1);
        lblSigRango.Text = descRangos[0];
        lblEmprendedoresLado.Text = descRangos[1];
        lblActivosLado.Text = descRangos[2];
        lblpuntajeOrganiz.Text = descRangos[3];
        lblactivosOrganiz.Text = descRangos[4];
    }
    
    protected void lnkPtsIzq_Click(object sender, EventArgs e)
    {
        string lado = "I";
        DetallePuntos(Session["idUser"].ToString(), lado);
        lblTituloBono.Text = "PUNTOS IZQUIERDOS";
        modalMensaje.Show();
        timer2.Enabled = false;
    }

    protected void lnkPtsDer_Click(object sender, EventArgs e)
    {
        string lado = "D";
        DetallePuntos(Session["idUser"].ToString(), lado);
        lblTituloBono.Text = "PUNTOS DERECHOS";
        modalMensaje.Show();
        timer2.Enabled = false;
    }

    protected void DetallePuntos(string asociado, string lado)
    {
        LogrosAction action = new LogrosAction();
        List<DetallePuntosModel> lista = new List<DetallePuntosModel>();
        lista = action.consDetallePuntos(asociado, lado);
        gvdDetallePuntos.DataSource = lista;
        gvdDetallePuntos.DataBind();
    }

    protected void lnkInactIzq_Clik(object sender, EventArgs e)
    {
        string tipo = "InactivosIzq";
        DetalleLogros(Session["idUser"].ToString(), tipo);
        lblTituloBono.Text = "INACTIVOS IZQUIERDA";
        modalMensaje.Show();
        timer2.Enabled = false;
    }

    protected void lnkInactDer_Clik(object sender, EventArgs e)
    {
        string tipo = "InactivosDer";
        DetalleLogros(Session["idUser"].ToString(), tipo);
        lblTituloBono.Text = "INACTIVOS DERECHA";
        modalMensaje.Show();
        timer2.Enabled = false;
    }

    protected void lnkEmprIzq_Clik(object sender, EventArgs e)
    {
        string tipo = "EmprIzq";
        DetalleLogros(Session["idUser"].ToString(), tipo);
        lblTituloBono.Text = "EMPRESARIOS / EMPRENDEDORES IZQUIERDA";
        modalMensaje.Show();
        timer2.Enabled = false;
    }

    protected void lnkEmprDer_Clik(object sender, EventArgs e)
    {
        string tipo = "EmprDer";
        DetalleLogros(Session["idUser"].ToString(), tipo);
        lblTituloBono.Text = "EMPRESARIOS / EMPRENDEDORES DERECHA";
        modalMensaje.Show();
        timer2.Enabled = false;
    }

    protected void DetalleLogros(string asociado, string tipo)
    {
        LogrosAction action = new LogrosAction();
        List<DetalleLogrosModel> lista = new List<DetalleLogrosModel>();
        lista = action.consDetalleLogros(asociado, tipo);
        gvdDetalleLogros.DataSource = lista;
        gvdDetalleLogros.DataBind();
    }

    private static DateTime proxSabado()
    {
        int hoy = Convert.ToInt32(DateTime.Today.DayOfWeek);
        int faltan = 6 - hoy;
        if (faltan == 0)
        {
            faltan = 7;
        }
        DateTime sabado = DateTime.Today.AddDays(faltan);
        return sabado;
    }

    private static DateTime cierreCalif()
    {
        PrincipalAction action = new PrincipalAction();

        DateTime fechaCierre = action.cierreCalif();
        return fechaCierre;
    }
    
    protected void timer1_Tick1(object sender, EventArgs e)
    {
        DateTime hoy = DateTime.Now;
        //Condicion para que cuando sea mayor el día
        TimeSpan ts = sabado - hoy;
        lblDias.Text = ts.Days.ToString();
        lblHoras.Text = ts.Hours.ToString();
        lblMinutos.Text = ts.Minutes.ToString();
        int seg = ((sabado.Second - hoy.Second) + 60);
        if (seg == 60)
            lblSegundos.Text = "00";
        else
            lblSegundos.Text = seg.ToString();
    }

    protected void timer2_Tick(object sender, EventArgs e)
    {
        DateTime hoy = DateTime.Now;
        TimeSpan ts = fechaCierre - hoy;
        lblDiasCiclo.Text = ts.Days.ToString();
        lblHorasCiclo.Text = ts.Hours.ToString();
        lblMinutosCiclo.Text = ts.Minutes.ToString();
        int seg = ts.Seconds;
        if (seg == 60)
            lblSegundosCiclo.Text = "00";
        else
            lblSegundosCiclo.Text = seg.ToString();
    }
}