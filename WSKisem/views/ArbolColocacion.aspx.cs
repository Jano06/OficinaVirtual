using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using log4net;

public partial class views_ArbolColocacion : System.Web.UI.Page
{
    private string _nuevo;
    private string _idUser;

    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(views_ArbolColocacion));

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["idUser"].ToString() == null) //Si el usuario es nulo es porque ha caducado la sesión
        {
            Response.Redirect("~/Login.aspx"); //redirecciona a login
        }
        _idUser = Session["idUser"].ToString();
        if (!IsPostBack)
        {
            lblTitlePrincipal.Text = "ÁRBOL DE COLOCACIÓN";
            llenaArbol(_idUser);
            #region Nuevo
            if (!string.IsNullOrEmpty(Request.QueryString["nuevo"]))
            {
                try
                {
                    string nuevo = Request.QueryString["nuevo"].ToString();
                    _nuevo = Encriptador.desencriptar(nuevo);
                }
                catch (Exception ex)
                {
                    _LOGGER.Error("Error al recuperar variables " + ex.Message);
                    throw new Exception("Error en ArbolColoacion" + ex.Message);
                }
                if (_nuevo.Equals("1"))
                {
                    PnlNuevo.Visible = true;
                }
            }
            #endregion
        }
    }

    protected void llenaArbol(string tope)
    {
        if (tope == _idUser)
        {
            btnInicio.Enabled = false;
            btnSubir1.Enabled = false;
            btnSubir2.Enabled = false;
            btnSubir3.Enabled = false;
            btnSubir4.Enabled = false;
        }
        else
        {
            btnInicio.Enabled = true;
            btnSubir1.Enabled = true;
            btnSubir2.Enabled = true;
            btnSubir3.Enabled = true;
            btnSubir4.Enabled = true;
        }
        #region Declara variables
        DataView view = new DataView();
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<string> nombres = new List<string>();
        List<string> aliases = new List<string>();
        List<DateTime> inscripcion = new List<DateTime>();
        List<int> ids = new List<int>();
        List<int> rangos = new List<int>();
        List<int> status = new List<int>();
        List<int> patrocinadores = new List<int>();
        #endregion
        DataSet objDS = action.ConsArbolColocacion(tope);
        view = new DataView(objDS.Tables[0]);
        view.RowFilter = "ID=" + tope.ToString();
        foreach(DataRowView drv in view)
        {
            ids.Add(int.Parse(drv["ID"].ToString()));
            nombres.Add(drv["NOMBRE"].ToString());
            aliases.Add(drv["ALIAS"].ToString());
            status.Add(int.Parse(drv["STATUS"].ToString()));
            inscripcion.Add(Convert.ToDateTime(drv["FINSC"].ToString()));
            patrocinadores.Add(int.Parse(drv["PATROCINADOR"].ToString()));
            rangos.Add(int.Parse(drv["RANGOPAGO"].ToString()));
        }
        for (int i = 0; i < 15; i++)
        {
            if (ids[i] == 0 || ids[i] == -1)
            {
                ids.Add(-1);
                ids.Add(-1);
                nombres.Add("");
                nombres.Add("");
                aliases.Add("");
                aliases.Add("");
                status.Add(-1);
                status.Add(-1);
                inscripcion.Add(new DateTime());
                inscripcion.Add(new DateTime());
                patrocinadores.Add(-1);
                patrocinadores.Add(-1);
                rangos.Add(-1);
                rangos.Add(-1);
            }
            else
            {
                view.RowFilter = "padre=" + ids[i].ToString();
                view.Sort = "LADO DESC";
                int renglon = view.Count;
                switch (renglon)
                {
                    case 0:
                        ids.Add(0);
                        ids.Add(0);
                        nombres.Add("");
                        nombres.Add("");
                        aliases.Add("");
                        aliases.Add("");
                        status.Add(-1);
                        status.Add(-1);
                        inscripcion.Add(new DateTime());
                        inscripcion.Add(new DateTime());
                        patrocinadores.Add(-1);
                        patrocinadores.Add(-1);
                        rangos.Add(0);
                        rangos.Add(0);
                        break;
                    case 1:
                        foreach (DataRowView drv in view)
                        {
                            if (drv["LADO"].ToString() == "I")
                            {
                                ids.Add(int.Parse(drv["ID"].ToString()));
                                nombres.Add(drv["NOMBRE"].ToString());
                                aliases.Add(drv["ALIAS"].ToString());
                                status.Add(int.Parse(drv["STATUS"].ToString()));
                                inscripcion.Add(Convert.ToDateTime(drv["FINSC"].ToString()));
                                patrocinadores.Add(int.Parse(drv["PATROCINADOR"].ToString()));
                                rangos.Add(int.Parse(drv["RANGOPAGO"].ToString()));

                                ids.Add(0);
                                nombres.Add("");
                                aliases.Add("");
                                status.Add(-1);
                                patrocinadores.Add(-1);
                                rangos.Add(0);
                                inscripcion.Add(new DateTime());
                            }
                            else if (drv["LADO"].ToString() == "D")
                            {
                                ids.Add(0);
                                nombres.Add("");
                                aliases.Add("");
                                status.Add(-1);
                                inscripcion.Add(new DateTime());
                                patrocinadores.Add(-1);
                                rangos.Add(0);

                                ids.Add(int.Parse(drv["ID"].ToString()));
                                nombres.Add(drv["NOMBRE"].ToString());
                                aliases.Add(drv["ALIAS"].ToString());
                                status.Add(int.Parse(drv["STATUS"].ToString()));
                                inscripcion.Add(Convert.ToDateTime(drv["FINSC"].ToString()));
                                patrocinadores.Add(int.Parse(drv["PATROCINADOR"].ToString()));
                                rangos.Add(int.Parse(drv["RANGOPAGO"].ToString()));
                            }
                        }
                        break;
                    default:
                        foreach (DataRowView drv in view)
                        {
                            ids.Add(int.Parse(drv["ID"].ToString()));
                            nombres.Add(drv["NOMBRE"].ToString());
                            aliases.Add(drv["ALIAS"].ToString());
                            status.Add(int.Parse(drv["STATUS"].ToString()));
                            inscripcion.Add(Convert.ToDateTime(drv["FINSC"].ToString()));
                            patrocinadores.Add(int.Parse(drv["PATROCINADOR"].ToString()));
                            rangos.Add(int.Parse(drv["RANGOPAGO"].ToString()));
                        }
                        break;
                }
            }
        }

        ContentPlaceHolder contenedor = (ContentPlaceHolder)Master.FindControl("ContenidoPrincipal");
        for (int i = 0; i < 31; i++)
        {
            ImageButton boton = (ImageButton)contenedor.FindControl("imgBtn" + i);
            string grande = string.Empty;
            if (ids[i] > 0)
            {
                string statusStr = string.Empty;
                switch (status[i])
                {
                    case 0:
                        statusStr = "Inactivo";
                        boton.ImageUrl = "~/Imagenes/Arbol/Rangos/" + rangos[i] + "i.png";
                        break;
                    case 1:
                        statusStr = "Activo";
                        boton.ImageUrl = "~/Imagenes/Arbol/Rangos/" + rangos[i] + ".png";
                        break;
                    case 2:
                        statusStr = "Suspendido";
                        boton.ImageUrl = "~/Imagenes/Arbol/Rangos/suspendido.png";
                        break;
                    default:
                        statusStr = "Indefinido";
                        break;
                }

                string rangoStr = string.Empty;
                switch (rangos[i])
                {
                    case 1:
                        rangoStr = "Asociado";
                        break;
                    case 2:
                        rangoStr = "Colaborador";
                        break;
                    case 3:
                        rangoStr = "Colaborador Ejecutivo";
                        break;
                    case 4:
                        rangoStr = "Bronce";
                        break;
                    case 5:
                        rangoStr = "Plata";
                        break;
                    case 6:
                        rangoStr = "Oro";
                        break;
                    case 7:
                        rangoStr = "Platino";
                        break;
                    case 8:
                        rangoStr = "Diamante";
                        break;
                    case 9:
                        rangoStr = "Diamante Ejecutivo";
                        break;
                    case 10:
                        rangoStr = "Diamante Internacional";
                        break;
                    default:
                        rangoStr = "Indefinido";
                        break;
                }
                boton.ToolTip = "Alias: " + aliases[i] + System.Environment.NewLine + "Nombre: " + nombres[i] + System.Environment.NewLine + "Usuario: " + ids[i] + System.Environment.NewLine + "Rango: " + rangoStr + System.Environment.NewLine + "Status: " + statusStr + System.Environment.NewLine + "Patrocinador: " + patrocinadores[i] + System.Environment.NewLine + "Fecha Inscripción: " + (Convert.ToDateTime(inscripcion[i].ToString()).ToString("dd/MMMM/yyyy")).ToString().ToUpper();
                boton.Enabled = true;
                //if (status[i] == 1)
                //    boton.ImageUrl = "~/Imagenes/Arbol/Rangos/" + rangos[i] + ".png";
                //else if(status[i] == 0)
                //    boton.ImageUrl = "~/Imagenes/Arbol/Rangos/" + rangos[i] + "i.png";
                //else if (status[i] == 2)
                //    boton.ImageUrl = "~/Imagenes/Arbol/Rangos/suspendido.png";

                if (i > 14)
                {
                    buscaHijos(ids[i], (i + 1));
                }
            }
            else
            {
                boton.ImageUrl = "~/Imagenes/Arbol/Rangos/" + ids[i] + ".png";
                boton.ToolTip = "";
                if (i > 14)
                {
                    int indice = i - 14;
                    ImageButton btnIzq = (ImageButton)contenedor.FindControl("I" + indice);
                    ImageButton btnDer = (ImageButton)contenedor.FindControl("D" + indice);
                    btnIzq.Visible = false;
                    btnDer.Visible = false;
                }
            }
        
            if (ids[i] == -1)
            {
                if (i > 14)
                {
                    int indice = i - 14;
                    ImageButton btnIzq = (ImageButton)contenedor.FindControl("I" + indice);
                    ImageButton btnDer = (ImageButton)contenedor.FindControl("D" + indice);
                    btnIzq.Visible = false;
                    btnDer.Visible = false;
                }
                else
                {
                    boton.Enabled = false;
                }
            }
            if (i == 0)
            {
                if (status[i] == 1)
                    boton.ImageUrl = "~/Imagenes/Arbol/Grandes/" + rangos[i] + ".png";
                else if (status[i] == 0)
                    boton.ImageUrl = "~/Imagenes/Arbol/Grandes/" + rangos[i] + "i.png";
                else if (status[i] == 2)
                    boton.ImageUrl = "~/Imagenes/Arbol/Grandes/Suspendido.png";
            }
        }
        for (int contador = 0; contador < 31; contador++)
        {
            Label aliaslabel = (Label)contenedor.FindControl("lblAlias" + contador);
            aliaslabel.Text = aliases[contador];
            Style etiquetastyle = new Style();
            var _with1 = etiquetastyle;
            if (ids[contador] > 0)
            {
                //_with1.BorderColor = System.Drawing.Color.DarkBlue;
                //_with1.BorderWidth = new Unit(1);
                //_with1.ForeColor = System.Drawing.Color.DarkBlue;
                _with1.CssClass = "textochico";
                //_with1.Width = 40;
                _with1.BackColor = System.Drawing.Color.White;
                aliaslabel.Visible = true;
            }
            else
            {
                aliaslabel.Visible = false;
            }
            aliaslabel.ApplyStyle(etiquetastyle);
        }
        imgBtn0.Enabled = false;
        Session["idArbol"] = ids;
        buscaPuntos(tope);
    }

    protected void buscaHijos(int asociado, int posicion)
    {
        posicion -= 15;
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<ArbolNext> lista = action.ProxHijos(asociado.ToString());
        int idHijoIzq = 0, idHijoDer = 0;
        bool izq = false, der = false;
        foreach (ArbolNext arbol in lista)
        {
            if (arbol.Lado == "D")
            {
                der = true;
                idHijoDer = int.Parse(arbol.IdAsociadoHijo);
            }
            if (arbol.Lado == "I")
            {
                izq = true;
                idHijoIzq = int.Parse(arbol.IdAsociadoHijo);
            }
        }
        ContentPlaceHolder contenedor = (ContentPlaceHolder)Master.FindControl("ContenidoPrincipal");
        ImageButton btnHijoIzq = (ImageButton)contenedor.FindControl("I" + posicion);
        ImageButton btnHijoDer = (ImageButton)contenedor.FindControl("D" + posicion);
        btnHijoIzq.CommandArgument = idHijoIzq.ToString();
        btnHijoDer.CommandArgument = idHijoDer.ToString();
        btnHijoIzq.ToolTip = "Asociado" + idHijoIzq.ToString();
        btnHijoDer.ToolTip = "Asociado" + idHijoDer.ToString();
        btnHijoIzq.Visible = izq;
        btnHijoDer.Visible = der;
    }

    protected void buscaPuntos(string asociado)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<PuntosModel> listaPuntos = new List<PuntosModel>();

        listaPuntos = action.ConsPuntos(asociado);
        foreach (PuntosModel model in listaPuntos)
        {
            lblPuntosDer.Text = model.PtosDer.ToString();
            lblPuntosIzq.Text = model.PtosIzq.ToString();
        }
    }

    protected void imgBtn_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton b = (ImageButton)sender;
        string x = b.ID;
        x = x.Substring(6, (x.Length - 6));
        accionBoton(int.Parse(x));
    }

    protected void Izq_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton izq = (ImageButton)sender;
        int id = int.Parse(izq.CommandArgument);
        llenaArbol(id.ToString());
    }

    protected void Der_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton der = (ImageButton)sender;
        int id = int.Parse(der.CommandArgument);
        llenaArbol(id.ToString());
    }

    private void accionBoton(int lugar)
    {
        string padre = string.Empty; string lado = string.Empty;
        ContentPlaceHolder contenedor = (ContentPlaceHolder)Master.FindControl("ContenidoPrincipal");
        ImageButton boton = (ImageButton)contenedor.FindControl("imgBtn" + lugar.ToString());
        List<int> ids = (List<int>)Session["idArbol"];
        //List<int> ids = Session["idArbol"] != null ? (List<int>)Session["idArbol"] : null;
        if (ids[lugar] > 0)
        {
            llenaArbol(ids[lugar].ToString());
        }
        else
        {
            if (lugar % 2 == 0)
            {
                padre = Convert.ToInt32(ids[(lugar / 2) - 1]).ToString();
                lado = "D";
            }
            else
            {
                padre = Convert.ToInt32(ids[(((lugar - 1) / 2))]).ToString();
                lado = "I";
            }
            NavegacionSegura.navega(this, "CompraInscripcion", new string[] { padre, lado, "ArbolColocacion" });
        }
    }

    protected void imgFondoDer_Click(object sender, ImageClickEventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<int> ids = (List<int>)Session["idArbol"];
        int asoc = ids[0];
        llenaArbol(action.BuscaFondoDer(asoc).ToString());
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        if (txtIdAsociado.Text.Length > 0)
        {
            try
            {
                Convert.ToInt32(txtIdAsociado.Text);
                if (txtIdAsociado.Text == _idUser.ToString())
                {
                    llenaArbol(txtIdAsociado.Text);
                    txtIdAsociado.Text = "";
                }
                else
                {
                    if (action.BuscaAsociado(txtIdAsociado.Text.ToString(), _idUser.ToString()))
                    {
                        llenaArbol(txtIdAsociado.Text.ToString());
                        txtIdAsociado.Text = "";
                    }
                    else
                    {
                        cellmensaje.ForeColor = System.Drawing.Color.Red;
                        btnAceptar.BackColor = System.Drawing.Color.Red;
                        cellmensaje.Text = "No se encuentra el Asociado";
                        modalMensaje.Show();
                        txtIdAsociado.Text = "";
                    }
                }
            }
            catch
            {
                cellmensaje.ForeColor = System.Drawing.Color.Red;
                btnAceptar.BackColor = System.Drawing.Color.Red;
                cellmensaje.Text = "Formato Incorrecto";
                modalMensaje.Show();
                txtIdAsociado.Text = "";
            }
        }
        else
        {
            cellmensaje.ForeColor = System.Drawing.Color.Red;
            btnAceptar.BackColor = System.Drawing.Color.Red;
            cellmensaje.Text = "Ingresa un Asociado";
            modalMensaje.Show();
            txtIdAsociado.Text = "";
        }
    }
    
    protected void click_btnPopUpAceptar(object sender, EventArgs e)
    {
        cellmensaje.Text = string.Empty;
        modalMensaje.Hide();
    }

    protected void imgFondoIzq_Click(object sender, ImageClickEventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<int> ids = (List<int>)Session["idArbol"];
        int asoc = ids[0];
        llenaArbol(action.BuscaFondoIzq(asoc).ToString());
    }

    protected void btnSubir1_Click(object sender, ImageClickEventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<int> ids = (List<int>)Session["idArbol"];
        int asoc = ids[0];
        llenaArbol(action.SubeNivel(asoc, int.Parse(_idUser.ToString()), 1).ToString());
    }

    protected void btnSubir2_Click(object sender, ImageClickEventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<int> ids = (List<int>)Session["idArbol"];
        int asoc = ids[0];
        //List<int> ids = Session["idArbol"] != null ? (List<int>)Session["idArbol"] : null;
        llenaArbol(action.SubeNivel(asoc, int.Parse(_idUser.ToString()), 2).ToString());
    }

    protected void btnSubir3_Click(object sender, ImageClickEventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<int> ids = (List<int>)Session["idArbol"];
        int asoc = ids[0];
        llenaArbol(action.SubeNivel(asoc, int.Parse(_idUser.ToString()), 3).ToString());
    }

    protected void btnSubir4_Click(object sender, ImageClickEventArgs e)
    {
        ArbolColocacionAction action = new ArbolColocacionAction();
        List<int> ids = (List<int>)Session["idArbol"];
        int asoc = ids[0];
        llenaArbol(action.SubeNivel(asoc, int.Parse(_idUser.ToString()), 4).ToString());
    }

    protected void btnInicio_Click(object sender, ImageClickEventArgs e)
    {
        string idAsoc = _idUser.ToString();
        llenaArbol(idAsoc);
    }
}