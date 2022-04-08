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
    public class DaoReservacionCitaPaciente
    {
        /* Variable de Conexion SQL */
        SqlConnection cone = new SqlConnection
                (ConfigurationManager.ConnectionStrings["myconex"]
                .ConnectionString);

        public DataTable listarTabla(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("listarReservacionCita @NombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ConsultarCodigoExistente(EntidadReservacionCitaPaciente objc)
        {
            SqlDataAdapter da = new SqlDataAdapter("validacionCodigo @Codigo", cone);
            da.SelectCommand.Parameters.AddWithValue("@Codigo", objc.codigo);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarDatosPaciente(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec ListarDatosPaciente @NombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable ListadoFacturaPaciente(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec ListadoFacturaPaciente @NombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public DataTable listarEspecialidadPaciente()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarEspecialidadPaciente", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarMedicoPaciente(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec listarMedicoPaciente @especialidad", cone);
            da.SelectCommand.Parameters.AddWithValue("@especialidad", ci.idEspecialidad);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public DataTable listarTurnoPaciente()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarTurnoPaciente", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public DataTable listarEstado()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarEstadoPago", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarFiltroPago(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec listarPorEstadoPago @NombreUsuario, @idEstadoPago", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            da.SelectCommand.Parameters.AddWithValue("@idEstadoPago", ci.idEstadoPago);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarReservacionCitaCompleto(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("listarReservacionCitaCompleto @NombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public string insertar(EntidadReservacionCitaPaciente obj)
        {
            string rpta = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "RegistrarReservacionCita";
                cmd.Parameters.AddWithValue("@idPaciente", obj.idPaciente);
                cmd.Parameters.AddWithValue("@idMedico", obj.idMedico);
                cmd.Parameters.AddWithValue("@idTurno", obj.idTurno);
                cmd.Parameters.AddWithValue("@fecha", obj.fecha);
                cmd.Parameters.AddWithValue("@idEstadoCita", obj.idEstadoCita);
                cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@idEstadoPago", obj.idEstadoPago);
                cmd.Parameters.AddWithValue("@idCodPagos", obj.idCodPagos);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cone;
                cone.Open();
                cmd.ExecuteNonQuery();
                cone.Close();
                cmd.Dispose();
                rpta = "¡Se registro con exito!";

            }
            catch (SqlException ex)
            {
                rpta = "Error al Grabar: " + ex.Message;
            }
            return rpta;
        }

        /*HISTORIA CLINICA*/

        public DataTable ListarHistorialPaciente(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec ListarHistorialMedico @NombreUsuario", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }




        public DataTable listarFiltroEspecialidad(EntidadReservacionCitaPaciente ci)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec listarFiltroEspecialidad @NombreUsuario, @idespecialidad", cone);
            da.SelectCommand.Parameters.AddWithValue("@NombreUsuario", ci.usuario);
            da.SelectCommand.Parameters.AddWithValue("@idespecialidad", ci.idEspecialidad);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }





        public int ModificarEstado(EntidadReservacionCitaPaciente objC)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Actualizar";
                cmd.Parameters.AddWithValue("@idCita", objC.idCita);
                cmd.Parameters.AddWithValue("@CodigoPago", objC.idCodPagos);
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

