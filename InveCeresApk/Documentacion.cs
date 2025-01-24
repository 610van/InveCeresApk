﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Data.SqlClient;

namespace InveCeresApk
{
    public partial class Documentacion : Form
    {
        ClassSeguimiento classSeguimiento = new ClassSeguimiento();
        ClassConexion conexion = ClassConexion.getInstancia();

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó información (por ejemplo, si el txtReporte tiene texto)
            if (string.IsNullOrEmpty(txtReporte.Text) && ListaCampos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione la información a generar antes de crear el PDF.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método sin generar el PDF
            }

            string outputPath = "C:\\Users\\MA VICTORIA GIL MTZ\\source\\repos\\InveCeresApk\\EjemploPDF.pdf";

            // Crear el documento
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);

            try
            {
                // Crear escritor para el documento
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
                document.Open();

                // Agregar imagen en la parte superior izquierda
                string imagePath = "C:\\Users\\MA VICTORIA GIL MTZ\\source\\repos\\InveCeresApk\\Grupo-Ceres.png"; 
                if (File.Exists(imagePath))
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
                    img.ScaleToFit(100f, 100f); // Ajustar tamaño de la imagen
                    img.SetAbsolutePosition(50, document.PageSize.Height - img.ScaledHeight - 25); // Posición (x, y)
                    document.Add(img);
                }
                document.Add(new Paragraph("\n")); // Espaciado
                document.Add(new Paragraph("\n")); // Espaciado
                document.Add(new Paragraph("\n")); // Espaciado

                // Título
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLACK);
                Paragraph title = new Paragraph("Comercializadora agricola CERES. S.A. DE C.V.", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                document.Add(new Paragraph("\n")); // Espaciado

                var cuerpo = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                document.Add(new Paragraph("Informe de Actividades: Comercializadora Agrícola CERES, S.A. de C.V.", cuerpo));
                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph("\n")); // Espaciado

                var cuerpo1 = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                document.Add(new Paragraph("En el presente documento se detalla un reporte generado automáticamente que incluye información", cuerpo1));

                var cuerpo2 = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                document.Add(new Paragraph("relevante sobre las operaciones recientes realizadas en la Comercializadora Agrícola CERES, S.A. de", cuerpo2));

                var cuerpo3 = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                document.Add(new Paragraph("C.V. El informe tiene como objetivo ofrecer una visión general de los datos procesados para facilitar", cuerpo3));

                var cuerpo4 = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                document.Add(new Paragraph("la toma de decisiones estratégicas.", cuerpo4));

                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph("\n")); // Espaciado

                string titulo = "Reporte " + txtReporte.Text;
                // Texto simple
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
                document.Add(new Paragraph(titulo, normalFont));

                document.Add(new Paragraph("\n")); // Espaciado
                document.Add(new Paragraph("\n")); // Espaciado
                document.Add(new Paragraph("\n")); // Espaciado

                // Tabla
                PdfPTable table = new PdfPTable(3); // 3 columnas
                table.WidthPercentage = 100;

                // Agregar encabezados
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                PdfPCell header1 = new PdfPCell(new Phrase("Columna 1", headerFont)) { BackgroundColor = BaseColor.DARK_GRAY };
                PdfPCell header2 = new PdfPCell(new Phrase("Columna 2", headerFont)) { BackgroundColor = BaseColor.DARK_GRAY };
                PdfPCell header3 = new PdfPCell(new Phrase("Columna 3", headerFont)) { BackgroundColor = BaseColor.DARK_GRAY };

                table.AddCell(header1);
                table.AddCell(header2);
                table.AddCell(header3);

                // Agregar datos
                for (int i = 1; i <= 9; i++)
                {
                    table.AddCell($"Dato {i}");
                }

                document.Add(table);

                document.Add(new Paragraph("\n")); // Espaciado
               

                // Footer
                Paragraph footer = new Paragraph("CERES S.A DE C.V", normalFont);
                footer.Alignment = Element.ALIGN_CENTER;
                document.Add(footer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar el PDF: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        public void cargarDGBSeguimiento()
        {
            //dgbMostrar.DataSource = classSeguimiento.SeguimientoDGB();
        }



        private void Documentacion_Load(object sender, EventArgs e)
        {
            cargarDGBSeguimiento(); 
        }
        private int longitudanterior = 0;

        private void txtcampo_TextChanged(object sender, EventArgs e)
        {
           // if (txtcampo.Text.Length == 0)
           // {
             //   cargarDGBSeguimiento();
            //}
          //  else
           // {
                //dgbMostrar.DataSource = classSeguimiento.Buscar(txtcampo.Text);
            //}
        }

        private void Documentacion_Load_1(object sender, EventArgs e)
        {
            cargarDGBSeguimiento();
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtReporte_TextChanged(object sender, EventArgs e)
        {
            if (txtReporte.Text.Length == 0)
            {
                cargarDGBSeguimiento();
            }
            else
            {
                //dgbMostrar.DataSource = classSeguimiento.Buscar(txtReporte.Text);
            }
        }

        private void ListaCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
