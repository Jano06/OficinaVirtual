using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using log4net;

public class AltaProspectoAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(AltaProspectoAction));

    public string InsertaProspecto(MisDatosPersonalesModel model)
    {
        string idProspecto = string.Empty;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT (MAX(ID)+1) AS MAX FROM PROSPECTOS";
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                idProspecto = reader["MAX"].ToString();
            }
            reader.Close();
            mySqlConn.Dispose();
            mySqlConn.Close();

            strQuery = "INSERT INTO PROSPECTOS (ID, NOMBRE, APPATERNO, APMATERNO, FNAC, LUGARNACIM, ESTADOCIVIL, RFC, CURP, COMPANIA, TELLOCAL, TELMOVIL, NEXTEL, "
            + "EMAIL, ALIAS, PAIS, IDIOMA, CALLECASA, NUMCASA, INTCASA, COLCASA, CPCASA, MUNICIPIOCASA, CIUDADCASA, ESTADOCASA, OBSERVCASA, CALLEPAQ, NUMPAQ, INTPAQ, "
            + "COLPAQ, CPPAQ, MUNICIPIOPAQ, CIUDADPAQ, ESTADOPAQ, OBSERVPAQ, TIPO, PATROCINADOR, PADRE, LADO, STATUS) VALUES "
            + "(" + idProspecto + ", '" + model.Nombre + "', '" + model.ApPaterno + "', '" + model.ApMaterno + "', '" + model.FechaNacimiento.ToString("yyyy/MM/dd") + "', '" + model.LugarNacimiento + "', "
            + "'" + model.EdoCivil + "', '" + model.RFC + "', '" + model.Curp + "', '" + model.Compania + "', '" + model.Telefono + "', '" + model.Celular + "', '"
            + model.TelOtro + "', '" + model.Email + "', '', '" + model.PaisPers + "', '" + model.Idioma + "', '" + model.CallePers + "', '" + model.NumExtPers + "', '"
            + model.NumIntPers + "', '" + model.ColoniaPers + "', '" + model.CpPers + "', '" + model.MunicipioPers + "', '" + model.CiudadPers + "', '" + model.EdoPers + "', '" + model.ReferenciaPers + "', '" + model.CalleEnv + "', '"
            + model.NumExtEnv + "', '" + model.NumIntEnv + "', '" + model.ColoniaEnv + "', '" + model.CpEnv + "', '" + model.MunicipioEnv + "', '" + model.CiudadEnv + "', '" + model.EdoEnv + "', '" + model.ReferenciaEnv + "', "
            + model.TipoAsociado + ", " + model.IdUsuario + ", 0, '', 0) ";

            mySqlConn.Open();
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Insertar Prospecto: " + ex.Message);
            throw new Exception("Error AltaProspectoAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return idProspecto;
    }

    public List<MiProspectoModel> cargaProspectos(string idUser)
    {
        List<MiProspectoModel> Prospectos = new List<MiProspectoModel>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT ID, NOMBRE, APPATERNO, APMATERNO, TELMOVIL AS CELULAR, EMAIL FROM PROSPECTOS WHERE STATUS=0 AND PATROCINADOR=" + idUser;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                MiProspectoModel model = new MiProspectoModel();
                model.IdProspecto = reader["ID"].ToString();
                model.Nombre = reader["NOMBRE"].ToString();
                model.ApPaterno = reader["APPATERNO"].ToString();
                model.ApMaterno = reader["APMATERNO"].ToString();
                model.Email = reader["EMAIL"].ToString();
                model.Celular = reader["CELULAR"].ToString();
                Prospectos.Add(model);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Cargar Prospectos: " + ex.Message);
            throw new Exception("Error AltaProspectoAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return Prospectos;
    }

    public void EliminaProspecto(string idProspecto)
    { 
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "UPDATE PROSPECTOS SET STATUS=2 WHERE ID=" + idProspecto;
            mySqlConn.Open();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Eliminar Prospecto: " + ex.Message);
            throw new Exception("Error AltaProspectoAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    public void actualizaProspecto(string idProspecto, string padre, string lado)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "UPDATE PROSPECTOS SET LADO='" + lado + "', PADRE=" + padre + " WHERE ID=" + idProspecto + "";

            mySqlConn.Open();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Actualizar Prospecto: " + ex.Message);
            throw new Exception("Error ComprasAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }

    public MisDatosPersonalesModel DatosProspecto(string idProspecto)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();

        try
        {
            string strQuery = "SELECT CONCAT(NOMBRE, ' ',APPATERNO, ' ', APMATERNO) AS NOMBRE, FNAC, LUGARNACIM, ESTADOCIVIL, RFC, CURP, TELLOCAL, TELMOVIL, "
                + "NEXTEL, EMAIL, COMPANIA, PAIS, IDIOMA, CALLECASA, NUMCASA, INTCASA, COLCASA, CPCASA, MUNICIPIOCASA, CIUDADCASA, ESTADOCASA, CALLEPAQ, "
                + "NUMPAQ, INTPAQ, COLPAQ, CPPAQ, MUNICIPIOPAQ, CIUDADPAQ, ESTADOPAQ, TIPO FROM PROSPECTOS WHERE ID=" + idProspecto;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.Nombre = reader["NOMBRE"].ToString();
                model.FechaNacimiento = Convert.ToDateTime(reader["FNAC"].ToString());
                model.LugarNacimiento = reader["LUGARNACIM"].ToString();
                model.EdoCivil = reader["ESTADOCIVIL"].ToString();
                model.RFC = reader["RFC"].ToString();
                model.Curp = reader["CURP"].ToString();
                model.Telefono = reader["TELLOCAL"].ToString();
                model.Celular = reader["TELMOVIL"].ToString();
                model.TelOtro = reader["NEXTEL"].ToString();
                model.Email = reader["EMAIL"].ToString();
                model.Compania = reader["COMPANIA"].ToString();
                model.PaisPers = reader["PAIS"].ToString();
                model.Idioma = reader["IDIOMA"].ToString();
                model.CallePers = reader["CALLECASA"].ToString();
                model.NumExtPers = reader["NUMCASA"].ToString();
                model.NumIntPers = reader["INTCASA"].ToString();
                model.ColoniaPers = reader["COLCASA"].ToString();
                model.CpPers = reader["CPCASA"].ToString();
                model.MunicipioPers = reader["MUNICIPIOCASA"].ToString();
                model.CiudadPers = reader["CIUDADCASA"].ToString();
                model.EdoPers = reader["ESTADOCASA"].ToString();
                model.CalleEnv = reader["CALLEPAQ"].ToString();
                model.NumExtEnv = reader["NUMPAQ"].ToString();
                model.NumIntEnv = reader["INTPAQ"].ToString();
                model.ColoniaEnv = reader["COLPAQ"].ToString();
                model.CpEnv = reader["CPPAQ"].ToString();
                model.MunicipioEnv = reader["MUNICIPIOPAQ"].ToString();
                model.CiudadEnv = reader["CIUDADPAQ"].ToString();
                model.EdoEnv = reader["ESTADOPAQ"].ToString();
                model.TipoAsociado = reader["TIPO"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Consulta Prospectos: " + ex.Message);
            throw new Exception("Error AltaProspectoAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public MisDatosPersonalesModel ProspectoDatos(string idProspecto)
    {
        MisDatosPersonalesModel model = new MisDatosPersonalesModel();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();

        try
        {
            string strQuery = "SELECT NOMBRE, APPATERNO, APMATERNO, FNAC, LUGARNACIM, ESTADOCIVIL, COMPANIA, RFC, CURP, TELLOCAL, TELMOVIL, "
                + "NEXTEL, EMAIL, PAIS, IDIOMA, CALLECASA, NUMCASA, INTCASA, COLCASA, CPCASA, MUNICIPIOCASA, CIUDADCASA, ESTADOCASA, OBSERVCASA, CALLEPAQ, "
                + "NUMPAQ, INTPAQ, COLPAQ, CPPAQ, MUNICIPIOPAQ, CIUDADPAQ, ESTADOPAQ, OBSERVPAQ, TIPO FROM PROSPECTOS WHERE ID=" + idProspecto;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                model.Nombre = reader["NOMBRE"].ToString();
                model.ApPaterno = reader["APPATERNO"].ToString();
                model.ApMaterno = reader["APMATERNO"].ToString();
                model.FechaNacimiento = Convert.ToDateTime(reader["FNAC"].ToString());
                model.LugarNacimiento = reader["LUGARNACIM"].ToString();
                model.EdoCivil = reader["ESTADOCIVIL"].ToString();
                model.Compania = reader["COMPANIA"].ToString();
                model.RFC = reader["RFC"].ToString();
                model.Curp = reader["CURP"].ToString();
                model.Telefono = reader["TELLOCAL"].ToString();
                model.Celular = reader["TELMOVIL"].ToString();
                model.TelOtro = reader["NEXTEL"].ToString();
                model.Email = reader["EMAIL"].ToString();
                model.PaisPers = reader["PAIS"].ToString();
                model.Idioma = reader["IDIOMA"].ToString();
                model.CallePers = reader["CALLECASA"].ToString();
                model.NumExtPers = reader["NUMCASA"].ToString();
                model.NumIntPers = reader["INTCASA"].ToString();
                model.ColoniaPers = reader["COLCASA"].ToString();
                model.CpPers = reader["CPCASA"].ToString();
                model.MunicipioPers = reader["MUNICIPIOCASA"].ToString();
                model.CiudadPers = reader["CIUDADCASA"].ToString();
                model.EdoPers = reader["ESTADOCASA"].ToString();
                model.ReferenciaPers = reader["OBSERVCASA"].ToString();
                model.CalleEnv = reader["CALLEPAQ"].ToString();
                model.NumExtEnv = reader["NUMPAQ"].ToString();
                model.NumIntEnv = reader["INTPAQ"].ToString();
                model.ColoniaEnv = reader["COLPAQ"].ToString();
                model.CpEnv = reader["CPPAQ"].ToString();
                model.MunicipioEnv = reader["MUNICIPIOPAQ"].ToString();
                model.CiudadEnv = reader["CIUDADPAQ"].ToString();
                model.EdoEnv = reader["ESTADOPAQ"].ToString();
                model.ReferenciaEnv = reader["OBSERVPAQ"].ToString();
                model.TipoAsociado = reader["TIPO"].ToString();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Consulta Prospecto: " + ex.Message);
            throw new Exception("Error AltaProspectoAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return model;
    }

    public void EditaProspecto(MisDatosPersonalesModel model, string idProspecto)
    {
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "UPDATE PROSPECTOS SET NOMBRE='" + model.Nombre + "', APPATERNO='" + model.ApPaterno + "', "
                + "APMATERNO='" + model.ApMaterno + "', FNAC='" + model.FechaNacimiento.ToString("yyyy/MM/dd") + "', ESTADOCIVIL='" + model.EdoCivil + "', "
                + "RFC='" + model.RFC + "', CURP='" + model.Curp + "', COMPANIA='" + model.Compania + "', TELLOCAL='" + model.Telefono + "', "
                + "TELMOVIL='" + model.Celular + "', NEXTEL='" + model.TelOtro + "', EMAIL='" + model.Email + "', PAIS='" + model.PaisPers + "', "
                + "IDIOMA='" + model.Idioma + "', CALLECASA='" + model.CallePers + "', NUMCASA='" + model.NumExtPers + "', INTCASA='" + model.NumIntPers + "', "
                + "COLCASA='" + model.ColoniaPers + "', CPCASA='" + model.CpPers + "', MUNICIPIOCASA='" + model.MunicipioPers + "', ESTADOCASA='" + model.EdoPers + "', "
                + "CIUDADCASA='" + model.CiudadPers + "', OBSERVCASA='"+model.ReferenciaPers+"', CALLEPAQ='" + model.CalleEnv + "', NUMPAQ='" + model.NumExtEnv + "', INTPAQ='" + model.NumIntEnv + "', "
                + "COLPAQ='" + model.ColoniaEnv + "', CPPAQ='" + model.CpEnv + "', MUNICIPIOCASA='" + model.MunicipioEnv + "', ESTADOCASA='" + model.EdoEnv + "', "
                + "CIUDADCASA='" + model.CiudadEnv + "', OBSERVPAQ='"+model.ReferenciaEnv+"' "
                + "WHERE ID=" + idProspecto;
            mySqlConn.Open();
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            queryEx.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Actualizar Prospecto: " + ex.Message);
            throw new Exception("Error AltaProspectoAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
    }
}