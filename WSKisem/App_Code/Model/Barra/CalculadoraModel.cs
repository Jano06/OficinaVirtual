using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CalculadoraModel
/// </summary>
public class CalculadoraModel
{
    private string idAsociado;
    private string bono;
    private double monto;
    private string fechaDesde;
    private string fechaHasta;

    public string IdAsociado { get { return idAsociado; } set { idAsociado = value; } }
    public string Bono { get { return bono; } set { bono = value; } }
    public double Monto { get { return monto; } set { monto = value; } }
    public string FechaDesde { get { return fechaDesde; } set { fechaDesde = value; } }
    public string FechaHasta { get { return fechaHasta; } set { fechaHasta = value; } }
}