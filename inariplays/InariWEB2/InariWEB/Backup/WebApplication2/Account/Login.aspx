<%@ Page Title="INARI PLAYS - Inicio de Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Account.Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
                <div class="form-horizontal">
        <h2>Iniciar sesión</h2>
         <asp:Label ID="Labelerror" runat="server" CssClass="field-validation-error" Visible="false">Contraseña o usuario incorrectos</asp:Label>

        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" ID ="logon">
            <LayoutTemplate>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">Usuario</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="Por favor, introduzca un usuario" />
                        </li>
                        <li>
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="Por favor, introduzca una contraseña" />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label ID="Label3" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">¿Recordarme en este equipo?</asp:Label>
                        </li>
                    </ol>
                    <asp:Button ID="Button1" runat="server" CommandName="Login" Text="Iniciar sesión" OnClick ="cambiainicio"/>
                </fieldset>
            </LayoutTemplate>
        </asp:Login>

        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" ForeColor="#3333FF" BorderStyle="None" Font-Underline="True">Registrate aquí  </asp:HyperLink>
            si aún no tienes una cuenta.
        </p>
                    </div>
   
</asp:Content>

