using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Bono3Model
/// </summary>
public class Bono3Model
{
    private string asociado;
    private string nombre;
    private string fechaInsc;
    private string orden;
    private string patrocinador;
    private string ganancia;

    public string Asociado { get { return asociado; } set { asociado = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string FechaInsc { get { return fechaInsc; } set { fechaInsc = value; } }
    public string Orden { get { return orden; } set { orden = value; } }
    public string Patrocinador { get { return patrocinador; } set { patrocinador = value; } }
    public string Ganancia { get { return ganancia; } set { ganancia = value; } }
}