using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTienda.Entidades
{
    class Cliente
    {
        private int id;
        private string dni;
        private string nombres;
        private string apellidos;
        private int edad;
        private string ciudad;

        public Cliente()
        {
            this.id = 0;
            this.dni = "";
            this.nombres = "";
            this.apellidos = "";
            this.edad = 0;
            this.ciudad = "";
        }

        public int Id { get => id; set => id = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
    }
}
