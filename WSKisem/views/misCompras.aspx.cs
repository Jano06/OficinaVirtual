using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class views_misCompras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "MIS COMPRAS";
            llenaFechas(DateTime.Today);
            if (Session["GridViewCompras"] != null)
            { ConsultaComprasView(); }
            else
            {
                Session["GridViewCompras"] = null;
                Session["fechaInicioCompras"] = null;
                Session["fechaFinCompras"] = null;
            }
        }
    }

    protected void ConsultaComprasView()
    {
        string fechaInicio, fechaFin;
        MisComprasAction action = new MisComprasAction();
        List<MisComprasModel> lista = new List<MisComprasModel>();
        MisComprasModel setDataAction = (MisComprasModel)Session["SetDataMisCompras"];
        txtFechaInicio.Text = Session["fechaInicioCompras"].ToString();
        txtFechaFin.Text = Session["fechaFinCompras"].ToString();
        fechaInicio = txtFechaInicio.Text.Substring(6, 4) + "/" + txtFechaInicio.Text.Substring(3, 2) + "/" + txtFechaInicio.Text.Substring(0, 2);
        fechaFin = txtFechaFin.Text.Substring(6, 4) + "/" + txtFechaFin.Text.Substring(3, 2) + "/" + txtFechaFin.Text.Substring(0, 2);
        lista = action.ConsultaCompras(int.Parse(Session["idUser"].ToString()), fechaInicio, fechaFin);
        gvdCompras.DataSource = lista;
        gvdCompras.DataBind();
        Session.Add("GridViewCompras", gvdCompras);
        Session.Add("fechaInicioCompras", txtFechaInicio.Text);
        Session.Add("fechaFinCompras", txtFechaFin.Text);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string msgError = string.Empty;
        msgError = validaCampos();
        if (msgError.Length == 0)
        {
            string fechaInicio = string.Empty; string fechaFin = string.Empty;
            MisComprasAction action = new MisComprasAction();
            List<MisComprasModel> lista = new List<MisComprasModel>();

            fechaInicio = txtFechaInicio.Text.Substring(6, 4) + "/" + txtFechaInicio.Text.Substring(3, 2) + "/" + txtFechaInicio.Text.Substring(0, 2);
            fechaFin = txtFechaFin.Text.Substring(6, 4) + "/" + txtFechaFin.Text.Substring(3, 2) + "/" + txtFechaFin.Text.Substring(0, 2);
            lista = action.ConsultaCompras(int.Parse(Session["idUser"].ToString()), fechaInicio, fechaFin);
            gvdCompras.DataSource = lista;
            gvdCompras.PageIndex = 0;
            gvdCompras.DataBind();

            Session.Add("GridViewCompras", gvdCompras);
            Session.Add("fechaInicioCompras", txtFechaInicio.Text);
            Session.Add("fechaFinCompras", txtFechaFin.Text);
        }
        else
        {
            cellmensaje.Text = msgError;
            modalMensaje.Show();
        }
    }

    protected void GetCompras()
    {
        MisComprasAction action = new MisComprasAction();
        List<MisComprasModel> lista = new List<MisComprasModel>();

        string fechaInicio = txtFechaInicio.Text.Substring(6, 4) + "/" + txtFechaInicio.Text.Substring(3, 2) + "/" + txtFechaInicio.Text.Substring(0, 2);
        string fechaFin = txtFechaFin.Text.Substring(6, 4) + "/" + txtFechaFin.Text.Substring(3, 2) + "/" + txtFechaFin.Text.Substring(0, 2);
        lista = action.ConsultaCompras(int.Parse(Session["idUser"].ToString()), fechaInicio, fechaFin);
        gvdCompras.DataSource = lista;
        gvdCompras.PageIndex = 0;
        gvdCompras.DataBind();

        Session.Add("GridViewCompras", gvdCompras);
        Session.Add("fechaInicioCompras", txtFechaInicio.Text);
        Session.Add("fechaFinCompras", txtFechaFin.Text);
    }

    protected void imgbtndetalle_Click(object sender, EventArgs e)
    {
        ImageButton ImgDetalle;
        GridViewRow gvrNavegar;
        Label lblIdCompra, lblPeriodo;
        string parameter, periodo;
        ImgDetalle = (ImageButton)sender;
        gvrNavegar = (GridViewRow)ImgDetalle.Parent.Parent;
        lblIdCompra = (Label)gvrNavegar.FindControl("lblNoOrden");
        parameter = lblIdCompra.Text.Trim();
        lblPeriodo = (Label)gvrNavegar.FindControl("lblPeriodo");
        periodo = lblPeriodo.Text.Trim();
        NavegacionSegura.navega(this, "DetalleCompras", new string[] { parameter, periodo, "misCompras" });
    }

    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected string validaCampos()
    {
        string mensaje = string.Empty;
        if (!(txtFechaInicio.Text.Length == 0 || txtFechaFin.Text.Length == 0))
        {
            try
            {
                if (Convert.ToDateTime(txtFechaInicio.Text) > Convert.ToDateTime(txtFechaFin.Text))
                {
                    mensaje += "La fecha de fin no puede ser mayor a la fecha de fin.</br>";
                }
            }
            catch (Exception)
            {
                mensaje += "Formato incrrecto de fechas.</br>";
            }
        }
        if (txtFechaInicio.Text.Length < 1)
            mensaje += "Ingresa Fecha Inicio.</br>";
        if (txtFechaFin.Text.Length < 1)
            mensaje += "Ingresa Fecha Fin.</br>";
        return mensaje;
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        llenaFechas(Convert.ToDateTime(txtFechaInicio.Text).AddMonths(1));
        GetCompras();
    }
    
    protected void btnAnterior_Click(object sender, EventArgs e)
    {
        llenaFechas(Convert.ToDateTime(txtFechaInicio.Text).AddMonths(-1));
        GetCompras();
    }

    protected void llenaFechas(DateTime fecha)
    {
        DateTime fechaDesde = new DateTime();
        DateTime fechaHasta = new DateTime();

        fechaDesde = Convert.ToDateTime("01/" + (fecha.Month) + "/" + fecha.Year);

        if ((fecha.Month + 1) > 12)
            fechaHasta = Convert.ToDateTime("31/12/" + (fecha.Year));
        else
            fechaHasta = Convert.ToDateTime("01/" + (fecha.Month + 1) + "/" + fecha.Year).AddDays(-1);

        txtFechaInicio.Text = fechaDesde.ToString("dd/MM/yyyy");
        txtFechaFin.Text = fechaHasta.ToString("dd/MM/yyyy");
    }
    
    protected void btnPrimero_Click(object sender, EventArgs e)
    {
        MisComprasAction action = new MisComprasAction();
        llenaFechas(Convert.ToDateTime(action.primerCompra(int.Parse(Session["idUser"].ToString()))));
        GetCompras();
    }

    protected void btnUltimo_Click(object sender, EventArgs e)
    {
        MisComprasAction action = new MisComprasAction();
        llenaFechas(Convert.ToDateTime(action.ultCompra(int.Parse(Session["idUser"].ToString()))));
        GetCompras();
    }
}