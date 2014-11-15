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
/// Descripción breve de misPagosAction
/// </summary>
public class MisPagosAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(MisPagosAction));

    public double ConsultaCompras(string idAsociado, string idCorte)
    {
        double total = 0;
        string inicio = string.Empty; string fin = string.Empty;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT INICIO, FINAL FROM PERIODOS WHERE ID=" + idCorte;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                inicio = Convert.ToDateTime(reader["INICIO"].ToString()).ToString("yyyy/MM/dd").ToUpper();
                fin = Convert.ToDateTime(reader["FINAL"].ToString()).ToString("yyyy/MM/dd").ToUpper();
            }
            reader.Close();
            mySqlConn.Dispose();
            mySqlConn.Close();

            strQuery = "SELECT SUM(TOTAL) AS TOTAL FROM COMPRAS WHERE STATUSPAGO='PAGADO' AND ASOCIADO=" + idAsociado + " AND FECHA BETWEEN '" + inicio + "' AND '" + fin + "'";

            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (reader["TOTAL"].ToString() == null)
                    total = double.Parse(reader["TOTAL"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar ConsultaCompras: " + ex.Message);
            throw new Exception("Error MisPagosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return total;
    }

    public BonosModel CalculaComisiones(string idAsociado, string idCorte)
    {
        BonosModel model = new BonosModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT SUM(MONTO) AS MONTO, BONO FROM PAGOS "
            + "GROUP BY BONO, CORTE, STATUS, ASOCIADO "
            + "HAVING CORTE= " + idCorte + " AND STATUS= 1 AND ASOCIADO= " + idAsociado;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                switch (reader["BONO"].ToString())
                { 
                    case "1":
                        model.Bono1 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "2":
                        model.Bono2 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "3":
                        model.Bono3 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "4":
                        model.Bono4 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "5":
                        model.Bono5 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "6":
                        model.Bono6 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "7":
                        model.Bono7 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "8":
                        model.Bono8 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "9":
                        model.Bono9 = double.Parse(reader["MONTO"].ToString());
                        break;
                    case "11":
                        model.Bono11 = double.Parse(reader["MONTO"].ToString());
                        break;
                }
            }
            reader.Close();
        }
        catch (Exception ex)
        { 
            _LOGGER.Error("Error al consultar CalculaComisiones: " + ex.Message);
            throw new Exception("Error MisPagosAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }
}