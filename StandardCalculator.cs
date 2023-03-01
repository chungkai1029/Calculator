using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                return;
            }
            else
            {
                textBox1.Text += button0.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button1.Text;
            }
            else
            {
                textBox1.Text += button1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button2.Text;
            }
            else
            {
                textBox1.Text += button2.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button3.Text;
            }
            else
            {
                textBox1.Text += button3.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button4.Text;
            }
            else
            {
                textBox1.Text += button4.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button5.Text;
            }
            else
            {
                textBox1.Text += button5.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button6.Text;
            }
            else
            {
                textBox1.Text += button6.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button7.Text;
            }
            else
            {
                textBox1.Text += button7.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button8.Text;
            }
            else
            {
                textBox1.Text += button8.Text;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = button9.Text;
            }
            else
            {
                textBox1.Text += button9.Text;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex regex = new Regex(@"[\p{Sm}\p{Pd}]");

            if (regex.IsMatch(textBox1.Text))
            {
                // Split the string of textbox with new Line.
                string[] newLineSplit = textBox1.Text.Split("\r\n");

                // Find the match word.
                Match match = regex.Match(newLineSplit[0]);
                int firstNum = Convert.ToInt32(newLineSplit[0].Replace(match.ToString(), ""));
                int secondNum = Convert.ToInt32(newLineSplit[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(firstNum + secondNum);
                        break;
                    case "-":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(firstNum - secondNum);
                        break;
                    case "กั":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(firstNum * secondNum);
                        break;
                    case "กา":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(firstNum / secondNum);
                        break;
                }
            }
            else
            {
                textBox1.Text += buttonEqual.Text + "\r\n" + textBox1.Text;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found math symbol.
            Regex regex = new Regex(@"[\p{Sm}\p{Pd}]");

            // Find if the string of textbox match or not.
            if (regex.IsMatch(textBox1.Text))
            {
                // Split the string of textbox with new Line.
                string[] newLineSplit = textBox1.Text.Split("\r\n");

                // Find the match word.
                Match match = regex.Match(newLineSplit[0]);
                int firstNum = Convert.ToInt32(newLineSplit[0].Replace(match.ToString(), ""));
                int secondNum = Convert.ToInt32(newLineSplit[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(firstNum + secondNum) + buttonPlus.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(firstNum - secondNum) + buttonPlus.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(firstNum * secondNum) + buttonPlus.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(firstNum / secondNum) + buttonPlus.Text + "\r\n";
                        break;
                }
            }
            else
            {
                textBox1.Text += buttonPlus.Text + "\r\n";
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex regex = new Regex(@"[\p{Sm}\p{Pd}]");

            // Find if the string of textbox match or not.
            if (regex.IsMatch(textBox1.Text))
            {
                // Split the string of textbox with new Line.
                string[] newLineSplit = textBox1.Text.Split("\r\n");

                // Find the match word.
                Match match = regex.Match(newLineSplit[0]);
                int firstNum = Convert.ToInt32(newLineSplit[0].Replace(match.ToString(), ""));
                int secondNum = Convert.ToInt32(newLineSplit[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(firstNum + secondNum) + buttonMinus.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(firstNum - secondNum) + buttonMinus.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(firstNum * secondNum) + buttonMinus.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(firstNum / secondNum) + buttonMinus.Text + "\r\n";
                        break;
                }
            }
            else
            {
                textBox1.Text += buttonMinus.Text + "\r\n";
            }
        }

        private void buttonMultiple_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex regex = new Regex(@"[\p{Sm}\p{Pd}]");

            // Find if the string of textbox match or not.
            if (regex.IsMatch(textBox1.Text))
            {
                // Split the string of textbox with new Line.
                string[] newLineSplit = textBox1.Text.Split("\r\n");

                // Find the match word.
                Match match = regex.Match(newLineSplit[0]);
                int firstNum = Convert.ToInt32(newLineSplit[0].Replace(match.ToString(), ""));
                int secondNum = Convert.ToInt32(newLineSplit[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(firstNum + secondNum) + buttonMultiple.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(firstNum - secondNum) + buttonMultiple.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(firstNum * secondNum) + buttonMultiple.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(firstNum / secondNum) + buttonMultiple.Text + "\r\n";
                        break;
                }
            }
            else
            {
                textBox1.Text += buttonMultiple.Text + "\r\n";
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex regex = new Regex(@"[\p{Sm}\p{Pd}]");

            // Find if the string of textbox match or not.
            if (regex.IsMatch(textBox1.Text))
            {
                // Split the string of textbox with new Line.
                string[] newLineSplit = textBox1.Text.Split("\r\n");

                // Find the match word.
                Match match = regex.Match(newLineSplit[0]);
                int firstNum = Convert.ToInt32(newLineSplit[0].Replace(match.ToString(), ""));
                int secondNum = Convert.ToInt32(newLineSplit[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(firstNum + secondNum) + buttonDivide.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(firstNum - secondNum) + buttonDivide.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(firstNum * secondNum) + buttonDivide.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(firstNum / secondNum) + buttonDivide.Text + "\r\n";
                        break;
                }
            }
            else
            {
                textBox1.Text += buttonDivide.Text + "\r\n";
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found decimal.
            Regex regex = new Regex("\\.");

            // Find if the string of textbox match or not.
            if (regex.IsMatch(textBox1.Text))
            {
                return;
            }
            else
            {
                textBox1.Text += ".";
            }
        }

        private void buttonInverse_Click(object sender, EventArgs e)
        {

        }
    }
}