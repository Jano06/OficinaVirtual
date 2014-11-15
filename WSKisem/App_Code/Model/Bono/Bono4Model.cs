using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono4Model
/// </summary>
public class Bono4Model
{
    private string asociado;
    private string nombre;
    private string compra;
    private string fecha;
    private string volumen;

    public string Asociado { get { return asociado; } set { asociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string Compra { get { return compra; } set { compra = value; } }
    public string Fecha { get { return fecha; } set { fecha = value; } }
    public string Volumen { get { return volumen; } set { volumen = value; } }
}