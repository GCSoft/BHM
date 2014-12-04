/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	encTerminos
' Autor:	Ruben.Cobos
' Fecha:	21-Noviembre-2013
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
using BHM.BusinessProcess.Page;
using BHM.BusinessProcess.Object;
using BHM.Entity.Object;

namespace BHM.Web.Application.WebApp.Private.Encuesta
{
    public partial class encTerminos : NonMenuPage
    {


        // Utilerías
        GCJavascript gcJavascript = new GCJavascript();


        // Rutinas del programador

        void UpdateResultadoEncuesta_AceptarTerminos(){
            ENTSession oENTSession = new ENTSession();
            ENTResponse oENTResponse = new ENTResponse();

            BPEncuesta oBPEncuesta = new BPEncuesta();

            try
            {

                // Validaciones
                if (this.chkTerminos.Checked == false) { throw new Exception("No es posible iniciar la encuesta sin haber aceptado los términos"); }

                // Obtener sesión
                oENTSession = (ENTSession)this.Session["oENTSession"];

                // Transacción
                oENTResponse = oBPEncuesta.UpdateResultadoEncuesta_AceptarTerminos(oENTSession.Encuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { throw (new Exception(oENTResponse.MessageDB)); }

                // Mensaje de usuario
                this.Response.Redirect("encEncuesta.aspx", false);

            }catch (Exception ex){
                throw (ex);
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
                oENTSession = (ENTSession)this.Session["oENTSession"];

                // Aviso
                this.lblEncabezado.Text = "Estimado " + oENTSession.Nombre + ",";

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.chkTerminos.ClientID + "');", true);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e){
            try
            {

                UpdateResultadoEncuesta_AceptarTerminos();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.chkTerminos.ClientID + "');", true);
            }
        }

    }
}