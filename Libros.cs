using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD2
{
    public class Libros
    {
       
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string TITULO { get; set; }
        public int NUM_EDICION { get; set; }
        public int ANIO_PUBLICACION { get; set; }
        public string AUTORES { get; set; }
        public string PAIS { get; set; }
        public string SINOPSIS { get; set; }
        public string CARRERA { get; set; }
        public string MATERIA { get; set; }
    }
}