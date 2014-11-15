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
/// Descripción breve de MisComprasAction
/// </summary>
public class MisComprasAction
{
	private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(OrganizacionAction));

    public List<MisComprasModel> ConsultaCompras(int idAsociado, string fechaInicio, string fechaFin)
    {
        List<MisComprasModel> listaCompras = new List<MisComprasModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, FECHAORDEN, FECHA, PUNTOS, TOTAL, STATUSPAGO, STATUSENTREGA, REFERENCIA FROM COMPRAS " +
                "WHERE COMPRAS.ASOCIADO=" + idAsociado + " AND COMPRAS.FECHA BETWEEN '" + fechaInicio + "' AND '" + fechaFin + "' " +
                "ORDER BY ID";
            
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                MisComprasModel model = new MisComprasModel();
                model.NumeroOrden = reader["ID"].ToString();
                model.FechaOrden = Convert.ToDateTime(reader["FECHAORDEN"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.FechaPago = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.Puntos = reader["PUNTOS"].ToString();
                model.Total = (Convert.ToDouble(reader["TOTAL"].ToString())).ToString("c");
                model.Pago = reader["STATUSPAGO"].ToString();
                model.Periodo = periodoComisionable(Convert.ToDateTime(reader["FECHA"].ToString()));
                model.Entrega = reader["STATUSENTREGA"].ToString();
                model.Referencia = reader["REFERENCIA"].ToString();
                listaCompras.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Compras: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return listaCompras;
    }

    private string periodoComisionable(DateTime fecha)
    {
        string respuesta = string.Empty;
        DateTime desde = new DateTime(); 
        DateTime hasta = new DateTime();

        for (int i = 1; i < 21; i++)
        {
            fecha = fecha.AddDays(-1);
            if (fecha.DayOfWeek.Equals(DayOfWeek.Friday))
            {
                desde = fecha.AddDays(1);
                hasta = fecha.AddDays(7);
                break;
            }
        }
        respuesta = "DEL " + desde.Date.ToString("dd/MMMM/yyyy").ToUpper() + " AL " + hasta.Date.ToString("dd/MMMM/yyyy").ToUpper();
        return respuesta;
    }

    public DetalleCompraModel ConsultaDetalleCompra(int idCompras, int idAsociado, string periodo)
    {
        DetalleCompraModel model = new DetalleCompraModel();
        
        model.IdOrden = idCompras.ToString();
        model.Periodo = periodo;

        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, NOMBRE, APPATERNO, APMATERNO, CALLEPAQ, NUMPAQ, INTPAQ, COLPAQ, MUNICIPIOPAQ, ESTADOPAQ, CIUDADPAQ FROM ASOCIADOS " +
                            "WHERE ID= " + idAsociado.ToString();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.NoDistribuidor = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString() + " " + reader["APPATERNO"].ToString() + " " + reader["APMATERNO"].ToString();
                model.Direccion = reader["CALLEPAQ"].ToString() + " #" + reader["NUMPAQ"].ToString() + " " + reader["INTPAQ"].ToString();
                model.DireccionColonia = reader["COLPAQ"].ToString() + " " + reader["MUNICIPIOPAQ"].ToString() + ", " + reader["ESTADOPAQ"].ToString(); // ", " + reader["CIUDADPAQ"].ToString() +
            }
            mySqlConn.Close();

            strQuery = "SELECT COMPRAS.FECHA, COMPRAS.FECHAORDEN, COMPRAS.STATUSPAGO, COMPRAS.STATUSENTREGA, COMPRAS.AUTOR, "+
                "CONCAT(ASOCIADOS.NOMBRE, ' ', ASOCIADOS.APPATERNO) AS NOMBRE " +
                "FROM COMPRAS LEFT JOIN ASOCIADOS ON COMPRAS.AUTOR=ASOCIADOS.ID WHERE COMPRAS.ID= " + idCompras;
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                if (reader["AUTOR"].ToString() == string.Empty)
                { model.Operador = ""; }

                model.FechaPago = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();
                model.FechaOrden = Convert.ToDateTime(reader["FECHAORDEN"].ToString()).ToString("dd/MMMM/yyyy").ToUpper();

                if (reader["STATUSPAGO"].ToString() == "PENDIENTE")
                { model.StatusOrden = "PENDIENTE DE PAGO"; }
                else
                {
                    if (reader["STATUSENTREGA"].ToString() == "PENDIENTE")
                    { model.StatusOrden = "PENDIENTE DE ENTREGA"; }
                    else
                    { model.StatusOrden = "ENTREGADO"; }
                }

                if (reader["AUTOR"].ToString() == "OV")
                {
                    model.Operador = "OFICINA VIRTUAL";
                    model.OrigenOrden = "OFICINA VIRTUAL";
                }
                else
                {
                    model.Operador = reader["NOMBRE"].ToString();
                    model.OrigenOrden = "ADMINISTRADOR";
                }
            }
            mySqlConn.Close();

            strQuery = "SELECT PAQUETES.CODIGO, PAQUETES.NOMBRE, COMPRASDETALLE.CANTIDAD, COMPRASDETALLE.COSTO, COMPRASDETALLE.PUNTOS " +
                "FROM COMPRASDETALLE, PAQUETES WHERE COMPRASDETALLE.PAQUETE = PAQUETES.ID AND COMPRASDETALLE.COMPRA=" + idCompras.ToString();
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.CodigoArt = reader["CODIGO"].ToString();
                model.DescripcArt = reader["NOMBRE"].ToString();
                model.CantArt = Convert.ToInt32(reader["CANTIDAD"].ToString());
                model.PrecioUnit = double.Parse(reader["COSTO"].ToString());
                model.Puntos = Convert.ToInt32(reader["PUNTOS"].ToString());
            }
            mySqlConn.Close();

            model.Total = (model.CantArt * model.PrecioUnit);
            
        }
        catch (Exception e)
        {
            _LOGGER.Error("Error al consultar la informacion de:" + idCompras + e.Message);// mensaje de error del usuario
            throw new Exception("ConsultCompra Error: " + e.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public string ultCompra(int idAsociado)
    {
        string compra = string.Empty;
        List<MisComprasModel> listaCompras = new List<MisComprasModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT MAX(FECHA) AS FECHA FROM COMPRAS WHERE ASOCIADO = " + idAsociado;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy");
            }
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Ultima Compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return compra;
    }

    public string primerCompra(int idAsociado)
    {
        string compra = string.Empty;
        List<MisComprasModel> listaCompras = new List<MisComprasModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT MIN(FECHA) AS FECHA FROM COMPRAS WHERE ASOCIADO = " + idAsociado + " AND NOT (FECHA='0000-00-00')";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                compra = Convert.ToDateTime(reader["FECHA"].ToString()).ToString("dd/MMMM/yyyy");
            }
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Ultima Compra: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return compra;
    }
}