using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadPaciente
    {
        public int idPaciente { set; get; }
        public string nombrePaciente { set; get; }
        public string apellidoPaternoPaciente { set; get; }
        public string apellidoMaternoPaciente { set; get; }
        public string correoPaciente { set; get; }
        public string generoPaciente { set; get; }
        public string DNIPaciente { set; get; }
        public string CelularPaciente { set; get; }
        public string estadoCivilPaciente { set; get; }
        public string fechaNacimiento { set; get; }
        public string edadPaciente { set; get; }
    }
}