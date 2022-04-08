using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Proyecto.Entidades;

namespace Proyecto.Dao
{
    public class DaoRegistroMedicoAdministrador
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        //Metodo para insertar

        public String insertarPaciente(EntidadMedico objMedico)
        {

            String rpta = "";

            try
            {
                //Crear Objeto comando
                SqlCommand cmd = new SqlCommand();
                //Crear Sentencia SQL
                cmd.CommandText = "insert into Medico values (@idEspecialidad,@generoMedico,@nombreMedico,@apellidoPaternoMedico,@apellidoMaternoMedico,@correoMedico," +
                    "@DNIMedico,@CelularMedico)";
                //Referenciar o pasar parametros del comando
                cmd.Parameters.AddWithValue("@idEspecialidad", objMedico.idEspecialidad);
                cmd.Parameters.AddWithValue("@generoMedico", objMedico.generoMedico);
                cmd.Parameters.AddWithValue("@nombreMedico", objMedico.nombreMedico);
                cmd.Parameters.AddWithValue("@apellidoPaternoMedico", objMedico.apellidoPaternoMedico);
                cmd.Parameters.AddWithValue("@apellidoMaternoMedico", objMedico.apellidoMaternoMedico);
                cmd.Parameters.AddWithValue("@correoMedico", objMedico.correoMedico);
                cmd.Parameters.AddWithValue("@DNIMedico", objMedico.DNIMedico);
                cmd.Parameters.AddWithValue("@CelularMedico", objMedico.celularMedico);
                // Conectar el objeto de la conexion del comando
                cmd.Connection = con;
                //Abri conexion al servidor BD
                con.Open();
                //Enviar la orden al servidor
                cmd.ExecuteNonQuery();
                //Cerrar la conexion al servidor
                con.Close();
                //Liberar memoria del comando
                cmd.Dispose();
                //Enviar respuesta
                rpta = "Regisro Exitoso";
            }
            catch (SqlException ex)
            {
                rpta = "Error al grabar" + ex.Message;
            }

            return rpta;

        }



    }
}