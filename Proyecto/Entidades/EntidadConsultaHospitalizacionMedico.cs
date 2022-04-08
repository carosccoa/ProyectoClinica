using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadConsultaHospitalizacionMedico
    {
        /* USUARIO */
        public string nombreUsuario { set; get; }

        /* LISTADO */
        public int idHospitalizacion { set; get; }
        public string Paciente { set; get; }
        public DateTime FechaIngreso { set; get; }
        public string Habitacion { set; get; }
        public string Enfermero { set; get; }
        public string Diagnostico { set; get; }
        public string Tratamiento { set; get; }
        public DateTime FechaSalida { set; get; }

        /* CONSULTAS */
        public string pabellonHabitacion { set; get; }
        public int numeroHabitacion { set; get; }
    }
}

