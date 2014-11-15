using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MisGananciasModel
/// </summary>
public class MisGananciasModel
{
    private string idCorte;
    private string ganancias;
    private string retencionISR;
    private string iva;
    private string retencionIva;
    private string gananciaNeta;
    private string periodo;

    public string IdCorte { get { return idCorte; } set { idCorte = value; } }
    public string Ganancias { get { return ganancias; } set { ganancias = value; } }
    public string RetencionISR { get { return retencionISR; } set { retencionISR = value; } }
    public string Iva { get { return iva; } set { iva = value; } }
    public string RetencionIva { get { return retencionIva; } set { retencionIva = value; } }
    public string GananciaNeta { get { return gananciaNeta; } set { gananciaNeta = value; } }
    public string Periodo { get { return periodo; } set { periodo = value; } }
}