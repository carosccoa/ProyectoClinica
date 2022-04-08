using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadMedico
    {
       public int idMedico { set; get; }
        public int idEspecialidad { set; get; }
        public string generoMedico { set; get; }
        public string nombreMedico { set; get; }
        public string apellidoMaternoMedico { set; get; }
        public string apellidoPaternoMedico { set; get; }
        public string correoMedico { set; get; }
        public string DNIMedico { set; get; }
        public string celularMedico { set; get; }

    }
}