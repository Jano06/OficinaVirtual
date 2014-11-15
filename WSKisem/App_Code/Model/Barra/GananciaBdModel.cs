using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de GananciaBdModel
/// </summary>
public class GananciaBdModel
{
    private string corte;
    private double monto;
    private DateTime inicio;
    private DateTime fin;
    private string factura;

    public string Corte { get { return corte; } set { corte = value; } }
    public double Monto { get { return monto; } set { monto = value; } }
    public DateTime Inicio { get { return inicio; } set { inicio = value; } }
    public DateTime Fin { get { return fin; } set { fin = value; } }
    public string Factura { get { return factura; } set { factura = value; } }
}