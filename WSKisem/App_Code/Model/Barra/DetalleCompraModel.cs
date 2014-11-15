using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DetalleCompraModel
/// </summary>
public class DetalleCompraModel
{
    private string idOrden;
    private string noDistribuidor;
    private string nombre;
    private string direccion;
    private string direccionColonia;
    private string fechaOrden;
    private string fechaPago;
    private string origenOrden;
    private string periodo;
    private string statusOrden;
    private string operador;
    private string codigoArt;
    private string descripcArt;
    private int cantArt;
    private int puntos;
    private double precioUnit;
    private double total;

    public string IdOrden { get { return idOrden; } set { idOrden = value; } }
    public string NoDistribuidor { get { return noDistribuidor; } set { noDistribuidor = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string Direccion { get { return direccion; } set { direccion = value; } }
    public string DireccionColonia { get { return direccionColonia; } set { direccionColonia = value; } }
    public string FechaOrden { get { return fechaOrden; } set { fechaOrden = value; } }
    public string FechaPago { get { return fechaPago; } set { fechaPago = value; } }
    public string OrigenOrden { get { return origenOrden; } set { origenOrden = value; } }
    public string Periodo { get { return periodo; } set { periodo = value; } }
    public string StatusOrden { get { return statusOrden; } set { statusOrden = value; } }
    public string Operador { get { return operador; } set { operador = value; } }
    public string CodigoArt { get { return codigoArt; } set { codigoArt = value; } }
    public string DescripcArt { get { return descripcArt; } set { descripcArt = value; } }
    public int CantArt { get { return cantArt; } set { cantArt = value; } }
    public int Puntos { get { return puntos; } set { puntos = value; } }
    public double PrecioUnit { get { return precioUnit; } set { precioUnit = value; } }
    public double Total { get { return total; } set { total = value; } }
}