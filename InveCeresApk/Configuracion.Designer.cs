namespace InveCeresApk
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBaseDatos = new System.Windows.Forms.Button();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(724, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(315, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleciona tu base de datos";
            // 
            // btnBaseDatos
            // 
            this.btnBaseDatos.BackgroundImage = global::InveCeresApk.Properties.Resources.subir;
            this.btnBaseDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBaseDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaseDatos.Location = new System.Drawing.Point(388, 189);
            this.btnBaseDatos.Name = "btnBaseDatos";
            this.btnBaseDatos.Size = new System.Drawing.Size(124, 79);
            this.btnBaseDatos.TabIndex = 9;
            this.btnBaseDatos.UseVisualStyleBackColor = true;
            this.btnBaseDatos.Click += new System.EventHandler(this.btnBaseDatos_Click_1);
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(121, 135);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(659, 20);
            this.txtBase.TabIndex = 10;
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 280);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.btnBaseDatos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBaseDatos;
        private System.Windows.Forms.TextBox txtBase;
    }
}