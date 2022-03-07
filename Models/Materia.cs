using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.Models
{
    internal class Materia
    {
        private string _id_materia;
        private string _nombre_materia;

        public Materia(string materia, string nombreMateria)
        {
            this._id_materia = materia;
            this._nombre_materia = nombreMateria;
        }

        public string idMateria
        {
            get { return _id_materia; }
            set { _id_materia = value; }
        }

        public string nombreMateria
        {
            set { _nombre_materia = value; }
            get { return _nombre_materia; }
        }
        public override string ToString()
        {
            return $"Id: {_id_materia}, Nombre: {_nombre_materia}";
        }

    }

}