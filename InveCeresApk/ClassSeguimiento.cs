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
    public class ClassSeguimiento
    {
        ClassConexion conexion = ClassConexion.getInstancia();
        public DataTable SeguimientoDGB()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection con = conexion.crearConexion())
                {
                    string consulta = "SELECT * FROM Seguimiento";
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
            string nombreCampo, string productoAplicado, string fechaAplicacion, string seguimientoAplicado, string observaciones)
        {
            try
            {
                string consulta = $"INSERT INTO Seguimiento (NombreCampo, ProductoAplicado, FechaAplicacion, SeguimientoAplicacio, Observaciones) Values('{nombreCampo}','{productoAplicado}','{fechaAplicacion}','{seguimientoAplicado}','{observaciones}',)";
                conexion.consultaSQL(consulta);
                MessageBox.Show("Registro Guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        public void eliminaregistro(
            string nombrecampo)
        {
            try
            {
                string consulta = $"DElETE FROM Seguimiento WHERE NombreCampo='{nombrecampo}'";
                conexion.consultaSQL(consulta);
                MessageBox.Show("Registros eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        public void editarregistro(
            string nombreCampo, string ProductoAplicado, string fechaAplicacion, string SeguimientoAplicado, string Observaciones, string NombreCampo1)
        {
            try
            {
                string consulta = $"UPDATE Seguimiento SET NombreCampo='{nombreCampo}', ProductoAplicado= '{ProductoAplicado}', FechaAplicacion= '{fechaAplicacion}', SeguimientoAplicacio='{SeguimientoAplicado}', Observaciones='{Observaciones}' WHERE NombreCampo='{NombreCampo1}'";
                conexion.consultaSQL(consulta);
                MessageBox.Show("Registro editado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
        public DataTable Buscar(string VALOR1)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection con = conexion.crearConexion())
                {
                    string consulta = $"SELECT * FROM Seguimiento WHERE NombreCampo LIKE '{VALOR1}%'";
                    dt = conexion.EjecutarConsulta(consulta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de la tabla Control." + ex.Message);
            }
            return dt;
        }
        public string complecampo(string nombreCampo)
        {
            string nombrereturn = "";
            try
            {
                string consulta = $"SELECT Campo FROM Control WHERE Campo LIKE '{nombreCampo}%'LIMIT 1";
                conexion = ClassConexion.getInstancia();
                nombrereturn = conexion.devolvervalor(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos" + ex.Message);
            }
            return nombrereturn;
        }
    }
}