namespace PathCalculation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null!;

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
        ///  Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            titleLabel = new Label();
            calculationGrid = new DataGridView();
            gasolinePriceColumn = new DataGridViewTextBoxColumn();
            gasPriceColumn = new DataGridViewTextBoxColumn();
            mileageColumn = new DataGridViewTextBoxColumn();
            savingsColumn = new DataGridViewTextBoxColumn();
            formulaLabel = new Label();
            statusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)calculationGrid).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            titleLabel.Location = new Point(24, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(227, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Расчет километража";
            // 
            // calculationGrid
            // 
            calculationGrid.AllowUserToResizeRows = false;
            calculationGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calculationGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            calculationGrid.BackgroundColor = SystemColors.Window;
            calculationGrid.BorderStyle = BorderStyle.Fixed3D;
            calculationGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            calculationGrid.Columns.AddRange(new DataGridViewColumn[] { gasolinePriceColumn, gasPriceColumn, mileageColumn, savingsColumn });
            calculationGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            calculationGrid.Location = new Point(24, 42);
            calculationGrid.MultiSelect = false;
            calculationGrid.Name = "calculationGrid";
            calculationGrid.RowHeadersVisible = false;
            calculationGrid.RowTemplate.Height = 30;
            calculationGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            calculationGrid.Size = new Size(696, 353);
            calculationGrid.TabIndex = 2;
            calculationGrid.CellEndEdit += calculationGrid_CellEndEdit;
            calculationGrid.CellValueChanged += calculationGrid_CellValueChanged;
            calculationGrid.DataError += calculationGrid_DataError;
            // 
            // gasolinePriceColumn
            // 
            gasolinePriceColumn.FillWeight = 105F;
            gasolinePriceColumn.HeaderText = "Цена бензина";
            gasolinePriceColumn.Name = "gasolinePriceColumn";
            gasolinePriceColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // gasPriceColumn
            // 
            gasPriceColumn.FillWeight = 105F;
            gasPriceColumn.HeaderText = "Цена газа";
            gasPriceColumn.Name = "gasPriceColumn";
            gasPriceColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // mileageColumn
            // 
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Format = "N2";
            mileageColumn.DefaultCellStyle = dataGridViewCellStyle1;
            mileageColumn.FillWeight = 115F;
            mileageColumn.HeaderText = "Километраж";
            mileageColumn.Name = "mileageColumn";
            mileageColumn.ReadOnly = true;
            mileageColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // savingsColumn
            // 
            savingsColumn.FillWeight = 115F;
            savingsColumn.HeaderText = "Экономия";
            savingsColumn.Name = "savingsColumn";
            savingsColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // formulaLabel
            // 
            formulaLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            formulaLabel.AutoSize = true;
            formulaLabel.Location = new Point(487, 21);
            formulaLabel.Name = "formulaLabel";
            formulaLabel.Size = new Size(233, 15);
            formulaLabel.TabIndex = 3;
            formulaLabel.Text = "Формула: км = экономия / (бензин - газ)";
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statusLabel.BorderStyle = BorderStyle.FixedSingle;
            statusLabel.Location = new Point(24, 398);
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(10, 8, 10, 8);
            statusLabel.Size = new Size(696, 43);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "Введите исходные данные в таблицу.";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 464);
            Controls.Add(statusLabel);
            Controls.Add(formulaLabel);
            Controls.Add(calculationGrid);
            Controls.Add(titleLabel);
            MinimumSize = new Size(760, 360);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Калькулятор километража";
            ((System.ComponentModel.ISupportInitialize)calculationGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private DataGridView calculationGrid;
        private DataGridViewTextBoxColumn gasolinePriceColumn;
        private DataGridViewTextBoxColumn gasPriceColumn;
        private DataGridViewTextBoxColumn mileageColumn;
        private DataGridViewTextBoxColumn savingsColumn;
        private Label formulaLabel;
        private Label statusLabel;
    }
}
