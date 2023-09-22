namespace ExcelToDb
{
    partial class MainForm
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
            panel1 = new Panel();
            lblTotal = new Label();
            label6 = new Label();
            gbThree = new GroupBox();
            txtTableName = new TextBox();
            label3 = new Label();
            btnInsertToDb = new Button();
            gbOne = new GroupBox();
            btnFind = new Button();
            txtFilePath = new TextBox();
            label2 = new Label();
            btnLoading = new Button();
            gbTwo = new GroupBox();
            txtDbName = new TextBox();
            label7 = new Label();
            label5 = new Label();
            txtDbPassword = new TextBox();
            label4 = new Label();
            txtDbId = new TextBox();
            btnConnect = new Button();
            cbDbIntegratedSecurity = new CheckBox();
            label1 = new Label();
            txtDbServer = new TextBox();
            gvPreview = new DataGridView();
            txtLog = new RichTextBox();
            splitContainer1 = new SplitContainer();
            panel1.SuspendLayout();
            gbThree.SuspendLayout();
            gbOne.SuspendLayout();
            gbTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotal);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(gbThree);
            panel1.Controls.Add(gbOne);
            panel1.Controls.Add(gbTwo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1124, 458);
            panel1.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(40, 418);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 25);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total : 0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(199, 418);
            label6.Name = "label6";
            label6.Size = new Size(311, 25);
            label6.TabIndex = 12;
            label6.Text = "Preview rows count is limited by 100";
            // 
            // gbThree
            // 
            gbThree.Controls.Add(txtTableName);
            gbThree.Controls.Add(label3);
            gbThree.Controls.Add(btnInsertToDb);
            gbThree.Location = new Point(36, 278);
            gbThree.Name = "gbThree";
            gbThree.Size = new Size(1045, 100);
            gbThree.TabIndex = 30;
            gbThree.TabStop = false;
            gbThree.Text = "3. Insert data";
            // 
            // txtTableName
            // 
            txtTableName.Enabled = false;
            txtTableName.Location = new Point(163, 46);
            txtTableName.Name = "txtTableName";
            txtTableName.Size = new Size(650, 31);
            txtTableName.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 46);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 0;
            label3.Text = "Table Name";
            // 
            // btnInsertToDb
            // 
            btnInsertToDb.Enabled = false;
            btnInsertToDb.Location = new Point(828, 46);
            btnInsertToDb.Name = "btnInsertToDb";
            btnInsertToDb.Size = new Size(135, 34);
            btnInsertToDb.TabIndex = 32;
            btnInsertToDb.Text = "Insert to db";
            btnInsertToDb.UseVisualStyleBackColor = true;
            btnInsertToDb.Click += btnInsertToDb_Click;
            // 
            // gbOne
            // 
            gbOne.Controls.Add(btnFind);
            gbOne.Controls.Add(txtFilePath);
            gbOne.Controls.Add(label2);
            gbOne.Controls.Add(btnLoading);
            gbOne.Location = new Point(36, 25);
            gbOne.Name = "gbOne";
            gbOne.Size = new Size(1045, 103);
            gbOne.TabIndex = 10;
            gbOne.TabStop = false;
            gbOne.Text = "1. Load Excel File";
            // 
            // btnFind
            // 
            btnFind.Location = new Point(727, 45);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(86, 34);
            btnFind.TabIndex = 100;
            btnFind.Text = "Find...";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(165, 47);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(556, 31);
            txtFilePath.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 47);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 0;
            label2.Text = "FilePath";
            // 
            // btnLoading
            // 
            btnLoading.Location = new Point(828, 44);
            btnLoading.Name = "btnLoading";
            btnLoading.Size = new Size(135, 34);
            btnLoading.TabIndex = 12;
            btnLoading.Text = "Loading";
            btnLoading.UseVisualStyleBackColor = true;
            btnLoading.Click += btnLoading_Click;
            // 
            // gbTwo
            // 
            gbTwo.Controls.Add(txtDbName);
            gbTwo.Controls.Add(label7);
            gbTwo.Controls.Add(label5);
            gbTwo.Controls.Add(txtDbPassword);
            gbTwo.Controls.Add(label4);
            gbTwo.Controls.Add(txtDbId);
            gbTwo.Controls.Add(btnConnect);
            gbTwo.Controls.Add(cbDbIntegratedSecurity);
            gbTwo.Controls.Add(label1);
            gbTwo.Controls.Add(txtDbServer);
            gbTwo.Location = new Point(36, 134);
            gbTwo.Name = "gbTwo";
            gbTwo.Size = new Size(1045, 138);
            gbTwo.TabIndex = 20;
            gbTwo.TabStop = false;
            gbTwo.Text = "2. Connect SQL Server";
            // 
            // txtDbName
            // 
            txtDbName.Enabled = false;
            txtDbName.Location = new Point(566, 41);
            txtDbName.Name = "txtDbName";
            txtDbName.Size = new Size(247, 31);
            txtDbName.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(462, 41);
            label7.Name = "label7";
            label7.Size = new Size(87, 25);
            label7.TabIndex = 0;
            label7.Text = "Database";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(461, 84);
            label5.Name = "label5";
            label5.Size = new Size(88, 25);
            label5.TabIndex = 0;
            label5.Text = "Password";
            // 
            // txtDbPassword
            // 
            txtDbPassword.Enabled = false;
            txtDbPassword.Location = new Point(566, 84);
            txtDbPassword.Name = "txtDbPassword";
            txtDbPassword.Size = new Size(247, 31);
            txtDbPassword.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(116, 84);
            label4.Name = "label4";
            label4.Size = new Size(30, 25);
            label4.TabIndex = 0;
            label4.Text = "ID";
            // 
            // txtDbId
            // 
            txtDbId.Enabled = false;
            txtDbId.Location = new Point(163, 84);
            txtDbId.Name = "txtDbId";
            txtDbId.Size = new Size(268, 31);
            txtDbId.TabIndex = 24;
            // 
            // btnConnect
            // 
            btnConnect.Enabled = false;
            btnConnect.Location = new Point(828, 82);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(135, 34);
            btnConnect.TabIndex = 26;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cbDbIntegratedSecurity
            // 
            cbDbIntegratedSecurity.AutoSize = true;
            cbDbIntegratedSecurity.Enabled = false;
            cbDbIntegratedSecurity.Location = new Point(828, 43);
            cbDbIntegratedSecurity.Name = "cbDbIntegratedSecurity";
            cbDbIntegratedSecurity.Size = new Size(192, 29);
            cbDbIntegratedSecurity.TabIndex = 23;
            cbDbIntegratedSecurity.Text = "Integrated Security";
            cbDbIntegratedSecurity.UseVisualStyleBackColor = true;
            cbDbIntegratedSecurity.CheckedChanged += cbDbIntegratedSecurity_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 41);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 0;
            label1.Text = "Server";
            // 
            // txtDbServer
            // 
            txtDbServer.Enabled = false;
            txtDbServer.Location = new Point(163, 41);
            txtDbServer.Name = "txtDbServer";
            txtDbServer.Size = new Size(268, 31);
            txtDbServer.TabIndex = 21;
            // 
            // gvPreview
            // 
            gvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvPreview.Dock = DockStyle.Fill;
            gvPreview.Location = new Point(10, 0);
            gvPreview.Name = "gvPreview";
            gvPreview.RowHeadersWidth = 62;
            gvPreview.RowTemplate.Height = 33;
            gvPreview.Size = new Size(1104, 565);
            gvPreview.TabIndex = 0;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.White;
            txtLog.Dock = DockStyle.Fill;
            txtLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtLog.Location = new Point(10, 0);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLog.Size = new Size(1104, 145);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 458);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(gvPreview);
            splitContainer1.Panel1.Padding = new Padding(10, 0, 10, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtLog);
            splitContainer1.Panel2.Padding = new Padding(10, 0, 10, 10);
            splitContainer1.Size = new Size(1124, 724);
            splitContainer1.SplitterDistance = 565;
            splitContainer1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 1182);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            MinimumSize = new Size(1146, 1238);
            Name = "MainForm";
            Text = "ExcelToDB";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbThree.ResumeLayout(false);
            gbThree.PerformLayout();
            gbOne.ResumeLayout(false);
            gbOne.PerformLayout();
            gbTwo.ResumeLayout(false);
            gbTwo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvPreview).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnConnect;
        private TextBox txtDbServer;
        private Label label1;
        private Button btnLoading;
        private TextBox txtFilePath;
        private Label label2;
        private DataGridView gvPreview;
        private TextBox txtTableName;
        private Label label3;
        private Button btnInsertToDb;
        private RichTextBox txtLog;
        private GroupBox gbTwo;
        private CheckBox cbDbIntegratedSecurity;
        private Label label5;
        private TextBox txtDbPassword;
        private Label label4;
        private TextBox txtDbId;
        private GroupBox gbOne;
        private GroupBox gbThree;
        private SplitContainer splitContainer1;
        private Label label6;
        private Label lblTotal;
        private Label label7;
        private TextBox txtDbName;
        private Button btnFind;
    }
}