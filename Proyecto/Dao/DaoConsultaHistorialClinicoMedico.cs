using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Proyecto.Entidades;

namespace Proyecto.Dao
{
    public class DaoConsultaHistorialClinicoMedico
    {
        /* Variable de Conexion SQL */
        SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        /* LISTADO DE CITAS DE HOY */
        public DataTable listadoHC(EntidadConsultaHistoriaClinicaMedico objHC)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.pa_listadoHistoriaClinica @nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHC.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* CONSULTA POR DNI */
        public DataTable consultaDNIhc(EntidadConsultaHistoriaClinicaMedico objHC)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.consultaDNIhc @dni, @nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@dni", objHC.dniPaciente);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHC.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

