<%@ Page Title="Inicio de Sesion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="container">
    <h3 class="alert alert-light text-center">Inicio de sesion.</h3>
    <main class="mt-5">
        <h1 class="h3 mb-3 font-weight-normal text-center">Autentiquese antes de publicar algo en nuestro sitio </h1>
        <section class="w-25 m-auto">
            <table>
                <tr>
                    <td class="align-text-top">
                        <asp:TextBox BorderColor="Black" ToolTip="Introduzca el nombre de usuario" AutoCompleteType="DisplayName" ID="user" runat="server" CssClass=" form-control form-control-lg" placeholder="Usuario"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ValidationGroup="login" CssClass="text-danger" ID="userValidator" runat="server" EnableClientScript="true" ErrorMessage="Introduzca el nombre de usuario" ControlToValidate="user" /><br />
                    </td>
                </tr>
                <tr>
                    <td class="align-text-top">
                        <asp:TextBox BorderColor="Black" ToolTip="Introduzca su contraseña" ID="pass" TextMode="password" runat="server" CssClass="form-control form-control-lg" placeholder="Contraseña"></asp:TextBox>
                        &nbsp;
          <asp:RequiredFieldValidator ValidationGroup="login" EnableClientScript="true" ID="passValidator" CssClass="text-danger" runat="server" ErrorMessage="Introduzca su contraseña." ControlToValidate="pass" /><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ValidationGroup="login" runat="server" ID="Validation" CssClass="btn btn-lg btn-success pl-5 pr-5 w-100" Text="Entrar" OnClick="ValidateForm" /><br />
                        <asp:Label runat="server" ID="lblStatus" CssClass="text-danger mt-2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <span>¿Aun no tienes una cuenta creada?</span>
                        <a runat="server" href="~/Register.aspx" class="btn btn-lg btn-info pl-4 pr-4">Registrate ya !</a>
                    </td>
                </tr>   
                <tr>
                    <td>
                        <br />
                        <span>¿Perdiste tu contraseña?</span>
                        <a runat="server" href="~/Recovery.aspx" class="font-weight-bold text-dark pl-4 pr-4">Recuperar</a>
                    </td>
                </tr>   
            </table>
        </section>
    </main>
        </div>
</asp:Content>

