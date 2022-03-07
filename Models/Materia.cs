using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.Models
{
    internal class Materia
    {
        private int _id_materia;
        private string _nombre_materia;

        public Materia(int materia, string nombreMateria)
        {
            this._id_materia = materia;
            this._nombre_materia = nombreMateria;
        }

        public int idMateria
        {
            get { return _id_materia; }
            set { _id_materia = value; }
        }

        public string nombreMateria
        {
            set { _nombre_materia = value; }
            get { return _nombre_materia; }
        }


    }

}