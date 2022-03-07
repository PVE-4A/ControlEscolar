using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.Models
{
    internal class Grupo
    {
        private int _id_grupo;
        private string _grado;
        private string _nombre;

        public Grupo(int grupo, string grado, string nombre)
        {
            this._id_grupo = grupo;
            this._grado = grado;
            this._nombre = nombre;
        }

        public int id_grupo
        {
            get { return _id_grupo; }
            set { _id_grupo = value; }
        }

        public string grado
        {
            get { return _grado; }
            set { _grado = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public override string ToString()
        {
            return $"Id: {_id_grupo}, Nombre: {_nombre}, Grado: {_grado}";
        }
    }
}