using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ardienter
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(List<string> purchasedItems, double totalCost, int discount)
        {
            InitializeComponent();

            // Display purchased items
            foreach (var item in purchasedItems)
            {
                listBoxReceipt.Items.Add(item);
            }

            // Compute Discounted Amount and Final Amount
            double discountAmount = totalCost * (discount / 100.0);
            double finalAmount = totalCost - discountAmount;

            // Display values
            labelTotal.Text = $"Total: {totalCost:C}";
            labelDiscount.Text = $"Discount: {discount}%";
            labelDiscountedAmount.Text = $"Discounted Amount: {discountAmount:C}";
            labelFinalAmount.Text = $"Final Amount: {finalAmount:C}";
        }
    }
}
