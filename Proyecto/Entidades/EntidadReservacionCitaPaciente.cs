using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadReservacionCitaPaciente
    {
        public int idCita { set; get; }
        public int idPaciente { set; get; }
        public int idMedico { set; get; }
        public int idTurno { set; get; }
        public string fecha { set; get; }
        public string idEstadoCita { set; get; }
        public string descripcion { set; get; }
        public string idEstadoPago { set; get; }
        public string idCodPagos { set; get; }
        public string usuario { set; get; }
        public string codigo { set; get; }
        public int idEspecialidad { set; get; }
    }
}

