using System.Globalization;

namespace PathCalculation
{
    public partial class Form1 : Form
    {
        private const int GasolinePriceColumnIndex = 0;
        private const int GasPriceColumnIndex = 1;
        private const int MileageColumnIndex = 2;
        private const int SavingsColumnIndex = 3;

        private bool isUpdatingMileage;

        public Form1()
        {
            InitializeComponent();
            InitializeTable();
        }

        private void InitializeTable()
        {
            if (calculationGrid.Rows.Count > 0)
            {
                calculationGrid.CurrentCell = calculationGrid.Rows[0].Cells[GasolinePriceColumnIndex];
            }

            UpdateStatus("Введите данные. Для новой строки начните ввод в последней пустой строке таблицы.");
        }

        private void calculationGrid_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == MileageColumnIndex || isUpdatingMileage)
            {
                return;
            }

            RecalculateMileage(e.RowIndex);
        }

        private void calculationGrid_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RecalculateMileage(e.RowIndex);
            }
        }

        private void calculationGrid_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            if (e.RowIndex >= 0)
            {
                ClearMileageCell(e.RowIndex);
            }

            UpdateStatus("Используйте только числовые значения.");
        }

        private void RecalculateMileage(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= calculationGrid.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = calculationGrid.Rows[rowIndex];

            if (IsRowEmpty(row))
            {
                ClearMileageCell(rowIndex);
                UpdateStatus("Введите данные. Для новой строки начните ввод в последней пустой строке таблицы.");
                return;
            }

            if (!TryReadDecimal(row, GasolinePriceColumnIndex, "Цена бензина", out decimal gasolinePrice, out string gasolineError))
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, gasolineError));
                return;
            }

            if (gasolinePrice < 0)
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, "цена бензина не может быть отрицательной."));
                return;
            }

            if (!TryReadDecimal(row, GasPriceColumnIndex, "Цена газа", out decimal gasPrice, out string gasError))
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, gasError));
                return;
            }

            if (gasPrice < 0)
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, "цена газа не может быть отрицательной."));
                return;
            }

            if (!TryReadDecimal(row, SavingsColumnIndex, "Экономия", out decimal savings, out string savingsError))
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, savingsError));
                return;
            }

            if (savings < 0)
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, "экономия не может быть отрицательной."));
                return;
            }

            decimal difference = gasolinePrice - gasPrice;
            if (difference <= 0)
            {
                ClearMileageCell(rowIndex);
                UpdateStatus(BuildRowMessage(rowIndex, "цена бензина должна быть больше цены газа."));
                return;
            }

            decimal mileage = decimal.Round(savings / difference, 2, MidpointRounding.AwayFromZero);
            SetMileageValue(rowIndex, mileage);
            UpdateStatus(BuildRowMessage(rowIndex, $"нужно проехать {mileage:N2} км, чтобы получить экономию {savings:N2}."));
        }

        private bool TryReadDecimal(
            DataGridViewRow row,
            int columnIndex,
            string fieldName,
            out decimal value,
            out string errorMessage)
        {
            string rawValue = GetCellText(row, columnIndex);

            if (string.IsNullOrWhiteSpace(rawValue))
            {
                value = 0;
                errorMessage = $"введите значение в поле \"{fieldName}\".";
                return false;
            }

            if (!decimal.TryParse(rawValue, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                errorMessage = $"поле \"{fieldName}\" должно содержать число.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private bool IsRowEmpty(DataGridViewRow row)
        {
            return string.IsNullOrWhiteSpace(GetCellText(row, GasolinePriceColumnIndex))
                && string.IsNullOrWhiteSpace(GetCellText(row, GasPriceColumnIndex))
                && string.IsNullOrWhiteSpace(GetCellText(row, SavingsColumnIndex));
        }

        private string GetCellText(DataGridViewRow row, int columnIndex)
        {
            return Convert.ToString(row.Cells[columnIndex].EditedFormattedValue, CultureInfo.CurrentCulture)?.Trim() ?? string.Empty;
        }

        private void ClearMileageCell(int rowIndex)
        {
            SetMileageValue(rowIndex, null);
        }

        private void SetMileageValue(int rowIndex, decimal? mileage)
        {
            if (rowIndex < 0 || rowIndex >= calculationGrid.Rows.Count)
            {
                return;
            }

            isUpdatingMileage = true;
            calculationGrid.Rows[rowIndex].Cells[MileageColumnIndex].Value = mileage;
            isUpdatingMileage = false;
        }

        private static string BuildRowMessage(int rowIndex, string message)
        {
            return $"Строка {rowIndex + 1}: {message}";
        }

        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }

    }
}
