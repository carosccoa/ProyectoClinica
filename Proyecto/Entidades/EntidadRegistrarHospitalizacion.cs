using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Entidades
{
    public class EntidadRegistrarHospitalizacion
    {
        public string enfermero { set; get; }
        public int habitacion { set; get; }
        public string diagnostico { set; get; }
        public int paciente { set; get; }
        public int medico { set; get; }
        public string tratamiento { set; get; }
        public string pabellon { set; get; }
        public string dni { set; get; }
        /*REGISTRAR PACIENTE*/
        public string nomPH { set; get; }
        public string apePH { set; get; }
        public string apeMH { set; get; }
        public string genPH { set; get; }
        public string dniPH { set; get; }
        public string celPH { set; get; }
        public string fecNH { set; get; }
        public string edaPH { set; get; }
    }
}