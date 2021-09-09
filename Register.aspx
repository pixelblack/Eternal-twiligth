<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <main class="container">
    <h3 class="alert alert-light text-center">Registrese.</h3>
    <h1 class="h3 mb-3 font-weight-normal text-center">Introduzca sus datos en el formulario y obtendra una cuenta de inmediato. </h1>

    <section class="w-25 m-auto">
    <table>
         <tr>
           <td class="align-text-top">   
               <span>Nombre real</span>
               <asp:TextBox BorderColor="Black" ToolTip="Introduzca su nombre" AutoCompleteType="DisplayName" CssClass="form-control form-control-lg" ID="realName" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ValidationGroup="Register" CssClass="text-danger" runat="server" ErrorMessage="Introduzca su Nombre" EnableClientScript="true" ControlToValidate="realName"></asp:RequiredFieldValidator><br />
           </td>
        </tr>  <!-- nombre-->
         <tr>
           <td class="align-text-top">
               <span>Nombre de usuario. </span>
               <asp:TextBox BorderColor="Black" ToolTip="Introduzca su usuario" CssClass="form-control form-control-lg" ID="user" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ValidationGroup="Register" CssClass="text-danger" runat="server" ErrorMessage="Introduzca su nombre de usuario" EnableClientScript="true" ControlToValidate="user"></asp:RequiredFieldValidator>
               <br />

           </td>
        </tr>  <!-- usuario-->
         <tr>
           <td class="align-text-top mt-0 pt-0">
              <span>Direccion email. </span>
               <asp:TextBox BorderColor="Black" ToolTip="Introduzca su direccion E-mail" CssClass="form-control form-control-lg" ID="email" TextMode="Email" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator ValidationGroup="Register" runat="server" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" CssClass="text-danger" ControlToValidate="email" EnableClientScript="true" ErrorMessage="Direccion email incorrecta"></asp:RegularExpressionValidator>             
               <br />
           </td>
        </tr>  <!-- email-->
         <tr>
           <td class="align-text-top">
              <span>Contraseña. </span>
               <asp:TextBox BorderColor="Black" ToolTip="Defina una contraseña" CssClass="form-control form-control-lg" ID="pass" TextMode="Password" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ValidationGroup="Register" CssClass="text-danger" runat="server" EnableClientScript="true" ErrorMessage="Introduzca su contraseña" ControlToValidate="pass"></asp:RequiredFieldValidator><br />
           </td>
        </tr>  <!-- contrasenia-->    
         <tr>
           <td class="align-text-top">
              <span>Confirme su contraseña. </span>
               <asp:TextBox BorderColor="Black" ToolTip="Confirme su contraseña" CssClass="form-control mb-0 pb-0 form-control-lg" ID="passRpt" TextMode="Password" runat="server"></asp:TextBox>
               <asp:CompareValidator ValidationGroup="Register" CssClass="text-danger" runat="server" ErrorMessage="Las Contraseñas deben coincidir" ControlToCompare="pass" ControlToValidate="passRpt" EnableClientScript="true"></asp:CompareValidator>
           </td>
        </tr>  <!-- rpt contrasenia-->
         <tr>
           <td class="align-text-top">
               <span>Captcha. </span>
               <asp:Image runat="server" ImageUrl="~/RegistryCaptcha.aspx" CssClass="card-img mb-1"/>
               <span>Introduzca el Captcha. </span>
               <asp:TextBox BorderColor="Black" ToolTip="Texto del Captcha" CssClass="form-control form-control-lg" ID="captcha" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ValidationGroup="Register" ID="captchaFV" CssClass="text-danger" runat="server" ErrorMessage="Introduzca el texto del captcha" EnableClientScript="true" ControlToValidate="captcha"></asp:RequiredFieldValidator>
               <br />

           </td>
        </tr>  <!-- captcha-->
         <tr>
           <td class="align-text-top">
              <span>Sexo. </span>
               <asp:DropDownList BorderColor="Black" CssClass="dropdown form-control form-control-lg" ID="gender" runat="server">
                   <asp:ListItem Selected="True">---</asp:ListItem>
                   <asp:ListItem>Masculino</asp:ListItem>
                   <asp:ListItem>Femenino</asp:ListItem>               
               </asp:DropDownList>  
           </td>
        </tr>  <!-- genero-->         
         <tr>
           <td>
               <asp:Label runat="server" ID="lblStatus" CssClass="text-danger"></asp:Label><br />
              <asp:Button ValidationGroup="Register" runat="server" ID="Validation" CssClass="btn btn-info pl-5 pr-5 " Text="Registarse"/>
           </td>
        </tr>  <!-- estatus y btn validacion-->
         
    </table>         
    </section>

    </main>
</asp:Content>

