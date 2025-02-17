using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BD2
{
    public class DaoLibros
    {
        private string conexionString = "server=localhost;database=Biblioteca;user=root;password=root";

        public string AgregarLibro(Libros libro)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Libros (ISBN, TITULO, NUM_EDICION, ANIO_PUBLICACION, AUTORES, PAIS, SINOPSIS, CARRERA, MATERIA) " +
                                   "VALUES (@ISBN, @TITULO, @NUM_EDICION, @ANIO_PUBLICACION, @AUTORES, @PAIS, @SINOPSIS, @CARRERA, @MATERIA);" +
                                   "SELECT LAST_INSERT_ID();";  // Obtener el último ID insertado

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", libro.ISBN);
                        cmd.Parameters.AddWithValue("@TITULO", libro.TITULO);
                        cmd.Parameters.AddWithValue("@NUM_EDICION", libro.NUM_EDICION);
                        cmd.Parameters.AddWithValue("@ANIO_PUBLICACION", libro.ANIO_PUBLICACION);
                        cmd.Parameters.AddWithValue("@AUTORES", libro.AUTORES);
                        cmd.Parameters.AddWithValue("@PAIS", libro.PAIS);
                        cmd.Parameters.AddWithValue("@SINOPSIS", libro.SINOPSIS);
                        cmd.Parameters.AddWithValue("@CARRERA", libro.CARRERA);
                        cmd.Parameters.AddWithValue("@MATERIA", libro.MATERIA);

                        int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());  

                      
                        libro.ID = idGenerado;
                    }
                }

                return "Libro agregado correctamente con ID: " + libro.ID;
            }
            catch (Exception ex)
            {
                return "Error al agregar el libro: " + ex.Message;
            }
        }

        public List<Libros> ObtenerLibros()
        {
            List<Libros> listaLibros = new List<Libros>();

            using (MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                conexion.Open();
                string query = "SELECT * FROM Libros";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaLibros.Add(new Libros
                        {
                            ID = reader.IsDBNull(reader.GetOrdinal("ID")) ? 0 : reader.GetInt32("ID"),
                            ISBN = reader.GetString("ISBN"),
                            TITULO = reader.GetString("TITULO"),
                            NUM_EDICION = reader.GetInt32("NUM_EDICION"),
                            ANIO_PUBLICACION = reader.GetInt32("ANIO_PUBLICACION"),
                            AUTORES = reader.GetString("AUTORES"),
                            PAIS = reader.GetString("PAIS"),
                            SINOPSIS = reader.GetString("SINOPSIS"),
                            CARRERA = reader.GetString("CARRERA"),
                            MATERIA = reader.GetString("MATERIA")
                        });
                    }
                }
            }

            return listaLibros;
        }
    }
}
