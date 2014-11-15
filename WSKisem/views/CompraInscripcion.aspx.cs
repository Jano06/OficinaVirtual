using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using log4net;

public partial class views_CompraInscripcion : System.Web.UI.Page
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_CompraInscripcion));
    private string _padre;
    private string _lado;

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
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al recuperar variables " + ex.Message);
            throw new Exception("Error en CompraInscripcion" + ex.Message);
        }
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "COMPRA INSCRIPCIÓN";
            
            pnlCompra.Visible = false;
            CargaGrid();
            precioPaquete();
        }
    }

    private void CargaGrid()
    {
        AltaProspectoAction action = new AltaProspectoAction();
        List<MiProspectoModel> lista = action.cargaProspectos(Session["idUser"].ToString());
        gvdProspectos.DataSource = lista;
        gvdProspectos.DataBind();
    }

    private void precioPaquete()
    {
        ComprasAction action = new ComprasAction();
        List<string> detalleCompra = new List<string>();
        detalleCompra = action.ConsPrecioPqt("1");
        lblPrecioPqt1.Text = detalleCompra[1];
        lblNombrePqt1.Text = detalleCompra[0].ToUpper();
        detalleCompra = action.ConsPrecioPqt("2");
        lblPrecioPqt2.Text = detalleCompra[1];
        lblNombrePqt2.Text = detalleCompra[0].ToUpper();
        detalleCompra = action.ConsPrecioPqt("3");
        lblPrecioPqt3.Text = detalleCompra[1];
        lblNombrePqt3.Text = detalleCompra[0].ToUpper();
    }

    protected void imgBtnPqt1_Click(object sender, ImageClickEventArgs e)
    {
        string paquete = "1";
        NavegacionSegura.navega(this, "CompraInscrDetalle", new string[] { _padre, _lado, paquete, Session["idProspecto"].ToString(), "CompraInscripcion" });
    }

    protected void imgBtnPqt2_Click(object sender, ImageClickEventArgs e)
    {
        string paquete = "2";
        NavegacionSegura.navega(this, "CompraInscrDetalle", new string[] { _padre, _lado, paquete, Session["idProspecto"].ToString(), "CompraInscripcion" });
    }

    protected void imgBtnPqt3_Click(object sender, ImageClickEventArgs e)
    {
        string paquete = "3";
        NavegacionSegura.navega(this, "CompraInscrDetalle", new string[] { _padre, _lado, paquete, Session["idProspecto"].ToString(), "CompraInscripcion" });
    }

    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        CargaGrid();
        gvdProspectos.Enabled = true;
        pnlCompra.Visible = false;
    }

    protected void chkCompra_CheckedChange(object sender, EventArgs e)
    {
        CheckBox chkCompras;
        GridViewRow gvdProsp;
        Label lblIdProspecto;

        chkCompras = (CheckBox)sender;
        gvdProsp = (GridViewRow)chkCompras.Parent.Parent;
        lblIdProspecto = (Label)gvdProsp.FindControl("lblIdProspecto");
        Session["idProspecto"] = lblIdProspecto.Text.Trim();
        gvdProspectos.Enabled = false;
        pnlCompra.Visible = true;
    }
}