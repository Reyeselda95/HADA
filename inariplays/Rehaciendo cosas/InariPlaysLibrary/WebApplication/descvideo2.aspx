<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="descvideo2.aspx.cs" Inherits="WebApplication.descvideo2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="descrip" style="height:500px">
    <div class="imagenpeli">
                <asp:Image ID="peli1" runat="server" ImageUrl="Images/kingdommedio.png"/>
            </div>  
        <div class="peli">
         <asp:Label ID="tit" runat="server">Kingdom Hearts</asp:Label>
            <ul>
            <li>
            <asp:Label ID="titi" runat="server">Descripción: </asp:Label>
                </li>
                 <li>
            <asp:Label ID="titit" runat="server"> Kingdom Hearts es la feliz unión del maestro Square (Final Fantasy) y el rey de la animación, Disney, y el resultado no podía ser menos que espectacular. Esta bonita historia parte del nacimiento de Sora, un vigoroso aventurero de 14 añitos. Con un sabor muy a lo Tidus, el protagonista de FFX, Sora copia el inconfundible estilo de este héroe de Square con pelo a lo punky y le da su toque particular, y tan particular, porque se distingue a la legua con los enormes zapatones que calza, que seguro Mickey Mouse se moriría por tener, al más puro estilo de la casa Disney. Aparte de los personajes e impresionantes efectos visuales, el sistema de lucha merece mención especial ya que Square ha prescindido del clásico desarrollo por turnos para centrarse en un método de lucha en tiempo real más atractivo. Por tanto, podrás moverte a tu antojo y blandir tu espada cada vez que te apetezca en los distintos ataques o bien optar por acorralar al enemigo para una lucha más equilibrada. </asp:Label>
                </li>
          </ul>
            <div class="preciodesc">
                <asp:Label ID="precio" runat="server"> 22,18€ </asp:Label>
            </div>
            <div class="comprar">
                <asp:LinkButton ID="compra" runat="server">Añadir a la cesta</asp:LinkButton>
           </div>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>
