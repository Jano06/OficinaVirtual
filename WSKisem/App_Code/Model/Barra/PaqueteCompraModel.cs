using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PaqueteCompraModel
/// </summary>
public class PaqueteCompraModel
{
    private string descripcion;
    private string precioUnitario;
    private string monto;

    public string Descripcion { get { return descripcion; } set { descripcion = value; } }
    public string PrecioUnitario { get { return precioUnitario; } set { precioUnitario = value; } }
    public string Monto { get { return monto; } set { monto = value; } }
}