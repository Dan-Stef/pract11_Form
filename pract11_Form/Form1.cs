using System;
using System.Windows.Forms;

namespace pract11_Form
{
    public partial class Form1 : Form
    {
        int[,] IntArray;
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && isValid(textBox1.Text))
            {
                SetStricture(Convert.ToInt32(textBox1.Text));
            }
        }

        private void SetStricture(int x)
        {
            dataGridView1.ColumnCount = x;
            dataGridView1.RowCount = x;
            dataGridView2.ColumnCount = x;
            dataGridView2.RowCount = x;
            n = x;
            IntArray = new int[x,x];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private bool isValid(String str)
        {
            char[] chArr = str.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (!(chArr[i] >= '0' && chArr[i] <= '9') && chArr[i] != ',')
                {
                    return false;
                }
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            getColumnSum();
        }

        

        private void getDataForTwoDimArray()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    
                    IntArray[rows,col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
        }
        private void getColumnSum()
        {
            int[] temp = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int k = 0; k < n; k++)
                {
                    sum += IntArray[k, i];
                }
                temp[i] = sum;
            }
            dataGridView3.ColumnCount = n;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            for (int i = 0; i < n; i++)
            {
                dataGridView3.Rows[0].Cells[i].Value = temp[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (IntArray[i, k] == 0) count++;


                }
            }
            textBox4.Text = Convert.ToString(count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            if (textBox2.Text != "" && isValid(textBox2.Text))
            {
                for (int i = 0; i < n; i++)
                {
                    IntArray[i, i] = Convert.ToInt32(textBox2.Text);
                }
                for (int i = 0; i < n ; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        dataGridView1.Rows[i].Cells[k].Value = IntArray[i, k];
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    dataGridView1.Rows[i].Cells[k].Value = IntArray[i, k] + 1;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    dataGridView1.Rows[i].Cells[k].Value = IntArray[i, k] - 1;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            getDataForTwoDimArray();
            if (textBox6.Text != "" && isValid(textBox6.Text) && textBox5.Text != "" && isValid(textBox5.Text))
            {
                textBox7.Text = Convert.ToString(IntArray[Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text)]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            getDataForAnotherTwoDimArray();
        }
        private void getDataForAnotherTwoDimArray()
        {
            getDataForTwoDimArray();
            int[,] IntArray1 = new int[n, n];
            for (int rows = 0; rows < dataGridView2.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView2.Rows[rows].Cells.Count; col++)
                {

                    IntArray1[rows, col] = Convert.ToInt32(dataGridView2.Rows[rows].Cells[col].Value);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    IntArray[i, k] += IntArray1[i, k];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    dataGridView1.Rows[i].Cells[k].Value = IntArray[i, k];
                }
            }
        }
    }
}
