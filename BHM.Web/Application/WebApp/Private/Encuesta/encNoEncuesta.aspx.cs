/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	encNoEncuesta
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
using GCUtility.Security;
using BHM.BusinessProcess.Page;
using BHM.Entity.Object;

namespace BHM.Web.Application.WebApp.Private.Encuesta
{
    public partial class encNoEncuesta : NonMenuPage
    {


        // Eventos de la página

        protected void Page_Load(object sender, EventArgs e){
            ENTSession oENTSession = new ENTSession();

            try
            {

                // Validaciones
                if (this.IsPostBack) { return; }

                // Mensajes por Default
                this.litEncabezado.Text = "Estimado Usuario, ha ocurrido un problema al querer acceder a la encuesta que solicitó, a continuación se detalla:";
                this.lblNotificacion.Text = "No tiene configurada una encuesta";

                // Obtener sesión
                oENTSession = (ENTSession)this.Session["oENTSession"];

                // Aviso
                this.litEncabezado.Text = "&nbsp;Estimado <b>" + oENTSession.Nombre + " </b>, ha ocurrido un problema al querer acceder a la encuesta que solicitó, a continuación se detalla:";
                this.lblNotificacion.Text = oENTSession.Encuesta.MensajeRecuperacion;

                // Resetear configuración de encuesta
                oENTSession.Encuesta = new ENTEncuesta();
                Session["oENTSession"] = oENTSession;

            }catch (Exception){
                // Do Nothing
            }
        }

        protected void lnkRegresar_Click(object sender, EventArgs e){
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "parent.parent.window.location.href = '../../../../Application/WebApp/Private/AppIndex.aspx';", true);
        }

    }
}