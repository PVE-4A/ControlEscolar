using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Estudiante : Persona
    {
        private string _matricula;
        private string _tutor;
        private string _foto;
        private List<InscripcionActual> _inscripcion;
        private Programa _programa;
        public Programa programa
        {
            get { return _programa; }
            set { _programa = value; }
        }
        

        public List<InscripcionActual> inscripcion
        {
            get { return _inscripcion; }
            set { _inscripcion = value; }
        }



        public string foto
        {
            get { return _foto; }
            set { _foto = value; }
        }


        public string tutor
        {
            get { return _tutor; }
            set { _tutor = value; }
        }


        public string matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        public Estudiante(string matricula,
            string curp, 
            string nombre, 
            string apellido_paterno, 
            string apellido_materno, 
            string email, 
            string foto, 
            string tutor, 
            Programa programa) : base(curp, nombre, apellido_paterno, apellido_materno, email)
        {
            this._foto = foto;
            this._tutor = tutor;
            this._matricula = matricula;
            this._inscripcion = new List<InscripcionActual>();
            this._programa=programa;
        }
    }
}
