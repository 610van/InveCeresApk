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
    public partial class Seguimiento : Form
    {
        ClassSeguimiento classSeguimiento = new ClassSeguimiento();
        ClassConexion conexion = ClassConexion.getInstancia();
        ClassControl classControl = new ClassControl();

        public Seguimiento()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DGBSeguimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Seguimiento_Load(object sender, EventArgs e)
        {
            cargarDBGSeguimiento();
        }
        public void cargarDBGSeguimiento()
        {
            DGBSeguimiento.DataSource = classSeguimiento.SeguimientoDGB();
        }

        private void DGBSeguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow seleccion = DGBSeguimiento.Rows[e.RowIndex];
                txtNombreCampo.Text = seleccion.Cells[0].Value.ToString();
                txtProductoAplicado.Text = seleccion.Cells[1].Value.ToString();
                DateTime Fecha = Convert.ToDateTime(seleccion.Cells[2].Value);
                dtpFechaAplicacion.Value = Fecha;
                txtSeguimientoAplicacion.Text = seleccion.Cells[3].Value.ToString();
                txtObservacion.Text = seleccion.Cells[4].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregaregistros();
            limpiarcampos();
            cargarDGBSeguimiento();
        }
        public void agregaregistros()
        {
            DateTime time = dtpFechaAplicacion.Value;
            string Fecha=time.ToString();
            if (txtNombreCampo.Text.Length == 0 || txtProductoAplicado.Text.Length == 0 || txtSeguimientoAplicacion.Text.Length == 0 || txtObservacion.Text.Length == 0)
            {
                MessageBox.Show("No se puede agregar un registo en blanco");
            }
            else
            {
                classSeguimiento.insertaregistro(txtNombreCampo.Text, txtProductoAplicado.Text, Fecha, txtSeguimientoAplicacion.Text, txtObservacion.Text);
            }
        }
        public void eliminaregistro()
        {
            if (txtNombreCampo.Text.Length == 0 || txtProductoAplicado.Text.Length == 0 || txtSeguimientoAplicacion.Text.Length == 0 || txtObservacion.Text.Length == 0)
            {
                MessageBox.Show("No se puede eliminar un registo en blanco");
            }
            else
            {
                classSeguimiento.eliminaregistro(txtNombreCampo.Text);
                limpiarcampos();
            }
        }
        public void editarregistro()
        {
            string Fecha =dtpFechaAplicacion.Value.ToString();
            if (txtNombreCampo.Text.Length == 0 || txtProductoAplicado.Text.Length == 0 || txtSeguimientoAplicacion.Text.Length == 0 || txtObservacion.Text.Length == 0)
            {
                MessageBox.Show("No se puede editar un registo en blanco");
            }
            else
            {
                classSeguimiento.editarregistro(txtNombreCampo.Text, txtProductoAplicado.Text, Fecha, txtSeguimientoAplicacion.Text, txtObservacion.Text, txtNombreCampo.Text);
                limpiarcampos();
            }
        }
        private void limpiarcampos()
        {
            txtNombreCampo.Text = "";
            txtProductoAplicado.Text = "";
            txtSeguimientoAplicacion.Text = "";
            txtObservacion.Text = "";

        }
        public void cargarDGBSeguimiento()
        {
            DGBSeguimiento.DataSource = classSeguimiento.SeguimientoDGB();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarregistro();
            cargarDGBSeguimiento();
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
                cargarDGBSeguimiento();
            }
        }
        private int longitudAnterior = 0;
  
        private void txtNombreCampo_TextChanged(object sender, EventArgs e)
        {
          
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                cargarDGBSeguimiento();
            }
            else
            {
                DGBSeguimiento.DataSource = classSeguimiento.Buscar(txtBuscar.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal form1 = new Principal();
            form1.Show();
            this.Close();
        }

        private void Seguimiento_Load_1(object sender, EventArgs e)
        {
            cargarDBGSeguimiento();
            List<string> listaMelgas = classControl.ObtenerCamposMelgas();

            if (listaMelgas.Count > 0)
            {
                // Llena el ListBox con los valores de la lista.
                Melgas.Items.Clear(); // Limpia cualquier elemento previo en el ListBox.
                foreach (var campo in listaMelgas)
                {
                    Melgas.Items.Add(campo);
                }


            }
            else
            {
                MessageBox.Show("No se encontraron datos en la tabla Control.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CMBMelgas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtProductoAplicado_TextChanged(object sender, EventArgs e)
        {

        }

        private void Melgas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

