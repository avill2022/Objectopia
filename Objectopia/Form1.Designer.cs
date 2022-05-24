namespace Objectopia
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CadenaText = new System.Windows.Forms.RichTextBox();
            this.Ejecutar = new System.Windows.Forms.Button();
            this.Abrir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CadenaText
            // 
            this.CadenaText.Location = new System.Drawing.Point(462, 12);
            this.CadenaText.Name = "CadenaText";
            this.CadenaText.Size = new System.Drawing.Size(186, 274);
            this.CadenaText.TabIndex = 0;
            this.CadenaText.Text = "";
            // 
            // Ejecutar
            // 
            this.Ejecutar.Location = new System.Drawing.Point(573, 300);
            this.Ejecutar.Name = "Ejecutar";
            this.Ejecutar.Size = new System.Drawing.Size(75, 23);
            this.Ejecutar.TabIndex = 1;
            this.Ejecutar.Text = "Ejecutar";
            this.Ejecutar.UseVisualStyleBackColor = true;
            this.Ejecutar.Click += new System.EventHandler(this.Ejecutar_Click);
            // 
            // Abrir
            // 
            this.Abrir.Location = new System.Drawing.Point(462, 300);
            this.Abrir.Name = "Abrir";
            this.Abrir.Size = new System.Drawing.Size(75, 23);
            this.Abrir.TabIndex = 2;
            this.Abrir.Text = "Abrir";
            this.Abrir.UseVisualStyleBackColor = true;
            this.Abrir.Click += new System.EventHandler(this.Abrir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(670, 345);
            this.Controls.Add(this.Abrir);
            this.Controls.Add(this.Ejecutar);
            this.Controls.Add(this.CadenaText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(676, 374);
            this.MinimumSize = new System.Drawing.Size(676, 374);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Objetopia";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CadenaText;
        private System.Windows.Forms.Button Ejecutar;
        private System.Windows.Forms.Button Abrir;
    }
}

