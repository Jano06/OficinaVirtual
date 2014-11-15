using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;

/// <summary>
/// Descripción breve de PrincipalAction
/// </summary>
public class PrincipalAction
{
	DateTime desde, hasta;
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(PrincipalAction));

    public InfoPcpalModel ConsInfoPrincipal(int idAsociado)
    {
        InfoPcpalModel model = new InfoPcpalModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        int status = 0;
        try
        {
            string strQuery = "SELECT NOMBRE, APPATERNO, APMATERNO FROM ASOCIADOS " +
                            "WHERE ID = " + idAsociado + " AND STATUS < 2";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdUsuario = idAsociado;
                model.NombreUsuario = reader["NOMBRE"].ToString() + " " + reader["APPATERNO"].ToString() + " " + reader["APMATERNO"].ToString();
            }
            mySqlConn.Close();

            strQuery = "SELECT RANGOS.ID, RANGOS.NOMBRE FROM ASOCIADOS ASOC, RANGOS " +
                    "WHERE ASOC.RANGO = RANGOS.ID AND ASOC.ID = " + idAsociado;
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdMaxRango = int.Parse(reader["ID"].ToString());
                model.MaxRango = reader["NOMBRE"].ToString().ToUpper();
            }

            mySqlConn.Close();

            strQuery = "SELECT RANGOS.ID, RANGOS.NOMBRE FROM ASOCIADOS ASOC, RANGOS " +
                    "WHERE ASOC.RANGOPAGO = RANGOS.ID AND ASOC.ID = " + idAsociado;
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.IdRangoActual = int.Parse(reader["ID"].ToString());
                model.RangoActual = reader["NOMBRE"].ToString().ToUpper();
            }
            mySqlConn.Close();

            strQuery = "SELECT PATROCINADOR.NOMBRE, PATROCINADOR.APPATERNO, PATROCINADOR.APMATERNO FROM ASOCIADOS ASOC, ASOCIADOS PATROCINADOR " +
                    "WHERE PATROCINADOR.ID = ASOC.PATROCINADOR AND ASOC.ID = " + idAsociado;
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.Patrocinador = reader["NOMBRE"].ToString().ToUpper() + " " + reader["APPATERNO"].ToString().ToUpper() + " " + reader["APMATERNO"].ToString().ToUpper();
            }
            mySqlConn.Close();

            strQuery = "SELECT STATUS, DATE_FORMAT(FINACTIVACION,'%d-%m-%Y') as FINACTIVACION FROM ASOCIADOS " +
                    "WHERE ID = " + idAsociado;
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                status = int.Parse(reader["STATUS"].ToString());
                if (status != 1)
                {
                    DateTime inactivo = Convert.ToDateTime(reader["FINACTIVACION"]);
                    model.FechaActivacion = "Llevas Inactivo " + DateTime.Today.AddDays(-(inactivo.Day)).Day + " Dias";
                }
            }
            mySqlConn.Close();

            switch (status)
            {
                case 0:
                    model.Status = "INACTIVO";
                    break;
                case 1:
                    model.Status = "ACTIVO";
                    model.FechaActivacion = "";
                    break;
                case 2:
                    model.Status = "SUSPENDIDO";
                    break;
            }
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar la informacion de:" + idAsociado + e.Message);// mensaje de error del usuario
            throw new Exception("ConsultUser Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            conn.closeConection();
        }
        return model;
    }

    public proxCompraModel ConsProxCompra(int idAsociado)
    {
        proxCompraModel model = new proxCompraModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        int status = 0;
        string fechaInscripcion = "";
        try
        {
            string strQuery = "SELECT FINSC, STATUS FROM ASOCIADOS " +
                                    "WHERE ID =" + idAsociado;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if(!reader.IsDBNull(0))
                    fechaInscripcion = Convert.ToDateTime(reader["FINSC"]).ToString("dd/MM/yyyy");
                if(!reader.IsDBNull(1))
                    status = reader.GetInt32("STATUS");
            }
            mySqlConn.Close();

            DateTime fecha = Convert.ToDateTime(fechaInscripcion);
            DateTime prox = new DateTime();

            if (fecha.Day >= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
            {
                prox = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year);
            }
            else
            {
                prox = Convert.ToDateTime(fecha.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year);
            }
            
            
            if ((prox < DateTime.Today))
            {
                if ((DateTime.Today.Month + 1) > 12)
                {
                    if (fecha.Day >= DateTime.DaysInMonth(DateTime.Today.Year + 1, 1))
                    {
                        model.Calificacion = Convert.ToDateTime(DateTime.DaysInMonth((DateTime.Today.Year + 1), 1) + "/01/" + (DateTime.Today.Year + 1));
                    }
                    else
                    {
                        model.Calificacion = Convert.ToDateTime(fecha.Day + "/01/" + (DateTime.Today.Year + 1));
                    }
                }
                else
                {
                    
                    if (fecha.Day >= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
                    {
                        model.Calificacion = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "/" + (DateTime.Today.Month) + "/" + DateTime.Today.Year);
                    }
                    else
                    {
                        model.Calificacion = Convert.ToDateTime(fecha.Day + "/" + (DateTime.Today.Month + 1) + "/" + DateTime.Today.Year);
                    }
                }
            }
            else
            {
                if (fecha.Day >= DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
                {
                    model.Calificacion = Convert.ToDateTime(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "/" + (DateTime.Today.Month) + "/" + DateTime.Today.Year);
                }
                else
                {
                    model.Calificacion = Convert.ToDateTime(fecha.Day + "/" + (DateTime.Today.Month) + "/" + DateTime.Today.Year);
                }
            }

            int dia = fecha.Day;
            int banderaDesde = 0, banderaHasta = 0;

            fecha = model.Calificacion;
            for (int i = 0; i < 21; i++)
            {
                fecha = fecha.AddDays(-1);
                if (fecha.DayOfWeek == DayOfWeek.Friday && banderaDesde == 0 && banderaHasta == 1)
                {
                    desde = fecha.AddDays(1);
                    banderaDesde = 1;
                }
                if (fecha.DayOfWeek == DayOfWeek.Friday && banderaHasta == 0)
                {
                    hasta = fecha;
                    banderaHasta = 1;
                }
            }
            desde = desde.AddDays(7);
            hasta = hasta.AddDays(7);

            if (hasta < DateTime.Today || comprasEntre(desde.ToString("yyyy/MM/dd"), hasta.ToString("yyyy/MM/dd"), idAsociado))
            {
                banderaDesde = 0;
                banderaHasta = 0;
                fecha = Convert.ToDateTime(dia + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
                fecha = fecha.AddMonths(1);
                for (int i = 0; i < 21; i++)
                {
                    fecha = fecha.AddDays(-1);
                    if (fecha.DayOfWeek == DayOfWeek.Friday && banderaDesde == 0 && banderaHasta == 1)
                    {
                        desde = fecha.AddDays(1);
                        banderaDesde = 1;
                    }
                    if (fecha.DayOfWeek == DayOfWeek.Friday && banderaHasta == 0)
                    {
                        hasta = fecha;
                        banderaHasta = 1;
                    }
                }
                desde = desde.AddDays(7);
                hasta = hasta.AddDays(7);
            }
            model.RangoDesde = Convert.ToDateTime(desde.ToString("dd/MMMM/yyyy"));
            model.RangoHasta = Convert.ToDateTime(hasta.ToString("dd/MMMM/yyyy"));
        }   
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar la proxima compra de:" + idAsociado + e.Message);// mensaje de error del usuario
            throw new Exception("ConsultProxCompra Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            conn.closeConection();
        }
        return model;
    }

    

    public miOrganizacionModel ConsMiOrganizacion(int idAsociado)
    {
        miOrganizacionModel modelo = new miOrganizacionModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        string[] recorridoArray, ladoArray;
        string recorrido, lado;
        int izq = 0, der = 0;
        try
        {
            string strQuery = "SELECT COUNT(ID) AS TOTAL, LADOPATROCINADOR FROM ASOCIADOS WHERE PATROCINADOR=" + idAsociado + " AND STATUS=1 GROUP BY LADOPATROCINADOR";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    if (reader.GetString("LADOPATROCINADOR") == "D")
                        modelo.PatrocinLadoDer = reader.GetInt32("TOTAL");
                    else if (reader.GetString("LADOPATROCINADOR") == "I")
                        modelo.PatrocinLadoIzq = reader.GetInt32("TOTAL");
                }
            }
            mySqlConn.Close();

            strQuery = "SELECT ID, RECORRIDO, LADOSRECORRIDO FROM ASOCIADOS " +
                "WHERE STATUS=1 AND RECORRIDO LIKE '%." + idAsociado + ".%'";
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                recorrido = reader.GetString("RECORRIDO");
                lado = reader.GetString("LADOSRECORRIDO");
                recorridoArray = recorrido.Split(new char[] { '.' });
                ladoArray = lado.Split(new char[] { '.' });
                for (int i = 0; i < recorridoArray.Length; i++)
                {
                    if (!(recorridoArray[i] == string.Empty))
                    {
                        if (int.Parse(recorridoArray[i]) == idAsociado)
                        {
                            if (ladoArray[i].ToString() == "D")
                                der++;
                            else
                                izq++;
                        }
                    }
                }
            }
            mySqlConn.Close();
            modelo.AsocLadoDer = der;
            modelo.AsocLadoIzq = izq;
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar la Organizacion de:" + idAsociado + e.Message);// mensaje de error del usuario
            throw new Exception("ConstMiOrganizacion Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            conn.closeConection();
        }
        return modelo;
    }

    public int ConsultaRango(string idAsociado)
    {
        int rango = 0;
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        try
        {
            string strQuery = "SELECT RANGO FROM ASOCIADOS WHERE ID=" + idAsociado;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                rango = Convert.ToInt32(reader["RANGO"].ToString());
            }
            reader.Close();
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar Rango de:" + idAsociado + e.Message);// mensaje de error del usuario
            throw new Exception("ConsultaRango Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            conn.closeConection();
        }
        return rango;
    }
    
    public List<string> SiguienteRango(int sigRango)
    {
        List<string> descripcRango = new List<string>();
        switch(sigRango)
        {
            case 2:
                descripcRango.Add("Colaborador");
                descripcRango.Add("2 Emprendedores / Empresarios directos o más de un lado");
                descripcRango.Add("1 Emprendedor / Empresario directo o más del otro lado");
                descripcRango.Add("");
                descripcRango.Add("");
                break;
            case 3:
                descripcRango.Add("Colaborador Ejecutivo");
                descripcRango.Add("2 Emprendedores / Empresarios directos o más de un lado");
                descripcRango.Add("1 Emprendedor / Empresario directo o más del otro lado");
                descripcRango.Add("Un volúmen total de puntos para calificación de 1300");
                descripcRango.Add("Mínimo 165 puntos en el lado menor");
                break;
            case 4:
                descripcRango.Add("Bronce");
                descripcRango.Add("2 Emprendedores / Empresarios directos o más de un lado");
                descripcRango.Add("1 Emprendedor / Empresario directo o más del otro lado");
                descripcRango.Add("Un volúmen total de puntos para calificación de 550");
                descripcRango.Add("Mínimo 390 puntos en el lado menor");
                break;
            case 5:
                descripcRango.Add("Plata");
                descripcRango.Add("2 Emprendedores / Empresarios directos o más de un lado");
                descripcRango.Add("1 Emprendedor / Empresario directo o más del otro lado");
                descripcRango.Add("Un volúmen total de puntos para calificación de 2500");
                descripcRango.Add("Mínimo 750 puntos en el lado menor");
                break;
            case 6:
                descripcRango.Add("Oro");
                descripcRango.Add("2 Emprendedores / Empresarios directos por lado");
                descripcRango.Add("");
                descripcRango.Add("Un volúmen total de puntos para calificación de 5600");
                descripcRango.Add("Mínimo 1680 puntos en el lado menor");
                break;
            case 7:
                descripcRango.Add("Diamante");
                descripcRango.Add("2 Emprendedores / Empresarios directos por lado");
                descripcRango.Add("");
                descripcRango.Add("Un volúmen total de puntos para calificación de 11250");
                descripcRango.Add("Mínimo 3375 puntos en el lado menor");
                break;
            case 8:
                descripcRango.Add("Diamante Ejecutivo");
                descripcRango.Add("2 Emprendedores / Empresarios directos por lado");
                descripcRango.Add("");
                descripcRango.Add("Un volúmen total de puntos para calificación de 22500");
                descripcRango.Add("Mínimo 9000 puntos en el lado menor");
                break;
            case 9:
                descripcRango.Add("Diamante Internacional");
                descripcRango.Add("2 Emprendedores / Empresarios directos por lado");
                descripcRango.Add("");
                descripcRango.Add("Un volúmen total de puntos para calificación de 45000");
                descripcRango.Add("Mínimo 18000 puntos en el lado menor");
                break;
            default:
                descripcRango.Add("MÁXIMO RANGO ALCANZADO");
                descripcRango.Add("");
                descripcRango.Add("");
                descripcRango.Add("");
                descripcRango.Add("");
                break;
        }
        return descripcRango;
    }

    public bool comprasEntre(string inicio, string fin, int idAsociado)
    {
        bool resp = false;
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID FROM COMPRAS " +
                                    "WHERE ASOCIADO =" + idAsociado + " AND FECHA BETWEEN '" + inicio + "' AND '" + fin + "' ";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                resp = true;
            }
            mySqlConn.Close();
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar compras de:" + idAsociado + e.Message);// mensaje de error del usuario
            throw new Exception("ComprasEntre Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            conn.closeConection();
        }
        return resp;
    }

    public DateTime cierreCalif()
    {
        DateTime cierre = new DateTime();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        try
        {
            string strQuery = "SELECT FIN FROM CICLOS WHERE CURDATE() BETWEEN INICIO AND FIN";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                cierre = Convert.ToDateTime(reader["FIN"].ToString());
            }
            reader.Close();
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar cierre Calif de:" + e.Message);// mensaje de error del usuario
            throw new Exception("cierreCalif Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            conn.closeConection();
        }
        return cierre;
    }

    private string inicioCalif()
    {
        string fechaInicio = "";
        InfoPcpalModel model = new InfoPcpalModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO FROM CICLOS WHERE CURDATE() BETWEEN INICIO AND FIN";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();

            while (reader.Read())
            {
                fechaInicio = reader["INICIO"].ToString();
            }
            mySqlConn.Close();
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar Inicio Calif de:" + e.Message);// mensaje de error del usuario
            throw new Exception("Inicio Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            conn.closeConection();
        }
        return fechaInicio;
    }
}