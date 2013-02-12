namespace StateTracker.UI
{
    partial class FormBalanceHistory
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
            this.labelAccNo = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxAccNo = new System.Windows.Forms.TextBox();
            this.buttonGetHistory = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.executeTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAccNo
            // 
            this.labelAccNo.AutoSize = true;
            this.labelAccNo.Location = new System.Drawing.Point(12, 27);
            this.labelAccNo.Name = "labelAccNo";
            this.labelAccNo.Size = new System.Drawing.Size(64, 13);
            this.labelAccNo.TabIndex = 0;
            this.labelAccNo.Text = "Account No";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(12, 56);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(55, 13);
            this.labelStartDate.TabIndex = 1;
            this.labelStartDate.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(98, 56);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(210, 20);
            this.dateTimePickerStartDate.TabIndex = 3;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(99, 89);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(209, 20);
            this.dateTimePickerEndDate.TabIndex = 4;
            // 
            // textBoxAccNo
            // 
            this.textBoxAccNo.Location = new System.Drawing.Point(98, 24);
            this.textBoxAccNo.Name = "textBoxAccNo";
            this.textBoxAccNo.Size = new System.Drawing.Size(112, 20);
            this.textBoxAccNo.TabIndex = 5;
            // 
            // buttonGetHistory
            // 
            this.buttonGetHistory.Location = new System.Drawing.Point(231, 115);
            this.buttonGetHistory.Name = "buttonGetHistory";
            this.buttonGetHistory.Size = new System.Drawing.Size(77, 27);
            this.buttonGetHistory.TabIndex = 6;
            this.buttonGetHistory.Text = "Get History";
            this.buttonGetHistory.UseVisualStyleBackColor = true;
            this.buttonGetHistory.Click += new System.EventHandler(this.buttonGetHistory_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(349, 205);
            this.dataGridView1.TabIndex = 7;
            // 
            // executeTime
            // 
            this.executeTime.AutoSize = true;
            this.executeTime.Location = new System.Drawing.Point(12, 329);
            this.executeTime.Name = "executeTime";
            this.executeTime.Size = new System.Drawing.Size(0, 13);
            this.executeTime.TabIndex = 8;
            // 
            // FormBalanceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 410);
            this.Controls.Add(this.executeTime);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonGetHistory);
            this.Controls.Add(this.textBoxAccNo);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.labelAccNo);
            this.Name = "FormBalanceHistory";
            this.Text = "FormBalanceHistory";
            this.Load += new System.EventHandler(this.FormBalanceHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAccNo;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.TextBox textBoxAccNo;
        private System.Windows.Forms.Button buttonGetHistory;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label executeTime;
    }
}