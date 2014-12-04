<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/NonMenuTemplate.Master" AutoEventWireup="true" CodeBehind="encTerminos.aspx.cs" Inherits="BHM.Web.Application.WebApp.Private.Encuesta.encTerminos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntNonMenuTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntNonMenuTemplateBody" runat="server">

    <asp:Panel ID="pnlTitulo" runat="server" CssClass="TitlePanel">
        <table class="HeaderTable">
            <tr style="height:50px;">
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="FormPanel">
        <table class="FormTable">
            <tr>
				<td class="Espacio"></td>
                <td><asp:Label ID="lblEncabezado" runat="server" Font-Size="15px" Font-Bold="True"></asp:Label></td>
			</tr>
            <tr><td colspan="2" style="height:20px"></td></tr>
            <tr>
				<td colspan="2" style="text-align:center;">
                    <asp:Label ID="lblNotificacion" runat="server" CssClass="JustifyText" Font-Size="15px" Font-Bold="True" Text="Considerando a la honestidad como uno de los principales valores que tenemos como seres humanos y como organización, ponemos a su disposición la oportunidad de expresar sus inquietudes y de dar a conocer la percepción que usted tiene, sobre algunos factores que pueden ayudar a mejorar el funcionamiento de la empresa." Width="90%"></asp:Label>
				</td>
			</tr>
            <tr><td colspan="2" style="height:20px"></td></tr>
            <tr>
				<td colspan="2" style="text-align:center;">
                    <asp:Label ID="lblWarning" runat="server" CssClass="JustifyText" Font-Size="15px" Font-Bold="True" ForeColor="Red" Text="Esta encuesta es confidencial" Width="90%"></asp:Label>
                </td>
			</tr>
            <tr><td colspan="2" style="height:20px"></td></tr>
            <tr>
                <td class="Espacio"></td>
                <td><asp:CheckBox ID="chkTerminos" runat="server" Font-Size="15px" Font-Bold="True" Text="He leído y entiendo los términos de esta encuesta"/></td>
			</tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlBotones" runat="server" CssClass="ButtonPanel">
         <table style="width:100%">
            <tr><td colspan="3" style="height:40px"></td></tr>
            <tr>
                <td style="width:5%"></td>
                <td style="text-align:right; width:90%">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="Button_General" Width="125px" OnClick="btnAceptar_Click" />
                </td>
                <td style="width:5%"></td>
			</tr>
        </table>
    </asp:Panel>
    
</asp:Content>
