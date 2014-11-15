using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono7Model
/// </summary>
public class Bono7Model
{
    private string asociado;
    private string nombre;
    private string compra;
    private string fecha;
    private string monto;
    private string ganancia;

    public string Asociado { get { return asociado; } set { asociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string Compra { get { return compra; } set { compra = value; } }
    public string Fecha { get { return fecha; } set { fecha = value; } }
    public string Monto { get { return monto; } set { monto = value; } }
    public string Ganancia { get { return ganancia; } set { ganancia = value; } }
}