using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ArbolColocacionModel
/// </summary>
public class ArbolColocacionModel
{
    private string id;
    private string nombre;
    private string rango;
    private string padre;
    private string lado;
    private string status;
    private string alias;
    private string fInscr;
    private string patrocinador;

    public string Id { get { return id; } set { id = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string Rango { get { return rango; } set { rango = value; } }
    public string Padre { get { return padre; } set { padre = value; } }
    public string Lado { get { return lado; } set { lado = value; } }
    public string Status { get { return status; } set { status = value; } }
    public string Alias { get { return alias; } set { alias = value; } }
    public string FInscr { get { return fInscr; } set { fInscr = value; } }
    public string Patrocinador { get { return patrocinador; } set { patrocinador = value; } }
}