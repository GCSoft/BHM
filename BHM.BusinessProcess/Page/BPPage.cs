﻿/*---------------------------------------------------------------------------------------------------------------------------------
' Clase: BusinessProcess.Page
' Autor: Ruben.Cobos
' Fecha: 21-Octubre-2013
'
' Proposito:
'       Sobreescritura del método Page_PreLoad la cual se utilizará como clase padre de las paginas del proyecto que se visualizan
'       en el menú, implementa la seguridad de la aplicación.
'
' Errores:
'   V01:  Error general del método Overload_PageLoad
'   V02:  El usuario no tiene permisos de acceder a esta página
'   V03:  Intento de acceso como [System Administrator]
'----------------------------------------------------------------------------------------------------------------------------------*/

// Referencias
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Referencias manuales
using GCUtility.Security;
using BHM.Entity.Object;
using BHM.DataAccess.Object;
using System.Configuration;

namespace BHM.BusinessProcess.Page
{
    public class BPPage : System.Web.UI.Page
    {

        // Asignación de evento PreLoad

        override protected void OnInit(EventArgs e){
            this.PreLoad += new System.EventHandler(this.Override_PagePreLoad);
        }


        // Evento PreLoad

        protected void Override_PagePreLoad(object sender, EventArgs e){
            ENTSession oENTSession;

            GCEncryption gcEncryption = new GCEncryption();

            String sKey = "";
            String sPage = "";

            // Validación. Solo la primera vez que entre a la página
            if (this.IsPostBack) { return; }

            // Mensaje de error general
            sKey = gcEncryption.EncryptString("[V01] Acceso denegado", true);

            // Sesión
            if (this.Session["oENTSession"] == null) { this.Response.Redirect("~/Index.aspx", true); }

            // Información de Sesión
            oENTSession = (ENTSession)this.Session["oENTSession"];

            // Token generado
            if (!oENTSession.TokenGenerado){ this.Response.Redirect("~/Index.aspx", true); }

            // Página que esta visitando
            sPage = this.Request.Url.AbsolutePath;
            sPage = sPage.Split(new Char[] { '/' })[sPage.Split(new Char[] { '/' }).Length - 1];

            // Validación de permisos en la página actual
            if (oENTSession.DataTableSubMenu.Select("ASPX = '" + sPage + "'").Length < 1){
                sKey = gcEncryption.EncryptString("[V02] No tiene permisos para acceder a esta página", true);
                this.Response.Redirect("~/Application/WebApp/Private/SysApp/sappNotificacion.aspx?key=" + sKey, true);
            }

            // Validación de acceso a opciones [System Administrator]
            if ((sPage == "scatMenu.aspx" || sPage == "scatSubMenu.aspx") && (oENTSession.RolId != 1)){

                sKey = gcEncryption.EncryptString("[V03] No tiene permisos para acceder a esta página", true);
                this.Response.Redirect("~/Application/WebApp/Private/SysApp/sappNotificacion.aspx?key=" + sKey, true);
            }

            // Deshabilitar caché
            this.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        }

    }
}