using System;
using System.Collections.Generic;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace BD2
{
    public partial class Default : Page
    {
        private DaoLibros daoLibros = new DaoLibros();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLibros();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación para evitar espacios en blanco
            if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrWhiteSpace(txtAutores.Text) ||
                string.IsNullOrWhiteSpace(txtPais.Text) ||
                string.IsNullOrWhiteSpace(txtSinopsis.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text) ||
                string.IsNullOrWhiteSpace(txtMateria.Text))
            {
                Response.Write("<script>alert('Los campos no pueden estar vacíos o contener solo espacios en blanco.');</script>");
                return;
            }

            
            if (!int.TryParse(txtNumEdicion.Text, out int numEdicion))
            {
                Response.Write("<script>alert('El campo Número de Edición debe ser un número válido.');</script>");
                return;
            }

            if (!int.TryParse(txtAnioPublicacion.Text, out int anioPublicacion))
            {
                Response.Write("<script>alert('El campo Año de Publicación debe ser un número válido.');</script>");
                return;
            }

            Libros nuevoLibro = new Libros
            {
                ISBN = txtISBN.Text,
                TITULO = txtTitulo.Text,
                NUM_EDICION = numEdicion,
                ANIO_PUBLICACION = anioPublicacion,
                AUTORES = txtAutores.Text,
                PAIS = txtPais.Text,
                SINOPSIS = txtSinopsis.Text,
                CARRERA = txtCarrera.Text,
                MATERIA = txtMateria.Text
            };

            daoLibros.AgregarLibro(nuevoLibro);
            CargarLibros();
            LimpiarCampos();
        }

        private void CargarLibros()
        {
            List<Libros> libros = daoLibros.ObtenerLibros();
            Response.Write("<script>alert('Libros obtenidos: " + libros.Count + "');</script>");
            gvLibros.DataSource = libros;
            gvLibros.DataBind();
        }


        private void LimpiarCampos()
        {
            txtISBN.Text = "";
            txtTitulo.Text = "";
            txtNumEdicion.Text = "";
            txtAnioPublicacion.Text = "";
            txtAutores.Text = "";
            txtPais.Text = "";
            txtSinopsis.Text = "";
            txtCarrera.Text = "";
            txtMateria.Text = "";
        }
    } 


}
 