<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="miCarrito.aspx.cs" Inherits="Carrito.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h1>Carro de compras</h1>
    <asp:Button ID="btnCounter" runat="server" Text="Agregar item al Carrito?" OnClick="btnCounter_Click" />
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

</asp:Content>
