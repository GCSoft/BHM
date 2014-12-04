/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BPEncuesta
' Autor: Ruben.Cobos
' Fecha: 19-Noviembre-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencias manuales
using GCUtility.Security;
using GCUtility.Communication;
using BHM.DataAccess.Object;
using BHM.Entity.Object;
using System.Data;
using System.Web;

namespace BHM.BusinessProcess.Object
{
    public class BPEncuesta : BPBase
    {

        ///<remarks>
        ///   <name>BPEncuesta.InsertResultadoEncuesta</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Crea la marca de encuesta para un conjunto de usuarios y envía la invitación por correo</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse InsertResultadoEncuesta(ENTEncuesta oENTEncuesta){
            GCMail gcMail = new GCMail();
            GCEncryption gcEncryption = new GCEncryption();

            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            String HTMLMessage = "";
            String Key = "";

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.InsertResultadoEncuesta(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();
                if (oENTResponse.MessageDB != "") { return oENTResponse; }

                // Encriptar llave
                Key = gcEncryption.EncryptString(oENTResponse.DataSetResponse.Tables[1].Rows[0]["ResultadoEncuestaId"].ToString(), false);

                // Configuración del correo
                HTMLMessage = "" +
                "<html>" +
                   "<head>" +
                      "<title>BHM - Invitación</title>" +
                   "</head>" +
                   "<body style='height:100%; margin:0px; padding:0px; width:100%;'>" +
                      "<div style='clear:both; height:90%; text-align:center; width:100%;'>" +
                         "<div style='height:80%; clear: both; margin:0px auto; position:relative; top:10%; width:90%;'>" +
                            "<table border='0px;' cellpadding='0' cellspacing='0' style='height:100%; width:100%;'>" +
                               "<tr>" +
                                  "<td colspan='2' valign='middle' style='color:#549CC6; font-family:Arial; font-size:12px; font-weight:bold; text-align:left;'>BHM - Bienvenido al sistema</td>" +
                               "</tr>" +
                               "<tr><td colspan='3'><div style='border-bottom:1px solid #549CC6;'></div></td></tr>" +
                               "<tr style='height:10px'><td colspan='3'></td></tr>" +
                               "<tr>" +
                                  "<td colspan='2' valign='top' style='font-family:Arial; font-size:12px;'>" +
                                     "Estimado(a) <b>" + oENTResponse.DataSetResponse.Tables[1].Rows[0]["Nombre"].ToString() + "</b>, el equipo de sistemas de BHM lo invita a contestar la encuesta <b>" + oENTResponse.DataSetResponse.Tables[1].Rows[0]["EncuestaNombre"].ToString() + "</b>.<br><br>" +
                                     "<table border='0px' cellpadding='0' cellspacing ='0' class='Text' style='height:100%; width:100%'>" +
                                        "<tr style='height:10px'><td></td></tr>" +
                                        "<tr>" +
                                           "<td style='font-family:Arial; font-size:12px; text-align:left;'>" +
                                                 "<br>Puede acceder a la encuesta haciendo click <a href='" + this.QuizURL + "?key=" + Key + "'>aqui</a>" +
                                           "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                           "<td style='font-family:Arial; font-size:12px; text-align:left;'>" +
                                              "<br><br><br>Gracias por utilizar nuestros servicios informáticos" +
                                           "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                           "<td style='font-family:Arial; font-size:9px; text-align:center;'>" +
                                              "<br><br>Powered By GCSoft" +
                                           "</td>" +
                                        "</tr>" +
                                     "</table>" +
                                  "</td>" +
                               "</tr>" +
                               "<tr style='height:20px'><td colspan='3'></td></tr>" +
                               "<tr style='height:20px'><td colspan='3'></td></tr>" +
                               "<tr style='height:1px'><td colspan='3' style='background:#000063 repeat-x;'></td></tr>" +
                               "<tr style='height:60px; vertical-align:top;'>" +
                                  "<td colspan='2' style='font-family:Arial; font-size:10px; color: #180A3B; text-align:justify; vertical-align:middle;'>" +
                                     "Este correo electronico es confidencial y/o puede contener informacion privilegiada. Si usted no es su destinatario o no es alguna persona autorizada por este para recibir sus correos electronicos, NO debera usted utilizar, copiar, revelar, o tomar ninguna accion basada en este correo electronico o cualquier otra informacion incluida en el, favor de notificar al remitente de inmediato mediante el reenvio de este correo electronico y borrar a continuacion totalmente este correo electronico y sus anexos.<br/><br/>Nota: Los acentos y caracteres especiales fueron omitidos para su correcta lectura en cualquier medio electronico.<br/>" +
                                  "</td>" +
                                  "<td></td>" +
                               "</tr>" +
                               "<tr><td colspan='3'></td></tr>" +
                            "</table>" +
                         "</div>" +
                      "</div>" +
                   "</body>" +
                "</html>";

                // Enviar correo
                gcMail.Send("BHM - Invitación", oENTResponse.DataSetResponse.Tables[1].Rows[0]["Email"].ToString(), "BHM - Invitación", HTMLMessage);

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>BPEncuesta.SelectEncuesta</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Consulta el catálogo de Encuestas</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectEncuesta(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.SelectEncuesta(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>BPEncuesta.SelectEncuestaDetalle</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene el detalle de una Encuesta en base a los parámetros proporcionados</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectEncuestaDetalle(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.SelectEncuestaDetalle(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>BPEncuesta.SelectEncuestaDetalleOpcion</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene las opciones del detalle de una Encuesta en base a los parámetros proporcionados</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectEncuestaDetalleOpcion(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.SelectEncuestaDetalleOpcion(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>BPEncuesta.SelectResultadoEncuesta_Recovery</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Consulta el detalle de una encuesta en particular para su recuperación</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectResultadoEncuesta_Recovery(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.SelectResultadoEncuesta_Recovery(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

         ///<remarks>
        ///   <name>BPEncuesta.SelectResultadoEncuestaDetalle</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Obtiene las respuestas seleccionadas por el usuario para una pregunta en particular en base a los parámetros proporcionados</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los filtros necesarios para la consulta</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse SelectResultadoEncuestaDetalle(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.SelectResultadoEncuestaDetalle(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>BPEncuesta.UpdateResultadoEncuesta_AceptarTerminos</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Actualiza la marca de invitación de una encuesta en particular</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateResultadoEncuesta_AceptarTerminos(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.UpdateResultadoEncuesta_AceptarTerminos(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

        ///<remarks>
        ///   <name>BPEncuesta.UpdateResultadoEncuestaDetalle</name>
        ///   <create>19-Noviembre-2014</create>
        ///   <author>Ruben.Cobos</author>
        ///</remarks>
        ///<summary>Crea/Actualiza las respuestas de una encuesta en particular</summary>
        ///<param name="oENTEncuesta">Entidad de Encuesta con los parámetros necesarios para realizar la transacción</param>
        ///<returns>Una entidad de respuesta</returns>
        public ENTResponse UpdateResultadoEncuestaDetalle(ENTEncuesta oENTEncuesta){
            DAEncuesta oDAEncuesta = new DAEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Transacción en base de datos
                oENTResponse = oDAEncuesta.UpdateResultadoEncuestaDetalle(oENTEncuesta, this.ConnectionApplication, 0);

                // Validación de error en consulta
                if (oENTResponse.GeneratesException) { return oENTResponse; }

                // Validación de mensajes de la BD
                oENTResponse.MessageDB = oENTResponse.DataSetResponse.Tables[0].Rows[0]["Response"].ToString();

            }catch (Exception ex){
                oENTResponse.ExceptionRaised(ex.Message);
            }

            // Resultado
            return oENTResponse;
        }

    }
}
