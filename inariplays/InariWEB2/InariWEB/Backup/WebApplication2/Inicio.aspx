<%@ Page Title="INARI PLAYS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebApplication._Default" %>



<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>





<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="SlideContent">
   
    <link href="Content/style.css" rel="stylesheet" type="text/css" />
   
     <div class="top">
               
                  <ul>
                   <li>
                    <asp:Label ID="topventas" runat="server" Font-Size="Large">Los más vendidos</asp:Label>
                    </li>
                <li>
                      <asp:Image ID="Image1" runat="server" ImageUrl="Images/orderedList1.png"/>
                      <asp:Label ID="Top1" runat="server" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">Alejandro Sanz - Sirope</asp:Label>

                </li>
                <li>
                    <asp:Image ID="Image2" runat="server" ImageUrl="Images/orderedList2.png"/>
                     <asp:Label ID="Top2" runat="server" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">Kingdom Hearts</asp:Label>
                </li>
                <li>
                    <asp:Image ID="Image3" runat="server" ImageUrl="Images/orderedList3.png"/>
                     <asp:Label ID="Top3" runat="server" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">Star Wars: Reloj despertador Darth Vader</asp:Label>
                </li>
                <li>
                    <asp:Image  ID="Image4" runat="server" ImageUrl="Images/orderedList4.png"/>
                    <asp:Label ID="Top4" runat="server" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">Niños Grandes</asp:Label>
                </li>
                <li>
                    <asp:Image ID="cinco" runat="server" ImageUrl="Images/orderedList5.png"/>
                    <asp:Label ID="Top5" runat="server" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">The Killers - Battle Born</asp:Label>
                </li>
            </ul>
         </div>
   <div id="slideshow">
            <div class="sp-slideshow">
			
	<input id="button-1" type="radio" name="radio-set" class="sp-selector-1" checked="checked" />
	<label for="button-1" class="button-label-1"></label>
	
	<input id="button-2" type="radio" name="radio-set" class="sp-selector-2" />
	<label for="button-2" class="button-label-2"></label>
	
	<input id="button-3" type="radio" name="radio-set" class="sp-selector-3" />
	<label for="button-3" class="button-label-3"></label>
	
	<input id="button-4" type="radio" name="radio-set" class="sp-selector-4" />
	<label for="button-4" class="button-label-4"></label>
	
	<input id="button-5" type="radio" name="radio-set" class="sp-selector-5" />
	<label for="button-5" class="button-label-5"></label>
	
	<label for="button-1" class="sp-arrow sp-a1"></label>
	<label for="button-2" class="sp-arrow sp-a2"></label>
	<label for="button-3" class="sp-arrow sp-a3"></label>
	<label for="button-4" class="sp-arrow sp-a4"></label>
	<label for="button-5" class="sp-arrow sp-a5"></label>
	
	<div class="sp-content">
		<div class="sp-parallax-bg"></div>
		<ul class="sp-slider clearfix">
			<li><img src="/Images/sirope.png" alt="image01" /></li>
			<li><img src="/Images/1.jpg" alt="image02" /></li>
			<li><img src="/Images/2.jpg" alt="image03" /></li>
			<li><img src="/Images/3.jpg" alt="image04" /></li>
			<li><img src="/Images/4.jpg" alt="image05" /></li>
		</ul>
	</div><!-- sp-content -->
	
</div><!-- sp-slideshow -->

        </div>
      <div class="ofertas">
            <ul>
                <li>
                   <asp:Label ID="titulo" runat="server">OFERTAS</asp:Label>
                </li>
                <li>
                    <asp:Image ID="metal" runat="server" ImageUrl="Images/oferta.png" />
                </li>
                <li>
                    <asp:Label ID="nomof"  runat="server">Metal Gear Solid V</asp:Label>
                </li>
                <li>
                    <asp:Label ID="preof"  runat="server" > 14,99 € </asp:Label>
                </li>
                <li>
                    <asp:HyperLink id="comprar" runat="server" NavigateUrl="~/descvideo.aspx?id=9"><img src="Images/comprar.JPG" /></asp:HyperLink>
                </li>
                <li>
                    <asp:Image ID="imaof" runat="server" ImageUrl="Images/oferta2.png" />
                </li>
                 <li>
                    <asp:Label ID="nomof2"  runat="server" >Figura Funko Pop Eren  </asp:Label>
                </li>
                <li>
                    <asp:Label ID="nomof3"  runat="server" >  Jaeger 10 cm </asp:Label>
                </li>
                 <li>
                    <asp:Label ID="preof2"  runat="server"> 10,99 € </asp:Label>
                </li>
                <li>
                    <asp:HyperLink id="comprar2" runat="server" NavigateUrl="~/descmerchan.aspx?id=5"><img src="Images/comprar.JPG" /></asp:HyperLink>
                </li>
                
            </ul>
         </div>
</asp:Content>





<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .lista {
        width: 151px;
    }
</style>
</asp:Content>






