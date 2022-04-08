using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Proyecto.Entidades;

namespace Proyecto.Dao
{
    public class DaoConsultaHospitalizacionMedico
    {
        /* Variable de Conexion SQL */
        SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        /* LISTADO DE HOSPITALIZACIONES */
        public DataTable listadoHospitalizacion(EntidadConsultaHospitalizacionMedico objHospitalizacion)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.pa_listadoHospitalizacion @nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHospitalizacion.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* Consulta por DNI paciente */
        public DataTable consultaDNIpaciente(EntidadConsultaHospitalizacionMedico objHospitalizacion)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.consultaDNIpaciente @dni,@nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@dni", objHospitalizacion.Paciente);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHospitalizacion.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* Consulta por Pabellon */
        public DataTable consultaPabellon(EntidadConsultaHospitalizacionMedico objHospitalizacion)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.consultaPabellon @pabellon,@nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@pabellon", objHospitalizacion.pabellonHabitacion);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHospitalizacion.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* Consulta por Habitacion */
        public DataTable consultaHabitacion(EntidadConsultaHospitalizacionMedico objHospitalizacion)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.consultaHabitacion @habitacion,@nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@habitacion", objHospitalizacion.numeroHabitacion);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHospitalizacion.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /* Consulta por Fecha de Ingreso */
        public DataTable consultaFechaIngreso(EntidadConsultaHospitalizacionMedico objHospitalizacion)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec dbo.consultaFechaIngreso @fecha,@nombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@fecha", objHospitalizacion.FechaIngreso);
            da.SelectCommand.Parameters.AddWithValue("@nombreUsuario", objHospitalizacion.nombreUsuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int modificarHospitalizacion(EntidadConsultaHospitalizacionMedico objHospitalizacion)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "pa_modificarHospitalizacion";
                cmd.Parameters.AddWithValue("@id", objHospitalizacion.idHospitalizacion);
                cmd.Parameters.AddWithValue("@diagnostico", objHospitalizacion.Diagnostico);
                cmd.Parameters.AddWithValue("@tratamiento", objHospitalizacion.Tratamiento);
                cmd.Parameters.AddWithValue("@fechaSalida", objHospitalizacion.FechaSalida);
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

