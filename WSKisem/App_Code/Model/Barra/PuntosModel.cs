using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PuntosModel
/// </summary>
public class PuntosModel
{
    private int ptosDer;
    private int ptosIzq;

    public int PtosDer { get { return ptosDer; } set { ptosDer = value; } }
    public int PtosIzq { get { return ptosIzq; } set { ptosIzq = value; } }
}