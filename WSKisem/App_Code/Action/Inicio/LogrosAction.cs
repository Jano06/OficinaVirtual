using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;
using System.Text.RegularExpressions;

/// <summary>
/// Descripción breve de LogrosAction
/// </summary>
public class LogrosAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(LogrosAction));

    private DateTime ConsInicioCiclo()
    {
        DateTime inicio = new DateTime();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO FROM CICLOS WHERE CURDATE() BETWEEN INICIO AND FIN";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString()).Date;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Inicio Ciclo: " + ex.Message);
            throw new Exception("Error LogrosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return inicio;
    }

    private DateTime ConsFinCiclo()
    {
        DateTime fin = new DateTime();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT FIN FROM CICLOS WHERE CURDATE() BETWEEN INICIO AND FIN";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                fin = Convert.ToDateTime(reader["FIN"].ToString()).Date;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Fin Ciclo: " + ex.Message);
            throw new Exception("Error LogrosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return fin;
    }

    public LogrosModel ConsLogros(string idAsociado)
    {
        LogrosModel model = new LogrosModel();
        DateTime inicio = ConsInicioCiclo();//Convert.ToDateTime("2014-08-02")
        DateTime fin = ConsFinCiclo();//Convert.ToDateTime("2014-09-12");

        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT COMPRASDETALLE.CANTIDAD AS CANTIDAD, COMPRASDETALLE.PAQUETE AS PAQUETE, ASOCIADOS.RECORRIDO AS RECORRIDO, "
                + "ASOCIADOS.LADOSRECORRIDO AS LADORECORRIDO, COMPRAS.ID AS IDCOMPRA, ASOCIADOS.ID AS IDASOCIADO, ASOCIADOS.LADO AS LADO "
                + "FROM ASOCIADOS, COMPRAS, COMPRASDETALLE "
                + "WHERE ASOCIADOS.ID = COMPRAS.ASOCIADO AND COMPRAS.ID=COMPRASDETALLE.COMPRA "
                + "AND ASOCIADOS.RECORRIDO LIKE '%." + idAsociado + ".%' AND COMPRASDETALLE.PAQUETE BETWEEN 1 AND 3 AND COMPRAS.STATUSPAGO='PAGADO' "
                + "AND COMPRAS.FECHAORDEN BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + fin.ToString("yyyy/MM/dd") + "' "
                + "AND COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + fin.AddDays(3).ToString("yyyy/MM/dd") + "'";

            string directosLadoQuery = "SELECT COUNT(ID) AS DIRECTOS, LADOPATROCINADOR AS LADO FROM ASOCIADOS "
                + "WHERE PATROCINADOR = " + idAsociado + " AND (STATUS = 1 "
                + "OR '" + fin.ToString("yyyy/MM/dd") + "' BETWEEN INICIOACTIVACION AND FINACTIVACION) "
                + "AND PTSMES > 350 GROUP BY PATROCINADOR, LADOPATROCINADOR "
                + "ORDER BY PATROCINADOR, LADOPATROCINADOR";

            string inactivosLadoQuery = "SELECT COUNT(ID) AS DIRECTOS, LADOPATROCINADOR AS LADO FROM ASOCIADOS "
                + "WHERE PATROCINADOR=" + idAsociado + " AND STATUS = 0 "
                + "GROUP BY PATROCINADOR, LADOPATROCINADOR "
                + "ORDER BY PATROCINADOR, LADOPATROCINADOR";
            #region Puntos
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            
            string recorrido, lado;
            string[] recorridoArray;
            string[] ladosArray;
            int izq = 0, der = 0, totales=0, paquete = 0, cant = 0;
            while (reader.Read())
            {
                int Asociado = Convert.ToInt32(reader["IDASOCIADO"].ToString());
                recorrido = reader["RECORRIDO"].ToString();
                paquete = Convert.ToInt32(reader["PAQUETE"].ToString());
                cant = Convert.ToInt32(reader["CANTIDAD"].ToString());
                lado = reader["LADORECORRIDO"].ToString();
                recorridoArray = recorrido.Split(new char[] { '.' });
                ladosArray = lado.Split(new char[] { '.' });
                int posicion = 0;
                for (posicion = 0; posicion < recorridoArray.Length; posicion++)
                {
                    if (recorridoArray[posicion] == idAsociado)
                    {
                        break;
                    }
                }

                if (ladosArray[posicion] != "")
                {
                    if (ladosArray[posicion] == "D")
                    {
                        switch (paquete)
                        {
                            case 1:
                                der += 25 * cant;
                                break;
                            case 2:
                                der += 50 * cant;
                                break;
                            case 3:
                                der += 75 * cant;
                                break;
                        }
                    }
                    else if (ladosArray[posicion] == "I")
                    {
                        switch (paquete)
                        {
                            case 1:
                                izq += 25 * cant;
                                break;
                            case 2:
                                izq += 50 * cant;
                                break;
                            case 3:
                                izq += 75 * cant;
                                break;
                        }
                    }
                }
                else
                {
                    if (reader["LADO"].ToString() == "D")
                    {
                        switch (paquete)
                        {
                            case 1:
                                der += 25 * cant;
                                break;
                            case 2:
                                der += 50 * cant;
                                break;
                            case 3:
                                der += 75 * cant;
                                break;
                        }
                    }
                    else if (ladosArray[posicion] == "I")
                    {
                        switch (paquete)
                        {
                            case 1:
                                izq += 25 * cant;
                                break;
                            case 2:
                                izq += 50 * cant;
                                break;
                            case 3:
                                izq += 75 * cant;
                                break;
                        }
                    }
                }
            }
            reader.Close();
            mySqlConn.Close();
            mySqlConn.Dispose();
            int ladomenor = 0;
            if (der > izq)
                ladomenor = izq;
            else
                ladomenor = der;
            #endregion
            model.PuntosDer = der;
            model.PuntosIzq = izq;
            totales = der + izq;
            model.PuntoTotales = der + izq;
            #region directos

            queryEx = new MySqlCommand(directosLadoQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            int directosDer = 0, directosIzq = 0, directosTotales = 0;
            while (reader.Read())
            {
                if (reader["LADO"].ToString() == "D")
                    directosDer = Convert.ToInt32(reader["DIRECTOS"].ToString());
                else if(reader["LADO"].ToString() == "I")
                    directosIzq = Convert.ToInt32(reader["DIRECTOS"].ToString());
            }
            reader.Close();
            mySqlConn.Dispose();
            mySqlConn.Close();
            #endregion
            model.EmpreDer = directosDer;
            model.EmpreIzq = directosIzq;
            directosTotales = directosDer + directosIzq;
            #region inactivos

            queryEx = new MySqlCommand(inactivosLadoQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            int inactDer = 0, inactIzq = 0;
            while (reader.Read())
            {
                if (reader["LADO"].ToString() == "D")
                    inactDer = Convert.ToInt32(reader["DIRECTOS"].ToString());
                else if (reader["LADO"].ToString() == "I")
                    inactIzq = Convert.ToInt32(reader["DIRECTOS"].ToString());
            }
            reader.Close();
            mySqlConn.Dispose();
            mySqlConn.Close();
            #endregion
            model.InactDer = inactDer;
            model.InactIzq = inactIzq;
            
            if (directosTotales >= 3 && directosIzq >= 1 && directosDer >= 1)
                model.Rango = 2;
            if (directosDer >= 1 && directosIzq >= 1 && izq >= 10 && der >= 10 && totales >= 550 && ladomenor >= 165)
                model.Rango = 3;
            if ((directosDer + directosIzq) >= 3 && directosDer >= 1 && directosIzq >= 1 && izq >= 20 && der >= 20 && totales >= 1300 && ladomenor >= 390)
                model.Rango = 4;
            if ((directosDer + directosIzq) >= 3 && directosDer >= 1 && directosIzq >= 1 && izq >= 50 && der >= 50 && totales >= 2500 && ladomenor >= 750)
                model.Rango = 5;
            if (directosDer >= 2 && directosIzq >= 2 && izq >= 75 && der >= 75 && totales >= 5600 && ladomenor >= 1680)
                model.Rango = 6;
            if (directosDer >= 2 && directosIzq >= 2 && izq >= 75 && der >= 160 && totales >= 11250 && ladomenor >= 3375)
                model.Rango = 7;
            if (directosDer >= 2 && directosIzq >= 2 && izq >= 75 && der >= 75 && totales >= 22500 && ladomenor >= 9000)
                model.Rango = 8;
            if (directosDer >= 2 && directosIzq >= 2 && izq >= 75 && der >= 75 && totales >= 45000 && ladomenor >= 18000)
                model.Rango = 9;
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Logros: " + ex.Message);
            throw new Exception("Error LogrosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public List<DetallePuntosModel> consDetallePuntos(string idAsociado, string lado)
    {
        List<DetallePuntosModel> lista = new List<DetallePuntosModel>();
        DateTime inicio = ConsInicioCiclo();//Convert.ToDateTime("2014-08-02")
        DateTime fin = ConsFinCiclo();//Convert.ToDateTime("2014-09-12");

        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ASOCIADOS.ID AS IDASOCIADO, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, ASOCIADOS.RECORRIDO, ASOCIADOS.LADOSRECORRIDO, ASOCIADOS.LADO, "
                + "COMPRAS.ID AS IDCOMPRA, COMPRAS.FECHA AS FECHA, COMPRASDETALLE.PAQUETE AS PAQUETE, COMPRASDETALLE.CANTIDAD AS CANTIDAD "
                + "FROM ASOCIADOS, COMPRAS, COMPRASDETALLE "
                + "WHERE ASOCIADOS.ID = COMPRAS.ASOCIADO AND COMPRAS.ID=COMPRASDETALLE.COMPRA "
                + "AND ASOCIADOS.RECORRIDO LIKE '%." + idAsociado + ".%' AND COMPRASDETALLE.PAQUETE BETWEEN 1 AND 3 AND COMPRAS.STATUSPAGO='PAGADO' "
                + "AND COMPRAS.FECHAORDEN BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + fin.ToString("yyyy/MM/dd") + "' "
                + "AND COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + fin.AddDays(3).ToString("yyyy/MM/dd") + "'";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            string recorrido, lados;
            string[] recorridoArray;
            string[] ladosArray;
            int paquete = 0, cant = 0;
            while (reader.Read())
            {
                DetallePuntosModel model = new DetallePuntosModel();

                recorrido = reader["RECORRIDO"].ToString();
                paquete = Convert.ToInt32(reader["PAQUETE"].ToString());
                cant = Convert.ToInt32(reader["CANTIDAD"].ToString());
                lados = reader["LADOSRECORRIDO"].ToString();


                recorridoArray = recorrido.Split(new char[] { '.' });
                ladosArray = lados.Split(new char[] { '.' });
                int posicion = 0;
                for (posicion = 0; posicion < recorridoArray.Length; posicion++)
                {
                    if (recorridoArray[posicion] == idAsociado)
                    {
                        break;
                    }
                }

                if (ladosArray[posicion] != "")
                {
                    if (ladosArray[posicion] == lado)
                    {
                        model.IdAsociado = reader["IDASOCIADO"].ToString();
                        model.Nombre = reader["NOMBRE"].ToString();
                        model.IdCompra = reader["IDCOMPRA"].ToString();
                        model.FechaPago = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                        switch (paquete)
                        {
                            case 1:
                                model.Puntos = 25 * cant;
                                break;
                            case 2:
                                model.Puntos = 50 * cant;
                                break;
                            case 3:
                                model.Puntos = 75 * cant;
                                break;
                        }
                        lista.Add(model);
                    }
                }
                else
                {
                    if (reader["LADO"].ToString() == lado)
                    {
                        model.IdAsociado = reader["IDASOCIADO"].ToString();
                        model.Nombre = reader["NOMBRE"].ToString();
                        model.IdCompra = reader["IDCOMPRA"].ToString();
                        model.FechaPago = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                        switch (paquete)
                        {
                            case 1:
                                model.Puntos = 25 * cant;
                                break;
                            case 2:
                                model.Puntos = 50 * cant;
                                break;
                            case 3:
                                model.Puntos = 75 * cant;
                                break;
                        }
                        lista.Add(model);
                    }
                }

            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar detalle puntos: " + ex.Message);
            throw new Exception("Error LogrosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return lista;
    }

    public List<DetalleLogrosModel> consDetalleLogros(string idAsociado, string tipo)
    {
        List<DetalleLogrosModel> lista = new List<DetalleLogrosModel>();
        DateTime fin = ConsFinCiclo();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, CONCAT(NOMBRE, ' ', APPATERNO, ' ', APMATERNO) AS NOMBRE, INICIOACTIVACION, FINACTIVACION, PTSMES FROM ASOCIADOS WHERE PATROCINADOR=" + idAsociado;
            switch(tipo)
            {
                case "EmprIzq":
                    strQuery += " AND (STATUS=1 OR '" + fin.ToString("yyyy/MM/dd") + "' BETWEEN INICIOACTIVACION AND FINACTIVACION) AND LADOPATROCINADOR='I' ";
                    break;
                case "EmprDer":
                    strQuery += " AND (STATUS=1 OR '" + fin.ToString("yyyy/MM/dd") + "' BETWEEN INICIOACTIVACION AND FINACTIVACION) AND LADOPATROCINADOR='D' ";
                    break;
                case "InactivosIzq":
                    strQuery += " AND STATUS=0 AND LADOPATROCINADOR='I' ";
                    break;
                case "InactivosDer":
                    strQuery += " AND STATUS=0 AND LADOPATROCINADOR='D' ";
                    break;
            }
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                DetalleLogrosModel model = new DetalleLogrosModel();
                model.IdAsociado = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.InicioActivacion = Convert.ToDateTime(reader["INICIOACTIVACION"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.FinActivacion = Convert.ToDateTime(reader["FINACTIVACION"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.PtosMes = Convert.ToInt32(reader["PTSMES"].ToString());
                lista.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Detalle Logros: " + ex.Message);
            throw new Exception("Error LogrosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return lista;
    }
}