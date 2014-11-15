using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;
using System.Text.RegularExpressions;

/// <summary>
/// Descripción breve de ComprasAction
/// </summary>
public class ComprasAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(ComprasAction));

    public int Prospectos(string idUser)
    {
        int prospectos = 0;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT COUNT(*) AS CANTIDAD FROM PROSPECTOS WHERE PATROCINADOR= " + idUser + " AND STATUS=0";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                prospectos = Convert.ToInt32(reader["CANTIDAD"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Cantidad Prospectos: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return prospectos;
    }

    public List<string> ConsPrecioPqt(string pqt)
    {
        //double precioPqt = new double();
        List<string> detalle = new List<string>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT NOMBRE, COSTO FROM PAQUETES WHERE ID=" + pqt;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                detalle.Add(reader["NOMBRE"].ToString());
                detalle.Add(Convert.ToDouble(reader["COSTO"].ToString()).ToString("c"));
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Detalle Paquete: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return detalle;
    }

    public MisDatosPersonalesModel consDatosProspecto(string idUser)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, CONCAT(NOMBRE,' ',APPATERNO,' ',APMATERNO) as NOMBRE, "
                    + "CALLECASA, NUMCASA, COLCASA, CPCASA, MUNICIPIOCASA, ESTADOCASA FROM PROSPECTOS "
                    + "WHERE ID= " + idUser;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdUsuario = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString().ToUpper();
                model.CallePers = reader["CALLECASA"].ToString().ToUpper();
                model.NumExtPers = reader["NUMCASA"].ToString();
                model.ColoniaPers = reader["COLCASA"].ToString();
                model.CpPers = reader["CPCASA"].ToString();
                model.MunicipioPers = reader["MUNICIPIOCASA"].ToString().ToUpper();
                model.EdoPers = reader["ESTADOCASA"].ToString().ToUpper();
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Datos Prospecto: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public MisDatosPersonalesModel consDatos(string idUser)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, CONCAT(NOMBRE,' ',APPATERNO,' ',APMATERNO) as NOMBRE, "
                    + "CALLECASA, NUMCASA, COLCASA, CPCASA, MUNICIPIOCASA, ESTADOCASA FROM ASOCIADOS "
                    + "WHERE ID= " + idUser;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdUsuario = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString().ToUpper();
                model.CallePers = reader["CALLECASA"].ToString().ToUpper();
                model.NumExtPers = reader["NUMCASA"].ToString();
                model.ColoniaPers = reader["COLCASA"].ToString();
                model.CpPers = reader["CPCASA"].ToString();
                model.MunicipioPers = reader["MUNICIPIOCASA"].ToString().ToUpper();
                model.EdoPers = reader["ESTADOCASA"].ToString().ToUpper();
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Datos Persona: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public MisDatosPersonalesModel consDatosDomicilio(string idUser)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, CONCAT(NOMBRE,' ', APPATERNO,' ', APMATERNO) as NOMBRE, "
                    + "CALLEPAQ, NUMPAQ, COLPAQ, CPPAQ, MUNICIPIOPAQ, ESTADOPAQ FROM ASOCIADOS "
                    + "WHERE ID= " + idUser;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdUsuario = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString().ToUpper();
                model.CalleEnv = reader["CALLEPAQ"].ToString().ToUpper();
                model.NumExtEnv = reader["NUMPAQ"].ToString();
                model.CpEnv = reader["CPPAQ"].ToString();
                model.ColoniaEnv = reader["COLPAQ"].ToString();
                model.MunicipioEnv = reader["MUNICIPIOPAQ"].ToString();
                model.EdoEnv = reader["ESTADOPAQ"].ToString().ToUpper();
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Datos Persona: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public MisDatosPersonalesModel consDatosDomProsp(string idUser)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, CONCAT(NOMBRE,' ', APPATERNO,' ', APMATERNO) as NOMBRE, "
                    + "CALLEPAQ, NUMPAQ, COLPAQ, CPPAQ, MUNICIPIOPAQ, ESTADOPAQ FROM PROSPECTOS "
                    + "WHERE ID= " + idUser;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdUsuario = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString().ToUpper();
                model.CalleEnv = reader["CALLEPAQ"].ToString().ToUpper();
                model.NumExtEnv = reader["NUMPAQ"].ToString();
                model.CpEnv = reader["CPPAQ"].ToString();
                model.ColoniaEnv = reader["COLPAQ"].ToString();
                model.MunicipioEnv = reader["MUNICIPIOPAQ"].ToString();
                model.EdoEnv = reader["ESTADOPAQ"].ToString().ToUpper();
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Datos Domicilio Prospecto: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public List<string> DetallePaq(string pqt)
    {
        List<string> lista = new List<string>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT NOMBRE, COSTO FROM PAQUETES WHERE ID=" + pqt;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader["NOMBRE"].ToString());
                lista.Add(reader["COSTO"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Detalle Paquete: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return lista;
    }

    public List<string> DetalleInscr()
    {
        List<string> lista = new List<string>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT NOMBRE, COSTO FROM PAQUETES WHERE ID= 0";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader["NOMBRE"].ToString());
                lista.Add(reader["COSTO"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Detalle Inscripcion: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return lista;
    }

    public double DetalleEnvio()
    {
        double costoEnvio = new double();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT COSTOENVIO FROM CONFIGURACION";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                costoEnvio = Convert.ToDouble(reader["COSTOENVIO"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Detalle Envio: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return costoEnvio;
    }

    public proxCompraModel ConsRangoFechasInactivo(int diaActivacion)
    {
        proxCompraModel model = new proxCompraModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        DateTime fecha1 = new DateTime();
        DateTime fecha2 = new DateTime();
        DateTime hoy = DateTime.Today;
        try
        {
            if (diaActivacion >= DateTime.DaysInMonth(hoy.Year, hoy.Month))
            { fecha1 = Convert.ToDateTime(DateTime.DaysInMonth(hoy.Year, hoy.Month) + "/" + hoy.Month + "/" + hoy.Year); }
            else
            { fecha1 = Convert.ToDateTime(diaActivacion + "/" + hoy.Month + "/" + hoy.Year); }

            int mes= hoy.Month + 1;
            if (mes > 12)
            { mes = 1; }

            if (diaActivacion >= DateTime.DaysInMonth(hoy.Year,mes))
            {
                if ((hoy.Month + 1) > 12)
                { fecha2 = Convert.ToDateTime(DateTime.DaysInMonth((hoy.Year + 1), 1) + "/01/" + (hoy.Year + 1)); }
                else
                { fecha2 = Convert.ToDateTime(DateTime.DaysInMonth(hoy.Year, (hoy.Month + 1)) + "/" + (hoy.Month + 1) + "/" + hoy.Year); }
            }
            else
            {
                if (hoy.Month + 1 > 12)
                { fecha2 = Convert.ToDateTime(DateTime.DaysInMonth(hoy.Year, 1) + "/01/" + (hoy.Year + 1)); }
                else
                { fecha2 = Convert.ToDateTime(diaActivacion + "/" + (hoy.Month + 1) + "/" + hoy.Year); }
            }

            if (hoy >= fecha1)
            {
                model.RangoDesde = hoy;
                model.RangoHasta = fecha2.AddDays(-1);
            }
            else
            {
                model.RangoDesde = hoy;
                model.RangoHasta = fecha1.AddDays(-1);
            }
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar Rango Fechas Inactivo:" + e.Message);
            throw new Exception("ComprasAction Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            conn.closeConection();
        }
        return model;
    }

    public proxCompraModel ConsRangoFechasInactivoMasUno(int diaActivacion, DateTime calificacion, DateTime hoy)
    {
        proxCompraModel model = new proxCompraModel();
        try
        {
            if (hoy <= calificacion)
            {
                model.RangoDesde = calificacion;
                int mes = calificacion.Month;
                int anio = calificacion.Year;
                if (mes + 1 > 12)
                { mes = 1; anio++; }
                if (diaActivacion >= DateTime.DaysInMonth(anio, mes))
                {
                    model.RangoHasta = Convert.ToDateTime((DateTime.DaysInMonth(anio, mes) - 1) + "/" + (calificacion.Month + 1) + "/" + (calificacion.Year + 1));
                }
                else
                {
                    model.RangoHasta = calificacion.AddMonths(1).AddDays(-1);
                }
            }
            else
            {
                model.Calificacion = calificacion.AddMonths(-1);
                model.RangoDesde = hoy;
                int anio = calificacion.Year;
                int mes = calificacion.Month;
                if (mes + 1 > 12)
                { mes = 1; anio++; }
                if (diaActivacion >= DateTime.DaysInMonth(anio, mes))
                {
                    model.RangoHasta = Convert.ToDateTime((DateTime.DaysInMonth(anio, mes) - 1) + "/" + (calificacion.Month + 1) + "/" + (calificacion.Year + 1));
                }
                else
                {
                    model.RangoHasta = calificacion.AddMonths(1).AddDays(-1);
                }
            }
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar Rango Fechas Inactivo:" + e.Message);// mensaje de error del usuario
            throw new Exception("ComprasAction Error: " + e.Message);
        }
        return model;
    }

    public proxCompraModel ConsRangoFechasSigInactivo(int diaActivacion)
    {
        proxCompraModel model = new proxCompraModel();
        
        DateTime fecha1 = new DateTime();
        DateTime fecha2 = new DateTime();
        DateTime hoy = DateTime.Today;
        try
        {
            if (diaActivacion >= DateTime.DaysInMonth(hoy.Year, hoy.Month))
            { fecha1 = Convert.ToDateTime(DateTime.DaysInMonth(hoy.Year, hoy.Month) + "/" + hoy.Month + "/" + hoy.Year); }
            else
            { fecha1 = Convert.ToDateTime(diaActivacion + "/" + hoy.Month + "/" + hoy.Year); }

            if (diaActivacion >= DateTime.DaysInMonth(hoy.Year, hoy.Month + 1))
            {
                if (hoy.Month + 1 > 12)
                { fecha2 = Convert.ToDateTime(DateTime.DaysInMonth((hoy.Year + 1), 1) + "/01/" + (hoy.Year + 1)); }
                else
                { fecha2 = Convert.ToDateTime(DateTime.DaysInMonth(hoy.Year, (hoy.Month + 1)) + "/" + (hoy.Month + 1) + "/" + hoy.Year); }
            }
            else
            {
                if (hoy.Month + 1 > 12)
                { fecha2 = Convert.ToDateTime(DateTime.DaysInMonth(hoy.Year, 1) + "/01/" + (hoy.Year + 1)); }
                else
                { fecha2 = Convert.ToDateTime(diaActivacion + "/" + (hoy.Month + 1) + "/" + hoy.Year); }
            }

            model.RangoDesde = hoy;
            model.RangoHasta = fecha2;
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar Rango Fechas Inactivo:" + e.Message);// mensaje de error del usuario
            throw new Exception("ComprasAction Error: " + e.Message);
        }
        
        return model;
    }

    public proxCompraModel ConsSemanaActivacion(string idAsociado)
    {
        proxCompraModel model = new proxCompraModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        DateTime semana1 = new DateTime();
        DateTime semana2 = new DateTime();
        DateTime semana3 = new DateTime();
        DateTime fecha = new DateTime();
        DateTime fechaInsc1 = new DateTime();
        DateTime fechaInsc2 = new DateTime();
        DateTime fechaInsc3 = new DateTime();
        int status = 0;
        try
        {
            string strQuery = "SELECT FINSC, STATUS FROM ASOCIADOS " +
                                    "WHERE ID= " + idAsociado;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    fecha = Convert.ToDateTime(reader["FINSC"]);
                if (!reader.IsDBNull(1))
                    status = reader.GetInt32("STATUS");
            }
            mySqlConn.Close();
            DateTime hoy = DateTime.Today;
            int diaInsc = fecha.Day;
            model.DiaCalif = fecha.Day;
            int mes1 = 0, mes3 = 0;
            int anio1 = 0, anio3 = 0;

            if ((DateTime.Today.Month - 1) > 0)
            {
                mes1 = DateTime.Today.Month - 1;
                anio1 = DateTime.Today.Year;
            }
            else
            {
                mes1 = 12;
                anio1 = (DateTime.Today.Year - 1);
            }

            if ((DateTime.Today.Month + 1) > 12)
            {
                mes3 = 1;
                anio3 = (DateTime.Today.Year + 1);
            }
            else
            {
                mes3 = DateTime.Today.Month + 1;
                anio3 = DateTime.Today.Year;
            }

            if (diaInsc >= DateTime.DaysInMonth(anio1, mes1))
                fecha = Convert.ToDateTime(DateTime.DaysInMonth(anio1, mes1) + "/" + mes1 + "/" + anio1);
            else
                fecha = Convert.ToDateTime(diaInsc + "/" + mes1 + "/" + anio1);
            fechaInsc1 = fecha;
            for (int i = 0; i < 21; i++)
            {
                fecha = fecha.AddDays(-1);
                if (fecha.DayOfWeek == DayOfWeek.Friday)
                {
                    semana1 = fecha;
                    break;
                }
            }
            if (diaInsc >= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
                fecha = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "/" + (DateTime.Today.Month) + "/" + DateTime.Today.Year);
            else
                fecha = Convert.ToDateTime(diaInsc + "/" + (DateTime.Today.Month) + "/" + DateTime.Today.Year);
            fechaInsc2 = fecha;
            for (int i = 0; i < 21; i++)
            {
                fecha = fecha.AddDays(-1);
                if (fecha.DayOfWeek == DayOfWeek.Friday)
                {
                    semana2 = fecha;
                    break;
                }
            }
            if (diaInsc >= DateTime.DaysInMonth(anio3, mes3))
                fecha = Convert.ToDateTime(DateTime.DaysInMonth(anio3, mes3) + "/" + (mes3) + "/" + anio3);
            else
                fecha = Convert.ToDateTime(diaInsc + "/" + (mes3) + "/" + anio3);
            fechaInsc3 = fecha;
            for (int i = 0; i < 21; i++)
            {
                fecha = fecha.AddDays(-1);
                if (fecha.DayOfWeek == DayOfWeek.Friday)
                {
                    semana3 = fecha;
                    break;
                }
            }

            if (DateTime.Today >= semana1.AddDays(1) && DateTime.Today <= semana1.AddDays(7))
            {
                model.Calificacion = fechaInsc1;
                model.RangoHasta = semana1.AddDays(7);
                model.RangoDesde = semana1.AddDays(1);
            }
            else if (DateTime.Today >= semana2.AddDays(1) && DateTime.Today <= semana2.AddDays(7))
            {
                model.Calificacion = fechaInsc2;
                model.RangoHasta = semana2.AddDays(7);
                model.RangoDesde = semana2.AddDays(1);
            }
            else if (DateTime.Today >= semana3.AddDays(1) && DateTime.Today <= semana3.AddDays(7))
            {
                model.Calificacion = fechaInsc3;
                model.RangoHasta = semana3.AddDays(7);
                model.RangoDesde = semana3.AddDays(1);
            }
            
            if (status.Equals(1))
            {
                model.Status = "ACTIVO";
            }
            else if (status.Equals(0))
            {
                model.Status = "INACTIVO";
            }
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar Fecha Inscripcion:" + e.Message);// mensaje de error del usuario
            throw new Exception("ComprasAction Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            conn.closeConection();
        }
        return model;
    }

    public void insertaCompraActivo(ComprasModel compra, int activar, int excedente, proxCompraModel fechas, int sigPeriodo)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        DateTime finActiv = new DateTime();
        try
        {
            string strQuery = "SELECT PUNTOS FROM PAQUETES WHERE ID=" + compra.Paquete;
            
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra.Puntos = Convert.ToInt32(reader["PUNTOS"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT (MAX(ID) + 1) AS IDCOMPRA FROM COMPRAS";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra.IdCompra = reader["IDCOMPRA"].ToString();
            }
            reader.Close();
            mySqlConn.Close();
            
            compra.Referencia = referencia(compra.IdCompra).ToString();

            if (excedente.Equals(1))
            {
                strQuery = "INSERT INTO COMPRAS (ID, ASOCIADO, PAQUETE, CANTIDAD, PUNTOS, COSTO, FECHAORDEN, ACTIVACION, EXCEDENTE, IVA, ENVIO, TOTAL, STATUSPAGO, STATUSENTREGA, TIPOPAGO, TIPOENTREGA, REFERENCIA, AUTOR, OBSERVACIONES, INSCRIPCION)"
                    + " VALUES (" + compra.IdCompra + ", " + compra.Asociado + ", " + compra.Paquete + ", " + compra.Cantidad + ", " + compra.Puntos + ", " + compra.Costo + ", '" + compra.FechaOrden.ToString("yyyy/MM/dd") + "', 0, 1, " + compra.Iva + ", "
                    + compra.Envio + ", " + compra.Total + ", '" + compra.StatusPago + "', '" + compra.StatusEntrega + "', '" + compra.TipoPago + "', '" + compra.TipoEntrega + "', " + compra.Referencia + ", '" + compra.Autor + "', '" + compra.Observacion + "', 0)";
            }
            else
            {
                if (fechas.DiaCalif >= DateTime.DaysInMonth(fechas.Calificacion.Year, fechas.Calificacion.Month))
                {
                    if ((fechas.Calificacion.Month + 1) > 12)
                        finActiv = Convert.ToDateTime((DateTime.DaysInMonth((fechas.Calificacion.Year + 1), 1) - 1) + "/01/" + (fechas.Calificacion.Year + 1));
                    else
                        finActiv = Convert.ToDateTime((DateTime.DaysInMonth((fechas.Calificacion.Year), 1) - 1) + "/" + (fechas.Calificacion.Month + 1) + "/" + fechas.Calificacion.Year);
                }
                else
                {
                    if ((fechas.Calificacion.Month + 1) > 12)
                    {
                        if ((fechas.DiaCalif - 1) > 0)
                        { finActiv = Convert.ToDateTime((fechas.DiaCalif - 1) + "/01/" + (fechas.Calificacion.Year + 1)); }
                        else
                        { finActiv = Convert.ToDateTime(DateTime.DaysInMonth(fechas.Calificacion.Year, fechas.Calificacion.Month) + "/01/" + (fechas.Calificacion.Year + 1)); }
                    }
                    else
                    {
                       finActiv = fechas.Calificacion.AddMonths(1).AddDays(-1); 
                    }
                }
                if (sigPeriodo.Equals(1))
                {
                    strQuery = "INSERT INTO COMPRAS (ID, ASOCIADO, PAQUETE, CANTIDAD, PUNTOS, COSTO, FECHAORDEN, ACTIVACION, EXCEDENTE, IVA, ENVIO, TOTAL, STATUSPAGO, STATUSENTREGA, INICIOACTIVACION, FINACTIVACION, TIPOPAGO, TIPOENTREGA, REFERENCIA, AUTOR, OBSERVACIONES, INSCRIPCION)"
                                + " VALUES (" + compra.IdCompra + ", " + compra.Asociado + ", " + compra.Paquete + ", " + compra.Cantidad + ", " + compra.Puntos + ", " + compra.Costo + ", '" + compra.FechaOrden.ToString("yyyy/MM/dd") + "', 1, 0, " + compra.Iva + ", "
                                + compra.Envio + ", " + compra.Total + ", '" + compra.StatusPago + "', '" + compra.StatusEntrega + "', '" + fechas.Calificacion.ToString("yyyy/MM/dd") + "', '" + finActiv.ToString("yyyy/MM/dd") + "' , '" + compra.TipoPago + "', '" + compra.TipoEntrega + "', " + compra.Referencia + ", '" + compra.Autor + "','" + compra.Observacion + "', 0)";
                }
                else
                {
                    strQuery = "INSERT INTO COMPRAS (ID, ASOCIADO, PAQUETE, CANTIDAD, PUNTOS, COSTO, FECHAORDEN, ACTIVACION, EXCEDENTE, IVA, ENVIO, TOTAL, STATUSPAGO, STATUSENTREGA, INICIOACTIVACION, FINACTIVACION, TIPOPAGO, TIPOENTREGA, REFERENCIA, AUTOR, OBSERVACIONES, INSCRIPCION)"
                                + " VALUES (" + compra.IdCompra + ", " + compra.Asociado + ", " + compra.Paquete + ", " + compra.Cantidad + ", " + compra.Puntos + ", " + compra.Costo + ", '" + compra.FechaOrden.ToString("yyyy/MM/dd") + "', 1, 0, " + compra.Iva + ", "
                                + compra.Envio + ", " + compra.Total + ", '" + compra.StatusPago + "', '" + compra.StatusEntrega + "', '" + DateTime.Today.ToString("yyyy/MM/dd") + "', '" + finActiv.ToString("yyyy/MM/dd") + "' , '" + compra.TipoPago + "', '" + compra.TipoEntrega + "', " + compra.Referencia + ", '" + compra.Autor + "', '" + compra.Observacion + "', 0)";
                }
            }

            mySqlConn.Open();
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Insertar compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    public void InsertaDetalleCompra(ComprasModel compra)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "INSERT INTO COMPRASDETALLE (COMPRA, CANTIDAD, PAQUETE, COSTO, PUNTOS) "
                            + "VALUES (" + compra.IdCompra + ", " + compra.Cantidad + ", " + compra.Paquete + ", " + compra.Costo + ", " + compra.Puntos + ")";
            mySqlConn.Open();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
            mySqlConn.Dispose();
            mySqlConn.Close();

            if (compra.TipoEntrega == "DOMICILIO")
            {
                strQuery = "INSERT INTO COMPRASDETALLE (COMPRA, CANTIDAD, PAQUETE, COSTO, PUNTOS) "
                            + "VALUES (" + compra.IdCompra + ", 1, -1, " + compra.Envio + ", 0)";
                mySqlConn.Open();
                queryEx = new MySqlCommand(strQuery, mySqlConn);
                queryEx.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Insertar Detalle Compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    public void ConsCostoInscripc()
    { 
        
    }

    public void InsertaDetalleCompraProsp(ComprasModel compra, double costoInscripcion)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "INSERT INTO COMPRASDETALLE (COMPRA, CANTIDAD, PAQUETE, COSTO, PUNTOS) "
                            + "VALUES (" + compra.IdCompra + ", " + compra.Cantidad + ", " + compra.Paquete + ", " + compra.Costo + ", " + compra.Puntos + ")";
            mySqlConn.Open();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
            mySqlConn.Dispose();
            mySqlConn.Close();

            strQuery = "INSERT INTO COMPRASDETALLE (COMPRA, CANTIDAD, PAQUETE, COSTO, PUNTOS) "
                            + "VALUES (" + compra.IdCompra + ", 1, 0, " + costoInscripcion + ", 0)";
            mySqlConn.Open();
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
            mySqlConn.Dispose();
            mySqlConn.Close();

            if (compra.TipoEntrega == "DOMICILIO")
            {
                strQuery = "INSERT INTO COMPRASDETALLE (COMPRA, CANTIDAD, PAQUETE, COSTO, PUNTOS) "
                            + "VALUES (" + compra.IdCompra + ", 1, -1, " + compra.Envio + ", 0)";
                mySqlConn.Open();
                queryEx = new MySqlCommand(strQuery, mySqlConn);
                queryEx.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Insertar Detalle Compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    public void insertaCompraInactivo(ComprasModel compra, proxCompraModel fechas)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT PUNTOS FROM PAQUETES WHERE ID=" + compra.Paquete;
            
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra.Puntos = Convert.ToInt32(reader["PUNTOS"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT (MAX(ID) + 1) AS IDCOMPRA FROM COMPRAS";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra.IdCompra = reader["IDCOMPRA"].ToString();
            }
            reader.Close();
            mySqlConn.Close();
            
            compra.Referencia = referencia(compra.IdCompra).ToString();

            strQuery = "INSERT INTO COMPRAS (ID, ASOCIADO, PAQUETE, CANTIDAD, PUNTOS, COSTO, FECHAORDEN, ACTIVACION, EXCEDENTE, IVA, ENVIO, TOTAL, STATUSPAGO, STATUSENTREGA, INICIOACTIVACION, FINACTIVACION, TIPOPAGO, TIPOENTREGA, REFERENCIA, AUTOR, OBSERVACIONES)"
                        + " VALUES (" + compra.IdCompra + ", " + compra.Asociado + ", " + compra.Paquete + ", " + compra.Cantidad + ", " + compra.Puntos + ", " + compra.Costo + ", '" + compra.FechaOrden.ToString("yyyy/MM/dd") + "', 1, 0, " + compra.Iva + ", "
                        + compra.Envio + ", " + compra.Total + ", '" + compra.StatusPago + "', '" + compra.StatusEntrega + "', '" + fechas.RangoDesde.ToString("yyyy/MM/dd") + "', '" + fechas.RangoHasta.ToString("yyyy/MM/dd") + "' , '" + compra.TipoPago + "', '" + compra.TipoEntrega + "', " + compra.Referencia + ", '" + compra.Autor + "', '" + compra.Observacion + "')";
            //Registrar en la base de datos strQuery
            mySqlConn.Open();
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Insertar compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    public void insertaCompraProspecto(ComprasModel compra, string idProspecto)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT PUNTOS FROM PAQUETES WHERE ID=" + compra.Paquete;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra.Puntos = Convert.ToInt32(reader["PUNTOS"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT (MAX(ID) + 1) AS IDCOMPRA FROM COMPRAS";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra.IdCompra = reader["IDCOMPRA"].ToString();
            }
            reader.Close();
            mySqlConn.Close();

            compra.Referencia = referencia(compra.IdCompra).ToString();

            strQuery = "INSERT INTO COMPRAS (ID, ASOCIADO, PAQUETE, CANTIDAD, PUNTOS, COSTO, FECHAORDEN, ACTIVACION, EXCEDENTE, IVA, ENVIO, TOTAL, STATUSPAGO, STATUSENTREGA, INICIOACTIVACION, FINACTIVACION, TIPOPAGO, TIPOENTREGA, REFERENCIA, INSCRIPCION, AUTOR, OBSERVACIONES)"
                        + " VALUES (" + compra.IdCompra + ", " + compra.Asociado + ", " + compra.Paquete + ", " + compra.Cantidad + ", " + compra.Puntos + ", " + compra.Costo + ", '" + compra.FechaOrden.ToString("yyyy/MM/dd") + "', 1, 0, " + compra.Iva + ", "
                        + compra.Envio + ", " + compra.Total + ", '" + compra.StatusPago + "', '" + compra.StatusEntrega + "', '" + DateTime.Today.ToString("yyyy/MM/dd") + "', '" + DateTime.Today.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd") + "' , '" + compra.TipoPago + "', '" + compra.TipoEntrega + "', " + compra.Referencia + ", " + idProspecto + ", '" + compra.Autor + "', '" + compra.Observacion + "')";
            
            mySqlConn.Open();
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Insertar compra Prospecto: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    private int referencia(string compra)
    {
        string respuesta = string.Empty;
        int largo = compra.ToString().Length;
        int digVer = 0;
        int[] posiciones = new int[largo];
        int i = 0;
        foreach (char numero in compra.ToString())
        {
            posiciones[i] = int.Parse(numero.ToString());
            i++;
        }

        int digito = 2;
        largo -= 1;
        for (i = 0; i < posiciones.Length; i++)
        {
            posiciones[largo - i] = (posiciones[largo - i]) * digito;

            if (digito.Equals(2))
                digito = 1;
            else
                digito = 2;
        }

        for (i = 0; i < posiciones.Length; i++)
        {
            if (posiciones[i] > 9)
                posiciones[i] = reduce(posiciones[i]);
            digVer += posiciones[i];
        }
        digVer = digVer % 10;
        digVer = 10 - digVer;
        if (digVer.Equals(10))
            digVer = 0;
        respuesta = compra + "" + digVer.ToString();

        return int.Parse(respuesta);
    }

    private int reduce(int valor)
    {
        int unidades = valor % 10;
        int decenas = (valor - unidades) / 10;
        valor = decenas + unidades;
        if (valor > 9)
            valor = reduce(valor);
        return valor;
    }

    public string mensajeGracias()
    {
        string mensaje = string.Empty;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT MENSAJECOMPRA FROM CONFIGURACION";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                mensaje = reader["MENSAJECOMPRA"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Mensaje Compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return mensaje;
    }
}