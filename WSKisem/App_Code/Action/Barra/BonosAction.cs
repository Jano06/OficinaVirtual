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
/// Descripción breve de BonosAction
/// </summary>
public class BonosAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(BonosAction));
    private double pago1;
    private double pago2;
    private double pagoMin;
    private double puntos;

    public List<Bono1Model> ConsBono1(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono1Model> listaBono1 = new List<Bono1Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT COMPRAS.REFERENCIA AS COMPRA, COMPRAS.FECHA, COMPRAS.TOTAL AS MONTO, "
                + "SUM(COMPRASDETALLE.CANTIDAD)*200 AS GANANCIA "
                + "FROM COMPRAS, COMPRASDETALLE "
                + "WHERE COMPRAS.ID=COMPRASDETALLE.COMPRA AND COMPRASDETALLE.PAQUETE=3 AND COMPRAS.STATUSPAGO='PAGADO' AND COMPRAS.EXCEDENTE=1 "
                + "AND ((COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.AddDays(3).ToString("yyyy/MM/dd") + "') "
                + "AND (COMPRAS.FECHAORDEN BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "')) "
                + "AND compras.asociado=" + idAsociado + " "
                + "GROUP BY compras.referencia, compras.fecha, compras.total, comprasdetalle.cantidad, "
                + "comprasdetalle.paquete, compras.statuspago,  compras.excedente, compras.fecha, compras.asociado";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono1Model model = new Bono1Model();
                model.Compra = reader["COMPRA"].ToString();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Monto = Convert.ToDouble(reader["MONTO"].ToString()).ToString("c");
                model.Ganancia = Convert.ToDouble(reader["GANANCIA"].ToString()).ToString("c");
                listaBono1.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 1: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono1;
    }

    public List<Bono2Model> ConsBono2(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono2Model> listaBono2 = new List<Bono2Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT ASOCIADOS.ID, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
            + "ASOCIADOS.FINSC AS FECHA, "
            + "ASOCIADOS.ORDEN, "
            + "IF(ASOCIADOS.ORDEN<3,60+ "
            + "IF(COMPRAS.PUNTOS=650,50, "
            + "IF(COMPRAS.PUNTOS=900,100,0)), 120+ "
            + "IF(COMPRAS.PUNTOS=650,50, "
            + "IF(COMPRAS.PUNTOS=900,100,0))) AS GANANCIA "
            + "FROM ASOCIADOS, COMPRAS "
            + "WHERE ASOCIADOS.ID=COMPRAS.ASOCIADO AND ASOCIADOS.FINSC BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "' "
            + "AND ASOCIADOS.PATROCINADOR= " + idAsociado + " "
            + "AND COMPRAS.INSCRIPCION>0";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono2Model model = new Bono2Model();
                model.Asociado = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString().ToUpper();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Orden = reader["ORDEN"].ToString();
                model.Ganancia = Convert.ToDouble(reader["GANANCIA"].ToString()).ToString("c");
                listaBono2.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 2: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono2;
    }

    public List<Bono3Model> ConsBono3(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono3Model> listaBono3 = new List<Bono3Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT ID AS ASOCIADO, CONCAT(NOMBRE, ' ', APPATERNO, ' ', APMATERNO) AS NOMBRE, "
                + "FINSC AS FECHA, ORDEN, PATROCINADOR, 60 AS GANANCIA "
                + "FROM ASOCIADOS "
                + "WHERE ORDEN < 3 AND FINSC BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "' AND BONO6 = " + idAsociado;

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono3Model model = new Bono3Model();
                model.Asociado = reader["ASOCIADO"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.FechaInsc = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Orden = reader["ORDEN"].ToString();
                model.Patrocinador = reader["PATROCINADOR"].ToString();
                model.Ganancia = Convert.ToDouble(reader["GANANCIA"].ToString()).ToString("c");
                listaBono3.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 3: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono3;
    }

    public Bono4DetalleModel ConsBono4Detalle(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        Bono4DetalleModel model = new Bono4DetalleModel();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIALESI, INICIALESD, NUEVOSI, NUEVOSD, PAGADOS, PORCENTAJE "
                    + "FROM PUNTOSDETALLE "
                    + "WHERE CORTE=" + idCorte + " AND ASOCIADO=" + idAsociado;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.InicialesIzq = Convert.ToInt32(reader["INICIALESI"].ToString());
                model.InicialesDer = Convert.ToInt32(reader["INICIALESD"].ToString());
                model.NuevosIzq = Convert.ToInt32(reader["NUEVOSI"].ToString());
                model.NuevosDer = Convert.ToInt32(reader["NUEVOSD"].ToString());
                model.Pagados = Convert.ToInt32(reader["PAGADOS"].ToString());
                model.Porcentaje = reader["PORCENTAJE"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 4 Detalle: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public List<Bono4Model> ConsBono4(string idCorte, string idAsociado, string lado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono4Model> listaBono4 = new List<Bono4Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            strQuery = "SELECT COMPRAS.ASOCIADO, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
                + "COMPRAS.REFERENCIA AS COMPRA, COMPRAS.FECHA AS FECHA, PUNTOSASOCIADOS.PUNTOS AS VOLUMEN "
                + "FROM COMPRAS, ASOCIADOS, PUNTOSASOCIADOS "
                + "WHERE COMPRAS.ASOCIADO=ASOCIADOS.ID "
                + "AND COMPRAS.ID=PUNTOSASOCIADOS.COMPRA AND COMPRAS.PUNTOS > 240 AND COMPRAS.STATUSPAGO='PAGADO' "
                + "AND (COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "' "
                + "AND NOT (COMPRAS.FECHA='" + inicio.AddDays(2).ToString("yyyy/MM/dd") + "' AND COMPRAS.FECHAORDEN='" + inicio.AddDays(-1).ToString("yyyy/MM/dd") + "') "
                + "OR (COMPRAS.FECHA='" + final.AddDays(3).ToString("yyyy/MM/dd") + "' AND COMPRAS.FECHAORDEN='" + final.ToString("yyyy/MM/dd") + "')) "
                + "AND PUNTOSASOCIADOS.ASOCIADO=" + idAsociado + " AND PUNTOSASOCIADOS.LADO='" + lado + "' ORDER BY ASOCIADO";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono4Model model = new Bono4Model();
                model.Asociado = reader["ASOCIADO"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.Compra = reader["COMPRA"].ToString();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Volumen = reader["VOLUMEN"].ToString();
                listaBono4.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 4: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono4;
    }

    public List<Bono5Model> ConsBono5(string idCorte, string idAsociado)
    {
        List<Bono5Model> listaBono5 = new List<Bono5Model>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT PAGOS.ASOCIADO, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
            + "PAGOS.MONTO, PAGOS.MONTO*.2 AS GANANCIA "
            + "FROM PAGOS, ASOCIADOS WHERE PAGOS.ASOCIADO=ASOCIADOS.ID AND PAGOS.CORTE=" + idCorte
            + " AND ASOCIADOS.PATROCINADOR=" + idAsociado + " AND PAGOS.BONO=4";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono5Model model = new Bono5Model();
                model.IdAsociado = reader["ASOCIADO"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.Monto = (Convert.ToDouble(reader["MONTO"].ToString())).ToString("c");
                model.Ganancia = (Convert.ToDouble(reader["GANANCIA"].ToString())).ToString("c");
                listaBono5.Add(model);
            }
            reader.Close();

        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 5: " + ex.Message);
            throw new Exception("Error Bono5Action: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono5;
    }

    private void misPuntos(string idAsociado, string idCorte)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT MAX(MISPUNTOS) AS PUNTOS FROM PAGOS WHERE STATUS=1 AND CORTE=" + idCorte + " AND ASOCIADO=" + idAsociado;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                puntos = Convert.ToDouble(reader["PUNTOS"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Puntos: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    private void valoresBono6()
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
         try
        {
            string strQuery = "SELECT PAGO1BONO6, PAGO2BONO6, PAGOMINIMO678 FROM CONFIGURACION";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                pago1 = Convert.ToDouble(reader["PAGO1BONO6"].ToString());
                pago2 = Convert.ToDouble(reader["PAGO2BONO6"].ToString());
                pagoMin = Convert.ToDouble(reader["PAGOMINIMO678"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
         }
        catch(Exception ex)
        {
            _LOGGER.Error("Error al consultar valores Bono 6: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    private void valoresBono7()
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT PAGO1BONO7, PAGO2BONO7, PAGOMINIMO678 FROM CONFIGURACION";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                pago1 = Convert.ToDouble(reader["PAGO1BONO7"].ToString());
                pago2 = Convert.ToDouble(reader["PAGO2BONO7"].ToString());
                pagoMin = Convert.ToDouble(reader["PAGOMINIMO678"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar valores Bono 7: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    private void valoresBono8()
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT PAGO1BONO8, PAGO2BONO8, PAGOMINIMO678 FROM CONFIGURACION";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                pago1 = Convert.ToDouble(reader["PAGO1BONO8"].ToString());
                pago2 = Convert.ToDouble(reader["PAGO2BONO8"].ToString());
                pagoMin = Convert.ToDouble(reader["PAGOMINIMO678"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar valores Bono 8: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    private double GananciaBono6(string compra)
    {
        double resp = 0;
        
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT CANTIDAD, PAQUETE FROM COMPRASDETALLE WHERE PAQUETE > 0 AND COMPRA=" + compra;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (puntos > 350)
                {
                    switch (Convert.ToInt32(reader["PAQUETE"].ToString()))
                    { 
                        case 1:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pago1;
                            break;
                        case 2:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pago2;
                            break;
                        case 3:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) *pago2;
                            break;
                    }
                }
                else
                    resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pagoMin;
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Ganancia Bono 6: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }

    private double GananciaBono7(string compra)
    {
        double resp = 0;
        
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT CANTIDAD, PAQUETE FROM COMPRASDETALLE WHERE COMPRA=" + compra;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (puntos > 350)
                {
                    switch (Convert.ToInt32(reader["PAQUETE"].ToString()))
                    { 
                        case 1:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pago1;
                            break;
                        case 2:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pago2;
                            break;
                        case 3:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) *pago2;
                            break;
                    }
                }
                else
                    resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pagoMin;
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Ganancia Bono 7: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }

    private double GananciaBono8(string compra)
    {
        double resp = 0;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT CANTIDAD, PAQUETE FROM COMPRASDETALLE WHERE COMPRA=" + compra;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (puntos > 350)
                {
                    switch (Convert.ToInt32(reader["PAQUETE"].ToString()))
                    { 
                        case 1:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pago1;
                            break;
                        case 2:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pago2;
                            break;
                        case 3:
                            resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) *pago2;
                            break;
                    }
                }
                else
                    resp += Convert.ToInt32(reader["CANTIDAD"].ToString()) * pagoMin;
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Ganancia Bono 8: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }
    
    public List<Bono6Model> ConsBono6(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono6Model> listaBono6 = new List<Bono6Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            valoresBono6();
            misPuntos(idAsociado, idCorte);

            strQuery = "SELECT COMPRAS.ASOCIADO, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
                + "COMPRAS.REFERENCIA AS COMPRA, COMPRAS.FECHA AS FECHA, COMPRAS.TOTAL AS MONTO, COMPRAS.PUNTOS AS GANANCIA, COMPRAS.ID AS IDCOMPRA "
                + "FROM ASOCIADOS, COMPRAS, COMPRASDETALLE "
                + "WHERE ASOCIADOS.ID = COMPRAS.ASOCIADO AND COMPRAS.ID = COMPRASDETALLE.COMPRA "
                + "AND COMPRASDETALLE.PAQUETE > 0 AND COMPRAS.EXCEDENTE = 0 AND COMPRAS.STATUSPAGO = 'PAGADO' AND COMPRAS.INSCRIPCION = 0 "
                + "AND ASOCIADOS.BONO6 = " + idAsociado.ToString() + " "
                + "AND ((COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.AddDays(3).ToString("yyyy/MM/dd") + "') "
                + "AND (COMPRAS.FECHAORDEN BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "')) "
                + "ORDER BY COMPRAS.ID DESC";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono6Model model = new Bono6Model();
                model.Asociado = reader["ASOCIADO"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.Compra = reader["COMPRA"].ToString();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Monto = Convert.ToDouble(reader["MONTO"].ToString()).ToString("c");
                model.Ganancia = GananciaBono6(reader["IDCOMPRA"].ToString()).ToString("c");
                listaBono6.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 6: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono6;
    }

    public List<Bono7Model> ConsBono7(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono7Model> listaBono7 = new List<Bono7Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            valoresBono7();
            misPuntos(idAsociado, idCorte);

            strQuery = "SELECT COMPRAS.ASOCIADO, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
                + "COMPRAS.REFERENCIA AS COMPRA, COMPRAS.FECHA AS FECHA, COMPRAS.TOTAL AS MONTO, COMPRAS.ID AS IDCOMPRA FROM COMPRAS "
                + "INNER JOIN ASOCIADOS ON COMPRAS.ASOCIADO = ASOCIADOS.ID "
                + "INNER JOIN ASOCIADOS AS ASOCIADOS_1 ON ASOCIADOS.BONO6 = ASOCIADOS_1.ID "
                + "WHERE COMPRAS.PUNTOS > 0 AND COMPRAS.STATUSPAGO = 'PAGADO' AND COMPRAS.EXCEDENTE = 0  AND COMPRAS.INSCRIPCION = 0 "
                + "AND ((COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.AddDays(3).ToString("yyyy/MM/dd") + "') "
                + "AND (COMPRAS.FECHAORDEN BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "')) "
                + "AND ASOCIADOS_1.PATROCINADOR = " + idAsociado;

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono7Model model = new Bono7Model();
                model.Asociado = reader["ASOCIADO"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.Compra = reader["COMPRA"].ToString();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Monto = Convert.ToDouble(reader["MONTO"].ToString()).ToString("c");
                model.Ganancia = GananciaBono7(reader["IDCOMPRA"].ToString()).ToString("c");
                listaBono7.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 7: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono7;
    }

    public List<Bono8Model> ConsBono8(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        DateTime inicio = new DateTime();
        DateTime final = new DateTime();
        List<Bono8Model> listaBono8 = new List<Bono8Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString());
                final = Convert.ToDateTime(reader["FINAL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();

            valoresBono8();
            misPuntos(idAsociado, idCorte);

            strQuery = "SELECT COMPRAS.ASOCIADO, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
                + "COMPRAS.REFERENCIA AS COMPRA, COMPRAS.FECHA AS FECHA, COMPRAS.TOTAL AS MONTO, ASOCIADOS.PATROCINADOR, COMPRAS.PUNTOS, COMPRAS.ID AS IDCOMPRA "
                + "FROM COMPRAS "
                + "INNER JOIN ASOCIADOS ON COMPRAS.ASOCIADO = ASOCIADOS.ID "
                + "INNER JOIN ASOCIADOS AS ASOCIADOS_1 ON ASOCIADOS.BONO6 = ASOCIADOS_1.ID "
                + "WHERE COMPRAS.PUNTOS > 0 AND COMPRAS.STATUSPAGO = 'PAGADO' AND COMPRAS.EXCEDENTE = 0 "
                + "AND (COMPRAS.INSCRIPCION = 0 OR COMPRAS.PUNTOS = 350) "
                + "AND ((COMPRAS.FECHA BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.AddDays(3).ToString("yyyy/MM/dd") + "') "
                + "AND (COMPRAS.FECHAORDEN BETWEEN '" + inicio.ToString("yyyy/MM/dd") + "' AND '" + final.ToString("yyyy/MM/dd") + "')) "
                + "AND (";

            List<int> directos = ConsultaDirectos(idAsociado);
            for (int i = 0; i < directos.Count; i++)
            {
                if (i == 0)
                    strQuery += "ASOCIADOS_1.PATROCINADOR=" + directos[i].ToString();
                else
                    strQuery += " OR ASOCIADOS_1.PATROCINADOR=" + directos[i].ToString();
            }
            strQuery += ")";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono8Model model = new Bono8Model();
                model.Asociado = reader["ASOCIADO"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.Compra = reader["COMPRA"].ToString();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Monto = Convert.ToDouble(reader["MONTO"].ToString()).ToString("c");
                model.Ganancia = GananciaBono8(reader["IDCOMPRA"].ToString()).ToString("c");
                listaBono8.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 8: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono8;
    }

    private List<int> ConsultaDirectos(string idAsociado)
    {
        List<int> listaDirectos = new List<int>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID FROM ASOCIADOS WHERE PATROCINADOR=" + idAsociado.ToString() + " ORDER BY ID";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                listaDirectos.Add(Convert.ToInt32(reader["ID"].ToString()));
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar valores Bono 8: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaDirectos;
    }

    public List<Bono11Model> ConsBono11(string idCorte, string idAsociado)
    {
        Conection con = new Conection();
        List<Bono11Model> listaBono11 = new List<Bono11Model>();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT COMPRAS.ID AS COMPRA, CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO) AS NOMBRE, "
                + "COMPRAS.FECHA AS FECHA, BONO11COMPRAS.NIVEL AS NIVEL, COMPRAS.PUNTOS AS PUNTOS, BONO11COMPRAS.MONTO AS GANANCIAS "
                + "FROM COMPRAS, BONO11COMPRAS, ASOCIADOS WHERE COMPRAS.ID = BONO11COMPRAS.COMPRA AND COMPRAS.ASOCIADO = ASOCIADOS.ID "
                + "AND BONO11COMPRAS.ASOCIADO = " + idAsociado + " AND CORTE = " + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                Bono11Model model = new Bono11Model();
                model.Compra = reader["COMPRA"].ToString();
                model.Asociado = reader["NOMBRE"].ToString();
                model.Fecha = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Nivel = reader["NIVEL"].ToString();
                model.Puntos = reader["PUNTOS"].ToString();
                model.Ganancia = Convert.ToDouble(reader["GANANCIAS"].ToString()).ToString("c");
                listaBono11.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Bono 11: " + ex.Message);
            throw new Exception("Error BonosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaBono11;
    }
}