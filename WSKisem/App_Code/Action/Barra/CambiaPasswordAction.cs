using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;
using System.Text.RegularExpressions;

/// <summary>
/// Descripción breve de CambiaPasswordAction
/// </summary>
public class CambiaPasswordAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(CambiaPasswordAction));

    public string ChecaPassword(string idUser)
    {
        string password = string.Empty;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT PASSWORD FROM ASOCIADOS WHERE ID=" + idUser;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                password = reader["PASSWORD"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Password: " + ex.Message);
            throw new Exception("Error CambiaPasswordAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return password;
    }

    public bool ActualizaPassword(string nuevoPassword, string idUser)
    {
        bool update = false;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "UPDATE ASOCIADOS SET PASSWORD='" + nuevoPassword + "' WHERE ID=" + idUser;
            mySqlConn.Open();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
            update = true;
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Password: " + ex.Message);
            throw new Exception("Error CambiaPasswordAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return update;
    }
}