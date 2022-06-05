﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int ID { get; set; }
        [DisplayName ("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
        public bool Estado { get; set; }
    }
    public class cantArticulo
    {
        public int id { get; set; }
        public int cant { get; set; }

        public cantArticulo(int a, int b)
        {
            id = a;
            cant = b;
        }
    }
}
