using System.Text.RegularExpressions;

namespace Calculator
{
    public partial class StandardCalculator : Form
    {
        // A bool flag to check if the text of Lower Screen could be replaced.
        bool isFisrtWord = false;

        public StandardCalculator()
        {
            InitializeComponent();
        }

        #region Number
        private void CheckScreen(string txt)
        {
            if (isFisrtWord == true)
            {
                LowerScreen.Text = txt;
                isFisrtWord = false;    // Change the bool flag to mark the text of LowerScreen could not be replaced.
            }
            else if (LowerScreen.Text == "0")
            {
                LowerScreen.Text = txt;
            }
            else
            {
                LowerScreen.Text += txt;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            CheckScreen(button0.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckScreen(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckScreen(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckScreen(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckScreen(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckScreen(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckScreen(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckScreen(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CheckScreen(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CheckScreen(button9.Text);
        }
        #endregion

        #region Clear
        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Clear the text of UpperScreen and LowerScreen.
            UpperScreen.Text = "";
            LowerScreen.Text = "0";
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            // Clear the text of LowerScreen only.
            LowerScreen.Text = "0";
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            // Get the text of LowerScreen.
            string lowerText = LowerScreen.Text;

            // Substring the last character to replace the text of LowerScreen.
            if (lowerText.Length <= 1)
            {
                LowerScreen.Text = "0";
            }
            else
            {
                LowerScreen.Text = lowerText.Substring(0, lowerText.Length - 1);
            }
        }
        #endregion

        #region Operator
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            // Check if operator match the text of UpperScreen and the last charactor is "=".
            if (findOperator.IsMatch(upperText) && upperText.LastIndexOf("=") == -1)
            {
                // Find the match operator in the text of UpperScreen.
                Match match = findOperator.Match(upperText);
                double num1 = Convert.ToDouble(upperText.Replace(match.ToString(), ""));
                double num2 = Convert.ToDouble(lowerText);

                switch (match.ToString())
                {
                    case "+":
                        UpperScreen.Text = upperText + lowerText + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        UpperScreen.Text = upperText + lowerText + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        UpperScreen.Text = upperText + lowerText + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        UpperScreen.Text = upperText + lowerText + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 / num2);
                        break;
                }
            }
            else if (findOperator.IsMatch(UpperScreen.Text))
            {
                // Find the match operators in the text of UpperScreen and get the first match operator.
                MatchCollection matches = findOperator.Matches(upperText);
                Match firstMatch = matches.First();

                // If the first match word is "=" then keep the text of UpperScreen and LowerScreen.
                if (firstMatch.ToString() == "=")
                {
                    return;
                }

                // Split first line with operator (exclude equal) to get the second number.
                string[] splitOperator = upperText.Replace("=", "").Split(firstMatch.ToString());
                double num1 = Convert.ToDouble(lowerText);
                double num2 = Convert.ToDouble(splitOperator[1]);

                switch (firstMatch.ToString())
                {
                    case "+":
                        UpperScreen.Text = $"{num1}+{num2}" + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        UpperScreen.Text = $"{num1}-{num2}" + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        UpperScreen.Text = $"{num1}กั{num2}" + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        UpperScreen.Text = $"{num1}กา{num2}" + buttonEqual.Text;
                        LowerScreen.Text = Convert.ToString(num1 / num2);
                        break;
                }
            }
            else
            {
                UpperScreen.Text = lowerText + buttonEqual.Text;
            }

            // Then change the bool flag to mark the text of LowerScreen could be replaced.
            isFisrtWord = true;
        }

        private void OperatorExceptEqual(string txt)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            // Check if the bool flag is true or false.
            if (isFisrtWord == true && upperText.LastIndexOf("=") == -1)
            {
                UpperScreen.Text = upperText.Substring(0, upperText.Length - 1) + txt;
            }
            else if (findOperator.IsMatch(upperText) && upperText.LastIndexOf("=") == -1)   // Check if operator match the text of UpperScreen and the last charactor is "=".
            {
                // Find the match operator in the text of UpperScreen.
                Match match = findOperator.Match(upperText);
                double num1 = Convert.ToDouble(upperText.Replace(match.ToString(), ""));
                double num2 = Convert.ToDouble(lowerText);

                switch (match.ToString())
                {
                    case "+":
                        UpperScreen.Text = Convert.ToString(num1 + num2) + txt;
                        LowerScreen.Text = Convert.ToString(num1 + num2);
                        break;
                    case "-":
                        UpperScreen.Text = Convert.ToString(num1 - num2) + txt;
                        LowerScreen.Text = Convert.ToString(num1 - num2);
                        break;
                    case "กั":
                        UpperScreen.Text = Convert.ToString(num1 * num2) + txt;
                        LowerScreen.Text = Convert.ToString(num1 * num2);
                        break;
                    case "กา":
                        UpperScreen.Text = Convert.ToString(num1 / num2) + txt;
                        LowerScreen.Text = Convert.ToString(num1 / num2);
                        break;
                }
            }
            else
            {
                UpperScreen.Text = lowerText + txt;
            }

            // Tehn change the bool flag to mark the text of LowerScreen could be replaced.
            isFisrtWord = true;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            OperatorExceptEqual(buttonPlus.Text);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            OperatorExceptEqual(buttonMinus.Text);
        }

        private void buttonMultiple_Click(object sender, EventArgs e)
        {
            OperatorExceptEqual(buttonMultiple.Text);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            OperatorExceptEqual(buttonDivide.Text);
        }
        #endregion

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found decimal.
            Regex findDecimal = new Regex("\\.");

            // Get the text of LowerScreen.
            string lowerText = LowerScreen.Text;

            // Find if the text of LowerScreen match decimal or not.
            if (findDecimal.IsMatch(lowerText))
            {
                return;
            }
            else if(isFisrtWord == true)
            {
                LowerScreen.Text = "0.";
                isFisrtWord = false;    // Change the bool flag to mark the text of LowerScreen could not be replaced.
            }
            else
            {
                LowerScreen.Text += ".";
            }
        }

        private void buttonFraction_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            // Check if operator match the text of UpperScreen and the last charactor is "=".
            if (findOperator.IsMatch(upperText) && upperText.LastIndexOf("=") == -1)
            {
                // Find the match operators in the text of UpperScreen and get the last match operator.
                MatchCollection matches = findOperator.Matches(upperText);
                Match firstMatch = matches.First();

                // Split first line with operator (exclude equal) to get the second number.
                string[] splitOperator = upperText.Split(firstMatch.ToString());
                string number = splitOperator[1];

                if (number == "")
                {
                    UpperScreen.Text += $"1/({lowerText})";
                    LowerScreen.Text = Convert.ToString(1 / Convert.ToDouble(lowerText));
                }
                else
                {
                    UpperScreen.Text = upperText.Replace(number, $"1/({number})");
                    LowerScreen.Text = Convert.ToString(1 / Convert.ToDouble(lowerText));
                }
            }
            else if (!findOperator.IsMatch(upperText) && upperText.Length > 0)
            {
                UpperScreen.Text = $"1/({upperText})";
                LowerScreen.Text = Convert.ToString(1 / Convert.ToDouble(lowerText));
            }
            else
            {
                UpperScreen.Text = $"1/({lowerText})";
                LowerScreen.Text = Convert.ToString(1 / Convert.ToDouble(lowerText));
            }

            // Change the bool flag to mark the text of LowerScreen could not be replaced.
            isFisrtWord = false;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            // Check if operator match the text of UpperScreen and the last charactor is "=".
            if (findOperator.IsMatch(upperText) && upperText.LastIndexOf("=") == -1)
            {
                // Find the match operators in the text of UpperScreen and get the last match operator.
                MatchCollection matches = findOperator.Matches(upperText);
                Match firstMatch = matches.First();

                // Split first line with operator (exclude equal) to get the second number.
                string[] splitOperator = upperText.Split(firstMatch.ToString());
                string number = splitOperator[1];

                if (number == "")
                {
                    UpperScreen.Text += $"sqr({lowerText})";
                    LowerScreen.Text = Convert.ToString(Math.Pow(Convert.ToDouble(lowerText), 2));
                }
                else
                {
                    UpperScreen.Text = upperText.Replace(number, $"sqr({number})");
                    LowerScreen.Text = Convert.ToString(Math.Pow(Convert.ToDouble(lowerText), 2));
                }
            }
            else if (!findOperator.IsMatch(upperText) && upperText.Length > 0)
            {
                UpperScreen.Text = $"sqr({upperText})";
                LowerScreen.Text = Convert.ToString(Math.Pow(Convert.ToDouble(lowerText), 2));
            }
            else
            {
                UpperScreen.Text = $"sqr({lowerText})";
                LowerScreen.Text = Convert.ToString(Math.Pow(Convert.ToDouble(lowerText), 2));
            }

            // Change the bool flag to mark the text of LowerScreen could not be replaced.
            isFisrtWord = false;
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            // Check if operator match the text of UpperScreen and the last charactor is "=".
            if (findOperator.IsMatch(upperText) && upperText.LastIndexOf("=") == -1)
            {
                // Find the match operators in the text of UpperScreen and get the last match operator.
                MatchCollection matches = findOperator.Matches(upperText);
                Match firstMatch = matches.First();
                Match lastMatch = matches.Last();

                if (lastMatch.ToString() == buttonRoot.Text && firstMatch.ToString() == lastMatch.ToString())
                {
                    UpperScreen.Text = $"{buttonRoot.Text}({upperText})";
                    LowerScreen.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(lowerText)));
                }
                else if (lastMatch.ToString() == buttonRoot.Text && firstMatch.ToString() != lastMatch.ToString())
                {
                    // Split first line with operator (exclude equal) to get the second number.
                    string[] splitOperator = upperText.Split(firstMatch.ToString());
                    string number = splitOperator[1];

                    UpperScreen.Text = upperText.Replace(number.ToString(), $"{buttonRoot.Text}({number})");
                    LowerScreen.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(lowerText)));
                }
                else
                {
                    UpperScreen.Text += $"{buttonRoot.Text}({lowerText})";
                    LowerScreen.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(lowerText)));
                }
            }
            else if (!findOperator.IsMatch(upperText) && upperText.Length > 0)
            {
                UpperScreen.Text = $"{buttonRoot.Text}({upperText})";
                LowerScreen.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(lowerText)));
            }
            else
            {
                UpperScreen.Text = $"{buttonRoot.Text}({lowerText})";
                LowerScreen.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(lowerText)));
            }

            // Change the bool flag to mark the text of LowerScreen could not be replaced.
            isFisrtWord = false;
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            // Define a regular expression for found operator.
            Regex findOperator = new Regex(@"[\p{Sm}\p{Pd}]");

            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            if (upperText == "" || upperText == "0")
            {
                UpperScreen.Text = "0";
                LowerScreen.Text = "0";
            }
            else if(findOperator.IsMatch(upperText))
            {
                // Find the match operators in the text of UpperScreen and get the last match operator.
                MatchCollection matches = findOperator.Matches(upperText);
                Match match = matches.First();

                double num1 = Convert.ToDouble(upperText.Replace(match.ToString(), ""));
                double num2 = Convert.ToDouble(lowerText);

                switch (match.ToString())
                {
                    case "+":
                        UpperScreen.Text = upperText + Convert.ToString(num1 * num2 / 100);
                        LowerScreen.Text = Convert.ToString(num1 * num2 / 100);
                        break;
                    case "-":
                        UpperScreen.Text = upperText + Convert.ToString(num1 * num2 / 100);
                        LowerScreen.Text = Convert.ToString(num1 * num2 / 100);
                        break;
                    case "กั":
                        UpperScreen.Text = upperText + Convert.ToString(num2 / 100);
                        LowerScreen.Text = Convert.ToString(num2 / 100);
                        break;
                    case "กา":
                        UpperScreen.Text = upperText + Convert.ToString(num2 / 100);
                        LowerScreen.Text = Convert.ToString(num2 / 100);
                        break;
                }
            }

            // Change th e bool flag to mark the text of LowerScreen could not be replaced.
            isFisrtWord = false;
        }

        private void buttonInverse_Click(object sender, EventArgs e)
        {
            // Get the text of UpperScreen and LowerScreen.
            string upperText = UpperScreen.Text;
            string lowerText = LowerScreen.Text;

            LowerScreen.Text = Convert.ToString(0 - Convert.ToDouble(lowerText));

            // Change the bool flag to mark the text of LowerScreen could not be replaced.
            isFisrtWord = false;
        }
    }
}