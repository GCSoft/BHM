/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	AppIndex
' Autor:	Ruben.Cobos
' Fecha:	21-Noviembre-2014
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using GCUtility.Function;
using GCUtility.Security;
using BHM.BusinessProcess.Object;
using BHM.BusinessProcess.Page;
using BHM.Entity.Object;

namespace BHM.Web.Application.WebApp.Private
{
    public partial class AppIndex : NonMenuPage
    {

        // Utilerías
        GCCommon gcCommon = new GCCommon();
        GCEncryption gcEncryption = new GCEncryption();
        GCJavascript gcJavascript = new GCJavascript();


        // Rutinas del programador

        void RedirectQuiz(ENTSession oENTSession){
            BPEncuesta oBPEncuesta = new BPEncuesta();

            ENTEncuesta oENTEncuesta = new ENTEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            try
            {

                // Datos del formulario
                oENTEncuesta.UsuarioId = oENTSession.UsuarioId;
                oENTEncuesta.ResultadoEncuestaId = oENTSession.Encuesta.ResultadoEncuestaId;

                // Transacción
                oENTResponse = oBPEncuesta.SelectResultadoEncuesta_Recovery(oENTEncuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { throw (new Exception(oENTResponse.MessageDB)); }

                // Recuperación exitosa
                oENTSession.Encuesta.EncuestaId = Int32.Parse( oENTResponse.DataSetResponse.Tables[1].Rows[0]["EncuestaId"].ToString());
                oENTSession.Encuesta.Nombre = oENTResponse.DataSetResponse.Tables[1].Rows[0]["Nombre"].ToString();
                oENTSession.Encuesta.Descripcion = oENTResponse.DataSetResponse.Tables[1].Rows[0]["Descripcion"].ToString();
                oENTSession.Encuesta.Entrada = oENTResponse.DataSetResponse.Tables[1].Rows[0]["Entrada"].ToString();
                oENTSession.Encuesta.Activo = Int16.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["Activo"].ToString());
                oENTSession.Encuesta.PreguntasPorPagina = Int16.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["PreguntasPorPagina"].ToString());
                oENTSession.Encuesta.SoloAvanzar = Int16.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["SoloAvanzar"].ToString());
                oENTSession.Encuesta.Aceptada = Int16.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["Aceptada"].ToString());
                oENTSession.Encuesta.Finalizada = Int16.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["Finalizada"].ToString());
                oENTSession.Encuesta.Paginas = Int32.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["Paginas"].ToString());
                oENTSession.Encuesta.PaginaActual = Int32.Parse(oENTResponse.DataSetResponse.Tables[1].Rows[0]["PaginaActual"].ToString());

                // Actualiza sesión
                Session["oENTSession"] = oENTSession;

                // Canalizar    
                this.Response.Redirect("Encuesta/" + ( oENTSession.Encuesta.Aceptada == 0 ? "encTerminos.aspx" : "encEncuesta.aspx" ) , false);

            }catch (Exception ex){

                oENTSession.Encuesta.MensajeRecuperacion = ex.Message;
                Session["oENTSession"] = oENTSession;
                this.Response.Redirect("Encuesta/encNoEncuesta.aspx", false);

            }
        }


        // Eventos de la página

        protected void Page_Load(object sender, EventArgs e){
            ENTSession oENTSession = new ENTSession();

            try
            {

                // Validaciones
                if (this.IsPostBack) { return; }

                // Obtener sesión
                oENTSession = (ENTSession)Session["oENTSession"];

                // Canalizar al usuario a encuesta
                if( oENTSession.Encuesta.ResultadoEncuestaId != 0 ){
                    RedirectQuiz(oENTSession);
                    return;
                }

                // Canalizar al usuario por rol
                switch (oENTSession.RolId){
				    case 1: // System Administrator
					    break;

				    default:
					    break;
			    }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

    }
}