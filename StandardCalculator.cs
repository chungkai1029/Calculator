using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        #region Number
        private void CheckTextBox(string txt)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = txt;
            }
            else
            {
                textBox1.Text += txt;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            CheckTextBox(button0.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckTextBox(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckTextBox(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckTextBox(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckTextBox(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckTextBox(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckTextBox(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckTextBox(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CheckTextBox(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CheckTextBox(button9.Text);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }
        #endregion

        #region Operator
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = textBox1.Text.Split("\r\n");

            // Check if operator match the text in textBox1 and the last charactor is "="
            if (findOperator.IsMatch(textBox1.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        textBox1.Text = textBox1.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(textBox1.Text))
            {
                // Find the match words in first line and get the fitst match operator.
                MatchCollection matches = findOperator.Matches(splitNewLine[0]);
                Match firstMatch = matches[0];

                // If the first match word is "=" then keep text on textbox.
                if (firstMatch.ToString() == "=")
                {
                    textBox1.Text = splitNewLine[0] + "\r\n" + splitNewLine[1];
                    return;
                }

                // Split first line with operator (exclude equal) to get the second number.
                string[] splitOperator = splitNewLine[0].Replace("=", "").Split(firstMatch.ToString());
                decimal num1 = Convert.ToDecimal(splitNewLine[1]);
                decimal num2 = Convert.ToDecimal(splitOperator[1]);

                switch (firstMatch.ToString())
                {
                    case "+":
                        textBox1.Text = $"{num1}+{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        textBox1.Text = $"{num1}-{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        textBox1.Text = $"{num1}กั{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        textBox1.Text = $"{num1}กา{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 / num2);
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
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = textBox1.Text.Split("\r\n");

            // Check if operator match the Text in textBox1 and the last charactor is "="
            if (findOperator.IsMatch(textBox1.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(num1 + num2) + buttonPlus.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(num1 - num2) + buttonPlus.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(num1 * num2) + buttonPlus.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(num1 / num2) + buttonPlus.Text + "\r\n";
                        break;
                }
            }
            else if (findOperator.IsMatch(textBox1.Text))
            {
                textBox1.Text = splitNewLine[1] + buttonPlus.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                textBox1.Text += buttonPlus.Text + "\r\n";
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = textBox1.Text.Split("\r\n");

            // Check if operator match the Text in textBox1 and the last charactor is "="
            if (findOperator.IsMatch(textBox1.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(num1 + num2) + buttonMinus.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(num1 - num2) + buttonMinus.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(num1 * num2) + buttonMinus.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(num1 / num2) + buttonMinus.Text + "\r\n";
                        break;
                }
            }
            else if (findOperator.IsMatch(textBox1.Text))
            {
                textBox1.Text = splitNewLine[1] + buttonMinus.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                textBox1.Text += buttonMinus.Text + "\r\n";
            }
        }

        private void buttonMultiple_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = textBox1.Text.Split("\r\n");

            // Check if operator match the Text in textBox1 and the last charactor is "="
            if (findOperator.IsMatch(textBox1.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(num1 + num2) + buttonMultiple.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(num1 - num2) + buttonMultiple.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(num1 * num2) + buttonMultiple.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(num1 / num2) + buttonMultiple.Text + "\r\n";
                        break;
                }
            }
            else if (findOperator.IsMatch(textBox1.Text))
            {
                textBox1.Text = splitNewLine[1] + buttonMultiple.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                textBox1.Text += buttonMultiple.Text + "\r\n";
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = textBox1.Text.Split("\r\n");

            // Check if operator match the Text in textBox1 and the last charactor is "="
            if (findOperator.IsMatch(textBox1.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        textBox1.Text = Convert.ToString(num1 + num2) + buttonDivide.Text + "\r\n";
                        break;
                    case "-":
                        textBox1.Text = Convert.ToString(num1 - num2) + buttonDivide.Text + "\r\n";
                        break;
                    case "กั":
                        textBox1.Text = Convert.ToString(num1 * num2) + buttonDivide.Text + "\r\n";
                        break;
                    case "กา":
                        textBox1.Text = Convert.ToString(num1 / num2) + buttonDivide.Text + "\r\n";
                        break;
                }
            }
            else if (findOperator.IsMatch(textBox1.Text))
            {
                textBox1.Text = splitNewLine[1] + buttonDivide.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                textBox1.Text += buttonDivide.Text + "\r\n";
            }
        }
        #endregion

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found decimal.
            Regex findDecimal = new Regex("\\.");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = textBox1.Text.Split("\r\n");

            // Find if the string of textbox match or not.
            if (findDecimal.IsMatch(splitNewLine[splitNewLine.Length - 1]))
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