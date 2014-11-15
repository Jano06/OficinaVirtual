using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de proxCompraModel
/// </summary>
public class proxCompraModel
{
    private DateTime calificacion;
    private DateTime rangoDesde;
    private DateTime rangoHasta;
    private string status;
    private int diaCalif;

    public DateTime Calificacion { get { return calificacion; } set { calificacion = value; } }
    public DateTime RangoDesde { get { return rangoDesde; } set { rangoDesde = value; } }
    public DateTime RangoHasta { get { return rangoHasta; } set { rangoHasta = value; } }
    public string Status { get { return status; } set { status = value; } }
    public int DiaCalif { get { return diaCalif; } set { diaCalif = value; } }
}