using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Distance_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            double enterDistance;
            double fromConvert = 0;
            double toConvert = 0;
            double convertedDistance;

            if (double.TryParse(DistanceToConvertTextBox.Text, out enterDistance))
            {
                if (FromListBox.SelectedIndex != -1 && ToListBox.SelectedIndex != -1)
                {
                    switch (FromListBox.SelectedItem.ToString())
                    {
                        case "Inches":
                            fromConvert = (double) 1 / 36;
                            break;
                        case "Feet":
                            fromConvert = (double) 1 / 3;
                            break;
                        case "Yards":
                            fromConvert = 1;
                            break;
                    }

                    switch (ToListBox.SelectedItem.ToString())
                    {
                        case "Inches":
                            toConvert = 36;
                            break;
                        case "Feet":
                            toConvert = 3;
                            break;
                        case "Yards":
                            toConvert = 1;
                            break;
                    }

                    convertedDistance = enterDistance * fromConvert * toConvert;
                    ConvertedDistanceLabel.Text = convertedDistance.ToString("n2");
                    DistanceToConvertTextBox.Focus();
                }
                else
                {
                    MessageBox.Show("Выберите оба поля!");
                }
            }
            else
            {
                DistanceToConvertTextBox.Focus();
                MessageBox.Show("Введите корректное число!");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
