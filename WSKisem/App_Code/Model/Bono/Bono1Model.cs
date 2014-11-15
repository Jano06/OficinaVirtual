using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono1Model
/// </summary>
public class Bono1Model
{
    private string compra;
    private string fecha;
    private string monto;
    private string ganancia;

    public string Compra { get { return compra; } set { compra = value; } }
    public string Fecha { get { return fecha; } set { fecha = value; } }
    public string Monto { get { return monto; } set { monto = value; } }
    public string Ganancia { get { return ganancia; } set { ganancia = value; } }
}