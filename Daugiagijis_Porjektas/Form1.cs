using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daugiagijis_Porjektas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;

            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = 1;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                dataGridView1.Rows.Add();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                dataGridView1.Rows.Add();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("", "");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                dataGridView1.Columns.Add("", "");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                dataGridView1.Columns.Add("", "");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                dataGridView2.Rows.Add();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                dataGridView2.Rows.Add();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add("", "");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                dataGridView2.Columns.Add("", "");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                dataGridView2.Columns.Add("", "");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button13_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                PerformAddition();
            });
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                PerformSubtraction();
            });
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                PerformMultiplication();
            });
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void PerformAddition()
        {
            int rows = dataGridView1.RowCount;
            int columns = dataGridView1.ColumnCount;

            if (rows != dataGridView2.RowCount || columns != dataGridView2.ColumnCount)
            {
                MessageBox.Show("Matrica A ir Matrica B turi turėti vienodą dydį.");
                return;
            }

            // Užtikrinkite, kad `dataGridView3` turi pakankamai eilučių ir stulpelių
            dataGridView3.Invoke(() => {
                dataGridView3.RowCount = rows; // Nustatykite reikiamą eilučių skaičių
                dataGridView3.ColumnCount = columns; // Nustatykite reikiamą stulpelių skaičių
            });

            int[,] firstMatrix = new int[rows, columns];
            int[,] secondMatrix = new int[rows, columns];

            // Užpildykite matricas iš `dataGridView1` ir `dataGridView2`
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    firstMatrix[i, j] = Convert.ToInt32(dataGridView1.Invoke(() => dataGridView1.Rows[i].Cells[j].Value));
                    secondMatrix[i, j] = Convert.ToInt32(dataGridView2.Invoke(() => dataGridView2.Rows[i].Cells[j].Value));
                }
            }

            MatricuSkaic calculator = new MatricuSkaic();

            // Naudojame `AddMatrices` metodą
            int[,] resultMatrix = await Task.Run(() => calculator.AddMatrices(firstMatrix, secondMatrix));

            // Užpildykite `dataGridView3` rezultatais
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridView3.Invoke(() => dataGridView3.Rows[i].Cells[j].Value = resultMatrix[i, j]);
                }
            }
        }

        private async void PerformSubtraction()
        {
            int rows = dataGridView1.RowCount;
            int columns = dataGridView1.ColumnCount;

            if (rows != dataGridView2.RowCount || columns != dataGridView2.ColumnCount)
            {
                MessageBox.Show("Matrica A ir Matrica B turi turėti vienodą dydį.");
                return;
            }

            // Užtikrinkite, kad `dataGridView3` turi pakankamai eilučių ir stulpelių
            dataGridView3.Invoke(() => {
                dataGridView3.RowCount = rows; // Nustatykite reikiamą eilučių skaičių
                dataGridView3.ColumnCount = columns; // Nustatykite reikiamą stulpelių skaičių
            });

            int[,] firstMatrix = new int[rows, columns];
            int[,] secondMatrix = new int[rows, columns];

            // Užpildykite matricas iš `dataGridView1` ir `dataGridView2`
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    firstMatrix[i, j] = Convert.ToInt32(dataGridView1.Invoke(() => dataGridView1.Rows[i].Cells[j].Value));
                    secondMatrix[i, j] = Convert.ToInt32(dataGridView2.Invoke(() => dataGridView2.Rows[i].Cells[j].Value));
                }
            }

            MatricuSkaic calculator = new MatricuSkaic();

            // Naudojame `SubtractMatrices` metodą
            int[,] resultMatrix = await Task.Run(() => calculator.SubtractMatrices(firstMatrix, secondMatrix));

            // Užpildykite `dataGridView3` rezultatais
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridView3.Invoke(() => dataGridView3.Rows[i].Cells[j].Value = resultMatrix[i, j]);
                }
            }
        }

        private async void PerformMultiplication()
        {
            // Gaukite matrica A ir B
            int rows1 = dataGridView1.RowCount;
            int columns1 = dataGridView1.ColumnCount;
            int rows2 = dataGridView2.RowCount;
            int columns2 = dataGridView2.ColumnCount;

            if (columns1 != rows2)
            {
                MessageBox.Show("Matricų stulpelių ir eilučių skaičius nesuderinamas daugybai.");
                return;
            }

            // Sukurkite matrica C, kuri bus rezultatų matricas
            dataGridView3.Invoke((MethodInvoker)(() => dataGridView3.RowCount = rows1));
            dataGridView3.Invoke((MethodInvoker)(() => dataGridView3.ColumnCount = columns2));

            // Inicijuokite matricas
            int[,] firstMatrix = new int[rows1, columns1];
            int[,] secondMatrix = new int[rows2, columns2];

            // Užpildykite matricas duomenimis iš `dataGridView1` ir `dataGridView2`
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < columns1; j++)
                {
                    firstMatrix[i, j] = Convert.ToInt32(dataGridView1.Invoke(() => dataGridView1.Rows[i].Cells[j].Value));
                }
            }

            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    secondMatrix[i, j] = Convert.ToInt32(dataGridView2.Invoke(() => dataGridView2.Rows[i].Cells[j].Value));
                }
            }

            MatricuSkaic calculator = new MatricuSkaic();

            // Naudojame `MultiplyMatrices` metodą
            int[,] resultMatrix = await Task.Run(() => calculator.MultiplyMatrices(firstMatrix, secondMatrix));

            // Uždėkite rezultatus į `dataGridView3`
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < columns2; j++)
                {
                    dataGridView3.Invoke(() => dataGridView3.Rows[i].Cells[j].Value = resultMatrix[i, j]);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ColumnCount > 0)
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.ColumnCount - 1);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView2.ColumnCount > 0)
            {
                dataGridView2.Columns.RemoveAt(dataGridView2.ColumnCount - 1);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 1);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.RowCount - 1);
            }
        }
    }
}
