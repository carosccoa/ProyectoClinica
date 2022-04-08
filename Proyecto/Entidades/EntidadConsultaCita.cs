using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadConsultaCita
    {
        /* USUARIO */
        public string nombreUsuario { set; get; }

        /* LISTADO */
        public int idCita { set; get; }
        public string especialidad { set; get; }
        public string medico { set; get; }
        public string fecha { set; get; }
        public string paciente { set; get; }
        public string estado { set; get; }

        /* CONSULTAS */
        public int idArea { set; get; }
        public int idEspecialidad { set; get; }
        public DateTime fechaIni { set; get; }
        public DateTime fechaFin { set; get; }
        public string dniPaciente { set; get; }
        public int idEstado { set; get; }

        /* REGISTRO HISTORIA CLINICA */
        public string resultadoCita { set; get; }
        public string medicacion { set; get; }
    }
}

