<%@ Page Title="Pagina Principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HEAD" runat="Server">
    <style>
        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BODY" runat="Server">
    <div id="myCarousel" class="carousel slide mb-5" data-ride="carousel">
        <div class="carousel-inner">
            <div style="height: 20rem" class="carousel-item active">
                <img class="bd-placeholder-img" width="100%" height="100%" src="Resources/carousel1.jpg"/>                           
                <div class="container">
                    <div class="carousel-caption  text-left" style="font-size: 24px;">
                        <h1 class="font-italic display-2">Enterese de nuestras noticias</h1>
                        <p class="lead">Un lugar donde conocera todo lo relacionado a nuestro grupo, se enterara de las ultimas noticias y aumentara su conocimiento.</p>

                    </div>
                </div>
            </div>
            <div style="height: 20rem" class="carousel-item">
                <img class="bd-placeholder-img" width="100%" height="100%" src="Resources/carousel2.jpg"/> 
                <div class="container">
                    <div class="carousel-caption text-center">
                        <h1 class="font-italic display-2">Escuche nuestra musica</h1>
                        <p class="lead ">Creada especificamente para que pueda escuchar la musica de su preferencia sin ser interrumpido.</p>
                    </div>
                </div>
            </div>
            <div style="height: 20rem" class="carousel-item">
                <img class="bd-placeholder-img" width="100%" height="100%" src="Resources/carousel3.jpg"/> 
                <div class="container">
                    <div class="carousel-caption text-right">
                        <h1 class="font-italic display-2">Observe nuestras fotos</h1>
                        <p class="lead">Mirando nuestras fotos usted podra experimentar nuestros mismos sentimientos.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <main class="container pb-3">       
        <div runat="server" id="lastPostPanel" class="row text-center">
           
        </div><!-- /.row -->
       
    </main>
</asp:Content>

