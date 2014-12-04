<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="encInvitacion.aspx.cs" Inherits="BHM.Web.Application.WebApp.Private.Encuesta.encInvitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">
    
    <asp:Panel ID="pnlTitulo" runat="server" CssClass="TitlePanel">
        <table class="HeaderTable">
            <tr>
                <td class="Titulo">Encuesta - Invitación</td>
            </tr>
            <tr>
                <td class="SubTitulo"><asp:Label ID="lblSubTitulo" runat="server" Text="Pantalla de gestión de invitaciones a usuarios para el llenado de encuestas."></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="FormPanel">
        <table class="FormTable">
            <tr>
				<td class="Etiqueta">Encuesta</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:DropDownList ID="ddlEncuesta" runat="server" CssClass="DropDownList_General" Width="216px"></asp:DropDownList></td>
                <td></td>
			</tr>
            <tr>
				<td class="Etiqueta">Usuario</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:DropDownList ID="ddlUsuario" runat="server" CssClass="DropDownList_General" Width="216px"></asp:DropDownList></td>
                <td></td>
			</tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlBotones" runat="server" CssClass="ButtonPanel">
        <asp:Button ID="btnInvitar" runat="server" Text="Enviar Invitación" CssClass="Button_General" Width="150px" OnClick="btnInvitar_Click" />
    </asp:Panel>

</asp:Content>
