using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MiProspectoModel
/// </summary>
public class MiProspectoModel
{
    private string idProspecto;
    private string nombre;
    private string apPaterno;
    private string apMaterno;
    private string celular;
    private string email;

    public string IdProspecto { get { return idProspecto; } set { idProspecto = value; } }
    public string Nombre { get { return nombre; } set { nombre = value; } }
    public string ApPaterno { get { return apPaterno; } set { apPaterno = value; } }
    public string ApMaterno { get { return apMaterno; } set { apMaterno = value; } }
    public string Celular { get { return celular; } set { celular = value; } }
    public string Email { get { return email; } set { email = value; } }
}