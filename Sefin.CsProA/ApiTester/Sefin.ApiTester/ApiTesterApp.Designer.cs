namespace Sefin.ApiTester
{
    partial class ApiTesterApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApiTesterApp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TablOutput = new System.Windows.Forms.TabControl();
            this.TabLog = new System.Windows.Forms.TabPage();
            this.TxtLog = new System.Windows.Forms.TextBox();
            this.TabQuery = new System.Windows.Forms.TabPage();
            this.TabData = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkClearLogs = new System.Windows.Forms.CheckBox();
            this.BtnClearLogs = new System.Windows.Forms.Button();
            this.BtnLoadDll = new System.Windows.Forms.Button();
            this.BtnExecute = new System.Windows.Forms.Button();
            this.CmbMethods = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.TablOutput.SuspendLayout();
            this.TabLog.SuspendLayout();
            this.TabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TablOutput);
            this.groupBox1.Location = new System.Drawing.Point(6, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 282);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // TablOutput
            // 
            this.TablOutput.Controls.Add(this.TabLog);
            this.TablOutput.Controls.Add(this.TabQuery);
            this.TablOutput.Controls.Add(this.TabData);
            this.TablOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablOutput.Location = new System.Drawing.Point(3, 16);
            this.TablOutput.Name = "TablOutput";
            this.TablOutput.SelectedIndex = 0;
            this.TablOutput.Size = new System.Drawing.Size(468, 263);
            this.TablOutput.TabIndex = 0;
            // 
            // TabLog
            // 
            this.TabLog.Controls.Add(this.TxtLog);
            this.TabLog.Location = new System.Drawing.Point(4, 22);
            this.TabLog.Name = "TabLog";
            this.TabLog.Padding = new System.Windows.Forms.Padding(3);
            this.TabLog.Size = new System.Drawing.Size(460, 237);
            this.TabLog.TabIndex = 0;
            this.TabLog.Text = "Log";
            this.TabLog.UseVisualStyleBackColor = true;
            // 
            // TxtLog
            // 
            this.TxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLog.Location = new System.Drawing.Point(3, 3);
            this.TxtLog.Multiline = true;
            this.TxtLog.Name = "TxtLog";
            this.TxtLog.ReadOnly = true;
            this.TxtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtLog.Size = new System.Drawing.Size(454, 231);
            this.TxtLog.TabIndex = 0;
            // 
            // TabQuery
            // 
            this.TabQuery.Location = new System.Drawing.Point(4, 22);
            this.TabQuery.Name = "TabQuery";
            this.TabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.TabQuery.Size = new System.Drawing.Size(460, 237);
            this.TabQuery.TabIndex = 1;
            this.TabQuery.Text = "Query";
            this.TabQuery.UseVisualStyleBackColor = true;
            // 
            // TabData
            // 
            this.TabData.Controls.Add(this.dataGridView1);
            this.TabData.Location = new System.Drawing.Point(4, 22);
            this.TabData.Name = "TabData";
            this.TabData.Padding = new System.Windows.Forms.Padding(3);
            this.TabData.Size = new System.Drawing.Size(460, 237);
            this.TabData.TabIndex = 2;
            this.TabData.Text = "Data";
            this.TabData.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(454, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ChkClearLogs);
            this.groupBox2.Controls.Add(this.BtnClearLogs);
            this.groupBox2.Controls.Add(this.BtnLoadDll);
            this.groupBox2.Controls.Add(this.BtnExecute);
            this.groupBox2.Controls.Add(this.CmbMethods);
            this.groupBox2.Location = new System.Drawing.Point(6, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ChkClearLogs
            // 
            this.ChkClearLogs.AutoSize = true;
            this.ChkClearLogs.Location = new System.Drawing.Point(149, 46);
            this.ChkClearLogs.Name = "ChkClearLogs";
            this.ChkClearLogs.Size = new System.Drawing.Size(105, 17);
            this.ChkClearLogs.TabIndex = 4;
            this.ChkClearLogs.Text = "Clear logs on run";
            this.ChkClearLogs.UseVisualStyleBackColor = true;
            // 
            // BtnClearLogs
            // 
            this.BtnClearLogs.Location = new System.Drawing.Point(79, 42);
            this.BtnClearLogs.Name = "BtnClearLogs";
            this.BtnClearLogs.Size = new System.Drawing.Size(63, 23);
            this.BtnClearLogs.TabIndex = 3;
            this.BtnClearLogs.Text = "Clear logs";
            this.BtnClearLogs.UseVisualStyleBackColor = true;
            this.BtnClearLogs.Click += new System.EventHandler(this.BtnClearLogs_Click);
            // 
            // BtnLoadDll
            // 
            this.BtnLoadDll.Enabled = false;
            this.BtnLoadDll.Location = new System.Drawing.Point(10, 42);
            this.BtnLoadDll.Name = "BtnLoadDll";
            this.BtnLoadDll.Size = new System.Drawing.Size(63, 23);
            this.BtnLoadDll.TabIndex = 2;
            this.BtnLoadDll.Text = "Load dll...";
            this.BtnLoadDll.UseVisualStyleBackColor = true;
            this.BtnLoadDll.Click += new System.EventHandler(this.BtnLoadDll_Click);
            // 
            // BtnExecute
            // 
            this.BtnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExecute.Location = new System.Drawing.Point(425, 11);
            this.BtnExecute.Name = "BtnExecute";
            this.BtnExecute.Size = new System.Drawing.Size(39, 23);
            this.BtnExecute.TabIndex = 1;
            this.BtnExecute.Text = "Run";
            this.BtnExecute.UseVisualStyleBackColor = true;
            this.BtnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // CmbMethods
            // 
            this.CmbMethods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbMethods.FormattingEnabled = true;
            this.CmbMethods.Location = new System.Drawing.Point(10, 13);
            this.CmbMethods.Name = "CmbMethods";
            this.CmbMethods.Size = new System.Drawing.Size(409, 21);
            this.CmbMethods.TabIndex = 0;
            // 
            // ApiTesterApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 361);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApiTesterApp";
            this.Text = "API Tester";
            this.groupBox1.ResumeLayout(false);
            this.TablOutput.ResumeLayout(false);
            this.TabLog.ResumeLayout(false);
            this.TabLog.PerformLayout();
            this.TabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl TablOutput;
        private System.Windows.Forms.TabPage TabLog;
        private System.Windows.Forms.TabPage TabQuery;
        private System.Windows.Forms.TabPage TabData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtLog;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CmbMethods;
        private System.Windows.Forms.Button BtnLoadDll;
        private System.Windows.Forms.Button BtnExecute;
        private System.Windows.Forms.CheckBox ChkClearLogs;
        private System.Windows.Forms.Button BtnClearLogs;
    }
}

