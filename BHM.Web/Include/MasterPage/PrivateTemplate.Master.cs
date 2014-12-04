/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	PrivateTemplate
' Autor:    Ruben.Cobos
' Fecha:    21-Octubre-2013
'
' Descripción:
'           MasterPage de las pantallas de trabajo en la sección Privada de la aplicación
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
    public partial class PrivateTemplate : System.Web.UI.MasterPage
    {

        
        // Eventos de la página

		protected void Page_Load(object sender, EventArgs e){		
			ENTSession oENTSession = new ENTSession();

			try
			{

                // Validaciones
                if (this.IsPostBack) { return; }

				// Imagen de Exit
				this.imgExit.Attributes.Add("onmouseover", "src='../../../../Include/Image/Web/SalirOn.png'");
				this.imgExit.Attributes.Add("onmouseout", "src='../../../../Include/Image/Web/SalirOff.png'");

				// Nombre de usuario
				oENTSession = (ENTSession)this.Session["oENTSession"];
				this.lblUserName.Text = "Bienvenido: " + oENTSession.Nombre + " | ";

			}catch (Exception){
				// Do Nothing
			}
		}

		protected void imgExit_Click(object sender, ImageClickEventArgs e){
            this.Response.Redirect("~/Application/WebApp/Private/SysApp/sappLogout.aspx");
		}


    }
}