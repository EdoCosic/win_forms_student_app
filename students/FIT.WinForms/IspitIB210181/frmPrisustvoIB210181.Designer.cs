namespace FIT.WinForms.IspitIB210181
{
    partial class frmPrisustvoIB210181
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
            components = new System.ComponentModel.Container();
            lblPrisustvo = new Label();
            label1 = new Label();
            label2 = new Label();
            cmbNastava = new ComboBox();
            cmbStudent = new ComboBox();
            button1 = new Button();
            lblOd = new Label();
            label4 = new Label();
            lblDo = new Label();
            dgvPrisustvo = new DataGridView();
            Nastava = new DataGridViewTextBoxColumn();
            Student = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            txtInfo = new TextBox();
            txtBroj = new TextBox();
            btnGenerisi = new Button();
            label5 = new Label();
            label3 = new Label();
            err = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvPrisustvo).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)err).BeginInit();
            SuspendLayout();
            // 
            // lblPrisustvo
            // 
            lblPrisustvo.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblPrisustvo.Location = new Point(12, 17);
            lblPrisustvo.Name = "lblPrisustvo";
            lblPrisustvo.Size = new Size(484, 72);
            lblPrisustvo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 117);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "Nastava:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(283, 117);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Student:";
            // 
            // cmbNastava
            // 
            cmbNastava.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNastava.FormattingEnabled = true;
            cmbNastava.Location = new Point(23, 135);
            cmbNastava.Name = "cmbNastava";
            cmbNastava.Size = new Size(254, 23);
            cmbNastava.TabIndex = 3;
            // 
            // cmbStudent
            // 
            cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(283, 135);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(258, 23);
            cmbStudent.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(547, 135);
            button1.Name = "button1";
            button1.Size = new Size(95, 23);
            button1.TabIndex = 4;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblOd
            // 
            lblOd.AutoSize = true;
            lblOd.Location = new Point(544, 41);
            lblOd.Name = "lblOd";
            lblOd.Size = new Size(38, 15);
            lblOd.TabIndex = 5;
            lblOd.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(579, 41);
            label4.Name = "label4";
            label4.Size = new Size(12, 15);
            label4.TabIndex = 5;
            label4.Text = "/";
            // 
            // lblDo
            // 
            lblDo.AutoSize = true;
            lblDo.Location = new Point(588, 41);
            lblDo.Name = "lblDo";
            lblDo.Size = new Size(38, 15);
            lblDo.TabIndex = 5;
            lblDo.Text = "label3";
            // 
            // dgvPrisustvo
            // 
            dgvPrisustvo.AllowUserToAddRows = false;
            dgvPrisustvo.AllowUserToDeleteRows = false;
            dgvPrisustvo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrisustvo.Columns.AddRange(new DataGridViewColumn[] { Nastava, Student });
            dgvPrisustvo.Location = new Point(23, 164);
            dgvPrisustvo.Name = "dgvPrisustvo";
            dgvPrisustvo.ReadOnly = true;
            dgvPrisustvo.RowTemplate.Height = 25;
            dgvPrisustvo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrisustvo.Size = new Size(615, 171);
            dgvPrisustvo.TabIndex = 6;
            // 
            // Nastava
            // 
            Nastava.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Nastava.DataPropertyName = "Nastava";
            Nastava.HeaderText = "Predmet, prostorija, vrijeme";
            Nastava.Name = "Nastava";
            Nastava.ReadOnly = true;
            // 
            // Student
            // 
            Student.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Student.DataPropertyName = "Student";
            Student.HeaderText = "Student";
            Student.Name = "Student";
            Student.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInfo);
            groupBox1.Controls.Add(txtBroj);
            groupBox1.Controls.Add(btnGenerisi);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(23, 356);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(615, 206);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generator";
            // 
            // txtInfo
            // 
            txtInfo.Location = new Point(6, 100);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.Size = new Size(597, 100);
            txtInfo.TabIndex = 4;
            // 
            // txtBroj
            // 
            txtBroj.Location = new Point(104, 30);
            txtBroj.Name = "txtBroj";
            txtBroj.Size = new Size(65, 23);
            txtBroj.TabIndex = 3;
            // 
            // btnGenerisi
            // 
            btnGenerisi.Location = new Point(175, 30);
            btnGenerisi.Name = "btnGenerisi";
            btnGenerisi.Size = new Size(75, 23);
            btnGenerisi.TabIndex = 2;
            btnGenerisi.Text = "Generisi";
            btnGenerisi.UseVisualStyleBackColor = true;
            btnGenerisi.Click += btnGenerisi_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 82);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 1;
            label5.Text = "Info:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 33);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 0;
            label3.Text = "Broj zapisa:";
            // 
            // err
            // 
            err.ContainerControl = this;
            // 
            // frmPrisustvoIB210181
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 574);
            Controls.Add(groupBox1);
            Controls.Add(dgvPrisustvo);
            Controls.Add(lblDo);
            Controls.Add(label4);
            Controls.Add(lblOd);
            Controls.Add(button1);
            Controls.Add(cmbStudent);
            Controls.Add(cmbNastava);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPrisustvo);
            Name = "frmPrisustvoIB210181";
            Text = "Evidencija nastave";
            Load += frmPrisustvoIB210181_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrisustvo).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)err).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPrisustvo;
        private Label label1;
        private Label label2;
        private ComboBox cmbNastava;
        private ComboBox cmbStudent;
        private Button button1;
        private Label lblOd;
        private Label label4;
        private Label lblDo;
        private DataGridView dgvPrisustvo;
        private DataGridViewTextBoxColumn Nastava;
        private DataGridViewTextBoxColumn Student;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox txtInfo;
        private TextBox txtBroj;
        private Button btnGenerisi;
        private Label label5;
        private ErrorProvider err;
    }
}