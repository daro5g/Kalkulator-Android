using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using YAMP;

namespace AndroidCalc
{
    [Activity(Label = "Epic Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText console;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Define controls to be able to access them
            console = FindViewById<EditText>(Resource.Id.console);
            Button buttonC = FindViewById<Button>(Resource.Id.buttonC);
            Button buttonBracket = FindViewById<Button>(Resource.Id.buttonBracket);
            Button buttonDot = FindViewById<Button>(Resource.Id.buttonDot);
            Button buttonArrow = FindViewById<Button>(Resource.Id.buttonArrow);
            Button buttonDiv = FindViewById<Button>(Resource.Id.buttonDiv);
            Button buttonMul = FindViewById<Button>(Resource.Id.buttonMul);
            Button buttonSub = FindViewById<Button>(Resource.Id.buttonSub);
            Button button0 = FindViewById<Button>(Resource.Id.button0);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            Button button9 = FindViewById<Button>(Resource.Id.button9);
            Button buttonPlus = FindViewById<Button>(Resource.Id.buttonPlus);
            Button buttonEq = FindViewById<Button>(Resource.Id.buttonEqual);
            Button buttonScience = FindViewById<Button>(Resource.Id.buttonScientific);

            //Attach event handlers to controls
            button0.Click += Button0_Click;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button6.Click += Button6_Click;
            button7.Click += Button7_Click;
            button8.Click += Button8_Click;
            button9.Click += Button9_Click;
            buttonC.Click += ButtonC_Click;
            buttonBracket.Click += ButtonBracket_Click;
            buttonDot.Click += ButtonDot_Click;
            buttonArrow.Click += ButtonArrow_Click;
            buttonDiv.Click += ButtonDiv_Click;
            buttonMul.Click += ButtonMul_Click;
            buttonSub.Click += ButtonSub_Click;
            buttonPlus.Click += ButtonPlus_Click;
            buttonEq.Click += ButtonEq_Click;
            buttonScience.Click += ButtonScience_Click;

            console.Text = Intent.GetStringExtra("consoleState") ?? "0";
        }

        private void ButtonScience_Click(object sender, EventArgs e)
        {
            calculate();
            var intent = new Intent(this, typeof(ScienceActivity));
            intent.PutExtra("consoleState", console.Text);
            StartActivity(intent);
        }

        private void calculate()
        {
            try
            {
                if (bracketopen)
                    console.Text += ")";
                Parser parser = new Parser();
                var result = parser.Evaluate(console.Text);
                console.Text = result.ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void ButtonEq_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            consoleInsertOperator("+");
        }

        private void ButtonSub_Click(object sender, EventArgs e)
        {
            consoleInsertOperator("-");
        }

        private void ButtonMul_Click(object sender, EventArgs e)
        {
            consoleInsertOperator("*");
        }

        private void ButtonDiv_Click(object sender, EventArgs e)
        {
            consoleInsertOperator("/");
        }

        private void ButtonArrow_Click(object sender, EventArgs e)
        {
            if (console.Text[console.Text.Length - 1] == '(')
                bracketopen = false;
            else if (console.Text[console.Text.Length - 1] == ')')
                bracketopen = true;
            console.Text = console.Text.Remove(console.Text.Length - 1);
            if (console.Text == "")
                console.Text = "0";
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            consoleInsertDot();
        }

        private void ButtonBracket_Click(object sender, EventArgs e)
        {
            consoleInsertBracket();
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            console.Text = "0";
            bracketopen = false;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            console_insertnumber(9);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            console_insertnumber(8);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            console_insertnumber(7);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            console_insertnumber(6);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            console_insertnumber(5);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            console_insertnumber(4);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            console_insertnumber(3);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            console_insertnumber(2);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            console_insertnumber(1);
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            console_insertnumber(0);
        }

        bool bracketopen = false;

        private void console_insertnumber(int number)
        {
            if (console.Text != "0")
            {
                if (console.Text[console.Text.Length - 1] != ')')
                    console.Text += number.ToString();
                else console.Text += "*" + number.ToString();
            }
            else console.Text = number.ToString();
        }

        private void consoleInsertBracket()
        {
            string lastCharacter = console.Text[console.Text.Length - 1].ToString();
            int n;
            if (console.Text == "0")
            {
                console.Text = "(";
                bracketopen = true;
            }
            else if (int.TryParse(lastCharacter, out n))
            {
                if (bracketopen)
                {
                    console.Text += ")";
                    bracketopen = false;
                }
                else
                {
                    console.Text += "*(";
                    bracketopen = true;
                }
            }
            else if (lastCharacter == "+" || lastCharacter == "-" || lastCharacter == "*" || lastCharacter == "/")
            {
                if (!bracketopen)
                {
                    console.Text += "(";
                    bracketopen = true;
                }
            }
        }

        private void consoleInsertOperator(string op)
        {
            string lastCharacter = console.Text[console.Text.Length - 1].ToString();
            int n;
            if (int.TryParse(lastCharacter, out n))
            {
                console.Text += op;
            }
            else if (lastCharacter == ")")
            {
                console.Text += op;
            }
        }

        private void consoleInsertDot()
        {
            string lastCharacter = console.Text[console.Text.Length - 1].ToString();
            string secondToLastCharacter = "kek";
            if (console.Text.Length > 1)
                secondToLastCharacter = console.Text[console.Text.Length - 2].ToString();
            int n;
            if (int.TryParse(lastCharacter, out n) && secondToLastCharacter != ".")
            {
                console.Text += ".";
            }
        }
    }
}

