<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="miCarrito.aspx.cs" Inherits="Carrito.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h1>Carro de compras</h1>
    <asp:Button ID="btnCounter" runat="server" Text="Agregar item al Carrito?" OnClick="btnCounter_Click" />
    <asp:GridView ID="dgvCarro" runat="server"></asp:GridView>

</asp:Content>
