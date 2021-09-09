<%@ Page Title="Fotos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Photo.aspx.cs" Inherits="Photo" %>

<%@ OutputCache Duration="600" VaryByParam="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HEAD" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BODY" runat="Server">
    <main class="container">

        <div class="p-4 p-md-5 mb-4 jumbotron rounded" style="background-image:url(Resources/photosbanner.jpg); background-size:cover; background-repeat:no-repeat;background-position-y:center">
            <div class="px-0 ">
                <h1 class="display-3 font-italic text-center">Observe nuestras fotos</h1>
                <p class="lead my-3">Mirando nuestras fotos usted podra experimentar nuestros mismos sentimientos.</p>
            </div>
        </div>

        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 mb-2" runat="server" id="MediumNoticesPanel">
        </div>
    </main>
</asp:Content>

