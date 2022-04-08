using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadHospitalizacionAdministrador
    {
        public int idHospitalizacion { set; get; }
        public string Enfermero { set; get; }
        public string habitaciondis { set; get; }
        public int idHabitacion { set; get; }
        public string Diagnostico { set; get; }
        public int estadoHabitacion { set; get; }
        public int idMedico { set; get; }
        public string Tratamiento { set; get; }
        public int idPacienteHos { set; get; }
        public string pabellon { set; get; }
        public DateTime FechaIngreso { set; get; }
        public DateTime FechaSalida { set; get; }
        public DateTime FechaModificacion { set; get; }

    }
}