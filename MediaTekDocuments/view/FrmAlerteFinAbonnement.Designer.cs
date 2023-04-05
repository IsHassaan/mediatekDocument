
namespace MediaTekDocuments.view
{
    partial class FrmAlerteFinAbonnement
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
            this.dgvAbonnementsAEcheance = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonnementsAEcheance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAbonnementsAEcheance
            // 
            this.dgvAbonnementsAEcheance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbonnementsAEcheance.Location = new System.Drawing.Point(370, 104);
            this.dgvAbonnementsAEcheance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvAbonnementsAEcheance.Name = "dgvAbonnementsAEcheance";
            this.dgvAbonnementsAEcheance.RowHeadersWidth = 51;
            this.dgvAbonnementsAEcheance.Size = new System.Drawing.Size(592, 195);
            this.dgvAbonnementsAEcheance.TabIndex = 1;
            this.dgvAbonnementsAEcheance.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAbonnementsAEcheance_ColumnHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(947, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Certains de vos abonnements arrivent à éxpiration dans moins de 30 jours";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(531, 331);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(276, 51);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Compris";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmAlerteFinAbonnement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 421);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAbonnementsAEcheance);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAlerteFinAbonnement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALERTE FIN D\'ABONNEMENTS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonnementsAEcheance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAbonnementsAEcheance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
    }
}