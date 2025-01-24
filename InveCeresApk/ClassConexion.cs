using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace InveCeresApk
{
    public class ClassConexion
    {
        private String BasedeDatos;
        private static ClassConexion con = null;

        private ClassConexion()
        {
            //this.BasedeDatos = @"C:\Users\MA VICTORIA GIL MTZ\Downloads\DESCARGAS  DEL TECNOLOGICO\8 AÑO DEL TEC\control del campo\Db_ceres.db";
            this.BasedeDatos = Properties.Settings.Default.BaseDeDatos;
        }
        //crea la conexion entre el programa y la base de datos
        public SQLiteConnection crearConexion()
        {
            SQLiteConnection Cadena = new SQLiteConnection();
            try
            {
                Cadena.ConnectionString = "Data Source=" + this.BasedeDatos;
                Cadena.Open();
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw new Exception("Error al conectar la Base de Datos", ex);
            }
            return Cadena;
        }
        public static ClassConexion getInstancia()
        {
            if (con == null)
            {
                con = new ClassConexion();
            }
            return con;
        }
        //devuelve las tablas para su previa vista
        public DataTable EjecutarConsulta(string Consulta)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection conn = crearConexion())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(Consulta, conn))
                {
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        //Ejecuta las consultas 
        public void consultaSQL(string Consulta)
        {
            using (SQLiteConnection conn = crearConexion())
            {
                using (SQLiteCommand cmd = new SQLiteCommand(Consulta, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string devolvervalor(string consulta)
        {
            string valor = null;
            try
            {
                using (SQLiteConnection conn = crearConexion())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(consulta, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                valor = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            return valor;
        }


        

    }
}


