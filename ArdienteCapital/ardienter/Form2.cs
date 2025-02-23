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
    public partial class Form2 : Form
    {
        // Product data
        private string[] products = { "APPLE", "BANANA", "MILK", "CHICKEN", "JUICE", "EGG", "BREAD", "RICE", "SALT", "PORK" };
        private double[] itemPrice = { 9.25, 14.50, 20.20, 25.30, 5.30, 5.25, 9.50, 14.99, 0.99, 19.99 };
        double[] itemStock = { 50, 60, 70, 50, 25, 100, 50, 100, 50, 100 };
        private double totalCost = 0;

        public Form2()
        {
            InitializeComponent();
            LoadProducts();
            LoadPrice();
            LoadStock();

            // Set ListBox to read-only
            listBox1.SelectionMode = SelectionMode.None;
            listBox3.SelectionMode = SelectionMode.None;
            listBox4.SelectionMode = SelectionMode.None;
        }
        private void LoadProducts()
        {
            // Load products into the ListBox with price and stock
            listBox1.Items.Clear();
            listBox1.Items.Add("Product Name"); // Header
            listBox1.Items.Add(new string('-', 40)); // Separator line

            foreach (string product in products)
            {
                listBox1.Items.Add(product);
            }
        }

        private void LoadPrice()
        {
            // Load products into the ListBox with price and stock
            listBox3.Items.Clear();
            listBox3.Items.Add("Price"); // Header
            listBox3.Items.Add(new string('-', 40)); // Separator line

            foreach (double price in itemPrice)
            {
                listBox3.Items.Add($"{price:C}");
            }
        }

        private void LoadStock() 
        {
            // Load products into the ListBox with price and stock
            listBox4.Items.Clear();
            listBox4.Items.Add("Stock"); // Header
            listBox4.Items.Add(new string('-', 40)); // Separator line

            foreach (double stock in itemStock)
            {
                listBox4.Items.Add(stock.ToString());
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex - 2; // Adjust index to account for header
            if (selectedIndex >= 0 && selectedIndex < products.Length)
            {
                textBox2.Text = itemPrice[selectedIndex].ToString("C"); // Auto-fill price
            }
        }

        //Still listbox1 but doubled because of error when designing
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex - 2; // Adjust index to account for header
            if (selectedIndex >= 0 && selectedIndex < products.Length)
            {
                textBox2.Text = itemPrice[selectedIndex].ToString("C"); // Auto-fill price
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string inputProduct = textBox1.Text.Trim().ToUpper();
            int selectedIndex = Array.IndexOf(products, inputProduct);

            if (selectedIndex != -1 && double.TryParse(textBox3.Text, out double quantity) && quantity > 0)
            {
                if (itemStock[selectedIndex] >= quantity)
                {
                    double price = itemPrice[selectedIndex];
                    double itemCost = price * quantity;
                    totalCost += itemCost;

                    itemStock[selectedIndex] -= quantity; // Reduce stock

                    listBox2.Items.Add($"{quantity} x\t {products[selectedIndex]}  \t  {price:C}  \t    {itemCost:C}");

                    LoadStock(); // Refresh stock display
                    // Update total cost in textBox4
                    textBox4.Text = totalCost.ToString("C"); // Display total cost

                    // Calculate and display discount percentage
                    int discount = 0;
                    if (totalCost > 100 && totalCost <= 200)
                    {
                        discount = 10;
                    }
                    else if (totalCost > 200 && totalCost <= 500)
                    {
                        discount = 15;
                    }
                    else if (totalCost > 500)
                    {
                        discount = 20;
                    }

                    textBox5.Text = discount.ToString() + "%"; // Display discount in textBox5

                    // Clear input fields after adding the product
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Not enough stock available.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid product and quantity.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string inputProduct = textBox1.Text.Trim().ToUpper(); // Convert input to uppercase for case-insensitive matching

            int index = Array.IndexOf(products, inputProduct);
            if (index != -1)
            {
                textBox2.Text = itemPrice[index].ToString("C"); // Display price
            }
            else
            {
                textBox2.Clear(); // Clear price if product is not found
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double discountPercentage = 0;

            // Determine discount percentage
            if (totalCost > 100 && totalCost <= 200)
            {
                discountPercentage = 10;
            }
            else if (totalCost > 200 && totalCost <= 500)
            {
                discountPercentage = 15;
            }
            else if (totalCost > 500)
            {
                discountPercentage = 20;
            }

            // Calculate discounted amount and final amount
            double discountAmount = (totalCost * discountPercentage) / 100;
            double finalAmount = totalCost - discountAmount;

            // Pass the list of purchased items and cost details to Form4
            Form4 form4 = new Form4(this, listBox2, totalCost, discountPercentage, discountAmount, finalAmount);
            form4.Show();
        }
    }
}
