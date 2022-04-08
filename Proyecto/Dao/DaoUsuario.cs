using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using Proyecto.Entidades;
using System.Data.SqlClient;
namespace Proyecto.Dao
{
    public class DaoUsuario
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconex"].ConnectionString);

        public String insertarUsuario(EntidadUsuario objUs)
        {
           
            String rpta = "";

            try
            {
                //Crear Objeto comando
                SqlCommand cmd = new SqlCommand();
                //Crear Sentencia SQL
                cmd.CommandText = "execute registrarUsuario @paswordUsuario,@nombreUsuario,@idRolUsuario,@idPropietario";
                //Referenciar o pasar parametros del comando
                cmd.Parameters.AddWithValue("@paswordUsuario", objUs.paswordUsuario);
                cmd.Parameters.AddWithValue("@nombreUsuario", objUs.nombreUsuario);
                cmd.Parameters.AddWithValue("@idRolUsuario", objUs.idRolUsuario);
                cmd.Parameters.AddWithValue("@idPropietario", objUs.idPropietario);

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