<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="WebApplication.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   <div>
     <div>
         <asp:Button ID="Button1" runat="server" Text="Mostrar usuarios" />
     </div>
    <div>
        <asp:Button ID="Button2" runat="server" Text="Mostrar productos" />
    </div>
    <div>
        <asp:Button ID="Button3" runat="server" Text="Mostrar pedidos" />
    </div>
    <div>
        <asp:Button ID="Button4" runat="server" Text="Insertar producto" />
    </div>
       </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>

