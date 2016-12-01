<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="WebApplication.Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="menuadmin" runat="server">
<div id="cosikas">

    <asp:Table ID="Table1" runat="server" CellPadding="1" CellSpacing="1">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
                <div>
                 <div>
                     <asp:Button ID="Button1" runat="server" Text="Mostrar usuarios" OnClick="Mostrarusuarios" />
                 </div>
                <div>
                    <asp:Button ID="Button2" runat="server" Text="Mostrar productos" OnClick="mostrarproductos"/>
                </div>
                <div>
                    <asp:Button ID="Button3" runat="server" Text="Mostrar pedidos" OnClick="mostrarpedidos"/>
                </div>
                <div>
                    <asp:Button ID="Button4" runat="server" Text="Insertar producto" OnClick="MostrarNuevoProducto" />
                </div>
               </div>
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left" >    
            <!-- Aqui van a ir el gridview y los botones de nuevo producto -->
                 <div>
                  <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" 
        BackColor="White" CellPadding="1" CellSpacing="1" GridLines="Both"
        HorizontalAlign="Center" AllowPaging="True" Width="1000px" Visible=False  HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Top" SortedDescendingHeaderStyle-HorizontalAlign="Center" SortedDescendingHeaderStyle-VerticalAlign="Top" SortedAscendingHeaderStyle-HorizontalAlign="Center" SortedAscendingHeaderStyle-VerticalAlign="Top" SelectedRowStyle-HorizontalAlign="Left" SelectedRowStyle-VerticalAlign="Top" RowStyle-HorizontalAlign="Left" RowStyle-VerticalAlign="Top" PageSize="20">
        </asp:GridView>
            </div>

        <div>
         <p>
         <asp:Label ID="Label0" runat="server" AssociatedControlID="DropDownList1"  Visible=false>Tipo Producto</asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" Visible=false>
                <asp:ListItem>Merchandising</asp:ListItem>
                <asp:ListItem>Musica</asp:ListItem>
                <asp:ListItem>Pelicula</asp:ListItem>
                <asp:ListItem>Videojuego</asp:ListItem>
            </asp:DropDownList>
        </p>

        <p>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="nomproduc" Visible=false>Nombre del producto</asp:Label>
            <asp:TextBox runat="server" ID="nomproduc" Visible=false >Inserte Aqui el nombre del producto</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nomproduc"
             CssClass="field-validation-error" ErrorMessage="Por favor, introduzca el nombre." Enabled=false />
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" AssociatedControlID="produdesc" Visible=false>Descripcion del producto</asp:Label>
            <asp:TextBox runat="server" ID="produdesc" Visible=false TextMode="MultiLine">Inserte Aqui la descripcion del producto</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="produdesc"
             CssClass="field-validation-error" ErrorMessage="Por favor, introduzca la descripcion." Enabled=false />
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" AssociatedControlID="produprecio" Visible=false>Precio por Unidad</asp:Label>
            <asp:TextBox runat="server" ID="produprecio" Visible=false >Inserte Aqui el precio del producto</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="produprecio"
             CssClass="field-validation-error" ErrorMessage="Por favor, introduzca el precio." Enabled=false/>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" AssociatedControlID="produproc" Visible=false>Stock disponible</asp:Label>
            <asp:TextBox runat="server" ID="produproc" Visible=false >Inserte Aqui el stock del producto</asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="produproc"
             CssClass="field-validation-error" ErrorMessage="Por favor, introduzca el stock." Enabled=false />
        </p>

        <p>
            <asp:Label ID="Label6" runat="server" AssociatedControlID="produproc" Visible=false>Url de la Imagen</asp:Label>
            <asp:TextBox runat="server" ID="URL" Visible=false ></asp:TextBox>
        </p>
            <asp:Button ID="Button5" runat="server" Text="Insertar Producto" OnClick="insertarproducto" Visible=false />
     </div>
    
             
             </asp:TableCell></asp:TableRow></asp:Table><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT * FROM [Cliente]" ></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT productoId, nombre, precio, stock, FK_videojuegoId, FK_musicaId, FK_merchandisingId, FK_peliculaId FROM [Producto]" ></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" SelectCommand="SELECT * FROM [Pedido]" ></asp:SqlDataSource>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SlideContent" runat="server">
</asp:Content>

