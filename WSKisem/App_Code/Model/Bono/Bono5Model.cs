using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono5Model
/// </summary>
public class Bono5Model
{
    private string idAsociado;
    private string nombre;
    private string monto;
    private string ganancia;

    public string IdAsociado { get { return idAsociado; } set { idAsociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string Monto { get { return monto; } set { monto = value; } }
    public string Ganancia { get { return ganancia; } set { ganancia = value; } }
}