using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MisComprasModel
/// </summary>
public class MisComprasModel
{
    private string numeroOrden;
    private string fechaOrden;
    private string fechaPago;
    private string puntos;
    private string total;
    private string pago;
    private string entrega;
    private string periodo;
    private string referencia;

    public string NumeroOrden { get { return numeroOrden; } set { numeroOrden = value; } }
    public string FechaOrden { get { return fechaOrden; } set { fechaOrden = value; } }
    public string FechaPago { get { return fechaPago; } set { fechaPago = value; } }
    public string Puntos { get { return puntos; } set { puntos = value; } }
    public string Total { get { return total; } set { total = value; } }
    public string Pago { get { return pago; } set { pago = value; } }
    public string Entrega { get { return entrega; } set { entrega = value; } }
    public string Periodo { get { return periodo; } set { periodo = value; } }
    public string Referencia { get { return referencia; } set { referencia = value; } }
}