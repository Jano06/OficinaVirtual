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
/// Descripción breve de ArbolColocacionAction
/// </summary>
public class ArbolColocacionAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(ArbolColocacionAction));

    public List<ArbolNext> ProxHijos(string idAsociado)
     {
         List<ArbolNext> listaHijos = new List<ArbolNext>();
         Conection con = new Conection();
         MySqlConnection mySqlConn = con.conectBDPackage();
         try
         {
             string strQuery = "SELECT LADO, ID FROM ASOCIADOS WHERE PADRE=" + idAsociado;

             MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
             mySqlConn.Open();
             MySqlDataReader reader = queryEx.ExecuteReader();
            
             while (reader.Read())
             {
                 ArbolNext model = new ArbolNext();
                 model.Lado = reader["LADO"].ToString();
                 model.IdAsociadoHijo = reader["ID"].ToString();
                 listaHijos.Add(model);
             }
             reader.Close();
         }
         catch (Exception ex)
         {
             _LOGGER.Error("Error al consultar ProxHijos: " + ex.Message);
             throw new Exception("Error ArbolColocacionAction: " + ex.Message);
         }
         finally
         {
             mySqlConn.Dispose();
             mySqlConn.Close();
             con.closeConection();
         }
         return listaHijos;
     }

    public DataSet ConsArbolColocacion(string idAsociado)
    {
        Conection con = new Conection();
        DataSet objDS = new DataSet();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, CONCAT(NOMBRE, ' ', APPATERNO, ' ', APMATERNO) AS NOMBRE, RANGOPAGO, PADRE, LADO, STATUS, ALIAS, "
                            + "DATE_FORMAT(FINSC, '%d/%m/%Y') AS FINSC, PATROCINADOR FROM ASOCIADOS "
                            + "WHERE ASOCIADOS.ID = " + idAsociado + " OR RECORRIDO LIKE '%." + idAsociado + ".%' "
                            + "ORDER BY CHAR_LENGTH(LADOSRECORRIDO)";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = queryEx;
            mySqlConn.Open();
            adapter.Fill(objDS, "Asociados");
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Arbol Colocación: " + ex.Message);
            throw new Exception("Error ArbolColocacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return objDS;
    }

    public List<PuntosModel> ConsPuntos(string idAsociado)
    {
        List<PuntosModel> puntosAsoc = new List<PuntosModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT SUM(PORPAGAR) AS PUNTOS, LADO FROM PUNTOSASOCIADOS WHERE ASOCIADO=" + idAsociado + " GROUP BY LADO";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            int derechos = 0, izquierdos = 0;

            while (reader.Read())
            {    
                if (reader["LADO"].ToString() == "D")
                { derechos = int.Parse(reader["PUNTOS"].ToString()); }
                if (reader["LADO"].ToString() == "I")
                { izquierdos = int.Parse(reader["PUNTOS"].ToString()); }
            }
            PuntosModel model = new PuntosModel();
            model.PtosDer = derechos;
            model.PtosIzq = izquierdos;
            puntosAsoc.Add(model);
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar ProxHijos: " + ex.Message);
            throw new Exception("Error ArbolColocacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return puntosAsoc;
    }

    public bool BuscaAsociado(string idAsociado, string raiz)
    {
        bool resp=false;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID FROM ASOCIADOS WHERE ID =" + idAsociado + " AND RECORRIDO LIKE '%." + raiz + ".%'";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();

            while (reader.Read())
            {
                resp = true;
            }
            
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar BuscaAsociado: " + ex.Message);
            throw new Exception("Error ArbolColocacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }

    public int BuscaFondoIzq(int idAsociado)
    {
        int resp = idAsociado;
        Conection con = new Conection();
        
        MySqlConnection mySqlConn = con.conectBDPackage();
        string strQuery = string.Empty;
        try
        {
            strQuery = "SELECT ID FROM ASOCIADOS WHERE PADRE=" + idAsociado + " AND LADO='I' ";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            
            while (reader.Read())
            {
                resp = BuscaFondoIzq(int.Parse(reader["ID"].ToString()));
            }
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar BuscaFondoIzq: " + ex.Message);
            throw new Exception("Error ArbolColocacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }

    public int BuscaFondoDer(int idAsociado)
    {
        int resp = idAsociado;
        Conection con = new Conection();

        MySqlConnection mySqlConn = con.conectBDPackage();
        string strQuery = string.Empty;
        try
        {
            strQuery = "SELECT ID FROM ASOCIADOS WHERE PADRE=" + idAsociado + " AND LADO='D' ";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();

            while (reader.Read())
            {
                resp = BuscaFondoDer(int.Parse(reader["ID"].ToString()));
            }
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar BuscaFondoDer: " + ex.Message);
            throw new Exception("Error ArbolColocacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }

    public int SubeNivel(int idAsociado, int tope, int nivel)
    {
        int resp = idAsociado;
        Conection con = new Conection();

        MySqlConnection mySqlConn = con.conectBDPackage();
        string strQuery = string.Empty;
        try
        {

            for (int i = 0; i < nivel; i++)
            {
                if (resp != tope)
                {
                    strQuery = "SELECT PADRE FROM ASOCIADOS WHERE ID=" + resp;
                    MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
                    mySqlConn.Open();
                    MySqlDataReader reader = queryEx.ExecuteReader();
                    if (!(reader.HasRows))
                    {
                        break;
                    }
                    while (reader.Read())
                    {
                        resp = int.Parse(reader["PADRE"].ToString());
                    }
                    reader.Close();
                    mySqlConn.Close();
                }
            }
            
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar BuscaFondoIzq: " + ex.Message);
            throw new Exception("Error ArbolColocacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return resp;
    }
}