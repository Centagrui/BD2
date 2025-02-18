<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"Inherits="BD2.Default
" %>

<!DOCTYPE html>
<html>
<head>
    <title>Registro de Libros</title>
</head>
<body>
    <form runat="server">
        <h2>Registro de Libros</h2>
        ISBN: <asp:TextBox ID="txtISBN" runat="server" MaxLength="13" OnTextChanged="txtISBN_TextChanged" /><br />
        Título: <asp:TextBox ID="txtTitulo" runat="server" MaxLength="40" /><br />
        Número de Edición: <asp:TextBox ID="txtNumEdicion" runat="server" MaxLength="9" /><br />
        Año de Publicación: <asp:TextBox ID="txtAnioPublicacion" runat="server" /><br />
        Autores: <asp:TextBox ID="txtAutores" runat="server" MaxLength="90" /><br />
        País: <asp:TextBox ID="txtPais" runat="server" MaxLength="30" /><br />
        Sinopsis: <asp:TextBox ID="txtSinopsis" runat="server" TextMode="MultiLine" MaxLength="500" /><br />
        Carrera: <asp:TextBox ID="txtCarrera" runat="server" MaxLength="50" /><br />
        Materia: <asp:TextBox ID="txtMateria" runat="server" MaxLength="50" /><br />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Libro" OnClick="btnAgregar_Click" />
        
        <h3>Lista de Libros</h3>
        <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" Width="877px">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
        <asp:BoundField DataField="TITULO" HeaderText="Título" />
        <asp:BoundField DataField="NUM_EDICION" HeaderText="Número Edición" />
        <asp:BoundField DataField="ANIO_PUBLICACION" HeaderText="Año Publicación" />
        <asp:BoundField DataField="AUTORES" HeaderText="Autores" />
    </Columns>
</asp:GridView>




    </form>
</body>
</html>

