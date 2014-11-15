using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DetallePuntosModel
/// </summary>
public class DetallePuntosModel
{
    private string idAsociado;
    private string nombre;
    private string idCompra;
    private string fechaPago;
    private int puntos;

    public string IdAsociado { get { return idAsociado; } set { idAsociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string IdCompra { get { return idCompra; } set { idCompra = value; } }
    public string FechaPago { get { return fechaPago; } set { fechaPago = value; } }
    public int Puntos { get { return puntos; } set { puntos = value; } }
}