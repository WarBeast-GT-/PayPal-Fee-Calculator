using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayPal_Fee_Calculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Fee_Calculate fee_ = new Fee_Calculate();
        public MainWindow()
        {
            InitializeComponent();
            textBox_pay.TextChanged += TextBox_pay_TextChanged;
            textBox_vendor.TextChanged += TextBox_vendor_TextChanged;
            textBox_fee.TextChanged += TextBox_fee_TextChanged;

            textBox_vendor.GotMouseCapture += TextBox_vendor_GotMouseCapture;
            textBox_pay.GotMouseCapture += TextBox_pay_GotMouseCapture;
            textBox_fee.GotMouseCapture += TextBox_fee_GotMouseCapture;
        }

        private void TextBox_fee_GotMouseCapture(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TextBox_pay_GotMouseCapture(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TextBox_vendor_GotMouseCapture(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TextBox_fee_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_fee.IsFocused == false)
            {
                return;
            }
            else if (textBox_fee.GetLineLength(0) == 0)
            {
                textBox_fee.Text = "0,36";
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox_fee.Text, "[^0-9,]"))
            {
                MessageBox.Show("Please enter only Numbers.");
                textBox_fee.Text = "0,36";
            }
            else if(Convert.ToDouble(textBox_fee.Text) <= 0.35)
            {
                textBox_fee.Text = "0,36";
            }
            fee_.setFee(Convert.ToDouble(textBox_fee.Text));
            fee_.calculatePricePayFromFee();
            fee_.calculatePriceVendor();
            textBox_pay.Text = Convert.ToString(fee_.getPricePay());
            textBox_vendor.Text = Convert.ToString(fee_.getPriceVendor());
        }

        private void TextBox_vendor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(textBox_vendor.IsFocused == false)
            {
                return;
            }
            else if (textBox_vendor.GetLineLength(0) == 0)
            {
                textBox_vendor.Text = "0";
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox_vendor.Text, "[^0-9,]"))
            {
                MessageBox.Show("Please enter only Numbers.");
                textBox_vendor.Text = "0";
            }
            else if (Convert.ToDouble(textBox_vendor.Text) < 0)
            {
                textBox_vendor.Text = "0";
            }
            fee_.setPriceVendor(Convert.ToDouble(textBox_vendor.Text));
            fee_.calculatePricePay();
            fee_.calculateFee();
            textBox_pay.Text = Convert.ToString(fee_.getPricePay());
            textBox_fee.Text = Convert.ToString(fee_.getFee());
        }

        private void TextBox_pay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox_pay.IsFocused == false)
            {
                return;
            }
            else if (textBox_pay.GetLineLength(0) == 0)
            {
                textBox_pay.Text = "0,36";
            }
            else if(System.Text.RegularExpressions.Regex.IsMatch(textBox_pay.Text, "[^0-9,]"))
            {
                MessageBox.Show("Please enter only Numbers.");
                textBox_pay.Text = "0,36";
            }
            else if (Convert.ToDouble(textBox_pay.Text) <= 0.35)
            {
                textBox_pay.Text = "0,36";
            }
            fee_.setPricePay(Convert.ToDouble(textBox_pay.Text));
            fee_.calculatePriceVendor();
            fee_.calculateFee();
            textBox_vendor.Text = Convert.ToString(fee_.getPriceVendor());
            textBox_fee.Text = Convert.ToString(fee_.getFee());
        }
    }
}
