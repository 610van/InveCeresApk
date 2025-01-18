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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            Control insumos = new Control();
            insumos.Show();
            this.Hide();

        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            Seguimiento seguimiento = new Seguimiento();    
            seguimiento.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Documentacion documentacion = new Documentacion();
            documentacion.Show();
            this.Hide();
        }

        private void btnBase_Click(object sender, EventArgs e)
        {
            Configuracion configuracion = new Configuracion();  
            configuracion.Show();
            this.Hide();
        }
    }
}
