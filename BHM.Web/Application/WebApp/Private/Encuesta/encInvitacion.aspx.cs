/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	encInvitacion
' Autor:	Ruben.Cobos
' Fecha:	19-Noviembre-2014
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
using System.Data;

namespace BHM.Web.Application.WebApp.Private.Encuesta
{
    public partial class encInvitacion : BPPage
    {


        // Utilerías
        GCCommon gcCommon = new GCCommon();
        GCEncryption gcEncryption = new GCEncryption();
        GCJavascript gcJavascript = new GCJavascript();


        // Rutinas del programador

        void InsertResultadoEncuesta(){
            ENTEncuesta oENTEncuesta = new ENTEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            BPEncuesta oBPEncuesta = new BPEncuesta();

            try
            {

                // Validaciones
                if (this.ddlEncuesta.SelectedIndex == 0) { throw new Exception("* El campo [Encuesta] es requerido"); }
                if (this.ddlUsuario.SelectedIndex == 0) { throw new Exception("* El campo [Usuario] es requerido"); }

                // Formulario
                oENTEncuesta.EncuestaId = Int32.Parse(this.ddlEncuesta.SelectedItem.Value);
                oENTEncuesta.UsuarioId = Int32.Parse(this.ddlUsuario.SelectedItem.Value);

                // Transacción
                oENTResponse = oBPEncuesta.InsertResultadoEncuesta(oENTEncuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { throw (new Exception(oENTResponse.MessageDB)); }

                // Transacción exitosa
                this.ddlEncuesta.SelectedIndex = 0;
                this.ddlUsuario.SelectedIndex = 0;

                // Mensaje de usuario
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('Invitación enviada con éxito!'); focusControl('" + this.ddlEncuesta.ClientID + "');", true);

            }catch (Exception ex){
                throw (ex);
            }
        }

        void SelectEncuesta(){
            ENTEncuesta oENTEncuesta = new ENTEncuesta();
            ENTResponse oENTResponse = new ENTResponse();

            BPEncuesta oBPEncuesta = new BPEncuesta();
            String MessageDB = "";

            try
            {

                // Formulario
                oENTEncuesta.EncuestaId = 0; // Todas
                oENTEncuesta.Nombre = "";
                oENTEncuesta.Activo = 1;

                // Transacción
                oENTResponse = oBPEncuesta.SelectEncuesta(oENTEncuesta);

                // Mensajes y Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { MessageDB = "alert('" + gcJavascript.ClearText(oENTResponse.MessageDB) + "');"; }

                // Llenado de combo
                this.ddlEncuesta.DataTextField = "Nombre";
                this.ddlEncuesta.DataValueField = "EncuestaId";
                this.ddlEncuesta.DataSource = oENTResponse.DataSetResponse.Tables[1];
                this.ddlEncuesta.DataBind();

                // Agregar Item de selección
                this.ddlEncuesta.Items.Insert(0, new ListItem("[Seleccione]", "0"));

            }catch (Exception ex){
                throw (ex);
            }
        }

        void SelectUsuario(){
            ENTUsuario oENTUsuario = new ENTUsuario();
            ENTResponse oENTResponse = new ENTResponse();

            BPUsuario oBPUsuario = new BPUsuario();
            String MessageDB = "";

            try
            {

                // Formulario
                oENTUsuario.RolId = 0;
                oENTUsuario.UsuarioId = 0;
                oENTUsuario.Email = "";
                oENTUsuario.Nombre = "";
                oENTUsuario.Activo = 1;

                // Transacción
                oENTResponse = oBPUsuario.SelectUsuario(oENTUsuario);

                // Mensajes y Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { MessageDB = "alert('" + gcJavascript.ClearText(oENTResponse.MessageDB) + "');"; }

                // Llenado de combo
                this.ddlUsuario.DataTextField = "NombreCompleto";
                this.ddlUsuario.DataValueField = "UsuarioId";
                this.ddlUsuario.DataSource = oENTResponse.DataSetResponse.Tables[1];
                this.ddlUsuario.DataBind();

                // Agregar Item de selección
                this.ddlUsuario.Items.Insert(0, new ListItem("[Seleccione]", "0"));

            }catch (Exception ex){
                throw (ex);
            }
        }



        // Eventos de la página

        protected void Page_Load(object sender, EventArgs e){
            try
            {

                // Validaciones
                if (this.IsPostBack) { return; }

                // Llenado de controles
                SelectEncuesta();
                SelectUsuario();

                // Foco
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "focusControl('" + this.ddlEncuesta.ClientID + "');", true);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlEncuesta.ClientID + "');", true);
            }
        }

        protected void btnInvitar_Click(object sender, EventArgs e){
            try
            {

                InsertResultadoEncuesta();

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "'); focusControl('" + this.ddlEncuesta.ClientID + "');", true);
            }
        }


    }
}