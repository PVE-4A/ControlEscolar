namespace Ejercicio3
{
    class Unidad
    {
        private string _id_unidad;
        private string _nombre_unidad;

        public Unidad(string id_unidad, string nombre_unidad)
        {
            _id_unidad = id_unidad;
            _nombre_unidad = nombre_unidad;
        }

        public string nombre_unidad
        {
            get { return _nombre_unidad; }
            set { _nombre_unidad = value; }
        }
        
        public string id_undidad
        {
            get { return _id_unidad; }
            set { _id_unidad = value; }
        }      
    }
}