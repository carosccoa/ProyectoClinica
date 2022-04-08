using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadRegistrarCita
    {

        public int idPaciente { set; get; }
        public int idMedico { set; get; }
        public int idTurno { set; get; }
        public string fecha { set; get; }
        public int estadoCita { set; get; }
        public string descripcion { set; get; }
        public int idEspecialidad { set; get; }

    }
}