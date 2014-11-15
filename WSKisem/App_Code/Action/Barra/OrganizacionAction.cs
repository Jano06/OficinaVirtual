using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;

/// <summary>
/// Descripción breve de OrganizacionAction
/// </summary>
public class OrganizacionAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(OrganizacionAction));

    public List<OrganizacionModel> ConsultaOrganizacion(int idAsociado, string fecha, string status)
    {
        List<OrganizacionModel> listaOrganizacion = new List<OrganizacionModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ASOCIADOS.ID AS IDASOCIADO, " +
            "IF(ASOCIADOS.LADOPATROCINADOR='I', CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO),'') AS IZQUIERDO, " +
            "IF(ASOCIADOS.LADOPATROCINADOR='D', CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO, ' ', ASOCIADOS.APMATERNO),'') AS DERECHO, " +
            "RANGOS.NOMBRE AS RANGO, MAX(COMPRAS.FECHA) AS ULTCOMPRA, ASOCIADOS.STATUS, " +
            "MAX(COMPRAS.INICIOACTIVACION) AS INICIOACTIVACION, MAX(COMPRAS.FINACTIVACION) AS FINACTIVACION " +
            "FROM ASOCIADOS, RANGOS, COMPRAS " +
            "WHERE ASOCIADOS.ID = COMPRAS.ASOCIADO AND ASOCIADOS.RANGO = RANGOS.ID " +
            "AND ASOCIADOS.PATROCINADOR = " + idAsociado + " AND ASOCIADOS.FINSC <= '" + fecha + "' ";

            if (status != "3")
            { strQuery += "AND ASOCIADOS.STATUS=" + status + " "; }

            strQuery += "GROUP BY ASOCIADOS.ID ORDER BY ASOCIADOS.ID";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                OrganizacionModel model = new OrganizacionModel();
                if (!string.IsNullOrEmpty(reader["IDASOCIADO"].ToString()))
                    model.IdAsociado = reader["IDASOCIADO"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["IZQUIERDO"].ToString()))
                    model.Izquierdo = reader["IZQUIERDO"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["DERECHO"].ToString()))
                    model.Derecho = reader["DERECHO"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["RANGO"].ToString()))
                    model.Rango = reader["RANGO"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["ULTCOMPRA"].ToString()))
                    model.UltCompra = Convert.ToDateTime(reader["ULTCOMPRA"]).ToString("dd/MMMM/yyyy").ToUpper();
                if (!string.IsNullOrEmpty(reader["STATUS"].ToString()))
                {
                    if (reader["STATUS"].ToString() == "0")
                        model.Status = "INACTIVO";
                    if (reader["STATUS"].ToString() == "1")
                        model.Status = "ACTIVO";
                    if (reader["STATUS"].ToString() == "2")
                        model.Status = "SUSPENDIDO";
                }
                if (!(string.IsNullOrEmpty(reader["INICIOACTIVACION"].ToString())) && !(string.IsNullOrEmpty(reader["FINACTIVACION"].ToString())))
                    model.Periodo = Convert.ToDateTime(reader["INICIOACTIVACION"]).ToString("dd/MMMM/yyyy").ToUpper() + " AL " + Convert.ToDateTime(reader["FINACTIVACION"]).ToString("dd/MMMM/yyyy").ToUpper();
                listaOrganizacion.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Organizacion: " + ex.Message);
            throw new Exception("Error OrganizacionAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaOrganizacion;
    }
}