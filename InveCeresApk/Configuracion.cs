using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InveCeresApk
{
    public partial class Configuracion : Form
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal Form1 = new Principal();
            Form1.Show();
            this.Close();
        }

        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BaseDeDatos=txtBase.Text;
            Properties.Settings.Default.Save();
            
            Application.Restart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBaseDatos_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Agregada la ruta de la base, se reiniciara la aplicacion para guardar los datos");
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de l base de Datos|*.db|Todos los archivos|*.*";
            openFileDialog.Title = "Seleccionar un archivo de base de datos";

            if (openFileDialog .ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog .FileName;

                txtBase.Text= rutaArchivo;

                Properties.Settings.Default.BaseDeDatos = rutaArchivo;
                Properties.Settings.Default.Save();

                Application.Restart();
            }
            
        }
    }
}

