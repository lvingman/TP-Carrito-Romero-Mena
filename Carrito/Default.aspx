<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito._Default" EnableEventValidation = "false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <%--<asp:GridView CssClass="table" ID="dgvArticulos" runat="server" OnRowDataBound="dgvArticulos_RowDataBound" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" ></asp:GridView>--%>
        
            <h1 class="title"> Catalogo de Articulos</h1>
            
            <div class="containerProductos">
            
                <% foreach (dominio.Articulo item in listaArticulos)
                    { %>
                        <div class="card">
                            <img src="<%= item.Imagen %>" alt="Articulo" />
                            <h4><%= item.Nombre %></h4>
                            <p><%= item.Descripcion %></p>
                            <a href="link">Agregar</a>
                            <%--<asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />--%>
                        </div>
                <% } %>

            </div>
        

</asp:Content>
