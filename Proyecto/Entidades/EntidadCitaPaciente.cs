using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadCitaPaciente
    {
        public int idCita { set; get; }
        public string idPaciente { set; get; }
        public string idTurno { set; get; }
        public string fecha { set; get; }
        public string descripcion { set; get; }
        public string idEstado { set; get; }
        public string DNIPaciente { set; get; }
        public string fechaRef { set; get; }
    }
}