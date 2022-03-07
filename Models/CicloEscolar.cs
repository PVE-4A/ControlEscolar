using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.Models
{
    internal class CicloEscolar
    {
        private string _idCiclo;
        private String _Descripcion;

        public string idCiclo
        {
            get { return _idCiclo; }
            set { _idCiclo = value; }
        }

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public CicloEscolar(string idCiclo, String descripcion)
        {
            this._idCiclo = idCiclo;
            this._Descripcion = descripcion;
        }
        public override string ToString()
        {
            return $"Id: {_idCiclo}, Descripción: {_Descripcion}";
        }
    }
}
