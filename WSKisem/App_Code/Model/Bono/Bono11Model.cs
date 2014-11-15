using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono11Model
/// </summary>
public class Bono11Model
{
    private string compra;
    private string asociado;
    private string fecha;
    private string puntos;
    private string nivel;
    private string ganancia;

    public string Compra { get { return compra; } set { compra = value; } }
    public string Asociado { get { return asociado; } set { asociado = value; } }
    public string Fecha { get { return fecha; } set { fecha = value; } }
    public string Puntos { get { return puntos; } set { puntos = value; } }
    public string Nivel { get { return nivel; } set { nivel = value; } }
    public string Ganancia { get { return ganancia; } set { ganancia = value; } }
}