using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono4DetalleModel
/// </summary>
public class Bono4DetalleModel
{
    private int inicialesIzq;
    private int inicialesDer;
    private int nuevosIzq;
    private int nuevosDer;
    private int pagados;
    private string porcentaje;

    public int InicialesIzq { get { return inicialesIzq; } set { inicialesIzq = value; } }
    public int InicialesDer { get { return inicialesDer; } set { inicialesDer = value; } }
    public int NuevosIzq { get { return nuevosIzq; } set { nuevosIzq = value; } }
    public int NuevosDer { get { return nuevosDer; } set { nuevosDer = value; } }
    public int Pagados { get { return pagados; } set { pagados = value; } }
    public string Porcentaje { get { return porcentaje; } set { porcentaje = value; } }
}