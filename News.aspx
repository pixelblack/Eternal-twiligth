<%@ Page Title="Noticias" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<%@ OutputCache Duration="600" VaryByParam="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HEAD" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BODY" runat="Server">
    <main class="container">
        <div class="p-4 p-md-5 mb-4 jumbotron rounded" style="background-image:url(Resources/newsbanner.jpg); background-size:cover; background-repeat:no-repeat;background-position-y:center">
            <div class="px-0 text-white">
                <h1 class="display-3 font-italic text-center">Enterese de nuestras noticias</h1>
                <p class="lead my-3">Un lugar donde conocera todo lo relacionado a nuestro grupo,se enterara de las ultimas noticias y aumentara su conocimiento.</p>
            </div>
        </div>

        <div class="row mb-2" runat="server" id="MediumNoticesPanel">
        </div>
    </main>
</asp:Content>

