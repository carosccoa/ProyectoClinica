using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadConsulta
    {
        public string DNIPaciente { set; get; }
        public string medico { set; get; }
        public string paciente { set; get; }
        public string especialidad { set; get; }
        public string areaMedica { set; get; }
        public string estado { set; get; }
        public string estadoHabitacion { set; get; }
        public string numeroHabitacion { set; get; }
        public string pisoHabitacion { set; get; }
        public string pabellonHabitacion { set; get; }
    }
}