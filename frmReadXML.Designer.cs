namespace ReadXML
{
    partial class frmReadXML
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtPath = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();
            rtxFileLoaded = new RichTextBox();
            txtCompany = new TextBox();
            label2 = new Label();
            lblCompany = new Label();
            lblStatus = new Label();
            label4 = new Label();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Path:";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(68, 18);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(568, 23);
            txtPath.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(660, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLoad
            // 
            btnLoad.Enabled = false;
            btnLoad.Location = new Point(350, 52);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // rtxFileLoaded
            // 
            rtxFileLoaded.Location = new Point(23, 144);
            rtxFileLoaded.Name = "rtxFileLoaded";
            rtxFileLoaded.Size = new Size(712, 316);
            rtxFileLoaded.TabIndex = 4;
            rtxFileLoaded.Text = "";
            // 
            // txtCompany
            // 
            txtCompany.Enabled = false;
            txtCompany.Location = new Point(91, 87);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(140, 23);
            txtCompany.TabIndex = 5;
            txtCompany.Tag = "Empresa:lblCompany";
            txtCompany.TextChanged += txtCompany_TextChanged;
            txtCompany.Enter += txtCompany_Enter;
            txtCompany.KeyDown += txtCompany_KeyDown;
            txtCompany.Leave += txtCompany_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 90);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 6;
            label2.Text = "Company:";
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Location = new Point(94, 113);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(12, 15);
            lblCompany.TabIndex = 7;
            lblCompany.Text = "-";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(353, 113);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(12, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 90);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 9;
            label4.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.Enabled = false;
            txtStatus.Location = new Point(350, 87);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(140, 23);
            txtStatus.TabIndex = 8;
            txtStatus.Tag = "Estado:lblStatus";
            txtStatus.TextChanged += txtStatus_TextChanged;
            txtStatus.Enter += txtStatus_Enter;
            txtStatus.KeyDown += txtStatus_KeyDown;
            txtStatus.Leave += txtStatus_Leave;
            // 
            // frmReadXML
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 472);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(txtStatus);
            Controls.Add(lblCompany);
            Controls.Add(label2);
            Controls.Add(txtCompany);
            Controls.Add(rtxFileLoaded);
            Controls.Add(btnLoad);
            Controls.Add(btnSearch);
            Controls.Add(txtPath);
            Controls.Add(label1);
            Name = "frmReadXML";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Read Xml";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPath;
        private Button btnSearch;
        private Button btnLoad;
        private RichTextBox rtxFileLoaded;
        private TextBox txtCompany;
        private Label label2;
        private Label lblCompany;
        private Label lblStatus;
        private Label label4;
        private TextBox txtStatus;
    }
}