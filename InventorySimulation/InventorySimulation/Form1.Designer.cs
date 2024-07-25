namespace InventorySimulation
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
            this.simulate = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ae = new System.Windows.Forms.TextBox();
            this.As = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayWithinCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginingInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.randomDemand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndingInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RandomLeadDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysUntillordercome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // simulate
            // 
            this.simulate.Location = new System.Drawing.Point(536, 422);
            this.simulate.Name = "simulate";
            this.simulate.Size = new System.Drawing.Size(119, 45);
            this.simulate.TabIndex = 2;
            this.simulate.Text = "simulate";
            this.simulate.UseVisualStyleBackColor = true;
            this.simulate.Click += new System.EventHandler(this.simulate_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Day,
            this.Cycle,
            this.DayWithinCode,
            this.BeginingInventory,
            this.randomDemand,
            this.Demand,
            this.EndingInventory,
            this.ShortageQuantity,
            this.OrderQuantity,
            this.RandomLeadDay,
            this.LeadDay,
            this.DaysUntillordercome});
            this.dataGridView1.Location = new System.Drawing.Point(11, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1529, 391);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ending Enventory Avarege";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(763, 548);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Shortage Quantity Average";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ae
            // 
            this.ae.Location = new System.Drawing.Point(536, 541);
            this.ae.Name = "ae";
            this.ae.Size = new System.Drawing.Size(79, 22);
            this.ae.TabIndex = 12;
            this.ae.TextChanged += new System.EventHandler(this.ae_TextChanged);
            // 
            // As
            // 
            this.As.Location = new System.Drawing.Point(976, 548);
            this.As.Name = "As";
            this.As.Size = new System.Drawing.Size(85, 22);
            this.As.TabIndex = 13;
            this.As.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(250, 433);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 24);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "SelectTestCase\r\n";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Day
            // 
            this.Day.HeaderText = "Day";
            this.Day.MinimumWidth = 6;
            this.Day.Name = "Day";
            this.Day.Width = 125;
            // 
            // Cycle
            // 
            this.Cycle.HeaderText = "Cycle";
            this.Cycle.MinimumWidth = 6;
            this.Cycle.Name = "Cycle";
            this.Cycle.Width = 125;
            // 
            // DayWithinCode
            // 
            this.DayWithinCode.HeaderText = "DayWithinCycle";
            this.DayWithinCode.MinimumWidth = 6;
            this.DayWithinCode.Name = "DayWithinCode";
            this.DayWithinCode.Width = 125;
            // 
            // BeginingInventory
            // 
            this.BeginingInventory.HeaderText = "BeginingInventory";
            this.BeginingInventory.MinimumWidth = 6;
            this.BeginingInventory.Name = "BeginingInventory";
            this.BeginingInventory.Width = 125;
            // 
            // randomDemand
            // 
            this.randomDemand.HeaderText = "RandomDemand";
            this.randomDemand.MinimumWidth = 6;
            this.randomDemand.Name = "randomDemand";
            this.randomDemand.Width = 125;
            // 
            // Demand
            // 
            this.Demand.HeaderText = "Demand";
            this.Demand.MinimumWidth = 6;
            this.Demand.Name = "Demand";
            this.Demand.Width = 125;
            // 
            // EndingInventory
            // 
            this.EndingInventory.HeaderText = "EndingInventory";
            this.EndingInventory.MinimumWidth = 6;
            this.EndingInventory.Name = "EndingInventory";
            this.EndingInventory.Width = 125;
            // 
            // ShortageQuantity
            // 
            this.ShortageQuantity.HeaderText = "ShortageQuantity";
            this.ShortageQuantity.MinimumWidth = 6;
            this.ShortageQuantity.Name = "ShortageQuantity";
            this.ShortageQuantity.Width = 125;
            // 
            // OrderQuantity
            // 
            this.OrderQuantity.HeaderText = "OrderQuantity";
            this.OrderQuantity.MinimumWidth = 6;
            this.OrderQuantity.Name = "OrderQuantity";
            this.OrderQuantity.Width = 125;
            // 
            // RandomLeadDay
            // 
            this.RandomLeadDay.HeaderText = "RandomLeadDay";
            this.RandomLeadDay.MinimumWidth = 6;
            this.RandomLeadDay.Name = "RandomLeadDay";
            this.RandomLeadDay.Width = 125;
            // 
            // LeadDay
            // 
            this.LeadDay.HeaderText = "LeadDay";
            this.LeadDay.MinimumWidth = 6;
            this.LeadDay.Name = "LeadDay";
            this.LeadDay.Width = 125;
            // 
            // DaysUntillordercome
            // 
            this.DaysUntillordercome.HeaderText = "DaysUntillordercome";
            this.DaysUntillordercome.MinimumWidth = 6;
            this.DaysUntillordercome.Name = "DaysUntillordercome";
            this.DaysUntillordercome.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 591);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.As);
            this.Controls.Add(this.ae);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.simulate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button simulate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ae;
        private System.Windows.Forms.TextBox As;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayWithinCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginingInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn randomDemand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndingInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortageQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn RandomLeadDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysUntillordercome;
    }
}