using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono2Model
/// </summary>
public class Bono2Model
{
    private string asociado;
    private string nombre;
    private string fecha;
    private string orden;
    private string ganancia;

    public string Asociado { get { return asociado; } set { asociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string Fecha { get { return fecha; } set { fecha = value; } }
    public string Orden { get { return orden; } set { orden = value; } }
    public string Ganancia { get { return ganancia; } set { ganancia = value; } }
}