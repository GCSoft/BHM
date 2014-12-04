<%@ Page Title="" Language="C#" MasterPageFile="~/Include/MasterPage/QuizTemplate.Master" AutoEventWireup="true" CodeBehind="encEncuesta.aspx.cs" Inherits="BHM.Web.Application.WebApp.Private.Encuesta.encEncuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntQuizTemplateHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cntQuizTemplateBody" runat="server">
    
    <asp:Panel ID="pnlTitulo" runat="server" CssClass="TitlePanel">
        <table class="HeaderTable">
            <tr>
                <td class="Titulo"><asp:Label ID="lblTitulo" runat="server" Text="" ></asp:Label></td>
            </tr>
            <tr>
                <td class="SubTitulo"><asp:Label ID="lblSubTitulo" runat="server" Text="" ></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFormulario" runat="server" CssClass="FormPanel">
        <asp:Repeater ID="repPreguntas" runat="server" OnItemDataBound ="repPreguntas_ItemDataBound">
            <HeaderTemplate>
                <table class="FormTable">
                    <tr><td style="height:20px"></td></tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr>
				        <td style="text-align:center;">
                            <asp:HiddenField ID="EncuestaDetalleId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EncuestaDetalleId")%>' />
                            <asp:HiddenField ID="TipoControlId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TipoControlId")%>' />
                            <asp:HiddenField ID="Columnas" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Columnas")%>' />
                            <asp:HiddenField ID="PreguntaNumero" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "PreguntaNumero")%>' />
                            <asp:Label ID="lblPregunta" runat="server" CssClass="JustifyText" Font-Bold="True" ForeColor="#27245D" Font-Size="15px" Text='<%# DataBinder.Eval(Container.DataItem, "Pregunta") %>' Width="90%"></asp:Label>
				        </td>
			        </tr>
                    <tr>
				        <td style="text-align:center;">
                            <asp:TextBox ID="TextBox" runat="server" CssClass="Textarea_General" Width="90%"></asp:TextBox>
                            <span style="width:90%; display: inline-block;"><asp:CheckBoxList ID="CheckBoxList" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" CellSpacing="20"></asp:CheckBoxList></span>
                            <span style="width:90%; display: inline-block;"><asp:RadioButtonList ID="RadioButtonList" runat="server" CssClass="CheckBoxList_Regular" RepeatDirection="Horizontal" CellSpacing="20"></asp:RadioButtonList></span>
				        </td>
			        </tr>
                    <tr><td style="height:10px"></td></tr>
                </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <asp:Panel ID="pnlBotones" runat="server" CssClass="ButtonPanel">
         <table style="width:100%">
            <tr><td colspan="3"></td></tr>
            <tr>
                <td style="width:5%"></td>
                <td style="width:90%">
                    <table style="height:20px; vertical-align:top; width:100%;">
                        <tr>
                            <td style="text-align:left; width:33%">
                                <img id="imgPoweredBy" alt="GCSoft" runat="server" src="~/Include/Image/Web/GCSoft.png" />
                            </td>
                             <td style="text-align:center; width:33%">
                                <asp:Label ID="lblPaginado" runat="server" Font-Size="12px" Font-Bold="True" Text="" ></asp:Label>
                            </td>
                            <td style="text-align:right; width:34%">
                                <asp:Button ID="btnAnterior" runat="server" Text="Anterior" CssClass="Button_General" Width="125px" OnClick="btnAnterior_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="Button_General" Width="125px" OnClick="btnSiguiente_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:5%"></td>
			</tr>
             <tr><td colspan="3" style="height:20px"></td></tr>
        </table>
    </asp:Panel>

</asp:Content>
