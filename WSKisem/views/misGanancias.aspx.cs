using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class views_misGanancias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "INFORME DE MIS GANANCIAS";
            llenaResumen();
            //llenaPeriodo();

        }
    }

    protected void gvdGanancias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["GridViewPagos"] != null)
        {
            gvdGanancias.DataSource = ((GridView)Session["GridViewPagos"]).DataSource;
            gvdGanancias.PageIndex = e.NewPageIndex;
            Session.Add("numPage", gvdGanancias.PageIndex);
            gvdGanancias.DataBind();
        }
    }

    protected void llenaResumen()
    {
        MisGananciasAction action = new MisGananciasAction();
        List<GananciaBdModel> listaBD = new List<GananciaBdModel>();
        List<MisGananciasModel> lista = new List<MisGananciasModel>();

        listaBD = action.ConsultaGanancias(Session["idUser"].ToString());
        foreach (GananciaBdModel bd in listaBD)
        {
            MisGananciasModel model = new MisGananciasModel();
            if (bd.Factura == "1")
            {
                model.IdCorte=bd.Corte;
                if (bd.Inicio.Year == bd.Fin.Year)
                {
                    if (bd.Inicio.Month == bd.Fin.Month)
                    {
                        model.Periodo = "DEL " + bd.Inicio.Day + " AL " + bd.Fin.ToString("dd MMMM yyyy").ToUpper();
                    }
                    else
                    {
                        model.Periodo = "DEL " + bd.Inicio.ToString("dd MMMM").ToUpper() + " AL " + bd.Fin.ToString("dd MMMM yyyy").ToUpper();
                    }
                }
                else
                {
                    model.Periodo = "DEL " + bd.Inicio.ToString("dd MMMM yyyy").ToUpper() + " AL " + bd.Fin.ToString("dd MMMM yyyy").ToUpper();
                }

                model.Ganancias = (Convert.ToDouble(bd.Monto).ToString("c"));
                double porcIva = Convert.ToDouble(ConfigurationManager.AppSettings["iva"].ToString());
                double iva, retencionIva;
                iva = Convert.ToDouble((bd.Monto * porcIva));
                model.Iva = iva.ToString("c");
                retencionIva = Convert.ToDouble((bd.Monto * 0.1));
                model.RetencionIva = retencionIva.ToString("c");
                model.GananciaNeta = Convert.ToDouble((bd.Monto) + (iva) - (retencionIva)).ToString("c");
                model.RetencionISR = 0.ToString("c");
            }
            else if (bd.Factura == "0")
            {
                model.IdCorte = bd.Corte;
                if (bd.Inicio.Year == bd.Fin.Year)
                {
                    if (bd.Inicio.Month == bd.Fin.Month)
                    {
                        model.Periodo = "DEL " + bd.Inicio.Day + " AL " + bd.Fin.ToString("dd MMMM yyyy").ToUpper();
                    }
                    else
                    {
                        model.Periodo = "DEL " + bd.Inicio.ToString("dd MMMM").ToUpper() + " AL " + bd.Fin.ToString("dd MMMM yyyy").ToUpper();
                    }
                }
                else
                {
                    model.Periodo = "DEL " + bd.Inicio.ToString("dd MMMM yyyy").ToUpper() + " AL " + bd.Fin.ToString("dd MMMM yyyy").ToUpper();
                }
                model.Ganancias = (Convert.ToDouble(bd.Monto).ToString("c"));
                double retencion = (calculaISR(bd.Monto));
                model.RetencionISR = Convert.ToDouble(retencion).ToString("c");
                model.GananciaNeta = Convert.ToDouble((Convert.ToDouble(bd.Monto - retencion))).ToString("c");
                model.Iva = 0.ToString("c");
                model.RetencionIva = 0.ToString("c");
            }
            lista.Add(model);
        }
        gvdGanancias.DataSource = lista;
        gvdGanancias.DataBind();
        Session["GridViewPagos"] = gvdGanancias;
    }

    protected void llenaPeriodo()
    {
        DateTime fechaActual = DateTime.Today;
        DateTime desde = new DateTime(); DateTime hasta = new DateTime();

        for (int i = 1; i < 21; i++)
        {
            fechaActual = fechaActual.AddDays(-1);
            if (fechaActual.DayOfWeek.Equals(DayOfWeek.Friday))
            {
                desde = fechaActual.AddDays(1);
                hasta = fechaActual.AddDays(7);
                break;
            }
        }
    }

    protected double calculaISR(double importe)
    {
        double resp = 0;
        int indice = 0;
        if (!(importe == 0))
        {
            double excedente = 0;
            double[] limiteInf = { 0.01, 114.25, 969.51, 1703.81, 1980.59, 2371.33, 4782.62, 7538.1, 14391.45, 19188.62, 57565.77 };
            double[] limiteSup = { 114.24, 969.5, 1703.8, 1980.58, 2371.32, 4782.61, 7538.09, 14391.44, 19188.61, 57565.76, 1000000 };
            double[] cuotaFija = { 0, 2.17, 56.91, 136.85, 181.09, 251.16, 766.15, 1414.28, 3470.25, 5005.35, 18053.63 };
            double[] porcentajeLimInf = { 0.0192, 0.064, 0.1088, 0.16, 0.1792, 0.2136, 0.2352, 0.3, 0.32, 0.34, 0.35 };
            indice = limiteInf.Length - 1;

            for (int i = 0; i < limiteInf.Length; i++)
            {
                if (importe > limiteInf[indice])
                {
                    break;
                }
                indice -= 1;
            }
            resp = cuotaFija[indice];
            excedente = (importe - limiteInf[indice]);
            excedente = excedente * porcentajeLimInf[indice];
            resp += excedente;
        }
        return resp;
    }

    protected void imgBtnDetalle_Click(object sender, EventArgs e)
    {
        ImageButton ImgDetalle;
        GridViewRow gvdGanancias;
        Label lblIdCorte;
        Label lblPeriodo;
        Label lblIsr;
        Label lblIva;
        string parameter, periodo, isr, iva;
        ImgDetalle = (ImageButton)sender;
        gvdGanancias = (GridViewRow)ImgDetalle.Parent.Parent;
        lblIdCorte = (Label)gvdGanancias.FindControl("lblIdCorte");
        parameter = lblIdCorte.Text.Trim();
        lblIsr = (Label)gvdGanancias.FindControl("lblRetencionISR");
        isr = lblIsr.Text.Trim(new Char[] { ' ', '$' });
        lblIva = (Label)gvdGanancias.FindControl("lblRetencionIVA");
        iva = lblIva.Text.Trim(new Char[] { ' ', '$' });
        lblPeriodo = (Label)gvdGanancias.FindControl("lblPeriodo");
        periodo = lblPeriodo.Text.Trim();
        NavegacionSegura.navega(this, "DetalleGanancias", new string[] { parameter, periodo, isr, iva, "misGanancias" });
    }
}