<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="miCarrito.aspx.cs" Inherits="Carrito.About" %>



<asp:Content class="" ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Carro de compras</h1>

    <script type="text/javascript">
        window.history.pushState(null, null, '<%=Request.Url.LocalPath%>');
    </script>
    
    <div class="container align-content-center bg-light">
        <div class="row border text-center ">
            <div class="col-sm border">
                <h2>Codigo</h2>
            </div>
            <div class="col-sm border">
                <h2>Nombre</h2>
            </div>
            <div class="col-sm border">
                <h2>Descripcion</h2>
            </div>
            <div class="col-sm border">
                <h2>Imagen</h2>
            </div>
            <div class="col-sm border">
                <h2>Cantidad</h2>
            </div>
            <div class="col-sm border">
                <h2>Precio</h2>
            </div>
            <div class="col-sm border">
                <h2>Opciones</h2>
            </div>

            <div class="w-100 border"></div>
        <%foreach(dominio.Articulo item in listaArticulosCarro)
               {%>
                    
                        <div class="col border">
                            <h4><%= item.Codigo %></h4>
                        </div>
                        <div class="col border">
                            <h4><%= item.Nombre %></h4>
                        </div>
                        <div class="col border">
                            <p><%= item.Descripcion %></p>
                        </div>
                        <div class="col border">
                            <img class="img-thumbnail" src="<%= item.Imagen %>" onerror="this.src='<%=negocio.Diccionario.IMAGE_NOTFOUND%>'"  style="width:70%" />
                        </div>
                        <div class="col border">
                            <a href="miCarrito?idmas=<%= item.ID %>">+</a>
                            <p><%= cantArticulos.Find(x => x.id == item.ID).cant %></p>
                            <a href="miCarrito?idmenos=<%= item.ID %>">-</a>
                        </div>

                        <div class="col border">
                            <p>$<%= item.Precio * cantArticulos.Find(x => x.id == item.ID).cant %></p>
                        </div>

                        <div class="col border">
                            <a href="miCarrito?idelim=<%= item.ID %>">Eliminar Articulo</a> 
                        </div>
                        <div class="w-100"></div>
                    


           <%  } %>
            </div>
            <div class="col-sm border">
                <h2>Precio Total</h2>
            </div>
            <div class="col-sm border">
                <p>$<%= obtenerPrecioTotal() %></p>
            </div>
    </div>

    <%-- 
    <asp:GridView ID="dgvCarro" runat="server" AutoGenerateColumns="False" OnRowEditing="dgvCarro_RowEditing" OnRowUpdating="dgvCarro_RowUpdating">

        <Columns>
             
            <asp:TemplateField HeaderText ="Codigo">
                <ItemTemplate>
                    <asp:Label ID="lblCodigo" runat="server" Text='<% # Bind("Codigo")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText ="Nombre">
                <ItemTemplate>
                    <asp:Label ID="lblNombre" runat="server" Text='<% # Bind("Nombre")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText ="Descripcion">
                <ItemTemplate>
                    <asp:Label ID="lblDescripcion" runat="server" Text='<% # Bind("Descripcion")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText ="Imagen">
                <ItemTemplate>
                    <asp:Image ID="imgImagen" runat="server" ImageUrl='<% # Bind("Imagen")%>'></asp:Image>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        
    </asp:GridView>
    --%>
</asp:Content>
