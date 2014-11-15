using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de OrganizacionModel
/// </summary>
public class OrganizacionModel
{
    private string idAsociado;
    private string izquierdo;
    private string derecho;
    private string status;
    private string rango;
    private string ultCompra;
    private string periodo;

    public string IdAsociado { get { return idAsociado; } set { idAsociado = value; } }
    public string Izquierdo { get { return izquierdo; } set { izquierdo = value; } }
    public string Derecho { get { return derecho; } set { derecho = value; } }
    public string Status { get { return status; } set { status = value; } }
    public string Rango { get { return rango; } set { rango = value; } }
    public string UltCompra { get { return ultCompra; } set { ultCompra = value; } }
    public string Periodo { get { return periodo; } set { periodo = value; } }
}