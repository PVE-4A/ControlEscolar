using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.Models
{
    internal class InscripcionActual
    {
        private CicloEscolar _ciclo;
        private GrupoMateria _grupo_materia;
        private float? _cal_ord;
        private float? _cal_ext;
        private int _estatus;

        public InscripcionActual(GrupoMateria grupo_materia, CicloEscolar ciclo)
        {
            this._grupo_materia = grupo_materia;
            this._ciclo = ciclo;
            this._estatus = 0;
        }

        public GrupoMateria grupo_materia
        {
            get { return _grupo_materia; }
            set { _grupo_materia = value; }
        }
        public CicloEscolar ciclo
        {
            get { return _ciclo; }
            set { _ciclo = value; }
        }
        public int estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }


        public float? cal_ord
        {
            get { return _cal_ord; }
            set { _cal_ord = value; }
        }


        public float? cal_ext
        {
            get { return _cal_ext; }
            set { _cal_ext = value; }
        }

    }
}
