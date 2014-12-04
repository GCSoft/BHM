/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	PrivateTemplate
' Autor:    Ruben.Cobos
' Fecha:    21-Octubre-2013
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Referencias manuales
using BHM.Entity.Object;

namespace BHM.Web.Include.MasterPage
{
    public partial class QuizTemplate : System.Web.UI.MasterPage
    {
       
         // Eventos de la página

		protected void Page_Load(object sender, EventArgs e){		
			ENTSession oENTSession = new ENTSession();

			try
			{

                // Validaciones
                if (this.IsPostBack) { return; }

				// Nombre de usuario
				oENTSession = (ENTSession)this.Session["oENTSession"];
                this.lblUserName.Text = "Estimado " + oENTSession.Nombre + ", se le recuerda que esta encuesta es confidencial";

			}catch (Exception){
				// Do Nothing
			}
		}

    }
}