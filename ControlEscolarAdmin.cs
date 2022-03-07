using ControlEscolar.Models;
namespace ControlEscolar
{
    class ControlEscolarAdmin
    {
        private List<CicloEscolar> _ciclos;
        private List<Unidad> _unidades;
        private List<Programa> _programas;
        private List<Materia> _materias;
        private List<Grupo> _grupos;
        private List<Estudiante> _estudiantes;
        private List<GrupoMateria> _grupoMateria;
        public ControlEscolarAdmin()
        {
            _ciclos = new List<CicloEscolar>();
            _unidades = new List<Unidad>();
            _programas = new List<Programa>();
            _materias = new List<Materia>();
            _grupos = new List<Grupo>();
            _estudiantes = new List<Estudiante>();
            _grupoMateria = new List<GrupoMateria>();
        }
        public void showMenuPrincipal()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Bienvenido al Sistema de Control Escolar");
                Console.WriteLine("1.- Administración de Grupos");
                Console.WriteLine("2.- Administración de Alumnos");
                Console.WriteLine("3.- Inscripciones");
                Console.WriteLine("4.- Salir");
            } while (!validaMenu(4, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    showMenuAdminGrupos();
                    break;
                case 2: break;
                case 3: break;
                case 4: break;
            }
        }

        private void showMenuAdminGrupos()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Administración de Grupos");
                Console.WriteLine("1.- Unidades");
                Console.WriteLine("2.- Programas");
                Console.WriteLine("3.- Ciclos Escolares");
                Console.WriteLine("4.- Materias");
                Console.WriteLine("5.- Grupos");
                Console.WriteLine("6.- Regresar...");
            } while (!validaMenu(6, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    crudUnidades();
                    break;
                case 2:
                    crudProgramas();
                    break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: break;
            }
        }

        private void crudProgramas()
        {
            string? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Progrmas");
                Console.WriteLine("1.- Listar");
                Console.WriteLine("2.- Crear");
                Console.WriteLine("3.- Editar");
                Console.WriteLine("4.- Eliminar");
                Console.WriteLine("5.- Regresar...");
            } while (!validaMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {

                case 1:
                    listarProgramas();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudUnidades();
                    break;
                case 2:
                    if(_unidades.Count()>0)
                        crearPrograma();
                    else
                    {
                        Console.WriteLine("No puedes crear un Programa si no existen Unidades previamente.Presiona 'Enter' para continuar...");
                        Console.ReadLine();
                        crudProgramas();
                    }
                    break;
                case 3:
                    editarPrograma();
                    break;
                case 4:
                    eliminarPrograma();
                    break;
                case 5:
                    showMenuAdminGrupos();
                    break;
            }
        }
        private void eliminarPrograma()
        {
            string? id = null;
            listarProgramas();
            do
            {
                Console.Write("Escribe el Id del Programa a Eliminar: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            Programa? programaEliminar = _programas.FirstOrDefault(u => u.id_programa == id);
            if (programaEliminar == null)
            {
                Console.WriteLine("No se encontró el Programa. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudUnidades();
            }
            else
            {
                _programas.Remove(programaEliminar);
                Console.WriteLine($"El programa con id: {programaEliminar.id_programa} se eliminó correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudProgramas();
            }

        }

        private void editarPrograma()
        {
            string? id;
            string? nombre;
            listarProgramas();
            do
            {
                Console.Write("Escribe el Id del Programa a Editar: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            Programa? programaEdicion = _programas.FirstOrDefault(u => u.id_programa == id);
            if (programaEdicion == null)
            {
                Console.WriteLine("No se encontró el Programa. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudProgramas();
            }
            else
            {
                nombre = null;
                do
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    if (nombre == null || nombre == "")
                    {
                        Console.Write("Nombre inválido.");
                    }
                } while (nombre == null || nombre == "");
                programaEdicion.nombre_programa = nombre;
                Console.WriteLine($"El programa con id: {programaEdicion.id_programa} se editó correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudProgramas();
            }

        }

        private void crearPrograma()
        {
            string? id;
            string? nombre;
            Console.WriteLine("Alta de Programa");
            do
            {
                Console.Write("Id: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                if (nombre == null || nombre == "")
                {
                    Console.Write("Nombre inválido.");
                }
            } while (nombre == null || nombre == "");
            Console.Clear();
            listarUnidades();
            do
            {
                Console.Write("Escribe el Id de la Unidad a la que pertenece el Programa: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            Unidad? unidad = _unidades.FirstOrDefault(u => u.id_undidad == id);
            if (unidad == null)
            {
                Console.WriteLine("No se encontró la Unidad. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudProgramas();
            }
            else
            {
                Programa nuevoPrograma = new Programa(id, nombre,unidad);
                _programas.Add(nuevoPrograma);
                Console.WriteLine("Programa creado correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudProgramas();
            }
        }

        private void listarProgramas()
        {
            Console.WriteLine("Lista de Programas");
            foreach (Programa item in _programas)
            {
                Console.WriteLine(item.ToString());
            }

        }
        private void crudUnidades()
        {
            string? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Unidades");
                Console.WriteLine("1.- Listar");
                Console.WriteLine("2.- Crear");
                Console.WriteLine("3.- Editar");
                Console.WriteLine("4.- Eliminar");
                Console.WriteLine("5.- Regresar...");
            } while (!validaMenu(5, ref opcionSeleccionada));
            Console.Clear();
            switch (opcionSeleccionada)
            {

                case 1:
                    listarUnidades();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudUnidades();
                    break;
                case 2:
                    crearUnidad();
                    break;
                case 3:
                    editarUnidad();
                    break;
                case 4:
                    eliminarUnidad();
                    break;
                case 5:
                    showMenuAdminGrupos();
                    break;
            }
        }

        private void eliminarUnidad()
        {
            string? id = null;
            listarUnidades();
            do
            {
                Console.Write("Escribe el Id de la Unidad a Editar: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            Unidad? unidadEliminar = _unidades.FirstOrDefault(u => u.id_undidad == id);
            if (unidadEliminar == null)
            {
                Console.WriteLine("No se encontró la Unidad. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudUnidades();
            }
            else
            {
                _unidades.Remove(unidadEliminar);
                Console.WriteLine($"La unidad con id: {unidadEliminar.id_undidad} se eliminó correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudUnidades();
            }

        }

        private void editarUnidad()
        {
            string? id;
            string? nombre;
            listarUnidades();
            do
            {
                Console.Write("Escribe el Id de la Unidad a Editar: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            Unidad? unidadEdicion = _unidades.FirstOrDefault(u => u.id_undidad == id);
            if (unidadEdicion == null)
            {
                Console.WriteLine("No se encontró la Unidad. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudUnidades();
            }
            else
            {
                nombre = null;
                do
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    if (nombre == null || nombre == "")
                    {
                        Console.Write("Nombre inválido.");
                    }
                } while (nombre == null || nombre == "");
                unidadEdicion.nombre_unidad = nombre;
                Console.WriteLine($"La unidad con id: {unidadEdicion.id_undidad} se editó correctamente. Presiona 'Enter' para continuar...");
                Console.ReadLine();
                crudUnidades();
            }

        }

        private void crearUnidad()
        {
            string? id;
            string? nombre;
            Console.WriteLine("Alta de Unidad");
            do
            {
                Console.Write("Id: ");
                id = Console.ReadLine();
                if (id == null || id == "")
                {
                    Console.Write("Id inválido.");
                }
            } while (id == null || id == "");
            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                if (nombre == null || nombre == "")
                {
                    Console.Write("Nombre inválido.");
                }
            } while (nombre == null || nombre == "");
            Unidad nuevaUnidad = new Unidad(id, nombre);
            _unidades.Add(nuevaUnidad);
            Console.WriteLine("Unidad creada correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            crudUnidades();
        }

        private void listarUnidades()
        {
            Console.WriteLine("Lista de Unidades");
            foreach (Unidad item in _unidades)
            {
                Console.WriteLine(item.ToString());
            }

        }

        private bool validaMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opción Invalida.");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("El valor ingresado no es válido, debes ingresar un número.");
                return false;
            }
        }
    }
}