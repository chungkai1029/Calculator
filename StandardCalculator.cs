using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class Calculator : Form
    {
        // A flag to check if the string of last line could be replaced.
        bool isFisrtWord = false;

        public Calculator()
        {
            InitializeComponent();
        }

        #region Number
        private void CheckTextBox(string txt)
        {
            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            if (ScreenBox.Text == "0")
            {
                ScreenBox.Text = txt;
            }
            else if (isFisrtWord == true)
            {
                ScreenBox.Text = ScreenBox.Text.Replace($"\r\n{splitNewLine[splitNewLine.Length - 1]}", $"\r\n{txt}");
                isFisrtWord = false;
            }
            else
            {
                ScreenBox.Text += txt;
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
        #endregion

        #region Clear
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ScreenBox.Text = "0";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of last line.
            isFisrtWord = true;

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Replace the text of last line to "0".
            if (splitNewLine.Length > 1)
            {
                ScreenBox.Text = ScreenBox.Text.Replace($"\r\n{splitNewLine[splitNewLine.Length - 1]}", $"\r\n{0}");
            }
            else
            {
                ScreenBox.Text = ScreenBox.Text.Replace(splitNewLine[splitNewLine.Length - 1], "0");
            }
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of last line.
            isFisrtWord = true;

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // And find the last string in the textbox.
            string lastString = splitNewLine[splitNewLine.Length - 1];

            // Substring the last character to replace the last string.
            if (lastString.Length <= 1)
            {
                ScreenBox.Text = ScreenBox.Text.Replace(lastString, "0");
            }
            else
            {
                ScreenBox.Text = ScreenBox.Text.Replace(lastString, lastString.Substring(0, lastString.Length - 1));
            }
        }
        #endregion

        #region Operator
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of last line.
            isFisrtWord = true;

            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Check if operator match the text in ScreenBox and the last charactor is "="
            if (findOperator.IsMatch(ScreenBox.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        ScreenBox.Text = ScreenBox.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        ScreenBox.Text = ScreenBox.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        ScreenBox.Text = ScreenBox.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        ScreenBox.Text = ScreenBox.Text.Replace("\r\n", "") + buttonEqual.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(ScreenBox.Text))
            {
                // Find the match words in first line and get the fitst match operator.
                MatchCollection matches = findOperator.Matches(splitNewLine[0]);
                Match firstMatch = matches[0];

                // If the first match word is "=" then keep text on textbox.
                if (firstMatch.ToString() == "=")
                {
                    ScreenBox.Text = splitNewLine[0] + "\r\n" + splitNewLine[1];
                    return;
                }

                // Split first line with operator (exclude equal) to get the second number.
                string[] splitOperator = splitNewLine[0].Replace("=", "").Split(firstMatch.ToString());
                decimal num1 = Convert.ToDecimal(splitNewLine[1]);
                decimal num2 = Convert.ToDecimal(splitOperator[1]);

                switch (firstMatch.ToString())
                {
                    case "+":
                        ScreenBox.Text = $"{num1}+{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        ScreenBox.Text = $"{num1}-{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        ScreenBox.Text = $"{num1}กั{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        ScreenBox.Text = $"{num1}กา{num2}" + buttonEqual.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else
            {
                ScreenBox.Text += buttonEqual.Text + "\r\n" + ScreenBox.Text;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of last line.
            isFisrtWord = true;

            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Check if operator match the text in ScreenBox and the last charactor is "="
            if (findOperator.IsMatch(ScreenBox.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        ScreenBox.Text = Convert.ToString(num1 + num2) + buttonPlus.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        ScreenBox.Text = Convert.ToString(num1 - num2) + buttonPlus.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        ScreenBox.Text = Convert.ToString(num1 * num2) + buttonPlus.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        ScreenBox.Text = Convert.ToString(num1 / num2) + buttonPlus.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(ScreenBox.Text))
            {
                ScreenBox.Text = splitNewLine[1] + buttonPlus.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                ScreenBox.Text += buttonPlus.Text + "\r\n" + splitNewLine[0];
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of last line.
            isFisrtWord = true;

            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Check if operator match the text in ScreenBox and the last charactor is "="
            if (findOperator.IsMatch(ScreenBox.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        ScreenBox.Text = Convert.ToString(num1 + num2) + buttonMinus.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        ScreenBox.Text = Convert.ToString(num1 - num2) + buttonMinus.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        ScreenBox.Text = Convert.ToString(num1 * num2) + buttonMinus.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        ScreenBox.Text = Convert.ToString(num1 / num2) + buttonMinus.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(ScreenBox.Text))
            {
                ScreenBox.Text = splitNewLine[1] + buttonMinus.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                ScreenBox.Text += buttonMinus.Text + "\r\n" + splitNewLine[0];
            }
        }

        private void buttonMultiple_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of last line.
            isFisrtWord = true;

            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Check if operator match the text in ScreenBox and the last charactor is "="
            if (findOperator.IsMatch(ScreenBox.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        ScreenBox.Text = Convert.ToString(num1 + num2) + buttonMultiple.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        ScreenBox.Text = Convert.ToString(num1 - num2) + buttonMultiple.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        ScreenBox.Text = Convert.ToString(num1 * num2) + buttonMultiple.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        ScreenBox.Text = Convert.ToString(num1 / num2) + buttonMultiple.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(ScreenBox.Text))
            {
                ScreenBox.Text = splitNewLine[1] + buttonMultiple.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                ScreenBox.Text += buttonMultiple.Text + "\r\n" + splitNewLine[0];
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            // Change the bool flag to mark the first word of lsat line.
            isFisrtWord = true;

            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Check if operator match the text in ScreenBox and the last charactor is "="
            if (findOperator.IsMatch(ScreenBox.Text) && splitNewLine[0].LastIndexOf("=") == -1)
            {
                // Find the match operator in first line.
                Match match = findOperator.Match(splitNewLine[0]);
                decimal num1 = Convert.ToDecimal(splitNewLine[0].Replace(match.ToString(), ""));
                decimal num2 = Convert.ToDecimal(splitNewLine[1]);

                switch (match.ToString())
                {
                    case "+":
                        ScreenBox.Text = Convert.ToString(num1 + num2) + buttonDivide.Text + "\r\n" + Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        ScreenBox.Text = Convert.ToString(num1 - num2) + buttonDivide.Text + "\r\n" + Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        ScreenBox.Text = Convert.ToString(num1 * num2) + buttonDivide.Text + "\r\n" + Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        ScreenBox.Text = Convert.ToString(num1 / num2) + buttonDivide.Text + "\r\n" + Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(ScreenBox.Text))
            {
                ScreenBox.Text = splitNewLine[1] + buttonDivide.Text + "\r\n" + splitNewLine[1];
            }
            else
            {
                ScreenBox.Text += buttonDivide.Text + "\r\n" + splitNewLine[0];
            }
        }
        #endregion

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found decimal.
            Regex findDecimal = new Regex("\\.");

            // Split the string of textbox with new line character(in Windows).
            string[] splitNewLine = ScreenBox.Text.Split("\r\n");

            // Find if the string of textbox match or not.
            if (findDecimal.IsMatch(splitNewLine[splitNewLine.Length - 1]))
            {
                return;
            }
            else
            {
                ScreenBox.Text += ".";
            }
        }

        private void buttonFraction_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {

        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {

        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {

        }

        private void buttonInverse_Click(object sender, EventArgs e)
        {

        }
    }
}