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

namespace ardienter
{
    public partial class Form4: Form
    {
        private Form2 form2;
        public Form4(Form2 parentForm, ListBox purchasedItems, double totalCost, double discountPercentage, double discountAmount, double finalAmount)
        {
            InitializeComponent();
            form2 = parentForm;

            // Display purchased items
            foreach (var item in purchasedItems.Items)
            {
                listBoxReceipt.Items.Add(item);
            }

            // Display cost details
            labelTotal.Text = totalCost.ToString("C");        // Total Cost
            labelDiscount.Text = discountPercentage + "%";       // Discount Percentage
            labelDiscountedAmount.Text = discountAmount.ToString("C");   // Discount Amount
            labelFinalAmount.Text = finalAmount.ToString("C");      // Final Amount After Discount
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            form2.Close();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
