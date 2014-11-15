using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de InfoPcpalModel
/// </summary>
public class InfoPcpalModel
{
	
	private string nombreUsuario;
    private int idUsuario;
    private int idRangoActual;
    private string rangoActual;
    private int idMaxRango;
    private string maxRango;
    private string patrocinador;
    private string status;
    private string fechaActivacion;

    public int IdUsuario { get { return idUsuario; } set { idUsuario = value; } }
    public string NombreUsuario { get { return nombreUsuario; } set { nombreUsuario = value; } }
    public int IdRangoActual { get { return idRangoActual; } set { idRangoActual = value; } }
    public string RangoActual { get { return rangoActual; } set { rangoActual = value; } }
    public int IdMaxRango { get { return idMaxRango; } set { idMaxRango = value; } }
    public string MaxRango { get { return maxRango; } set { maxRango = value; } }
    public string Patrocinador { get { return patrocinador; } set { patrocinador = value; } }
    public string Status { get { return status; } set { status = value; } }
    public string FechaActivacion { get { return fechaActivacion; } set { fechaActivacion = value; } }
}