<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <hgroup class="title">
        <h1> Contacta con nosotros </h1>

    </hgroup>

    <section class="contact">
       
        <p>
            <span class="label">Teléfono:</span>
            <span>902 426 713</span>
        </p>
      
    </section>

    <section class="contact">
     
        <p>
            <span class="label">Email:</span>
            <span><a href="mailto:inariplaysg@gmail.com">InariPlays@gmail.com</a></span>
        </p>
       
    </section>

    <section class="contact">
          <p>
            <span class="label">Dirección:</span>
           <span> Avenida la Estación, 5-7, 03003 Alicante </span>
              <span>                                 </span>
        </p>
    </section>
   
    <section class="mapa">
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1564.5936720810428!2d-0.4915650999999978!3d38.344645700000015!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd62364dca9ac9db%3A0xea47ede6e9177475!2sAv+Estaci%C3%B3n%2C+5-%2C+7%2C+03003+Alacant%2C+Alicante!5e0!3m2!1ses!2ses!4v1431102950213" width="400" height="300" frameborder="0" style="border:0"></iframe>
    </section>

</asp:Content>