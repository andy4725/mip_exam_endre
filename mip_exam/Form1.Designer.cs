namespace mip_exam
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
            this.recipientLabel = new System.Windows.Forms.Label();
            this.recipientTextBox = new System.Windows.Forms.TextBox();
            this.priorityLabel = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.addDeliveryButton = new System.Windows.Forms.Button();
            this.generateDatasetButton = new System.Windows.Forms.Button();
            this.startProcessingButton = new System.Windows.Forms.Button();
            this.stopProcessingButton = new System.Windows.Forms.Button();
            this.pendingLabel = new System.Windows.Forms.Label();
            this.processingLabel = new System.Windows.Forms.Label();
            this.completedLabel = new System.Windows.Forms.Label();
            this.deliveryDataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // recipientLabel
            // 
            this.recipientLabel.AutoSize = true;
            this.recipientLabel.Location = new System.Drawing.Point(41, 96);
            this.recipientLabel.Name = "recipientLabel";
            this.recipientLabel.Size = new System.Drawing.Size(67, 16);
            this.recipientLabel.TabIndex = 0;
            this.recipientLabel.Text = "Recipient:";
            // 
            // recipientTextBox
            // 
            this.recipientTextBox.Location = new System.Drawing.Point(166, 93);
            this.recipientTextBox.Name = "recipientTextBox";
            this.recipientTextBox.Size = new System.Drawing.Size(163, 22);
            this.recipientTextBox.TabIndex = 1;
            // 
            // priorityLabel
            // 
            this.priorityLabel.AutoSize = true;
            this.priorityLabel.Location = new System.Drawing.Point(44, 147);
            this.priorityLabel.Name = "priorityLabel";
            this.priorityLabel.Size = new System.Drawing.Size(51, 16);
            this.priorityLabel.TabIndex = 2;
            this.priorityLabel.Text = "Priority:";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.priorityComboBox.Location = new System.Drawing.Point(166, 147);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(163, 24);
            this.priorityComboBox.TabIndex = 3;
            // 
            // addDeliveryButton
            // 
            this.addDeliveryButton.Location = new System.Drawing.Point(44, 213);
            this.addDeliveryButton.Name = "addDeliveryButton";
            this.addDeliveryButton.Size = new System.Drawing.Size(140, 33);
            this.addDeliveryButton.TabIndex = 4;
            this.addDeliveryButton.Text = "Add delivery";
            this.addDeliveryButton.UseVisualStyleBackColor = true;
            this.addDeliveryButton.Click += new System.EventHandler(this.addDeliveryButton_Click);
            // 
            // generateDatasetButton
            // 
            this.generateDatasetButton.Location = new System.Drawing.Point(44, 252);
            this.generateDatasetButton.Name = "generateDatasetButton";
            this.generateDatasetButton.Size = new System.Drawing.Size(137, 33);
            this.generateDatasetButton.TabIndex = 5;
            this.generateDatasetButton.Text = "Generate dataset";
            this.generateDatasetButton.UseVisualStyleBackColor = true;
            this.generateDatasetButton.Click += new System.EventHandler(this.generateDatasetButton_Click);
            // 
            // startProcessingButton
            // 
            this.startProcessingButton.Location = new System.Drawing.Point(44, 291);
            this.startProcessingButton.Name = "startProcessingButton";
            this.startProcessingButton.Size = new System.Drawing.Size(137, 33);
            this.startProcessingButton.TabIndex = 6;
            this.startProcessingButton.Text = "Start processing";
            this.startProcessingButton.UseVisualStyleBackColor = true;
            this.startProcessingButton.Click += new System.EventHandler(this.startProcessingButton_Click);
            // 
            // stopProcessingButton
            // 
            this.stopProcessingButton.Enabled = false;
            this.stopProcessingButton.Location = new System.Drawing.Point(44, 330);
            this.stopProcessingButton.Name = "stopProcessingButton";
            this.stopProcessingButton.Size = new System.Drawing.Size(137, 33);
            this.stopProcessingButton.TabIndex = 7;
            this.stopProcessingButton.Text = "Stop processing";
            this.stopProcessingButton.UseVisualStyleBackColor = true;
            this.stopProcessingButton.Click += new System.EventHandler(this.stopProcessingButton_Click);
            // 
            // pendingLabel
            // 
            this.pendingLabel.AutoSize = true;
            this.pendingLabel.Location = new System.Drawing.Point(234, 213);
            this.pendingLabel.Name = "pendingLabel";
            this.pendingLabel.Size = new System.Drawing.Size(70, 16);
            this.pendingLabel.TabIndex = 8;
            this.pendingLabel.Text = "Pending: 0";
            // 
            // processingLabel
            // 
            this.processingLabel.AutoSize = true;
            this.processingLabel.Location = new System.Drawing.Point(232, 252);
            this.processingLabel.Name = "processingLabel";
            this.processingLabel.Size = new System.Drawing.Size(88, 16);
            this.processingLabel.TabIndex = 9;
            this.processingLabel.Text = "Processing: 0";
            // 
            // completedLabel
            // 
            this.completedLabel.AutoSize = true;
            this.completedLabel.Location = new System.Drawing.Point(232, 291);
            this.completedLabel.Name = "completedLabel";
            this.completedLabel.Size = new System.Drawing.Size(86, 16);
            this.completedLabel.TabIndex = 10;
            this.completedLabel.Text = "Completed: 0";
            // 
            // deliveryDataGridView
            // 
            this.deliveryDataGridView.AllowUserToAddRows = false;
            this.deliveryDataGridView.AllowUserToDeleteRows = false;
            this.deliveryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deliveryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deliveryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Recipient,
            this.Priority,
            this.Status});
            this.deliveryDataGridView.Location = new System.Drawing.Point(443, 93);
            this.deliveryDataGridView.Name = "deliveryDataGridView";
            this.deliveryDataGridView.ReadOnly = true;
            this.deliveryDataGridView.RowHeadersWidth = 51;
            this.deliveryDataGridView.RowTemplate.Height = 24;
            this.deliveryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deliveryDataGridView.Size = new System.Drawing.Size(530, 276);
            this.deliveryDataGridView.TabIndex = 11;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Recipient
            // 
            this.Recipient.HeaderText = "Recipient";
            this.Recipient.MinimumWidth = 6;
            this.Recipient.Name = "Recipient";
            this.Recipient.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "Priority";
            this.Priority.MinimumWidth = 6;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 561);
            this.Controls.Add(this.deliveryDataGridView);
            this.Controls.Add(this.completedLabel);
            this.Controls.Add(this.processingLabel);
            this.Controls.Add(this.pendingLabel);
            this.Controls.Add(this.stopProcessingButton);
            this.Controls.Add(this.startProcessingButton);
            this.Controls.Add(this.generateDatasetButton);
            this.Controls.Add(this.addDeliveryButton);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.priorityLabel);
            this.Controls.Add(this.recipientTextBox);
            this.Controls.Add(this.recipientLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.deliveryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recipientLabel;
        private System.Windows.Forms.TextBox recipientTextBox;
        private System.Windows.Forms.Label priorityLabel;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.Button addDeliveryButton;
        private System.Windows.Forms.Button generateDatasetButton;
        private System.Windows.Forms.Button startProcessingButton;
        private System.Windows.Forms.Button stopProcessingButton;
        private System.Windows.Forms.Label pendingLabel;
        private System.Windows.Forms.Label processingLabel;
        private System.Windows.Forms.Label completedLabel;
        private System.Windows.Forms.DataGridView deliveryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

