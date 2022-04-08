using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto.Entidades;

namespace Proyecto.Dao
{
    public class DaoCitaPaciente
    {

        SqlConnection cone = new SqlConnection
         (ConfigurationManager.ConnectionStrings["myconex"]
         .ConnectionString);



        public DataTable listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarTablaCitaPaciente", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable consultadniCita(EntidadCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec listarCitaPaciente @dni", cone);
            da.SelectCommand.Parameters.AddWithValue("@dni", ci.DNIPaciente);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ResultadoSegunDNI(EntidadCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec listarCitaNombre @dniPaciente", cone);
            da.SelectCommand.Parameters.AddWithValue("@dniPaciente", ci.DNIPaciente);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string insertar(EntidadCitaPaciente obj)
        {
            string rpta = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertarCitaPaciente";
                cmd.Parameters.AddWithValue("@idPaciente", obj.idPaciente);
                cmd.Parameters.AddWithValue("@idTurno", obj.idTurno);
                cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@idEstado", obj.idEstado);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cone;
                cone.Open();
                cmd.ExecuteNonQuery();
                cone.Close();
                cmd.Dispose();
                rpta = "Registro Exitoso";

            }
            catch (SqlException ex)
            {
                rpta = "Error al Grabar: " + ex.Message;
            }
            return rpta;
        }

        public DataTable listarTurno()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarTurnoPaciente", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable ConsultarFiltroCita(EntidadCitaPaciente objc)
        {
            SqlDataAdapter da = new SqlDataAdapter("ConsultarRangoFechaPaciente @dni,@fechainicial,@fechafinal", cone);
            da.SelectCommand.Parameters.AddWithValue("@dni", objc.DNIPaciente);
            da.SelectCommand.Parameters.AddWithValue("@fechainicial", objc.fecha);
            da.SelectCommand.Parameters.AddWithValue("@fechafinal", objc.fechaRef);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public int modificarEstado(EntidadCitaPaciente objC)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "ModificarCitaPaciente";
                cmd.Parameters.AddWithValue("@idCita", objC.idCita);
                cmd.Parameters.AddWithValue("@estado", objC.idEstado);

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