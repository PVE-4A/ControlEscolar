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
                Console.WriteLine("2.- Administración de Estudiantes");
                Console.WriteLine("3.- Inscripciones");
                Console.WriteLine("4.- Salir");
            } while (!validaMenu(4, ref opcionSeleccionada));
            switch (opcionSeleccionada)
            {

                case 1:
                    showMenuAdminGrupos();
                    break;
                case 2:
                    showMenuAdminEstudiantes();
                    break;
                case 3: break;
                case 4: break;
            }
        }

        private void showMenuAdminEstudiantes()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Administración de Estudiantes");
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
                    listarEstudiantes();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    showMenuAdminEstudiantes();
                    break;
                case 2:
                    crearEstudiante();
                    break;
                case 3:
                    editarEstudiante();
                    break;
                case 4:
                    eliminarEstudiante();
                    break;
                case 5:
                    showMenuPrincipal();
                    break;
            }
        }

        private void listarEstudiantes()
        {
            Console.WriteLine("Lista de Estudiantes");
            foreach (Estudiante item in _estudiantes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void eliminarEstudiante()
        {
            string? matricula;
            listarEstudiantes();
            matricula = pedirValorString("Escribe la Matrícula del Estudiante a Eliminar");
            Estudiante? estudiante = _estudiantes.FirstOrDefault(e => e.matricula == matricula);
            if (estudiante == null)
            {
                Console.WriteLine("No se encontró el Estudiante. Presiona 'Enter' para continuar...");
            }
            else
            {
                _estudiantes.Remove(estudiante);
                Console.WriteLine($"El Estudiante con Matrícula: {estudiante.matricula} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            showMenuAdminEstudiantes();
        }

        private void editarEstudiante()
        {
            string? matricula;
            string? curp;
            string? nombre;
            string? apaterno;
            string? amaterno;
            string? email;
            Console.WriteLine("Editar de Estudiante");
            listarEstudiantes();
            matricula = pedirValorString("Matrícula del Estudiante a Editar");
            Estudiante? estudiante = _estudiantes.FirstOrDefault(e => e.matricula == matricula);
            if (estudiante == null)
            {
                Console.WriteLine("No se encontró el Estudiante. Presiona 'Enter' para continuar...");
            }
            else
            {
                curp = pedirValorString("Curp");
                nombre = pedirValorString("Nombre");
                apaterno = pedirValorString("Apellido Paterno");
                amaterno = pedirValorString("Apellido Materno");
                email = pedirValorString("Email");
                estudiante.curp=curp;
                estudiante.nombre=nombre;
                estudiante.apellido_paterno=apaterno;
                estudiante.apellido_materno=amaterno;
                estudiante.email=email;
                Console.WriteLine($"El Estudiante con Matrícula: {estudiante.matricula} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            showMenuAdminEstudiantes();
        }

        private void crearEstudiante()
        {
            string? matricula;
            string? curp;
            string? nombre;
            string? apaterno;
            string? amaterno;
            string? email;
            string? idPrograma;
            Console.WriteLine("Alta de Estudiante");
            matricula = pedirValorString("Matricula");
            curp = pedirValorString("Curp");
            nombre = pedirValorString("Nombre");
            apaterno = pedirValorString("Apellido Paterno");
            amaterno = pedirValorString("Apellido Materno");
            email = pedirValorString("Email");
            Console.Clear();
            listarProgramas();
            idPrograma = pedirValorString("Id del programa al que pertenece el Estudiante");
            Programa? programa = _programas.FirstOrDefault(p => p.id_programa == idPrograma);
            if (programa == null)
            {
                Console.WriteLine("No se encontró el Programa. Presiona 'Enter' para continuar...");
            }
            else
            {
                
                Estudiante nuevoEstudiante = new Estudiante(matricula, curp, nombre, apaterno, amaterno, email, null, null, programa);
                _estudiantes.Add(nuevoEstudiante);
                Console.WriteLine("Estudiante registrado correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            showMenuAdminEstudiantes();
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
                case 3:
                    crudCiclos();
                    break;
                case 4:
                    crudMaterias();
                    break;
                case 5:
                    crudGrupos();
                    break;
                case 6:
                    showMenuPrincipal();
                    break;
            }
        }
        private void crudGrupos()
        {
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Grupos");
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
                    listarGrupos();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudGrupos();
                    break;
                case 2:
                    crearGrupo();
                    break;
                case 3:
                    editarGrupo();
                    break;
                case 4:
                    eliminarGrupo();
                    break;
                case 5:
                    showMenuAdminGrupos();
                    break;
            }
        }

        private void eliminarGrupo()
        {
            int? id;
            listarGrupos();
            id = pedirValorInt("Escribe el Id del Grupo a Eliminar");
            Grupo? grupoEliminar = _grupos.FirstOrDefault(g => g.id_grupo == id);
            if (grupoEliminar == null)
            {
                Console.WriteLine("No se encontró el Grupo. Presiona 'Enter' para continuar...");
            }
            else
            {
                _grupos.Remove(grupoEliminar);
                Console.WriteLine($"El Grupo con id: {grupoEliminar.id_grupo} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudMaterias();
        }

        private void editarGrupo()
        {
            int? id;
            string? grado;
            string? nombre;
            listarGrupos();
            id = pedirValorInt("Escribe el Id del Grupo a Editar");
            Grupo? grupoEdicion = _grupos.FirstOrDefault(g => g.id_grupo == id);
            if (grupoEdicion == null)
            {
                Console.WriteLine("No se encontró el Grupo. Presiona 'Enter' para continuar...");
            }
            else
            {
                grado = pedirValorString("Grado");
                nombre = pedirValorString("Nombre");
                grupoEdicion.grado = grado;
                grupoEdicion.nombre = nombre;
                Console.WriteLine($"El Grupo con id: {grupoEdicion.id_grupo} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudGrupos();
        }

        private void crearGrupo()
        {
            string? grado;
            string? nombre;
            Console.WriteLine("Alta de Grupo");
            grado = pedirValorString("Grado");
            nombre = pedirValorString("Nombre");
            Grupo nuevoGrupo = new Grupo(_grupos.Count() + 1, grado, nombre);
            _grupos.Add(nuevoGrupo);
            Console.WriteLine("Grupo creada correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            crudGrupos();
        }

        private void listarGrupos()
        {
            Console.WriteLine("Lista de Grupos");
            foreach (Grupo item in _grupos)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private void crudMaterias()
        {
            string? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Materias");
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
                    listarMaterias();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudMaterias();
                    break;
                case 2:
                    crearMateria();
                    break;
                case 3:
                    editarMateria();
                    break;
                case 4:
                    eliminarMateria();
                    break;
                case 5:
                    showMenuAdminGrupos();
                    break;
            }
        }

        private void eliminarMateria()
        {
            string? id;
            listarCiclos();
            id = pedirValorString("Escribe el Id del CIclo Escolar a Eliminar");
            Materia? materiaEliminar = _materias.FirstOrDefault(m => m.idMateria == id);
            if (materiaEliminar == null)
            {
                Console.WriteLine("No se encontró el Ciclo Escolar. Presiona 'Enter' para continuar...");
            }
            else
            {
                _materias.Remove(materiaEliminar);
                Console.WriteLine($"La Materia con id: {materiaEliminar.idMateria} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudMaterias();
        }

        private void editarMateria()
        {
            string? id;
            string? nombre;
            listarMaterias();
            id = pedirValorString("Escribe el Id de la Materia a Editar");
            Materia? materiaEdicion = _materias.FirstOrDefault(m => m.idMateria == id);
            if (materiaEdicion == null)
            {
                Console.WriteLine("No se encontró la Materia. Presiona 'Enter' para continuar...");
            }
            else
            {
                nombre = pedirValorString("Nombre");
                materiaEdicion.nombreMateria = nombre;
                Console.WriteLine($"La Materia con id: {materiaEdicion.nombreMateria} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudMaterias();
        }

        private void crearMateria()
        {
            string? id;
            string? nombre;
            Console.WriteLine("Alta de Materia");
            id = pedirValorString("Id");
            nombre = pedirValorString("Nombre");
            Materia nuevaMateria = new Materia(id, nombre);
            _materias.Add(nuevaMateria);
            Console.WriteLine("Materia creada correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            crudMaterias();
        }

        private void listarMaterias()
        {
            Console.WriteLine("Lista de Materias");
            foreach (Materia item in _materias)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private void crudCiclos()
        {
            string? id;
            string? nombre;
            int opcionSeleccionada = 0;
            Console.Clear();
            do
            {
                Console.WriteLine("Ciclos Escolares");
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
                    listarCiclos();
                    Console.WriteLine("Presiona 'Enter' para continuar...");
                    Console.ReadLine();
                    crudUnidades();
                    break;
                case 2:
                    crearCiclos();
                    break;
                case 3:
                    editarCiclos();
                    break;
                case 4:
                    eliminarCiclos();
                    break;
                case 5:
                    showMenuAdminGrupos();
                    break;
            }
        }

        private void eliminarCiclos()
        {
            string? id;
            listarCiclos();
            id = pedirValorString("Escribe el Id del CIclo Escolar a Eliminar");
            CicloEscolar? cicloEliminar = _ciclos.FirstOrDefault(c => c.idCiclo == id);
            if (cicloEliminar == null)
            {
                Console.WriteLine("No se encontró el Ciclo Escolar. Presiona 'Enter' para continuar...");
            }
            else
            {
                _ciclos.Remove(cicloEliminar);
                Console.WriteLine($"El Ciclo Escolar con id: {cicloEliminar.idCiclo} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudCiclos();
        }

        private void editarCiclos()
        {
            string? id;
            string? nombre;
            listarCiclos();
            id = pedirValorString("Escribe el Id del Ciclo Escolar a Editar");
            CicloEscolar? cicloEdicion = _ciclos.FirstOrDefault(c => c.idCiclo == id);
            if (cicloEdicion == null)
            {
                Console.WriteLine("No se encontró el Ciclo Escolar. Presiona 'Enter' para continuar...");
            }
            else
            {
                nombre = pedirValorString("Nombre");
                cicloEdicion.Descripcion = nombre;
                Console.WriteLine($"El Ciclo Escolar con id: {cicloEdicion.idCiclo} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudCiclos();
        }

        private void crearCiclos()
        {
            string? id;
            string? nombre;
            Console.WriteLine("Alta de Ciclo Escolar");
            id = pedirValorString("Id");
            nombre = pedirValorString("Nombre");
            CicloEscolar nuevoCiclo = new CicloEscolar(id, nombre);
            _ciclos.Add(nuevoCiclo);
            Console.WriteLine("Ciclo Escolar creado correctamente. Presiona 'Enter' para continuar...");
            Console.ReadLine();
            crudCiclos();
        }

        private void listarCiclos()
        {
            Console.WriteLine("Lista de Ciclos Escolares");
            foreach (CicloEscolar item in _ciclos)
            {
                Console.WriteLine(item.ToString());
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
                    if (_unidades.Count() > 0)
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
            id = pedirValorString("Escribe el Id del Programa a Eliminar");
            Programa? programaEliminar = _programas.FirstOrDefault(u => u.id_programa == id);
            if (programaEliminar == null)
            {
                Console.WriteLine("No se encontró el Programa. Presiona 'Enter' para continuar...");
            }
            else
            {
                _programas.Remove(programaEliminar);
                Console.WriteLine($"El programa con id: {programaEliminar.id_programa} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudUnidades();
        }

        private void editarPrograma()
        {
            string? id;
            string? nombre;
            listarProgramas();
            id = pedirValorString("Escribe el Id del Programa a Editar");
            Programa? programaEdicion = _programas.FirstOrDefault(u => u.id_programa == id);
            if (programaEdicion == null)
            {
                Console.WriteLine("No se encontró el Programa. Presiona 'Enter' para continuar...");
            }
            else
            {
                nombre = pedirValorString("Nombre");
                programaEdicion.nombre_programa = nombre;
                Console.WriteLine($"El programa con id: {programaEdicion.id_programa} se editó correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudProgramas();

        }

        private void crearPrograma()
        {
            string? id;
            string? nombre;
            string? idUnidad;
            Console.WriteLine("Alta de Programa");
            id = pedirValorString("Id");
            nombre = pedirValorString("Nombre");
            Console.Clear();
            listarUnidades();
            idUnidad = pedirValorString("Escribe el Id de la Unidad a la que pertenece el Programa");
            Unidad? unidad = _unidades.FirstOrDefault(u => u.id_undidad == idUnidad);
            if (unidad == null)
            {
                Console.WriteLine("No se encontró la Unidad. Presiona 'Enter' para continuar...");
            }
            else
            {
                Programa nuevoPrograma = new Programa(id, nombre, unidad);
                _programas.Add(nuevoPrograma);
                Console.WriteLine("Programa creado correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudProgramas();
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
            id = pedirValorString("Escribe el Id de la Unidad a Editar");
            Unidad? unidadEliminar = _unidades.FirstOrDefault(u => u.id_undidad == id);
            if (unidadEliminar == null)
            {
                Console.WriteLine("No se encontró la Unidad. Presiona 'Enter' para continuar...");
            }
            else
            {
                _unidades.Remove(unidadEliminar);
                Console.WriteLine($"La unidad con id: {unidadEliminar.id_undidad} se eliminó correctamente. Presiona 'Enter' para continuar...");
            }

            Console.ReadLine();
            crudUnidades();
        }

        private void editarUnidad()
        {
            string? id;
            string? nombre;
            listarUnidades();
            id = pedirValorString("Escribe el Id de la Unidad a Editar");
            Unidad? unidadEdicion = _unidades.FirstOrDefault(u => u.id_undidad == id);
            if (unidadEdicion == null)
            {
                Console.WriteLine("No se encontró la Unidad. Presiona 'Enter' para continuar...");

            }
            else
            {
                nombre = pedirValorString("Nombre");
                unidadEdicion.nombre_unidad = nombre;
                Console.WriteLine($"La unidad con id: {unidadEdicion.id_undidad} se editó correctamente. Presiona 'Enter' para continuar...");
            }
            Console.ReadLine();
            crudUnidades();

        }

        private void crearUnidad()
        {
            string? id;
            string? nombre;
            Console.WriteLine("Alta de Unidad");
            id = pedirValorString("Id");
            nombre = pedirValorString("Nombre");
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
        private string pedirValorString(string texto)
        {
            string? valor;
            do
            {
                Console.Write($"{texto}: ");
                valor = Console.ReadLine();
                if (valor == null || valor == "")
                {
                    Console.WriteLine("Valor inválido.");
                }
            } while (valor == null || valor == "");
            return valor;
        }
        private int pedirValorInt(string texto)
        {
            int valor;
            Console.Write($"{texto}: ");
            while (int.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Debes ingresar un número.");
                Console.Write($"{texto}: ");
            }
            return valor;
        }
        public void inicializarDatos()
        {
            Unidad unidad = new Unidad("U1", "Unidad Académica de Ingeniería Electrica");
            _unidades.Add(unidad);
            Programa programa1 = new Programa("P1", "Ingeniería en Computación", unidad);
            Programa programa2 = new Programa("P2", "Ingeniería en Software", unidad);
            _programas.Add(programa1);
            _programas.Add(programa2);
            CicloEscolar ciclo = new CicloEscolar("2122SPAR", "Enero - Julio de 2022");
            _ciclos.Add(ciclo);
            Materia materia1 = new Materia("PVE", "Programación Visual y por Eventos");
            Materia materia2 = new Materia("POO", "Programación Orientada a Objetos");
            _materias.Add(materia1);
            _materias.Add(materia2);
            Grupo grupo1 = new Grupo(1, "4", "A");
            Grupo grupo2 = new Grupo(2, "4", "B");
            _grupos.Add(grupo1);
            _grupos.Add(grupo2);
            Estudiante estudiante1 = new Estudiante("22300348","SDT870818LU","Sergio","Duron","Torres","temporal@temp.com",null,null,programa1);
            Estudiante estudiante2 = new Estudiante("22300349","JPP880920MA","Jorge","Perez","Perez","temporal2@temp.com",null,null,programa2);
            _estudiantes.Add(estudiante1);
            _estudiantes.Add(estudiante2);
        }
    }

}