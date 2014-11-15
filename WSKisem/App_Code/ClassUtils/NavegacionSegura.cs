using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI;

/// <summary>
/// Descripción breve de NavegacionSegura
/// </summary>
public class NavegacionSegura
{
    private static Hashtable navTo = new Hashtable() 
        {            
            {"EditaDatos", "~/views/EditaDatos.aspx?id={0}"},
            {"misDatosPersonales","~/views/misDatosPersonales.aspx"},
            {"DetalleCompras", "~/views/DetalleCompra.aspx?idCorte={0}&periodo={1}"},
            {"misCompras","~/views/misCompras.aspx"},
            {"DetalleGanancias", "~/views/misPagos.aspx?idCorte={0}&periodo={1}&isr={2}&iva={3}"},
            {"misGanancias","~/views/misGanancias.aspx"},
            {"NuevaCompraDetalle", "~/views/NuevaCompraDetalle.aspx?paquete={0}"},
            {"NuevaCompra", "~/views/NuevaCompra.aspx"},
            {"NuevaCompraComprobante", "~/views/NuevaCompraComprobante.aspx?referencia={0}&total={1}"},
            {"Prospecto", "~/views/AltaProspecto.aspx"},
            {"ArbolColocacion", "~/views/ArbolColocacion.aspx?nuevo={0}"},
            {"CompraInscrDetalle", "~/views/CompraInscripcionDetalle.aspx?padre={0}&lado={1}&paquete={2}&idProsp={3}"},
            {"CompraInscripcion", "~/views/CompraInscripcion.aspx?padre={0}&lado={1}"},
            {"InfoProspecto", "~/views/InformacionProspecto.aspx?prospecto={0}"},
            {"EditaProspecto", "~/views/EditaProspecto.aspx?prospecto={0}"},
            //{"ConsultaAccionesParam", "~/views/Acciones/ConsultaAcciones.aspx?fechaInicio={0}&fechaFin={1}&linea={2}"},
            //{"Grafica","~/views/Graficas/GeneraGrafica.aspx"}
        };

    private static string NavTo(string navId)
    {
        return navTo[navId] == null ? String.Empty : navTo[navId].ToString();
    }

    public static Boolean navega(Page pagina)
    {
        string navId = pagina.Request.QueryString["navTo"] == null ? String.Empty : pagina.Request.QueryString["navTo"];

        string url = NavTo(navId);

        if (url.Equals(String.Empty))
        {
            return false;
        }

        pagina.Response.Redirect(url);

        return true;
    }

    public static Boolean navega(Page pagina, string[] parametros)
    {
        string navId = pagina.Request.QueryString["navTo"] == null ? String.Empty : pagina.Request.QueryString["navTo"];

        return navega(pagina, navId, parametros);
    }

    public static Boolean navega(Page pagina, string navId, string[] parametros)
    {
        string url = NavTo(navId);

        if (url.Equals(String.Empty))
        {
            return false;
        }

        for (int i = 0; i < parametros.Count(); i++)
        {
            url = url.Replace("{" + i + "}", Encriptador.encriptar(parametros[i]));
        }

        pagina.Response.Redirect(url);

        return true;
    }

    public static string vinculoNavegacion(string navId, string[] parametros)
    {
        string url = NavTo(navId);

        for (int i = 0; i < parametros.Count(); i++)
        {
            url = url.Replace("{" + i + "}", parametros[i]);
        }

        return url;
    }
}