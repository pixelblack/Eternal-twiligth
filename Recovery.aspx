<%@ Page Title="Recuperador de contraseña" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Recovery.aspx.cs" Inherits="Recovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <main class="container">
    <h3 class="alert alert-light text-dark text-center">Recuperar contraseña</h3>

    <section class="w-25 m-auto">
        <table>
            <tr>
                <td class="align-text-top">
                    <span>Direccion de correo</span>
                    <asp:TextBox BorderColor="Black" ToolTip="Introduzca el correo" AutoCompleteType="Email" ID="correo" CssClass="form-control" runat="server"/>
                    &nbsp;
                    <asp:RequiredFieldValidator ValidationGroup="recovery" ID="correoFieldValidator" EnableClientScript="true" ControlToValidate="correo" runat="server" ErrorMessage="Introduzca su correo" CssClass="text-danger" />
                    <asp:RegularExpressionValidator ValidationGroup="recovery" ID="correoRegexValidator" EnableClientScript="true" ControlToValidate="correo" runat="server" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ErrorMessage="Correo invalido" CssClass="text-danger" /><br />
                </td>
            </tr>
            <tr>
                <td class="align-text-top">
                    <span>Expresion: </span>
                    <asp:Label ID="lblCaptcha" runat="server" Text="lol"></asp:Label>
                    <asp:TextBox BorderColor="Black" ToolTip="Introduzca el resultado de la expresion en digitos" AutoCompleteType="Email" ID="simplyCaptcha" CssClass="form-control" runat="server"/>
                    <small class="form-text">Introduzca en <span class=" font-weight-bold">digitos</span> el resultado de la expresion superior</small>
                    <asp:RequiredFieldValidator ValidationGroup="recovery" ID="simplyCaptchaFieldValidator" ControlToValidate="simplyCaptcha" EnableClientScript="true" CssClass="text-danger" runat="server" ErrorMessage="Introduzca correctamente el resultado"/>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <span>Crear una nueva contraseña</span>
                    <asp:Button ValidationGroup="recovery" ID="validate" OnClick="ValidateAndCreateNewPass" runat="server" CssClass="btn btn-secondary pl-4 pr-4" Text="Crear nueva contraseña"/>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label runat="server" ID="resumen" Visible="false"
                        Text="A su correo le llegara un mensaje con la nueva contraseña segura que se le ha generado.</br>
                        Inicie sesion con sus nuevas credenciales y luego cambielas desde las opciones."/>                   
                </td>
            </tr>
        </table>
    </section>
    </main>
</asp:Content>

