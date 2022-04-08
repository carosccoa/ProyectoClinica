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
    public class DaoRegistrarAdministrador
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);



        public DataTable resPacHosp(EntidadRegistrarHospitalizacion erh)
        {
            SqlDataAdapter da = new SqlDataAdapter("busPacHosp", con);
            da.SelectCommand.Parameters.AddWithValue("@dni", erh.dni);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int regHabO(EntidadRegistrarHospitalizacion rh)
        {
            int rp = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "regHabitacionO";
                cmd.Parameters.AddWithValue("@idHab", rh.habitacion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                rp = 1;
            }
            catch (Exception ex)
            {

            }
            return rp;
        }





        public string registrarCita(EntidadRegistrarCita rc)
        {
            string rpta = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "registrarCitaAdministrador";
                cmd.Parameters.AddWithValue("@idPaciente", rc.idPaciente);
                cmd.Parameters.AddWithValue("@idMedico", rc.idMedico);
                cmd.Parameters.AddWithValue("@idTurno", rc.idTurno);
                cmd.Parameters.AddWithValue("@fecha", rc.fecha);
                cmd.Parameters.AddWithValue("@idEstado", rc.estadoCita);
                cmd.Parameters.AddWithValue("@descripcion", rc.descripcion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                rpta = "¡Se registro con exito!";
            }
            catch (Exception ex)
            {
                rpta = "Error en:" + ex;
            }
            return rpta;
        }
        public DataTable listarEspecialidad()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarEspecialidad", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable listarMedicoEsp(EntidadRegistrarCita erc)
        {
            SqlDataAdapter da = new SqlDataAdapter("listarMedicoEsp", con);
            da.SelectCommand.Parameters.AddWithValue("@esp", erc.idEspecialidad);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /***/

        public DataTable listarAreaRegistro()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarAreaRegistro", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarEspecialidadRegistro(EntidadEspecialidad erc)
        {
            SqlDataAdapter da = new SqlDataAdapter("ListarEspecialidadRegistro", con);
            da.SelectCommand.Parameters.AddWithValue("@esp", erc.idAreaMedica);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /*INSERTAR HOSPITALIZACION*/
        public string registrarHospitalizacion(EntidadRegistrarHospitalizacion rh)
        {
            string rpta = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "registrarHospitalizacion";
                cmd.Parameters.AddWithValue("@enfermero", rh.enfermero);
                cmd.Parameters.AddWithValue("@habitacion", rh.habitacion);
                cmd.Parameters.AddWithValue("@diagnostico", rh.diagnostico);
                cmd.Parameters.AddWithValue("@medico", rh.medico);
                cmd.Parameters.AddWithValue("@paciente", rh.paciente);
                cmd.Parameters.AddWithValue("@tratamiento", rh.tratamiento);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                rpta = "¡Se registro con exito!";
            }
            catch (Exception ex)
            {
                rpta = "Error en:" + ex;
            }
            return rpta;
        }
        public DataTable listaMedico()
        {
            SqlDataAdapter ds = new SqlDataAdapter("listarMedico", con);
            ds.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }
        public DataTable listarArea()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarArea", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable listarHabitacionDis(EntidadRegistrarHospitalizacion erc)
        {
            SqlDataAdapter da = new SqlDataAdapter("listarHabitacionDis", con);
            da.SelectCommand.Parameters.AddWithValue("@pabellon", erc.pabellon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable resDNI(EntidadRegistrarHospitalizacion erh)
        {
            SqlDataAdapter da = new SqlDataAdapter("dniPaciente", con);
            da.SelectCommand.Parameters.AddWithValue("@dni", erh.dni);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int registrarPacienteHos(EntidadRegistrarHospitalizacion erp)
        {
            int rpta = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "registrarPacienteHosp";
                cmd.Parameters.AddWithValue("@nomPH", erp.nomPH);
                cmd.Parameters.AddWithValue("@apePH", erp.apePH);
                cmd.Parameters.AddWithValue("@apeMH", erp.apeMH);
                cmd.Parameters.AddWithValue("@genPH", erp.genPH);
                cmd.Parameters.AddWithValue("@dniPH", erp.dniPH);
                cmd.Parameters.AddWithValue("@celPH", erp.celPH);
                cmd.Parameters.AddWithValue("@fecPH", erp.fecNH);
                cmd.Parameters.AddWithValue("@edaPH", erp.edaPH);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                rpta = 1;
            }
            catch (Exception ex)
            {

            }
            return rpta;
        }
    }
}