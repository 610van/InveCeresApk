using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace InveCeresApk
{
    public class ClassControl
    {
        ClassConexion conexion = ClassConexion.getInstancia();
        public DataTable ControlDGB()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection con = conexion.crearConexion())
                {
                    string consulta = "SELECT * FROM Control";
                    dt = conexion.EjecutarConsulta(consulta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de la tabla Control." + ex.Message);
            }
            return dt;
        }
        public void insertaregistro(
            string nombre, string hectarea, string melgas, string tipoPiña, string referencias)
        {
            try
            {
                string consulta = $"INSERT INTO Control (Campo, Hectareas, Melgas, TipoPiña, Referencias) Values('{nombre}','{hectarea}','{melgas}','{tipoPiña}','{referencias}')";
                conexion.consultaSQL(consulta);
                MessageBox.Show("Exito en el registro");
            }
            catch (Exception ex) {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        public void eliminaregistro(
            string campo)
        {
            try
            {
                string consulta = $"DElETE FROM Control WHERE Campo='{campo}'";
                conexion.consultaSQL(consulta);
                MessageBox.Show("Registros eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        public void editarregistro(
            string campo, string hectarea, string melgas, string tipoPiña, string referencias)
        {
            try
            {
                string consulta = $"UPDATE Control SET Campo='{campo}', Hectareas= '{hectarea}', Melgas= '{melgas}', TipoPiña='{tipoPiña}', Referencias='{referencias}' WHERE Campo='{campo}'";
                conexion.consultaSQL(consulta);
                MessageBox.Show("Registro editado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        public List<string> ObtenerCamposDistintos()
        {
            List<string> listaCampos = new List<string>();
            try
            {
                string consulta = "SELECT DISTINCT Campo FROM Control";
                using (SQLiteConnection conn = ClassConexion.getInstancia().crearConexion())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(consulta, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaCampos.Add(reader["Campo"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de la tabla Control: " + ex.Message);
            }
            return listaCampos;
        }
        public DataTable Buscar(string VALOR1)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection con = conexion.crearConexion())
                {
                    string consulta = $"SELECT * FROM Control WHERE Campo LIKE '{ VALOR1}%'";
                    dt = conexion.EjecutarConsulta(consulta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de la tabla Control." + ex.Message);
            }
            return dt;
        }
    }
}