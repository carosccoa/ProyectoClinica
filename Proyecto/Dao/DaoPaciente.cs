using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Proyecto.Dao;
using Proyecto.Entidades;

namespace Proyecto.Dao
{
    public class DaoPaciente
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        //Metodo para insertar

        public String insertarPaciente(EntidadPaciente objPas)
        {

            String rpta = "";

            try
            {
                //Crear Objeto comando
                SqlCommand cmd = new SqlCommand();
                //Crear Sentencia SQL
                cmd.CommandText = "insert into Paciente values (@nombrePaciente,@apellidoPaternoPaciente,@apellidoMaternoPaciente,@correoPaciente," +
                    "@generoPaciente,@DNIPaciente,@CelularPaciente,@estadoCivilPaciente,@fechaNacimiento,@edadPaciente)";
                //Referenciar o pasar parametros del comando
                cmd.Parameters.AddWithValue("@nombrePaciente", objPas.nombrePaciente);
                cmd.Parameters.AddWithValue("@apellidoPaternoPaciente", objPas.apellidoPaternoPaciente);
                cmd.Parameters.AddWithValue("@apellidoMaternoPaciente", objPas.apellidoMaternoPaciente);
                cmd.Parameters.AddWithValue("@correoPaciente", objPas.correoPaciente);
                cmd.Parameters.AddWithValue("@generoPaciente", objPas.generoPaciente);
                cmd.Parameters.AddWithValue("@DNIPaciente", objPas.DNIPaciente);
                cmd.Parameters.AddWithValue("@CelularPaciente", objPas.CelularPaciente);
                cmd.Parameters.AddWithValue("@estadoCivilPaciente", objPas.estadoCivilPaciente);
                cmd.Parameters.AddWithValue("@fechaNacimiento", objPas.fechaNacimiento);
                cmd.Parameters.AddWithValue("@edadPaciente", objPas.edadPaciente);
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