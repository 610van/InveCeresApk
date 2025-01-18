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
    public partial class Documentacion : Form
    {
        public Documentacion()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal Form1 = new Principal();
            Form1.Show();
            this.Close();
        }
    }
}
