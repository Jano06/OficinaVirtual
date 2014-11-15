using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de LogrosModel
/// </summary>
public class LogrosModel
{
    private int puntosIzq;
    private int puntosDer;
    private int puntoTotales;
    private int empreIzq;
    private int empreDer;
    private int inactIzq;
    private int inactDer;
    private int rango;

    public int PuntosIzq { get { return puntosIzq; } set { puntosIzq = value; } }
    public int PuntosDer { get { return puntosDer; } set { puntosDer = value; } }
    public int PuntoTotales { get { return puntoTotales; } set { puntoTotales = value; } }
    public int EmpreIzq { get { return empreIzq; } set { empreIzq = value; } }
    public int EmpreDer { get { return empreDer; } set { empreDer = value; } }
    public int InactIzq { get { return inactIzq; } set { inactIzq = value; } }
    public int InactDer { get { return inactDer; } set { inactDer = value; } }
    public int Rango { get { return rango; } set { rango = value; } }
}