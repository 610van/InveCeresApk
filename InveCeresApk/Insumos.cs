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
    public partial class Control : Form
    {
        ClassControl classControl=new ClassControl();
        public Control()
        {
            InitializeComponent();
        }

        private void Insumos_Load(object sender, EventArgs e)
        {
            cargarDGBcontrol();
        }
        public void cargarDGBcontrol()
        {
          DGBControl.DataSource = classControl.ControlDGB();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregaregistros();
            limpiarcampos();
            cargarDGBcontrol();
        }
        public void agregaregistros() {
            if (txtNombre.Text.Length == 0 || txthectareas.Text.Length== 0 ||txtMelgas.Text.Length==0 ||txtTipoPiña.Text.Length== 0 || txtRuta.Text.Length== 0)
            {
                MessageBox.Show("No se puede agregar un registo en blanco");
            }
            else
            {
                classControl.insertaregistro(txtNombre.Text, txthectareas.Text, txtMelgas.Text, txtTipoPiña.Text, txtRuta.Text);
            }
        }
        public void eliminaregistro() {
            if (txtNombre.Text.Length == 0 || txthectareas.Text.Length == 0 || txtMelgas.Text.Length == 0 || txtTipoPiña.Text.Length == 0 || txtRuta.Text.Length== 0)
            {
                MessageBox.Show("No se puede eliminar un registo en blanco");
            }
            else
            {
                classControl.eliminaregistro(txtNombre.Text);
                limpiarcampos();
            }
        }
        public void editarregistro()
        {
            if (txtNombre.Text.Length == 0 || txthectareas.Text.Length == 0 || txtMelgas.Text.Length == 0 || txtTipoPiña.Text.Length == 0)
            {
                MessageBox.Show("No se puede editar un registo en blanco");
            }
            else
            {
                classControl.editarregistro(txtNombre.Text, txthectareas.Text, txtMelgas.Text, txtTipoPiña.Text, txtRuta.Text);
                limpiarcampos();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Quieres eliminar este Registro?",
                                                  "Confirmar",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                eliminaregistro();
                cargarDGBcontrol();
            }
        }
        private void limpiarcampos()
        {
            txtNombre.Text = "";
            txthectareas.Text = "";
            txtMelgas.Text = "";
            txtTipoPiña.Text = "";
            txtRuta.Text = "";
            PBFoto.Image = null;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarregistro();
            cargarDGBcontrol();
        }

        private void DGBControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>= 0) {
                DataGridViewRow seleccion = DGBControl.Rows[e.RowIndex];
                txtNombre.Text= seleccion.Cells[0].Value.ToString();
                txthectareas.Text= seleccion.Cells[1].Value.ToString();
                txtMelgas.Text= seleccion.Cells[2].Value.ToString();
                txtTipoPiña.Text= seleccion.Cells[3].Value.ToString();
                txtRuta.Text= seleccion.Cells[4].Value.ToString();
                PBFoto.ImageLocation = txtRuta.Text;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                cargarDGBcontrol();
            }
            else
            {
                DGBControl.DataSource = classControl.Buscar(txtBuscar.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal form1 = new Principal();
            form1.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cargarDGBcontrol();
        }

        private void Control_Load(object sender, EventArgs e)
        {
            cargarDGBcontrol();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Principal Form1 = new Principal();
            Form1.Show();
            this.Close();
        }

        private void btnReferencia_Click(object sender, EventArgs e)
        {
            // Crear un cuadro de diálogo para seleccionar un archivo
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar una imagen", // Título del cuadro de diálogo
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif", // Filtro para imágenes
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) // Carpeta inicial
            };

            // Mostrar el cuadro de diálogo y verificar si se seleccionó un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionado
                string rutaImagen = openFileDialog.FileName;
                txtRuta.Text= rutaImagen;
                MessageBox.Show($"Has seleccionado la imagen:\n{rutaImagen}", "Ruta de la Imagen");

                // Opcional: Mostrar la imagen en un PictureBox (si tienes uno)
                PBFoto.ImageLocation = rutaImagen;
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna imagen.", "Aviso");
            }
        
        }

        private void txtRuta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
