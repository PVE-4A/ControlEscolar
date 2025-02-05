﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscolar.Models
{
    internal class GrupoMateria
    {
        private int _idGrupoMateria;
        public int idGrupoMateria
        {
            get { return _idGrupoMateria; }
            set { _idGrupoMateria = value; }
        }
        
        private string? _horario;
        private string? _docente;
        private Grupo _grupo;
        private Materia _materia;
        private Programa _programa;
        public Programa programa
        {
            get { return _programa; }
            set { _programa = value; }
        }
        

        public GrupoMateria(int idGrupoMateria,Materia materia, Grupo grupo, Programa programa)
        {
            _idGrupoMateria=idGrupoMateria;
            this._materia = materia;
            this._grupo = grupo;
            this._programa=programa;
        }

        public GrupoMateria(int idGrupoMateria,Materia materia, Grupo grupo,Programa programa, string docente, string horario) : this(idGrupoMateria,materia, grupo, programa)
        {
            this._docente = docente;
            this._horario = horario;
        }

        public Materia materia
        {
            get { return _materia; }
            set { _materia = value; }
        }


        public Grupo grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }


        public string docente
        {
            get { return _docente; }
            set { _docente = value; }
        }

        public string horario
        {
            get { return _horario; }
            set { _horario = value; }
        }
        public override string ToString()
        {
            return $"Id: {_idGrupoMateria}, Materia: {_materia.nombreMateria}, Grupo:{_grupo.grado+_grupo.nombre}";
        }
    }
}
