<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1>Crear una nueva cuenta</h1>
    </hgroup>
            <div runat="server" ID="pene">
              
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <ol>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="UserName">Nombre</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca su nombre." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="apellidos">Apellidos</asp:Label>
                                <asp:TextBox runat="server" ID="apellidos" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="apellidos"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca sus apellidos." />
                            </li>
                             <li>
                                <asp:Label runat="server" AssociatedControlID="NIF">NIF</asp:Label>
                                <asp:TextBox runat="server" ID="NIF" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="NIF"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca su NIF." />
                                 <asp:RegularExpressionValidator
                                    ID="checkdni"                                     
                                     ControlToValidate ="NIF"
                                     ValidationExpression ="^(\d{8}[A-Z])$"
                                     ErrorMessage="el nif debe contener 8 numeros y 1 letra"
                                     runat="server" />
                            </li>
                             <li>
                                <asp:Label runat="server" AssociatedControlID="Direccion">Dirección</asp:Label>
                                <asp:TextBox runat="server" ID="Direccion" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Direccion"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca una Dirección." />
                            </li>
                             <li>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="cp">Código Postal</asp:Label>
                                <asp:TextBox runat="server" ID="cp" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="CP"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca su código postal." />
                            </li>
                             <li>
                                <asp:Label runat="server" AssociatedControlID="telefono">Teléfono</asp:Label>
                                <asp:TextBox runat="server" ID="telefono" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="telefono"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca su telefono." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Email">Correo electrónico</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca un email válido." />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="Por favor, introduzca una contraseña" />
                            </li>
                            <li>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirmar contraseña</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Por favor, introduzca una confirmación de la contraseña." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="La contraseña y la contraseña confirmada no son las misma." />
                            </li>
                            
                        </ol>
                        <asp:Button runat="server" CommandName="MoveNext" Text="Registrar"  OnClick="NuevoCliente" OnClientClick="NuevoCliente" />
                    </fieldset>
              
            </div>
     
</asp:Content>