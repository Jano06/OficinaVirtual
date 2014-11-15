using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de miOrganizacionModel
/// </summary>
public class miOrganizacionModel
{
    private int patrocinLadoIzq;
    private int patrocinLadoDer;
    private int asocLadoIzq;
    private int asocLadoDer;

    public int PatrocinLadoIzq { get { return patrocinLadoIzq; } set { patrocinLadoIzq = value; } }
    public int PatrocinLadoDer { get { return patrocinLadoDer; } set { patrocinLadoDer = value; } }
    public int AsocLadoIzq { get { return asocLadoIzq; } set { asocLadoIzq = value; } }
    public int AsocLadoDer { get { return asocLadoDer; } set { asocLadoDer = value; } }
}