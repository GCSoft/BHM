/*---------------------------------------------------------------------------------------------------------------------------------
' Nombre:	encEncuesta
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
using System.Data;

namespace BHM.Web.Application.WebApp.Private.Encuesta
{
    public partial class encEncuesta : NonMenuPage
    {

        // Utilerías
        GCJavascript gcJavascript = new GCJavascript();


        
        // Funciones del programador

        DataTable SelectEncuestaDetalleOpcion(Int32 EncuestaDetalleId){
            ENTEncuesta oENTEncuesta = new ENTEncuesta();
            ENTResponse oENTResponse = new ENTResponse();
            BPEncuesta oBPEncuesta = new BPEncuesta();

            try
            {

                // Formulario
                oENTEncuesta.EncuestaDetalleId = EncuestaDetalleId;
                oENTEncuesta.RespuestaDetalle = "";
                oENTEncuesta.Activo = 1;

                // Transacción
                oENTResponse = oBPEncuesta.SelectEncuestaDetalleOpcion(oENTEncuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.MessageDB) + "');", true); }

            }catch (Exception ex){
                throw(ex);
            }

            return oENTResponse.DataSetResponse.Tables[1];
        }

        DataTable SelectResultadoEncuestaDetalle(Int32 EncuestaDetalleId){
            ENTSession oENTSession = new ENTSession();
            ENTEncuesta oENTEncuesta = new ENTEncuesta();
            ENTResponse oENTResponse = new ENTResponse();
            BPEncuesta oBPEncuesta = new BPEncuesta();

            try
            {

                // Obtener sesión
                oENTSession = (ENTSession)Session["oENTSession"];

                // Formulario
                oENTEncuesta.EncuestaDetalleId = EncuestaDetalleId;
                oENTEncuesta.ResultadoEncuestaId = oENTSession.Encuesta.ResultadoEncuestaId;

                // Transacción
                oENTResponse = oBPEncuesta.SelectResultadoEncuestaDetalle(oENTEncuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(oENTResponse.MessageDB) + "');", true); }

            }catch (Exception ex){
                throw(ex);
            }

            return oENTResponse.DataSetResponse.Tables[1];
        }

        DataTable ValidateForm(){
            TextBox TextBox;
            CheckBoxList CheckBoxList;
            RadioButtonList RadioButtonList;

            HiddenField EncuestaDetalleId;
            HiddenField PreguntaNumero;
            HiddenField TipoControlId;
            Label LabelPregunta;

            DataTable tblResultadoEncuesta;
            DataRow rowResultado;

            String ItemsSelected = "";

            try
            {

                // Inicializar variable de respuestas
                tblResultadoEncuesta = new DataTable("tblResultadoEncuesta");
                tblResultadoEncuesta.Columns.Add("EncuestaDetalleId", typeof(Int32));
                tblResultadoEncuesta.Columns.Add("Resultado", typeof(String));

                 // Validaciones
                foreach (RepeaterItem repItem in repPreguntas.Items){

                    EncuestaDetalleId = (HiddenField)repItem.FindControl("EncuestaDetalleId");
                    PreguntaNumero = (HiddenField)repItem.FindControl("PreguntaNumero");
                    TipoControlId = (HiddenField)repItem.FindControl("TipoControlId");
                    LabelPregunta = (Label)repItem.FindControl("lblPregunta");

                    switch( TipoControlId.Value.Trim() ){
                        case "1": // TextBox

                            TextBox = (TextBox)repItem.FindControl("TextBox");
                            if( TextBox.Text.Trim() == "" ) {
                                LabelPregunta.ForeColor = System.Drawing.Color.Red;
                                throw( new Exception("La pregunta " + PreguntaNumero.Value.Trim() + " no ha sido contestada" ) );
                            }

                            LabelPregunta.ForeColor = System.Drawing.ColorTranslator.FromHtml("#27245D");

                            rowResultado = tblResultadoEncuesta.NewRow();
                            rowResultado["EncuestaDetalleId"] = EncuestaDetalleId.Value.Trim();
                            rowResultado["Resultado"] = TextBox.Text.Trim();
                            tblResultadoEncuesta.Rows.Add(rowResultado);

                            break;

                        case "2": // Option

                            RadioButtonList = (RadioButtonList)repItem.FindControl("RadioButtonList");
                            ItemsSelected = "";

                            for (int k = 0; k < RadioButtonList.Items.Count; k++ ) {

					            if( RadioButtonList.Items[k].Selected ){

                                    ItemsSelected = ItemsSelected + ( ItemsSelected == "" ? "," + RadioButtonList.Items[k].Value.Trim() + "," : RadioButtonList.Items[k].Value.Trim() + "," );
					            }
				            }

                            if ( ItemsSelected == "" ) {
                                LabelPregunta.ForeColor = System.Drawing.Color.Red;
                                throw (new Exception("La pregunta " + PreguntaNumero.Value.Trim() + " no ha sido contestada"));
                            }

                            LabelPregunta.ForeColor = System.Drawing.ColorTranslator.FromHtml("#27245D");

                            rowResultado = tblResultadoEncuesta.NewRow();
                            rowResultado["EncuestaDetalleId"] = EncuestaDetalleId.Value.Trim();
                            rowResultado["Resultado"] = ItemsSelected;
                            tblResultadoEncuesta.Rows.Add(rowResultado);

                            break;

                        case "3": // Check

                            CheckBoxList = (CheckBoxList)repItem.FindControl("CheckBoxList");
                            ItemsSelected = "";

                            for (int k = 0; k < CheckBoxList.Items.Count; k++ ) {

					            if( CheckBoxList.Items[k].Selected ){

                                    ItemsSelected = ItemsSelected + ( ItemsSelected == "" ? "," + CheckBoxList.Items[k].Value.Trim() + "," : CheckBoxList.Items[k].Value.Trim() + "," );
					            }
				            }

                            if ( ItemsSelected == "" ) {
                                LabelPregunta.ForeColor = System.Drawing.Color.Red;
                                throw (new Exception("La pregunta " + PreguntaNumero.Value.Trim() + " no ha sido contestada")); 
                            }

                            LabelPregunta.ForeColor = System.Drawing.ColorTranslator.FromHtml("#27245D");

                            rowResultado = tblResultadoEncuesta.NewRow();
                            rowResultado["EncuestaDetalleId"] = EncuestaDetalleId.Value.Trim();
                            rowResultado["Resultado"] = ItemsSelected;
                            tblResultadoEncuesta.Rows.Add(rowResultado);

                            break;

                        default:

                            throw( new Exception( "No se ha configurado bien el set de respuestas en la pregunta " + PreguntaNumero.Value.Trim() ) );
                    }

                    
                }

            }catch (Exception ex){
                throw(ex);
            }

            return tblResultadoEncuesta;
        }


        // Rutinas del programador

        void ConfigurarEncuesta(ENTSession oENTSession){
            try
            {

                if( oENTSession.Encuesta.PaginaActual == 1 ){

                    this.lblSubTitulo.Text = oENTSession.Encuesta.Entrada;
                    this.btnAnterior.Enabled = false;
                    this.btnAnterior.CssClass = "Button_General_Disabled";
                }else{

                    this.lblSubTitulo.Text = "";
                    this.btnAnterior.Enabled = true;
                    this.btnAnterior.CssClass = "Button_General";
                }

                if( oENTSession.Encuesta.SoloAvanzar == 1 ){

                    this.btnAnterior.Enabled = false;
                    this.btnAnterior.CssClass = "Button_General_Disabled";
                }

                if( oENTSession.Encuesta.Paginas == oENTSession.Encuesta.PaginaActual ){

                    this.btnSiguiente.Text = "Finalizar";
                 }else{

                     this.btnSiguiente.Text = "Siguiente";
                }

                this.lblPaginado.Text = "Página " + oENTSession.Encuesta.PaginaActual.ToString() + " de " + oENTSession.Encuesta.Paginas.ToString();

            }catch (Exception ex){
                throw(ex);
            }
        }

        void SelectEncuestaDetalle(ENTSession oENTSession){
            ENTResponse oENTResponse = new ENTResponse();
            BPEncuesta oBPEncuesta = new BPEncuesta();

            try
            {

                // Transacción
                oENTResponse = oBPEncuesta.SelectEncuestaDetalle(oENTSession.Encuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { throw (new Exception(oENTResponse.MessageDB)); }

                // Vaciado de formulario
                this.lblTitulo.Text = oENTResponse.DataSetResponse.Tables[1].Rows[0]["Nombre"].ToString();

                if (oENTResponse.DataSetResponse.Tables[1].Rows[0]["Descripcion"].ToString() != "") {
                    this.lblSubTitulo.Text = this.lblSubTitulo.Text + (this.lblSubTitulo.Text == "" ? "" : "<br /><br />") + oENTResponse.DataSetResponse.Tables[1].Rows[0]["Descripcion"].ToString();
                }

                this.repPreguntas.DataSource = oENTResponse.DataSetResponse.Tables[3];
                this.repPreguntas.DataBind();

            }catch (Exception ex){
                throw(ex);
            }
        }

        void UpdateResultadoEncuestaDetalle(ENTSession oENTSession){
            ENTResponse oENTResponse = new ENTResponse();
            BPEncuesta oBPEncuesta = new BPEncuesta();

            try
            {

                 // Validaciones
                oENTSession.Encuesta.DataTableResultadoEncuesta = ValidateForm();

                // Transacción
                oENTResponse = oBPEncuesta.UpdateResultadoEncuestaDetalle(oENTSession.Encuesta);

                // Validaciones
                if (oENTResponse.GeneratesException) { throw (new Exception(oENTResponse.MessageError)); }
                if (oENTResponse.MessageDB != "") { throw (new Exception(oENTResponse.MessageDB)); }

                // Limpiar tabla de resultado
                oENTSession.Encuesta.DataTableResultadoEncuesta = null;

            }catch (Exception ex){
                throw(ex);
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

                // Validaciones
                if( oENTSession.Encuesta.ResultadoEncuestaId == 0 ){
                    this.Response.Redirect("encNoEncuesta.aspx", false);
                    return;
                }

                // Configuración de encuesta
                ConfigurarEncuesta(oENTSession);
                SelectEncuestaDetalle(oENTSession);

            }catch (Exception ex){
                this.btnAnterior.Enabled = false;
                this.btnSiguiente.Enabled = false;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e){
            ENTSession oENTSession = new ENTSession();

            try
            {

                // Obtener sesión
                oENTSession = (ENTSession)Session["oENTSession"];

                // Decrementar la página
                oENTSession.Encuesta.PaginaActual = oENTSession.Encuesta.PaginaActual - 1;

                // Canalizar
                this.Response.Redirect("encEncuesta.aspx", false);

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e){
            ENTSession oENTSession = new ENTSession();

            try
            {

                // Obtener sesión
                oENTSession = (ENTSession)Session["oENTSession"];

                // Guardar/Actualizar la pagina actual
                UpdateResultadoEncuestaDetalle(oENTSession);

                // Canalizar
                if( oENTSession.Encuesta.Paginas == oENTSession.Encuesta.PaginaActual ){

                    oENTSession.Encuesta = new ENTEncuesta();
                    this.Response.Redirect("../AppIndex.aspx", false);
                }else{

                    UpdateResultadoEncuestaDetalle(oENTSession);
                    oENTSession.Encuesta.PaginaActual = oENTSession.Encuesta.PaginaActual + 1;
                    this.Response.Redirect("encEncuesta.aspx", false);
                }

            }catch (Exception ex){
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Convert.ToString(Guid.NewGuid()), "alert('" + gcJavascript.ClearText(ex.Message) + "');", true);
            }
        }

        protected void repPreguntas_ItemDataBound(Object sender, RepeaterItemEventArgs e){
            TextBox TextBox;
            CheckBoxList CheckBoxList;
            RadioButtonList RadioButtonList;

            DataTable tblOpciones;
            DataTable tblRespuestas;
            DataRowView DataRow;

            String EncuestaDetalleId;
            String TipoControlId;
            String Columnas;

            try
            {

                // Validación de que sea Item 
                if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) { return; }

                // Obtener controles
                TextBox = (TextBox)e.Item.FindControl("TextBox");
                CheckBoxList = (CheckBoxList)e.Item.FindControl("CheckBoxList");
                RadioButtonList = (RadioButtonList)e.Item.FindControl("RadioButtonList");

                DataRow = (DataRowView)e.Item.DataItem;

                // Obtener información del registro
                EncuestaDetalleId = DataRow["EncuestaDetalleId"].ToString();
                TipoControlId = DataRow["TipoControlId"].ToString();
                Columnas = DataRow["Columnas"].ToString();
                
                // Mostrar el control correspondiente
                switch( TipoControlId ){
                    case "1": // TextBox

                        CheckBoxList.Visible = false;
                        RadioButtonList.Visible = false;

                        tblRespuestas = SelectResultadoEncuestaDetalle(Int32.Parse(EncuestaDetalleId));
                        TextBox.Text = tblRespuestas.Rows[0]["Resultado"].ToString().Trim();;

                        break;

                    case "2": // Option

                        TextBox.Visible = false;
                        CheckBoxList.Visible = false;

                        tblOpciones = SelectEncuestaDetalleOpcion(Int32.Parse(EncuestaDetalleId));
                        RadioButtonList.RepeatColumns = Int32.Parse(Columnas);
                        RadioButtonList.DataTextField = "RespuestaDetalle";
                        RadioButtonList.DataValueField = "EncuestaDetalleOpcionId";
                        RadioButtonList.DataSource = tblOpciones;
                        RadioButtonList.DataBind();

                        tblRespuestas = SelectResultadoEncuestaDetalle(Int32.Parse(EncuestaDetalleId));
                        for (int k = 0; k < RadioButtonList.Items.Count; k++ ) {

                            if (tblRespuestas.Select("EncuestaDetalleOpcionId=" + RadioButtonList.Items[k].Value.Trim()).Length > 0){
                                RadioButtonList.Items[k].Selected = true;
                            }
                        }

                        break;

                    case "3": // Check

                        TextBox.Visible = false;
                        RadioButtonList.Visible = false;

                        tblOpciones = SelectEncuestaDetalleOpcion(Int32.Parse(EncuestaDetalleId));
                        CheckBoxList.RepeatColumns = Int32.Parse(Columnas);
                        CheckBoxList.DataTextField = "RespuestaDetalle";
                        CheckBoxList.DataValueField = "EncuestaDetalleOpcionId";
                        CheckBoxList.DataSource = tblOpciones;
                        CheckBoxList.DataBind();

                        tblRespuestas = SelectResultadoEncuestaDetalle(Int32.Parse(EncuestaDetalleId));
                        for (int k = 0; k < CheckBoxList.Items.Count; k++ ) {

                            if (tblRespuestas.Select("EncuestaDetalleOpcionId=" + CheckBoxList.Items[k].Value.Trim()).Length > 0){
                                CheckBoxList.Items[k].Selected = true;
                            }
                        }

                        break;

                    default:

                        TextBox.Visible = false;
                        CheckBoxList.Visible = false;
                        RadioButtonList.Visible = false;
                        break;
                }

            }catch (Exception ex){
                throw (ex);
            }
        }

    }
}