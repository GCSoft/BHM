<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMenu.ascx.cs" Inherits="BHM.Web.Include.WebUserControls.wucMenu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<table style="width:250px">
	<tr>
		<td>
			<asp:Accordion ID="acrdMenu" runat="server"
                AutoSize="None"
                ContentCssClass="AccordionContent"
                EnableViewState="true"
                FadeTransitions="false"
                FramesPerSecond="40"
                HeaderCssClass="AccordionHeader"
                HeaderSelectedCssClass="AccordionHeaderSelected"
                RequireOpenedPane="false"
                SuppressHeaderPostbacks="true"
                TransitionDuration="250">
			</asp:Accordion>					         
		</td>
	</tr>
</table>