<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="peliculas.aspx.cs" Inherits="_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cuerpo" runat="server">
     
      <div class="page-header" id="tit">
        <h1>Películas</h1>
        <div>
          <label>Buscar películas:</label>
          <div>
           <form id="busquedaPeli" class="pull-right form-inline" >
              <asp:TextBox id="busquedaPeliculaTextBox" runat="server" CssClass="input-medium" />
                  <asp:DropDownList ID="busquedaGeneroDropDownList" runat="server">
                    <asp:ListItem value="accion">Acción</asp:ListItem>
                    <asp:ListItem value="comedia">Comedia</asp:ListItem>
                    <asp:ListItem value="terror">Terror</asp:ListItem>
                    <asp:ListItem value="suspense">Suspense</asp:ListItem>
                    <asp:ListItem value="cienciaFiccion">Ciencia Ficción</asp:ListItem>
                  </asp:DropDownList>
              <asp:Button ID="busquedaButton" runat="server" Text="Buscar" CssClass="btn" />
           </form>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="span4">
          <div class="well">
            <h4>Gran Torino</h4>
            <p>
              <span>Walt Kowalski (Clint Eastwood), un veterano de la guerra de Corea (1950-1953), es un obrero jubilado del sector del automóvil que ha enviudado recientemente. Su máxima pasión es cuidar de su más preciado tesoro: un coche Gran Torino.</span>
              <br> 
            </p>
            <p>Clint Eastwood</p>
            <img src="#"> 
            <br><br>
            <asp:Button ID="Button1" runat="server" Text="Reservar" CssClass="btn" /> 
          </div>
          <div class="well">
            <h4>Avatar</h4>
            <p>
              <span>Año 2154. Jake Sully (Sam Worthington), un ex-marine condenado a vivir en una silla de ruedas, sigue siendo, a pesar de ello, un auténtico guerrero. Precisamente por ello ha sido designado para ir a Pandora.</span>
              <br> 
            </p>
            <p></p>
            <p>James Cameron</p>
            <img src="#">
            <br><br>
            <asp:Button ID="Button2" runat="server" Text="Reservar" CssClass="btn" />  
          </div>
        </div>
        <div class="span4">
          <div class="well">
            <h4>Scarface</h4>
            <p>Tony Camonte (Paul Muni), un pistolero de origen italiano, ignorante y
              sin escrúpulos, es el lugarteniente de Johnny Lovo (Osgood Perkins), el
              hampón más poderoso del South End de Chicago.
              <br>
              <br> 
            </p>
            <p>Brian de Palma</p>
            <img src="#"> 
            <br><br>
            <asp:Button ID="Button3" runat="server" Text="Reservar" CssClass="btn" /> 
          </div>
          <div class="well">
            <h4>A Orange Clockwork</h4>
            <p>
              <span>Gran Bretaña, en un futuro indeterminado. Alex (Malcolm McDowell) es un joven muy agresivo que tiene dos pasiones: la violencia desaforada y Beethoven.<br></span>
              <br> 
            </p>
            <p>Stanley Kubrick</p>
            <img src="#"> 
            <br><br>
            <asp:Button ID="Button4" runat="server" Text="Reservar" CssClass="btn" /> 
          </div>
        </div>
        <div class="span4">
          <div class="well">
            <h4>Million Dollar Baby</h4>
            <p>
              <span>Después de haber entrenado y representado a los mejores púgiles, Frankie Dunn (Eastwood) regenta un gimnasio con la ayuda de Scrap (Freeman), un ex-boxeador que es además su único amigo.&nbsp;<br></span>
              <br> 
            </p>
            <p>Clint Eastwood</p>
            <img src="#"> 
            <br><br>
            <asp:Button ID="Button5" runat="server" Text="Reservar" CssClass="btn" /> 
          </div>
          <div class="well">
            <h4>Full Metal Jacket</h4>
            <p>
              <span>Un grupo de reclutas se prepara en Parish Island, centro de entrenamiento de la marina norteamericana. Allí está el sargento Hartmann, duro e implacable, cuya única misión en la vida es endurecer el cuerpo y el alma de </span>
              <br> 
            </p>
            <p>Stanley Kubrick</p>
            <img src="#"> 
            <br><br>
            <asp:Button ID="Button6" runat="server" Text="Reservar" CssClass="btn" /> 
          </div>
        </div>
      </div>

    </form>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="bajoCuerpo" Runat="Server">
    
  <div>
    <form >
        <h2>Nueva película</h2>
          <table class="table">
            <tbody>
              <tr>
                <th>Título:</th>
                <th>
                  <input type="text" class="input-medium"> 
                </th>
              </tr>
              <tr>
                <td>Director:</td>
                <td>
                  <input type="text" class="input-medium">&nbsp; &nbsp; &nbsp; <button class="btn btn-success">Nuevo Director</button>
                </td>
              </tr>
              <tr>
                <td>Año:</td>
                <td>
                  <input type="text" class="input-medium"> 
                </td>
              </tr>
              <tr>
                <td>Sinopsis:</td>
                <td>
                  <textarea></textarea>
                </td>
              </tr>
              <tr>
                <td>Stock:</td>
                <td>
                  <input type="text" class="input-medium"> 
                </td>
              </tr>
              <tr>
                <td>Foto:</td>
                <td>
                  <input type="text" class="input-medium"> 
                </td>
              </tr>
            </tbody>
          </table>
          <button class="btn btn-success">Insertar</button>
          <a></a> 
        </form>
      </div>
        
</asp:Content>

