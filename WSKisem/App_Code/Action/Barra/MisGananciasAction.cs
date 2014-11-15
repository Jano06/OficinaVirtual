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
/// Descripción breve de MisGananciasAction
/// </summary>
public class MisGananciasAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(OrganizacionAction));

    public List<GananciaBdModel> ConsultaGanancias(string idAsociado)
    {
        List<GananciaBdModel> listaGanancias = new List<GananciaBdModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT CORTE, SUM(MONTO) AS MONTO, DE, A, FACTURA "
            + "FROM PAGOS, PERIODOS "
            + "WHERE PAGOS.CORTE= PERIODOS.ID AND PAGOS.ASOCIADO= " + idAsociado + " AND PERIODOS.STATUS= 1 "
            + "GROUP BY CORTE HAVING SUM(MONTO)>0 ORDER BY CORTE DESC";
            
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                GananciaBdModel model = new GananciaBdModel();
                model.Corte = reader["CORTE"].ToString();
                model.Monto = Convert.ToDouble(reader["MONTO"].ToString());
                model.Inicio = Convert.ToDateTime(reader["DE"].ToString());
                model.Fin = Convert.ToDateTime(reader["A"].ToString());
                model.Factura = reader["FACTURA"].ToString();
                listaGanancias.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Ganancia: " + ex.Message);
            throw new Exception("Error GananciasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaGanancias;
    }
}