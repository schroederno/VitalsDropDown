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
using DevExpress.Xpf.Editors;

namespace DropBoxHeightWeightPrototype
{
    /// <summary>
    /// Interaction logic for CustomComboBox.xaml
    /// </summary>
    public partial class CustomComboBox : UserControl
    {
        private bool _isStarted = false;
        public CustomComboBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Text DP

        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string),
                typeof(CustomComboBox), new PropertyMetadata(string.Empty));

        #endregion
        #region IsInches DP

        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public bool IsInches
        {
            get { return (bool)GetValue(IsInchesProperty); }
            set { SetValue(IsInchesProperty, true); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty IsInchesProperty =
            DependencyProperty.Register("IsInches", typeof(bool),
                typeof(CustomComboBox), new PropertyMetadata(true));

        #endregion
        #region IsCentimeters DP

        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public bool IsCentimeters
        {
            get { return (bool)GetValue(IsCentimetersProperty); }
            set { SetValue(IsCentimetersProperty, true); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty IsCentimetersProperty =
            DependencyProperty.Register("IsCentimeters", typeof(bool),
                typeof(CustomComboBox), new PropertyMetadata(false));

        #endregion

        private void Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isStarted)
            {
                _isStarted = true;

                int outNum;
                bool result = int.TryParse(Box.Text, out outNum);
                if (result)
                {
                    _isStarted = true;
                    int feet = outNum / 12;
                    int inches = outNum - (feet * 12);
                    BoxFeet.EditValue = feet;
                    BoxInches.EditValue = inches;
                }
                _isStarted = false;
            }
        }
        public void BtnPressed(string character)
        {
            Box.Text += character;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            BtnDrop.IsChecked = false;
        }

        private void Box_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BtnDrop.IsChecked = true;
        }

        private void BtnArrow_Click(object sender, RoutedEventArgs e)
        {
            string temp = Box.Text;
            if (temp.Length > 0)
                Box.Text = temp.Substring(0, temp.Length - 1);
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            Box.Text = string.Empty;
        }

        private void BoxFeet_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (!_isStarted)
            {
                _isStarted = true;
                if (BoxFeet.SelectedItem != null)
                {
                    string temp = ((ComboBoxEditItem) BoxFeet.SelectedItem).Content.ToString();
                    double outNumFeet;
                    double outNumInches;
                    bool resultFeet = double.TryParse(temp, out outNumFeet);
                    bool resultInches = double.TryParse(BoxInches.EditValue.ToString(), out outNumInches);
                    if (resultFeet && resultInches)
                    {
                        var value = outNumFeet * 12 + outNumInches;
                        Box.Text = value.ToString();
                    }
                }
                _isStarted = false;
            }
        }



        private void BtnPeriod_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += ".";
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "9";
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "8";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "7";
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "6";
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "5";
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "4";
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "3";
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "2";
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "1";
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            Box.Text += "0";
        }

        private void BoxInches_SelectedIndexChanged(object sender, RoutedEventArgs e)
        {
            if (!_isStarted)
            {
                
                _isStarted = true;
                if (BoxInches.SelectedItem != null)
                {
                    string temp = ((ComboBoxEditItem) BoxInches.SelectedItem).Content.ToString();
                    double outNumFeet;
                    double outNumInches;
                    bool resultInches = double.TryParse(temp, out outNumFeet);
                    bool resultFeet = double.TryParse(BoxFeet.EditValue.ToString(), out outNumInches);
                    if (resultFeet && resultInches)
                    {
                        var value = outNumFeet * 12 + outNumInches;
                        Box.Text = value.ToString();
                    }
                }
                _isStarted = false;
            }
        }
    }

}
