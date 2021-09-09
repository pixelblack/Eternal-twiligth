<%@ Page Title="Administracion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Crud.aspx.cs" Inherits="Crud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HEAD" runat="Server">
    <style>
        #BODY_Grid tr:first-child td {
            font-weight: 700;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BODY" runat="Server">
    <main class="container">
    <h1 class="text-center">Pagina de administracion </h1>
    <h2 class="mt-5 ">Gestion de Usuarios</h2>
    <br />

    <asp:GridView ID="Grid" CssClass="table table-borderless border-0 small" DataSourceID="datasource" runat="server" AllowPaging="True" PagerSettings-Position="Bottom" PagerSettings-Mode="NextPreviousFirstLast" PageSize="21" AutoGenerateColumns="False" DataKeyNames="id" SelectedRowStyle-BackColor="LightGray">
        <Columns>
            <asp:ButtonField CommandName="Select" ControlStyle-CssClass="btn btn-primary btn-sm fa fa-check" HeaderText="Seleccion" CausesValidation="false" />

            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="realName" HeaderText="Nombre" SortExpression="realName" />
            <asp:BoundField DataField="userName" HeaderText="Usuario" SortExpression="userName" />
            <asp:BoundField DataField="password" HeaderText="Contraseña" SortExpression="password" />
            <asp:BoundField DataField="email" HeaderText="Correo" SortExpression="email" />
            <asp:BoundField DataField="gender" HeaderText="Genero" SortExpression="gender" />

            <asp:CommandField EditText="Editar" UpdateText="Aceptar" CancelText="Cancelar" HeaderText="Editar" ControlStyle-CssClass="btn btn-success btn-sm" ShowEditButton="True" />
            <asp:ButtonField HeaderText="Eliminar" ControlStyle-CssClass="btn btn-danger fa fa-trash-o" CommandName="Delete" CausesValidation="false" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="datasource" ConnectionString="<%$ ConnectionStrings:DataBase %>" SelectCommand="SELECT [id], [realName], [userName], [password], [email], [gender] FROM [users]" DeleteCommand="DELETE FROM users WHERE (id = @id)" InsertCommand="INSERT INTO users(realName, userName, password, email, gender) VALUES (@realName, @userName, @password, @email, @gender)" UpdateCommand="UPDATE users SET realName = @realName, userName = @userName, password = @password, email = @email, gender = @gender WHERE (id = @id)">
        <DeleteParameters>
            <asp:ControlParameter ControlID="Grid" Name="id" PropertyName="SelectedDataKey" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="realName" Type="String" />
            <asp:Parameter Name="userName" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="gender" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="realName" Type="String" />
            <asp:Parameter Name="userName" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="gender" Type="String" />
            <asp:Parameter Name="id" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <h2 class="mt-5">Registrar Usuario</h2>
    <table class="table table-borderless small mt-3 ">
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblStatus" CssClass="text-danger" runat="server"></asp:Label></td>
                <td>
                    <asp:RequiredFieldValidator ValidationGroup="Insert" CssClass="text-danger" runat="server" ErrorMessage="Introduzca un Nombre" EnableClientScript="true" ControlToValidate="txtName"></asp:RequiredFieldValidator></td>
                <td>
                    <asp:RequiredFieldValidator ValidationGroup="Insert" CssClass="text-danger" runat="server" ErrorMessage="Introduzca un Usuario" EnableClientScript="true" ControlToValidate="TxtUser"></asp:RequiredFieldValidator></td>
                <td>
                    <asp:RequiredFieldValidator ValidationGroup="Insert" CssClass="text-danger" runat="server" ErrorMessage="Introduzca una contraseña" EnableClientScript="true" ControlToValidate="TxtPass"></asp:RequiredFieldValidator></td>
                <td>
                    <asp:RegularExpressionValidator ValidationGroup="Insert" CssClass="text-danger" runat="server" ErrorMessage="Correo invalido" ValidationExpression="^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$" ControlToValidate="txtEmail" EnableClientScript="true"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td>
                    <button validationgroup="Insert" class="btn btn-info btn-sm font-weight-bold fa fa-plus" id="btnInsert" runat="server" />
                </td>
                <td>
                    <asp:TextBox ValidationGroup="Insert" CssClass="form form-control form-control-sm" runat="server" ID="txtName" placeholder="Nombre" AutoCompleteType="FirstName"></asp:TextBox></td>
                <td>
                    <asp:TextBox ValidationGroup="Insert" CssClass="form form-control form-control-sm" runat="server" ID="txtUser" placeholder="Usuario" AutoCompleteType="DisplayName"></asp:TextBox></td>
                <td>
                    <asp:TextBox ValidationGroup="Insert" CssClass="form form-control form-control-sm" runat="server" ID="txtPass" placeholder="Contraseña" AutoCompleteType="None"></asp:TextBox></td>
                <td>
                    <asp:TextBox ValidationGroup="Insert" CssClass="form form-control form-control-sm" runat="server" ID="txtEmail" placeholder="Correo" AutoCompleteType="Email"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ValidationGroup="Insert" CssClass="dropdown form-control form-control-sm" runat="server" ID="drGender">
                        <asp:ListItem Selected="True">---</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </tbody>

    </table>


    <h2 class="mb-5 mt-5">Publicar</h2> 
    <asp:Label runat="server" ID="statusPost" CssClass="text-success"></asp:Label>
    <table class="w-100">
        <tbody>
            <tr>
                <td>
                    <asp:TextBox ID="txtTitlePost" runat="server" CssClass="form-control m-1" placeholder="Titulo..." AutoCompleteType="JobTitle" />
                </td> <!--textbox del titulo-->
                <td>
                 <asp:DropDownList runat="server" ID="drdpost" CssClass="form-control" OnSelectedIndexChanged="ChangePostSelection" AutoPostBack="true">
                     <asp:ListItem Selected="True" Value="noticia">Noticia</asp:ListItem>
                     <asp:ListItem Value="foto">Foto</asp:ListItem>
                     <asp:ListItem Value="musica">Cancion</asp:ListItem>
                    </asp:DropDownList>
                </td> <!--drop down list seleccionadora de categoria-->
                <td>
                    <asp:FileUpload Visible="false" ID="flua" runat="server" CssClass="form-control-file text-right" />
                    <asp:Label Visible="false" runat="server" ID="lblStatusa" CssClass="text-danger float-right"></asp:Label>
                </td> <!--flua y lblStatusa-->
                <td>
                    <asp:FileUpload ID="fluf" runat="server" CssClass="form-control-file text-right" />
                    <asp:Label runat="server" ID="lblStatusf" CssClass="text-danger float-right"></asp:Label>
                </td> <!--fluf y lblStatusf-->
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="txtTextPost" runat="server" CssClass="form-control" Height="200px" TextMode="MultiLine" placeholder="Cuerpo de la publicacion" AutoCompleteType="Notes" />
                </td> <!--textbox del texto-->        
                <td>
                    <asp:Image Visible="false" CssClass="mr-5" runat="server" ID="imga" ImageUrl="~/Resources/audioFile.png" Width="200" Height="200" />
                    <asp:LinkButton Visible="false" ToolTip="Cargar" runat="server" ID="btnSubira" CssClass="btn btn-warning fa fa-upload fa-5x" OnClick="btnsubira_Click" CausesValidation="false" />
                </td> <!--imga y btnsubira-->
                <td class="float-right">
                    <asp:Image CssClass="mr-5" runat="server" ID="imgf" ImageUrl="~/Resources/NullIcon.png" Width="200" Height="200" />
                    <asp:LinkButton ToolTip="Cargar" runat="server" ID="btnSubirf" CssClass="btn btn-warning fa fa-upload fa-5x" OnClick="btnsubirf_Click" CausesValidation="false" />
                </td>  <!--imgf y btnsubirf-->
            </tr>
        </tbody>
    </table>
    <asp:Button runat="server" CssClass="btn btn-danger btn-lg mt-5" Text="Publicar" OnClick="Publish"/>
    <h2 class="mb-5 mt-5">Borrar publicacion</h2> 
     <asp:Label runat="server" ID="statusErasePost" CssClass="text-success"></asp:Label>
    <table>
        <tr>
            <td><asp:DropDownList runat="server" ID="drpErasePost" CssClass="form-control"><asp:ListItem Selected="True">ID</asp:ListItem><asp:ListItem>Titulo</asp:ListItem></asp:DropDownList></td>    
            <td><asp:TextBox runat="server" ID="txtErasePost" CssClass="form-control "></asp:TextBox></td>
            <td><asp:LinkButton runat="server" ID="btnErasePost" CssClass="btn btn-danger fa fa-trash" CausesValidation="false" OnClick="btnErasePost_Click"/></td>
        </tr>
    </table>    
        </main>
</asp:Content>


