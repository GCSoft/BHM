﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/PrivateTemplate.Master" AutoEventWireup="true" CodeBehind="sappChangePassword.aspx.cs" Inherits="BHM.Web.Application.WebApp.Private.SysApp.sappChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntPrivateTemplateHeader" runat="server">
    <script type="text/javascript">

        function validateNewPassword() {
            var txtPasswordAnterior = document.getElementById('cntPrivateTemplateBody_txtPasswordAnterior').value;
            var sNewPassword = document.getElementById('cntPrivateTemplateBody_txtNuevoPassword').value;
            var sNewPasswordConfirm = document.getElementById('cntPrivateTemplateBody_txtConfirmacionPassword').value;
            var oSpan = document.getElementById('spanMessage');

            var sTempOldPassword = txtPasswordAnterior.trim();
            var sTempNewPassword = sNewPassword.trim();
            var sTempNewPasswordConfirm = sNewPasswordConfirm.trim();


            // Espacios en blanco
            if (txtPasswordAnterior.length > 0 && sTempOldPassword.length == 0) {
                oSpan.innerHTML = 'No son permitidos los espacio en blanco';
                focusControl('cntPrivateTemplateBody_txtPasswordAnterior');
                return false;
            }

            if (sNewPassword.length > 0 && sTempNewPassword.length == 0) {
                oSpan.innerHTML = 'No son permitidos los espacio en blanco';
                focusControl('cntPrivateTemplateBody_txtNuevoPassword');
                return false;
            }

            if (sNewPasswordConfirm.length > 0 && sTempNewPasswordConfirm.length == 0) {
                oSpan.innerHTML = 'No son permitidos los espacio en blanco';
                focusControl('cntPrivateTemplateBody_txtConfirmacionPassword');
                return false;
            }

            // Campos vacíos
            if (txtPasswordAnterior == '') {
                oSpan.innerHTML = 'Contraseña anterior requerida';
                focusControl('cntPrivateTemplateBody_txtPasswordAnterior');
                return false;
            }

            if (sNewPassword == '') {
                oSpan.innerHTML = 'Nueva contraseña requerida';
                focusControl('cntPrivateTemplateBody_txtNuevoPassword');
                return false;
            }

            if (sNewPasswordConfirm == '') {
                oSpan.innerHTML = 'Confirmación de nueva contraseña requerida';
                focusControl('cntPrivateTemplateBody_txtConfirmacionPassword');
                return false;
            }

            // Contraseñas iguales
            if (txtPasswordAnterior == sNewPassword) {
                oSpan.innerHTML = 'Las contraseña anterior no puede ser igual a la nueva contraseña';
                focusControl('cntPrivateTemplateBody_txtNuevoPassword');
                return false;
            }

            if (sNewPassword != sNewPasswordConfirm) {
                oSpan.innerHTML = 'Las nueva contraseña no coincide con la confirmación';
                focusControl('cntPrivateTemplateBody_txtConfirmacionPassword');
                return false;
            }

            // Minimo 8 caracteres
            if (sNewPassword.length < 8) {
                oSpan.innerHTML = 'La nueva contraseña debe contener un mínimo de 8 caracteres';
                focusControl('cntPrivateTemplateBody_txtNuevoPassword');
                return false;
            }

            // Por lo menos un número
            if (/[0-9]+/.test(sNewPassword) == false) {
                oSpan.innerHTML = 'La nueva contraseña debe contener por lo menos un número';
                focusControl('cntPrivateTemplateBody_txtNuevoPassword');
                return false;
            }

            // Por lo menos una mayúscula
            if (/[A-Z]+/.test(sNewPassword) == false) {
                oSpan.innerHTML = 'La nueva contraseña debe contener por lo menos una letra mayúscula';
                focusControl('cntPrivateTemplateBody_txtNuevoPassword');
                return false;
            }

            oSpan.innerHTML = '';
            return true;
        }

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntPrivateTemplateBody" runat="server">

    <asp:Panel ID="pnlTitulo" runat="server" CssClass="TitlePanel">
        <table class="HeaderTable">
            <tr>
                <td class="Titulo">Sistema - Cambio de Contraseña</td>
            </tr>
            <tr>
                <td class="SubTitulo"><asp:Label ID="lblSubTitulo" runat="server" Text="Pantalla de cambio de contraseña. "></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="FormPanel">
        <table class="FormTable">
            <tr>
				<td class="Etiqueta">Contraseña Anterior</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:TextBox ID="txtPasswordAnterior" runat="server" CssClass="Textbox_General" TextMode="Password" ></asp:TextBox></td>
                <td></td>
			</tr>
            <tr>
				<td class="Etiqueta">Nueva Contraseña</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:TextBox ID="txtNuevoPassword" runat="server" CssClass="Textbox_General" TextMode="Password" ></asp:TextBox></td>
                <td></td>
			</tr>
            <tr>
				<td class="Etiqueta">Confirme Contraseña</td>
				<td class="Espacio"></td>
				<td class="Campo"><asp:TextBox ID="txtConfirmacionPassword" runat="server" CssClass="Textbox_General" TextMode="Password" ></asp:TextBox></td>
                <td></td>
			</tr>
            <tr>
                <td colspan="4" style="text-align:left;">
                    <span id="spanMessage" style="color:Red; font-family:Verdana; font-size:Smaller; display:block;">&nbsp;</span>
                </td>
			</tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlBotones" runat="server" CssClass="ButtonPanel">
        <asp:Button ID="btnActualizarPassword" runat="server" Text="Actualizar Contraseña" CssClass="Button_General" OnClick="btnActualizarPassword_Click" width="125px" />
    </asp:Panel>

    <asp:Panel ID="pnlNotificacion" runat="server" CssClass="NotificationPanel">
        * La nueva contraseña deberá tener un mínimo de 8 caracteres de los cuales por lo menos uno deberá ser numérico y por lo menos debe de contener una mayúscula. No deberá contener espacios en blanco.
    </asp:Panel>

    <asp:Panel ID="pnlFooter" runat="server" CssClass="FooterPanel">
        <%--Empty Content--%>
    </asp:Panel>

</asp:Content>
