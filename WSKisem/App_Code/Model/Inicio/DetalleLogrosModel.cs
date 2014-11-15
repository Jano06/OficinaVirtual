using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DetalleLogrosModel
/// </summary>
public class DetalleLogrosModel
{
    private string idAsociado;
    private string nombre;
    private string inicioActivacion;
    private string finActivacion;
    private int ptosMes;

    public string IdAsociado { get { return idAsociado; } set { idAsociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string InicioActivacion { get { return inicioActivacion; } set { inicioActivacion = value; } }
    public string FinActivacion { get { return finActivacion; } set { finActivacion = value; } }
    public int PtosMes { get { return ptosMes; } set { ptosMes = value; } }
}