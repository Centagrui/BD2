using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Web.UI;
using MySql.Data.MySqlClient;
using static Mysqlx.Expect.Open.Types.Condition.Types;

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
           
            if (validar())
            {
                Libros nuevoLibro = new Libros
                {
                    ISBN = txtISBN.Text,
                    TITULO = txtTitulo.Text,
                    NUM_EDICION = int.Parse(txtNumEdicion.Text),
                    ANIO_PUBLICACION = int.Parse(txtAnioPublicacion.Text),
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
        }

        private bool validar()
        {
            try
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
                    return false;
                }

                // validar el número de edición
                if (!int.TryParse(txtNumEdicion.Text, out int numEdicion))
                {
                    Response.Write("<script>alert('El campo Número de Edición debe ser un número válido.');</script>");
                    return false;
                }

                // validar el año de publicacion
                if (!int.TryParse(txtAnioPublicacion.Text, out int anioPublicacion))
                {
                    Response.Write("<script>alert('El campo Año de Publicación debe ser un número válido.');</script>");
                    return false;
                }

                // valiadar valores correctos para los campos
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if(!Regex.Match(txtISBN.Text, @"^[0-9]+$").Success){
                    Response.Write("<script>alert('El campo ISBN debe contener sólo números.');</script>");
                    return false;
                }

                if(!Regex.Match(txtTitulo.Text, @"^[0-9a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    Response.Write("<script>alert('El campo Título debe contener sólo letras, números, espacios, tildes y la letra ñ.');</script>");
                    return false;
                }

                if (!Regex.Match(txtNumEdicion.Text, @"^[0-9]+$").Success)
                {
                    Response.Write("<script>alert('El campo Número de edición debe contener sólo números.');</script>");
                    return false;
                }

                if (!Regex.Match(txtAnioPublicacion.Text, @"^[0-9]+$").Success)
                {
                    Response.Write("<script>alert('El campo Año de Publicación debe contener sólo números.');</script>");
                    return false;
                }

                if (!Regex.Match(txtAutores.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    Response.Write("<script>alert('El campo Autores debe contener sólo letras, espacios, tildes y la letra ñ.');</script>");
                    return false;
                }

                if (!Regex.Match(txtPais.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    Response.Write("<script>alert('El campo País debe contener sólo letras, espacios, tildes y la letra ñ.');</script>");
                    return false;
                }

                if (!Regex.Match(txtSinopsis.Text, @"^[0-9a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    Response.Write("<script>alert('El campo Sinópsis debe contener sólo letras, números, espacios, tildes y la letra ñ.');</script>");
                    return false;
                }

                if (!Regex.Match(txtCarrera.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    Response.Write("<script>alert('El campo Carrera debe contener sólo letras, espacios, tildes y la letra ñ.');</script>");
                    return false;
                }

                if (!Regex.Match(txtMateria.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    Response.Write("<script>alert('El campo Mareria debe contener sólo letras, espacios, tildes y la letra ñ.');</script>");
                    return false;
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                return true;
            }
            catch (Exception ex) {

                return false;
            }

            return true;
        }

        private void CargarLibros()
        {
            try
            {
                List<Libros> libros = daoLibros.ObtenerLibros();
                if(libros != null)
                {
                    Response.Write("<script>alert('Libros obtenidos: " + libros.Count + "');</script>");
                    gvLibros.DataSource = libros;
                    gvLibros.DataBind();
                }
                else Response.Write("<script>alert('No se pudo conseguir nigún libro.');</script>");
                
            }
            catch (Exception)
            {

            }
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

        protected void txtISBN_TextChanged(object sender, EventArgs e)
        {

        }
    } 


}
 