using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ComprasModel
/// </summary>
public class ComprasModel
{
    private string idCompra;
    private string asociado;
    private int paquete;
    private int cantidad;
    private int puntos;
    private double costo;
    private DateTime fechaOrden;
    private string tipoCompra;
    private double iva;
    private double envio;
    private double total;
    private string statusPago;
    private string statusEntrega;
    private DateTime inicioActivacion;
    private DateTime finActivacion;
    private string tipoPago;
    private string tipoEntrega;
    private string referencia;
    private string autor;
    private string observacion;

    public string IdCompra { get { return idCompra; } set { idCompra = value; } }
    public string Asociado { get { return asociado; } set { asociado = value; } }
    public int Paquete { get { return paquete; } set { paquete = value; } }
    public int Cantidad { get { return cantidad; } set { cantidad = value; } }
    public int Puntos { get { return puntos; } set { puntos = value; } }
    public double Costo { get { return costo; } set { costo = value; } }
    public DateTime FechaOrden { get { return fechaOrden; } set { fechaOrden = value; } }
    public string TipoCompra { get { return tipoCompra; } set { tipoCompra = value; } }
    public double Iva { get { return iva; } set { iva = value; } }
    public double Envio { get { return envio; } set { envio = value; } }
    public double Total { get { return total; } set { total = value; } }
    public string StatusPago { get { return statusPago; } set { statusPago = value; } }
    public string StatusEntrega { get { return statusEntrega; } set { statusEntrega = value; } }
    public DateTime InicioActivacion { get { return inicioActivacion; } set { inicioActivacion = value; } }
    public DateTime FinActivacion { get { return finActivacion; } set { finActivacion = value; } }
    public string TipoPago { get { return tipoPago; } set { tipoPago = value; } }
    public string TipoEntrega { get { return tipoEntrega; } set { tipoEntrega = value; } }
    public string Referencia { get { return referencia; } set { referencia = value; } }
    public string Autor { get { return autor; } set { autor = value; } }
    public string Observacion { get { return observacion; } set { observacion = value; } }
}