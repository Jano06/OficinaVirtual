using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using log4net;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Configuration;
/// <summary>
/// Descripción breve de EmailAction
/// </summary>
public class EmailAction
{
    private static readonly ILog _LOGGER = LogManager.GetLogger(typeof(EmailAction));

    private List<string> consInfoAsociado(string idAsociado)
    {
        List<string> infoMail = new List<string>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT CONCAT(NOMBRE, ' ', APPATERNO, ' ', APMATERNO) AS NOMBRE, EMAIL FROM ASOCIADOS WHERE ID=" + idAsociado;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                infoMail.Add(reader["NOMBRE"].ToString().ToUpper());
                infoMail.Add(reader["EMAIL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Info Asociado: " + ex.Message);
            throw new Exception("Error EmailAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return infoMail;
    }

    private List<string> consInfoProspecto(string idProspecto, string idAsociado)
    {
        List<string> info = new List<string>();
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT CONCAT(NOMBRE, ' ', APPATERNO, ' ', APMATERNO) AS NOMBRE, EMAIL FROM PROSPECTOS WHERE ID=" + idProspecto;
            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                info.Add(reader["NOMBRE"].ToString().ToUpper());
                info.Add(reader["EMAIL"].ToString());
            }
            reader.Close();
            mySqlConn.Close();
            
            strQuery = "SELECT CONCAT(NOMBRE, ' ', APPATERNO, ' ', APMATERNO) AS NOMBRE FROM ASOCIADOS WHERE ID=" + idAsociado;
            queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                info.Add(reader["NOMBRE"].ToString().ToUpper());
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al consultar Informacion: " + ex.Message);
            throw new Exception("Error EmailAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return info;
    }

    public string ConsMensajeCompra()
    {
        string MensajeCompra = string.Empty;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT MENSAJECOMPRA FROM CONFIGURACION";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                MensajeCompra = reader["MENSAJECOMPRA"].ToString();
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Consultar Mensaje Compra : " + ex.Message);
            throw new Exception("Error EmailAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return MensajeCompra;
    }

    private string ConsNombrePqt(int pqt)
    {
        string nomPqt = string.Empty;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT NOMBRE FROM PAQUETES WHERE ID=" + pqt;

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                nomPqt = reader["NOMBRE"].ToString().ToUpper();
            }
            reader.Close();
            mySqlConn.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Consultar Nombre Paquete : " + ex.Message);
            throw new Exception("Error EmailAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return nomPqt;
    }

    private double ConsPrecioInscr()
    {
        double precioInscr = 0;
        Conection con = new Conection();
        MySqlConnection mySqlConn = con.conectBDPackage();
        try
        {
            string strQuery = "SELECT COSTO FROM PAQUETES WHERE ID= 0";

            MySqlCommand queryEx = new MySqlCommand(strQuery, mySqlConn);
            mySqlConn.Open();
            MySqlDataReader reader = queryEx.ExecuteReader();
            while (reader.Read())
            {
                precioInscr = Convert.ToDouble(reader["COSTO"].ToString());
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            _LOGGER.Error("Error al Consultar Costo Inscripcion: " + ex.Message);
            throw new Exception("Error EmailAction: " + ex.Message);
        }
        finally
        {
            mySqlConn.Dispose();
            mySqlConn.Close();
            con.closeConection();
        }
        return precioInscr;
    }

    public void CorreoCompra(ComprasModel compra)
    {
        List<string> infoAsociado = new List<string>();
        string mensajeCompra = string.Empty;
        string nomPaquete = string.Empty;

        infoAsociado = consInfoAsociado(compra.Asociado);
        mensajeCompra = ConsMensajeCompra();
        nomPaquete = ConsNombrePqt(compra.Paquete);

        string[] a = Regex.Split(mensajeCompra, "\r\n");
        StringBuilder htmBody = new StringBuilder();
        StringBuilder body = new StringBuilder();

        #region MensajeCompra
        body.Append("<table width='800px' style='text-align:justify; color: #000000; font-size: medium; font-family: Arial;'>");
        
        for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
        {
            if (i == 7)
            {
                string cadena = string.Empty;
                string caux = string.Empty;
                caux = a[i];
                body.Append("<tr><td><a href='mailto:" + caux + "'>"+caux+"</a></td></tr>");
            }
            else if (a[i] == "")
            {
                body.Append("<tr><td></td></tr>");
            }
            else
            {
                string cadena = string.Empty;
                string caux = string.Empty;
                caux = a[i];
                body.Append("<tr><td>" + caux + "</td></tr>");
            }
        }
        #endregion
        #region CuerpoCorreo
        body.Append("</table>");
        body.Append("<br /><br /><br />");
        body.Append("<table width='600px' style='font-family: Arial; color: #000000; font-size: medium; font-weight: normal; margin-top: 0px; background-position: bottom; background-repeat: no-repeat;'>");
        body.Append("<tr>");
        body.Append("<td align='center' style='font-weight: bold;' colspan='2'>DATOS GENERALES</td>");
        body.Append("</tr>");
        body.Append("<tr>");
         body.Append("<td align='right'>Número Asociado:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.Asociado + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td width='150px' align='right'>Asociado:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + infoAsociado[0] + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Órden:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.IdCompra + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Volumen:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.Puntos + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Fecha:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.FechaOrden.ToString("dd/MMMM/yyyy").ToUpper() + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Entrega:</td>");
        body.Append("<td><span style='font-weight:bold;'>" + compra.TipoEntrega + "</span></td>");
        body.Append("</tr>");
        body.Append("</table>");
        body.Append("<br />");

        body.Append("<table width='800px' style='font-family: Arial; font-size: medium; font-weight: normal; margin-top: 0px; background-position: bottom; background-repeat: no-repeat;'>");
        body.Append("<tr>");
        body.Append("<td align='center' style='font-weight: bold;' colspan='5'>DETALLE COMPRA</td>");
        body.Append("</tr>");
        body.Append("<tr align='center' style='font-weight: bold; background-color:#084B8A; color:#FFFFFF'>");
        body.Append("<td width='15%'>Cantidad</td>");
        body.Append("<td width='50%'>Paquete</td>");
        body.Append("<td width='23%'>P. Unitario</td>");
        body.Append("<td colspan='2' width='10%'>Monto</td>");
        body.Append("</tr>");

        body.Append("<tr align='center'>");
        body.Append("<td>1</td>");
        body.Append("<td>" + nomPaquete + "</td>");
        body.Append("<td>" + compra.Costo.ToString("c") + "</td>");
        body.Append("<td width='2%'>$</td>");
        body.Append("<td align='right'>" + compra.Costo.ToString("N2") + "</td>");
        body.Append("</tr>");
        if (compra.Iva > 0)
        {
            body.Append("<tr align='center'>");
            body.Append("<td>1</td>");
            body.Append("<td>ENVIO</td>");
            body.Append("<td>" + compra.Envio.ToString("c") + "</td>");
            body.Append("<td>$</td>");
            body.Append("<td align='right'>" + compra.Envio.ToString("N2") + "</td>");
            body.Append("</tr>");
        }
        body.Append("<tr align='right'>");
        body.Append("<td></td>");
        body.Append("<td></td>");
        body.Append("<td style='font-weight: bold;'>Subtotal:</td>");
        body.Append("<td>$</td>");
        body.Append("<td>" + (compra.Costo + compra.Envio).ToString("N2") + "</td>");
        body.Append("</tr>");
        body.Append("<tr align='right'>");
        body.Append("<td></td>");
        body.Append("<td></td>");
        body.Append("<td style='font-weight: bold;'>IVA:</td>");
        body.Append("<td>$</td>");
        body.Append("<td>" + compra.Iva.ToString("N2") + "</td>");
        body.Append("</tr>");
        body.Append("<tr align='right'>");
        body.Append("<td></td>");
        body.Append("<td></td>");
        body.Append("<td style='font-weight: bold;'>Total:</td>");
        body.Append("<td style='font-weight: bold;'>$</td>");
        body.Append("<td style='font-weight: bold;' align='right'>" + compra.Total.ToString("N2") + "</td>");
        body.Append("</tr>");
        body.Append("</table>");
        body.Append("<br />");
        body.Append("<table width='800px' style='font-family: Arial; color: #000000; font-size: medium; font-weight: normal; margin-top: 0px; background-position: bottom; background-repeat: no-repeat;'>");
        body.Append("<tr align='center'>");
        body.Append("<td colspan='3' style='font-weight: bold;'>FORMAS DE PAGO</td>");
        body.Append("</tr>");
        body.Append("<tr align='center' style='font-weight: bold; background-color:#084B8A; color:#FFFFFF'>");
        body.Append("<td width='50%' style='font-weight: bold;'>Banco</td>");
        body.Append("<td width='25%' style='font-weight: bold;'>Cuenta</td>");
        body.Append("<td width='23%' style='font-weight: bold;'>Referencia</td>");
        body.Append("</tr>");
        body.Append("<tr align='center'>");
        body.Append("<td>SCOTIABANK</td>");
        body.Append("<td>03504208749</td>");
        body.Append("<td>" + compra.Referencia + "</td>");
        body.Append("</tr>");
        body.Append("<tr align='center'>");
        body.Append("<td>BANORTE</td>");
        body.Append("<td>0870626045</td>");
        body.Append("<td>" + compra.Referencia + "</td>");
        body.Append("</tr>");
        body.Append("</table>");

        htmBody.Append("<html>");
        htmBody.Append("<head>");
        htmBody.Append("<meta name='ProgId' content='FrontPage.Editor.Document'>");
        htmBody.Append("<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>");
        htmBody.Append("<title>Correo Electonico Autogenerado</title>");
        htmBody.Append("</head>");
        htmBody.Append("<body>");
        htmBody.Append(body.ToString());
        htmBody.Append("</body>");
        htmBody.Append("</html>");
        #endregion

        enviaEmail(infoAsociado[1], "Su orden con número " + compra.IdCompra + " fue realizada con éxito", htmBody.ToString());
    }

    public void CorreoCompraProspecto(ComprasModel compra, string idProspecto)
    {
        List<string> infoAsociado = new List<string>();
        string mensajeCompra = string.Empty;
        string nomPaquete = string.Empty;
        double precioInscr = 0;

        infoAsociado = consInfoProspecto(idProspecto, compra.Asociado);
        mensajeCompra = ConsMensajeCompra();
        nomPaquete = ConsNombrePqt(compra.Paquete);
        precioInscr = ConsPrecioInscr();

        double inscrSinIva = precioInscr / Convert.ToDouble(ConfigurationManager.AppSettings["ivaDesgloce"].ToString());

        string[] a = Regex.Split(mensajeCompra, "\r\n");
        StringBuilder htmBody = new StringBuilder();
        StringBuilder body = new StringBuilder();

        #region MensajeCompra
        body.Append("<table width='800px' style='text-align:justify; color: #000000; font-size: medium; font-family: Arial;'>");
        
        for (int i = a.GetLowerBound(0); i <= a.GetUpperBound(0); i++)
        {
            if (i == 7)
            {
                string cadena = string.Empty;
                string caux = string.Empty;
                caux = a[i];
                body.Append("<tr><td><a href='mailto:" + caux + "'>"+caux+"</a></td></tr>");
            }
            else if (a[i] == "")
            {
                body.Append("<tr><td></td></tr>");
            }
            else
            {
                string cadena = string.Empty;
                string caux = string.Empty;
                caux = a[i];
                body.Append("<tr><td>" + caux + "</td></tr>");
            }
        }
        #endregion
        #region CuerpoCorreo
        body.Append("</table>");
        body.Append("<br /><br /><br />");
        body.Append("<table width='600px' style='font-family: Arial; color: #000000; font-size: medium; font-weight: normal; margin-top: 0px; background-position: bottom; background-repeat: no-repeat;'>");
        body.Append("<tr>");
        body.Append("<td align='center' style='font-weight: bold;' colspan='2'>DATOS GENERALES</td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Invitado:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + infoAsociado[0] + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Número Patrocinador:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.Asociado + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td width='150px' align='right'>Patrocinador:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + infoAsociado[2] + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Orden:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.IdCompra + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Volumen:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.Puntos + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Fecha:</td>");
        body.Append("<td><span style='font-weight: bold;'>" + compra.FechaOrden.ToString("dd/MMMM/yyyy").ToUpper() + "</span></td>");
        body.Append("</tr>");
        body.Append("<tr>");
        body.Append("<td align='right'>Entrega:</td>");
        body.Append("<td><span style='font-weight:bold;'>" + compra.TipoEntrega + "</span></td>");
        body.Append("</tr>");
        body.Append("</table>");
        body.Append("<br />");

        body.Append("<table width='800px' style='font-family: Arial; font-size: medium; font-weight: normal; margin-top: 0px; background-position: bottom; background-repeat: no-repeat;'>");
        body.Append("<tr>");
        body.Append("<td align='center' style='font-weight: bold;' colspan='5'>DETALLE COMPRA</td>");
        body.Append("</tr>");
        body.Append("<tr align='center' style='font-weight: bold; background-color:#084B8A; color:#FFFFFF'>");
        body.Append("<td width='15%'>Cantidad</td>");
        body.Append("<td width='50%'>Paquete</td>");
        body.Append("<td width='23%'>P. Unitario</td>");
        body.Append("<td colspan='2' width='10%'>Monto</td>");
        body.Append("</tr>");

        body.Append("<tr align='center'>");
        body.Append("<td>1</td>");
        body.Append("<td>INSCRIPCIÓN</td>");
        body.Append("<td>" + inscrSinIva.ToString("c") + "</td>");
        body.Append("<td width='2%'>$</td>");
        body.Append("<td align='right'>" + inscrSinIva.ToString("N2") + "</td>");
        body.Append("</tr>");

        body.Append("<tr align='center'>");
        body.Append("<td>1</td>");
        body.Append("<td>" + nomPaquete + "</td>");
        body.Append("<td>" + compra.Costo.ToString("c") + "</td>");
        body.Append("<td width='2%'>$</td>");
        body.Append("<td align='right'>" + compra.Costo.ToString("N2") + "</td>");
        body.Append("</tr>");
        if (compra.TipoEntrega.Equals("DOMICILIO"))
        {
            body.Append("<tr align='center'>");
            body.Append("<td>1</td>");
            body.Append("<td>ENVIO</td>");
            body.Append("<td>" + compra.Envio.ToString("c") + "</td>");
            body.Append("<td>$</td>");
            body.Append("<td align='right'>" + compra.Envio.ToString("N2") + "</td>");
            body.Append("</tr>");
        }
        body.Append("<tr align='right'>");
        body.Append("<td></td>");
        body.Append("<td></td>");
        body.Append("<td style='font-weight: bold;'>Subtotal:</td>");
        body.Append("<td>$</td>");
        body.Append("<td>" + (compra.Costo + compra.Envio + inscrSinIva).ToString("N2") + "</td>");
        body.Append("</tr>");
        body.Append("<tr align='right'>");
        body.Append("<td></td>");
        body.Append("<td></td>");
        body.Append("<td style='font-weight: bold;'>IVA:</td>");
        body.Append("<td>$</td>");
        body.Append("<td>" + compra.Iva.ToString("N2") + "</td>");
        body.Append("</tr>");
        body.Append("<tr align='right'>");
        body.Append("<td></td>");
        body.Append("<td></td>");
        body.Append("<td style='font-weight: bold;'>Total:</td>");
        body.Append("<td style='font-weight: bold;'>$</td>");
        body.Append("<td style='font-weight: bold;' align='right'>" + compra.Total.ToString("N2") + "</td>");
        body.Append("</tr>");
        body.Append("</table>");
        body.Append("<br />");
        body.Append("<table width='800px' style='font-family: Arial; color: #000000; font-size: medium; font-weight: normal; margin-top: 0px; background-position: bottom; background-repeat: no-repeat;'>");
        body.Append("<tr align='center'>");
        body.Append("<td colspan='3' style='font-weight: bold;'>FORMAS DE PAGO</td>");
        body.Append("</tr>");
        body.Append("<tr align='center' style='font-weight: bold; background-color:#084B8A; color:#FFFFFF'>");
        body.Append("<td width='50%' style='font-weight: bold;'>Banco</td>");
        body.Append("<td width='25%' style='font-weight: bold;'>Cuenta</td>");
        body.Append("<td width='23%' style='font-weight: bold;'>Referencia</td>");
        body.Append("</tr>");
        body.Append("<tr align='center'>");
        body.Append("<td>SCOTIABANK</td>");
        body.Append("<td>03504208749</td>");
        body.Append("<td>" + compra.Referencia + "</td>");
        body.Append("</tr>");
        body.Append("<tr align='center'>");
        body.Append("<td>BANORTE</td>");
        body.Append("<td>0870626045</td>");
        body.Append("<td>" + compra.Referencia + "</td>");
        body.Append("</tr>");
        body.Append("</table>");

        htmBody.Append("<html>");
        htmBody.Append("<head>");
        htmBody.Append("<meta name='ProgId' content='FrontPage.Editor.Document'>");
        htmBody.Append("<meta http-equiv='Content-Type' content='text/html; charset=windows-1252'>");
        htmBody.Append("<title>Correo Electonico Autogenerado</title>");
        htmBody.Append("</head>");
        htmBody.Append("<body>");
        htmBody.Append(body.ToString());
        htmBody.Append("</body>");
        htmBody.Append("</html>");
        #endregion

        enviaEmail(infoAsociado[1], "Su orden con número " + compra.IdCompra + " fue realizada con éxito", htmBody.ToString());
    }

    private void enviaEmail(string destinatario, string asunto, string cuerpo)
    {
        try
        {
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("atencionaclientes@kisem.com.mx");
            correo.To.Add(destinatario);
            correo.Subject = asunto;
            correo.Body = cuerpo;
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "kisem.com.mx";
            smtp.Credentials = new System.Net.NetworkCredential("atencionaclientes@kisem.com.mx", "Atencionaclientes1");
            smtp.Port = 587;
            smtp.Send(correo);
        }
        catch (Exception)
        { 
            
        }
    }
}