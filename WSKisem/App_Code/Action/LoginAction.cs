using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;

/// <summary>
/// Descripción breve de LoginAction
/// </summary>
public class LoginAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(LoginAction));

    public LoginModel ConsultUser(string asocKisem, string password)
    {
        LoginModel model = new LoginModel();
        Conection conn = new Conection();
        MySqlConnection mySqlConn = conn.conectBDPackage();
        try
        {
            string strQuery = "SELECT id, nombre, appaterno, apmaterno FROM asociados " +
            "WHERE id = " + asocKisem + " AND password= '" + password + "' AND status < 2";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.Iduser = int.Parse(reader[0].ToString());
                model.User = reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString();
            }
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar el usuario." + asocKisem + e.Message);// mensaje de error del usuario
            throw new Exception("ConsultUser Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Close();
            conn.closeConection();
        }
        return model;
    }
}