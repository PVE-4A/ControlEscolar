using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class CicloEscolar
    {
        private int _idCiclo;
        private String _Descripcion;

        public int idCiclo
        {
            get { return _idCiclo; }
            set { _idCiclo = value; }
        }

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public CicloEscolar(int idCiclo, String descripcion)
        {
            this._idCiclo = idCiclo;
            this._Descripcion = descripcion;
        }
    }
}
