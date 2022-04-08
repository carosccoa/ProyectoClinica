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
    public class DaoHospitalizacionAdministrador
    {
        SqlConnection cone = new SqlConnection
      (ConfigurationManager.ConnectionStrings["myconex"]
      .ConnectionString);

        public DataTable listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("ListarHozpitalizacionAdministardor", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarPabellonAdministrador()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarPabellon", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarHabitacion(EntidadHospitalizacionAdministrador erc)
        {
            SqlDataAdapter da = new SqlDataAdapter("listarHabitacion", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable listarHabitacionDisponible(EntidadHospitalizacionAdministrador erc)
        {
            SqlDataAdapter da = new SqlDataAdapter("listarHabitacionDisponible", cone);
            da.SelectCommand.Parameters.AddWithValue("@pabellon", erc.pabellon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int modificarHabitacion(EntidadHospitalizacionAdministrador objC)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "ModificarHospitalizacion";
                cmd.Parameters.AddWithValue("@idhospitalizacion", objC.idHospitalizacion);
                cmd.Parameters.AddWithValue("@enfermero", objC.Enfermero);
                cmd.Parameters.AddWithValue("@idHabitacion", objC.idHabitacion);
                cmd.Parameters.AddWithValue("@estado", objC.estadoHabitacion);
                cmd.Parameters.AddWithValue("@habitacion", objC.habitaciondis);
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