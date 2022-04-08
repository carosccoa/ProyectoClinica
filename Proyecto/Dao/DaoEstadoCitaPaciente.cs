using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Proyecto.Entidades;
namespace Proyecto
{
    public class DaoEstadoCitaPaciente
    {
        SqlConnection cone = new SqlConnection
            (ConfigurationManager.ConnectionStrings["myconex"]
            .ConnectionString);

        public DataTable listar()
        {
            SqlDataAdapter da = new SqlDataAdapter("listarEstadoPaciente", cone);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}