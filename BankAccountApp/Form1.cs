using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankAccountApp
{
    public partial class Form1 : Form
    {

        List<BankAccount> AllAccount = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();          
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
                return;

            BankAccount bankAccount = new BankAccount(textBox1.Text);

            AllAccount.Add(bankAccount);

            RefreshGrid();
            MessageBox.Show("Account create sucessfully");
        }

        public void RefreshGrid()
        { 
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = AllAccount;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAccount selectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            selectAccount.Balance += numericUpDown1.Value;
            RefreshGrid();
            numericUpDown1.Value = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BankAccount selectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;

            if (numericUpDown1.Value > selectAccount.Balance)
            {
                // Agar withdraw zyada hai, to kuch na karo
                MessageBox.Show("Insufficient Balance!");
            }

            else
            {
                // Warna normal withdraw kar lo
                selectAccount.Balance -= numericUpDown1.Value;
                RefreshGrid();
            }

            numericUpDown1.Value = 0;
        }


    }
}







