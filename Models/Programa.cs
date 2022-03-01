namespace Ejercicio3
{
    class Programa
    {
        private string _id_programa;
        private string _nombre_programa;

        private Unidad _unidad;
        public Unidad unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }
        

        public Programa(string id_programa, string nombre_programa,Unidad unidad)
        {
            _id_programa = id_programa;
            _nombre_programa = nombre_programa;
            _unidad = unidad;
        }

        public string nombre_programa
        {
            get { return _nombre_programa; }
            set { _nombre_programa = value; }
        }
        
        public string id_programa
        {
            get { return _id_programa; }
            set { _id_programa = value; }
        }
    }
}