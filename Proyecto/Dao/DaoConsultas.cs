using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Proyecto.Entidades;
namespace Proyecto.Dao
{
    public class DaoConsultas
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);
        public DataTable consultaCitaMed(EntidadConsulta ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("consultaCitaMedica", con);
            da.SelectCommand.Parameters.AddWithValue("@dni", ci.DNIPaciente);
            da.SelectCommand.Parameters.AddWithValue("@estado", ci.estado);
            da.SelectCommand.Parameters.AddWithValue("@area", ci.areaMedica);
            da.SelectCommand.Parameters.AddWithValue("@especialidad", ci.especialidad);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*Listar INDEX Cita*/
        public DataTable indexCita()
        {
            SqlDataAdapter da = new SqlDataAdapter("indexCitaMedica", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*Listar INDEX Disponibilidad de Habitacion*/
        public DataTable indexDisHab()
        {
            SqlDataAdapter da = new SqlDataAdapter("indexChDisponible", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*CONSULTA DISPONIBILIDAD DE HABITACION*/
        public DataTable consultaHabitacion(EntidadConsulta ch)
        {
            SqlDataAdapter da = new SqlDataAdapter("chDisponible", con);
            da.SelectCommand.Parameters.AddWithValue("@especialidad", ch.especialidad);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*CONSULTAR HOSPITALIZACION*/
        public DataTable consultaHospitalizacion(EntidadConsulta ech)
        {
            SqlDataAdapter da = new SqlDataAdapter("consultaHospitalizacion", con);
            da.SelectCommand.Parameters.AddWithValue("@dni", ech.DNIPaciente);
            da.SelectCommand.Parameters.AddWithValue("@medico", ech.medico);
            da.SelectCommand.Parameters.AddWithValue("@habitacion", ech.numeroHabitacion);
            da.SelectCommand.Parameters.AddWithValue("@paciente", ech.paciente);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*CONSULTAR HISTORIAL MEDICO DE HOSPITALIZACION*/
        public DataTable conHisMedtaHospitalizacion(EntidadConsulta echm)
        {
            SqlDataAdapter da = new SqlDataAdapter("consultarHisHospitalizacion", con);
            da.SelectCommand.Parameters.AddWithValue("@dni", echm.DNIPaciente);
            da.SelectCommand.Parameters.AddWithValue("@paciente", echm.paciente);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*CONSULTAR estado*/
        public DataSet listarEstado()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstadoCita", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        /*Index Historial Medico*/
        public DataTable indexHisMedico()
        {
            SqlDataAdapter da = new SqlDataAdapter("indexHisMedico", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        /*Index Hospitalizacion*/
        public DataTable indexHospitalizacion()
        {
            SqlDataAdapter da = new SqlDataAdapter("indexHospitalizacion", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



    }
}