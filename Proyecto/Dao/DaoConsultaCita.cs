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
    public class DaoConsultaCita
    {
        /* Variable de Conexion SQL */
        SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        /* LISTADO DE CITAS DE HOY */
        public DataTable listadoCita(EntidadConsultaCita objCita)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.pa_listadoCita @nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objCita.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* LISTADO DE CITAS PROXIMAS */
        public DataTable citasProximas(EntidadConsultaCita objCita)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.pa_proximasCitas @nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objCita.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* CONSULTA POR DNI */
        public DataTable consultaDNI(EntidadConsultaCita objCita)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.consultaDNI @dni,@nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@dni", objCita.dniPaciente);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objCita.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* MODIFICAR CITA MEDICA */
        public int modificarCitaMedica(EntidadConsultaCita objCita)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "pa_modificarCitaMedica";
                cmd.Parameters.AddWithValue("@id", objCita.idCita);
                cmd.Parameters.AddWithValue("@estadoCita", objCita.idEstado);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cone;
                cone.Open();
                cmd.Dispose();

                i = cmd.ExecuteNonQuery();

                cone.Close();
            }
            catch (SqlException ex)
            {
                return 0;
            }
            return i;
        }

        /* CARGAR DATOS AL DROPDOWNLIST AREA */
        public DataSet cargarArea()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AreaMedica", cone);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /* CARGAR DATOS AL DROPDOWNLIST ESPECIALIDAD */
        public DataSet cargarEspecialidad()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Especialidad", cone);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        /* CARGAR DATOS AL DROPDOWNLIST ESTADO */
        public DataSet cargarEstado()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstadoCita", cone);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        /* AGREGAR HISTORIA CLINICA */
        public int agregarModCitaHC(EntidadConsultaCita objCita)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "pa_agregarModCitaHC";
                cmd.Parameters.AddWithValue("@resultadoCita", objCita.resultadoCita);
                cmd.Parameters.AddWithValue("@medicacion", objCita.medicacion);
                cmd.Parameters.AddWithValue("@idCita", objCita.idCita);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cone;
                cone.Open();
                cmd.Dispose();

                i = cmd.ExecuteNonQuery();

                cone.Close();
            }
            catch (SqlException ex)
            {
                return 0;
            }
            return i;
        }
    }
}

