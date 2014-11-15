using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;

/// <summary>
/// Descripción breve de MisDatosPersonalesAction
/// </summary>
public class MisDatosPersonalesAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(MisDatosPersonalesAction));

    public MisDatosPersonalesModel ConsultaDatos(int idAsociado)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ASOCIADOS.NOMBRE, APPATERNO, APMATERNO, APPATERNO, FNAC, LUGARNACIM, ESTADOCIVIL, RFC, CURP, COMPANIA, TELLOCAL, TELMOVIL, NEXTEL, EMAIL, PASSWORD, ALIAS, PAIS, IDIOMA, CALLECASA, NUMCASA, " +
                    "INTCASA, COLCASA, CPCASA, MUNICIPIOCASA, CIUDADCASA, ESTADOCASA, OBSERVCASA, CALLEPAQ, NUMPAQ, INTPAQ, COLPAQ, CPPAQ, MUNICIPIOPAQ, CIUDADPAQ, ESTADOPAQ, OBSERVPAQ, " +
                    "TIPO, FINSC, BODEGAS.NOMBRE AS BODEGA, FACTURA FROM ASOCIADOS, BODEGAS WHERE ASOCIADOS.BODEGA = BODEGAS.ID AND ASOCIADOS.ID = " + idAsociado;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.Nombre = reader["NOMBRE"].ToString().ToUpper();
                model.ApPaterno = reader["APPATERNO"].ToString().ToUpper();
                model.ApMaterno = reader["APMATERNO"].ToString().ToUpper();
                model.FechaNacimiento = Convert.ToDateTime(reader["FNAC"]);
                model.LugarNacimiento = reader["LUGARNACIM"].ToString().ToUpper();
                model.EdoCivil = reader["ESTADOCIVIL"].ToString().ToUpper();
                model.FechaIngreso = Convert.ToDateTime(reader["FINSC"]).ToString("dd/MMMM/yyyy").ToUpper();
                if (!string.IsNullOrEmpty(reader["BODEGA"].ToString()))
                    model.RFC = reader["RFC"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["RFC"].ToString()))
                    model.Curp = reader["CURP"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["CURP"].ToString()))
                    model.EdoCivil = reader["ESTADOCIVIL"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(reader["ESTADOCIVIL"].ToString()))
                    model.Compania = reader["COMPANIA"].ToString().ToUpper();
                model.Telefono = reader["TELLOCAL"].ToString();
                model.Celular = reader["TELMOVIL"].ToString();
                if (!string.IsNullOrEmpty(reader["NEXTEL"].ToString()))
                    model.TelOtro = reader["NEXTEL"].ToString();
                model.Email = reader["EMAIL"].ToString().ToLower();
                model.IdUsuario = idAsociado.ToString();
                model.Alias = reader["ALIAS"].ToString().ToUpper();
                model.Password = reader["PASSWORD"].ToString();
                if (int.Parse(reader["TIPO"].ToString()) == 0)
                    model.TipoAsociado = "ASOCIADO";
                else
                    model.TipoAsociado = "CONSUMIDOR";

                if (int.Parse(reader["FACTURA"].ToString()) == 0)
                    model.TipoRetencion = "RETENCIÓN ISR";
                else
                    model.TipoRetencion = "FACTURA";

                model.PaisPers = reader["PAIS"].ToString().ToUpper();
                model.Idioma = reader["IDIOMA"].ToString().ToUpper();
                model.CallePers = reader["CALLECASA"].ToString().ToUpper();
                model.NumExtPers = reader["NUMCASA"].ToString();
                if (!string.IsNullOrEmpty(reader["INTCASA"].ToString()))
                    model.NumIntPers = reader["INTCASA"].ToString();
                model.ColoniaPers = reader["COLCASA"].ToString().ToUpper();
                model.MunicipioPers = reader["MUNICIPIOCASA"].ToString().ToUpper();
                model.CiudadPers = reader["CIUDADCASA"].ToString().ToUpper();
                model.EdoPers = reader["ESTADOCASA"].ToString().ToUpper();
                model.ReferenciaPers = reader["OBSERVCASA"].ToString().ToUpper();
                model.CpPers = reader["CPCASA"].ToString();
                model.CalleEnv = reader["CALLEPAQ"].ToString().ToUpper();
                model.NumExtEnv = reader["NUMPAQ"].ToString();
                if (!string.IsNullOrEmpty(reader["INTPAQ"].ToString()))
                    model.NumIntEnv = reader["INTPAQ"].ToString();
                model.ColoniaEnv = reader["COLPAQ"].ToString().ToUpper();
                model.MunicipioEnv = reader["MUNICIPIOPAQ"].ToString().ToUpper();
                model.CiudadEnv = reader["CIUDADPAQ"].ToString().ToUpper();
                model.EdoEnv = reader["ESTADOPAQ"].ToString().ToUpper();
                model.ReferenciaEnv = reader["OBSERVPAQ"].ToString().ToUpper();
                model.CpEnv = reader["CPPAQ"].ToString();
                if (!string.IsNullOrEmpty(reader["BODEGA"].ToString()))
                    model.Bodega = reader["BODEGA"].ToString().ToUpper();
            }
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Consultar Datos Personales: " + ex.Message);
            throw new Exception("Error MisDatosPersonalesAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public void ActualizaDatos(MisDatosPersonalesModel datosNuevos)
    {
        Conection conn = new Conection();
        MySqlConnection mySqlCon = conn.conectBDPackage();
        try
        {
            string strQuery = "UPDATE ASOCIADOS " +
                "SET LUGARNACIM= '" + datosNuevos.LugarNacimiento + "', " +
                "ESTADOCIVIL= '" + datosNuevos.EdoCivil + "', " +
                "RFC= '" + datosNuevos.RFC + "', " +
                "CURP= '" + datosNuevos.Curp + "', " +
                "COMPANIA= '" + datosNuevos.Compania + "', " +
                "TELLOCAL= '" + datosNuevos.Telefono + "', " +
                "TELMOVIL= '" + datosNuevos.Celular + "', " +
                "NEXTEL= '" + datosNuevos.TelOtro + "', " +
                "EMAIL= '" + datosNuevos.Email + "', " +
                "PAIS= '" + datosNuevos.PaisPers + "', " +
                "IDIOMA= '" + datosNuevos.Idioma + "', " +
                "CALLECASA= '" + datosNuevos.CallePers + "', " +
                "NUMCASA= '" + datosNuevos.NumExtPers + "', " +
                "INTCASA= '" + datosNuevos.NumIntPers + "', " +
                "COLCASA= '" + datosNuevos.ColoniaPers + "', " +
                "CPCASA= '" + datosNuevos.CpPers + "', " +
                "MUNICIPIOCASA= '" + datosNuevos.MunicipioPers + "', " +
                "CIUDADCASA= '" + datosNuevos.CiudadPers + "', " +
                "ESTADOCASA= '" + datosNuevos.EdoPers + "', " +
                "OBSERVCASA= '" + datosNuevos.ReferenciaPers + "', " +
                "CALLEPAQ= '" + datosNuevos.CalleEnv + "', " +
                "NUMPAQ= '" + datosNuevos.NumExtEnv + "', " +
                "INTPAQ= '" + datosNuevos.NumIntEnv + "', " +
                "COLPAQ= '" + datosNuevos.ColoniaEnv + "', " +
                "CPPAQ= '" + datosNuevos.CpEnv + "', " +
                "MUNICIPIOPAQ= '" + datosNuevos.MunicipioEnv + "', " +
                "CIUDADPAQ= '" + datosNuevos.CiudadEnv + "', " +
                "ESTADOPAQ= '" + datosNuevos.EdoEnv + "', " +
                "OBSERVPAQ= '" + datosNuevos.ReferenciaEnv + "' " +
                "WHERE ID=" + datosNuevos.IdUsuario;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlCon);
            mySqlCon.Open();
            queryEx.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Actualizar Datos Personales: " + ex.Message);
            throw new Exception("Error MisDatosPersonalesAction: " + ex.Message);
        }
        finally
        {
            mySqlCon.Dispose();
            mySqlCon.Close();
            conn.closeConection();
        }
    }
}