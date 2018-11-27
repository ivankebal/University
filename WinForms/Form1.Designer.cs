namespace WinForms
{
    partial class Form1
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
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.InfoDataGridView = new System.Windows.Forms.DataGridView();
            this.ControlCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.TxtBoxLogin = new System.Windows.Forms.TextBox();
            this.LogBtn = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.ViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDataGridView)).BeginInit();
            this.LogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.button1);
            this.ViewPanel.Controls.Add(this.UpdateBtn);
            this.ViewPanel.Controls.Add(this.InfoDataGridView);
            this.ViewPanel.Location = new System.Drawing.Point(12, 12);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(586, 426);
            this.ViewPanel.TabIndex = 0;
            this.ViewPanel.Visible = false;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(4, 402);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateBtn.TabIndex = 1;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Visible = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // InfoDataGridView
            // 
            this.InfoDataGridView.AllowUserToAddRows = false;
            this.InfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ControlCol});
            this.InfoDataGridView.Location = new System.Drawing.Point(3, 3);
            this.InfoDataGridView.Name = "InfoDataGridView";
            this.InfoDataGridView.Size = new System.Drawing.Size(580, 392);
            this.InfoDataGridView.TabIndex = 0;
            this.InfoDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.InfoDataGridView_EditingControlShowing);
            // 
            // ControlCol
            // 
            this.ControlCol.HeaderText = "Control";
            this.ControlCol.Name = "ControlCol";
            this.ControlCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.LoginLabel);
            this.LogPanel.Controls.Add(this.TxtBoxLogin);
            this.LogPanel.Controls.Add(this.LogBtn);
            this.LogPanel.Location = new System.Drawing.Point(605, 12);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(183, 100);
            this.LogPanel.TabIndex = 1;
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Enabled = false;
            this.LoginLabel.Location = new System.Drawing.Point(3, 0);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(33, 13);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Login";
            // 
            // TxtBoxLogin
            // 
            this.TxtBoxLogin.Location = new System.Drawing.Point(42, 3);
            this.TxtBoxLogin.Name = "TxtBoxLogin";
            this.TxtBoxLogin.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxLogin.TabIndex = 1;
            this.TxtBoxLogin.Text = "Login";
            this.TxtBoxLogin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtBoxLogin_MouseDown);
            // 
            // LogBtn
            // 
            this.LogBtn.Location = new System.Drawing.Point(3, 29);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(75, 23);
            this.LogBtn.TabIndex = 2;
            this.LogBtn.Text = "Login";
            this.LogBtn.UseVisualStyleBackColor = true;
            this.LogBtn.Click += new System.EventHandler(this.LogBtn_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Location = new System.Drawing.Point(605, 119);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(183, 319);
            this.InfoPanel.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.LogPanel);
            this.Controls.Add(this.ViewPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDataGridView)).EndInit();
            this.LogPanel.ResumeLayout(false);
            this.LogPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ViewPanel;
        private System.Windows.Forms.FlowLayoutPanel LogPanel;
        private System.Windows.Forms.FlowLayoutPanel InfoPanel;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox TxtBoxLogin;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.DataGridView InfoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlCol;
        private System.Windows.Forms.Button button1;
    }
}

