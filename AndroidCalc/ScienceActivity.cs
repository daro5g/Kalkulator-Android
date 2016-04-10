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
    [Activity(Label = "Epic Calculator")]
    class ScienceActivity : Activity
    {

        EditText consoleS;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Science);

            consoleS = FindViewById<EditText>(Resource.Id.consoleS);
            Button buttonSin = FindViewById<Button>(Resource.Id.buttonSin);
            Button buttonCos = FindViewById<Button>(Resource.Id.buttonCos);
            Button buttonNeg = FindViewById<Button>(Resource.Id.buttonNeg);
            Button buttonTg = FindViewById<Button>(Resource.Id.buttonTg);
            Button buttonCtg = FindViewById<Button>(Resource.Id.buttonCtg);
            Button buttonAbs = FindViewById<Button>(Resource.Id.buttonAbs);
            Button buttonSquare = FindViewById<Button>(Resource.Id.buttonSquare);
            Button buttonSqrt = FindViewById<Button>(Resource.Id.buttonSqrt);
            Button buttonPercent = FindViewById<Button>(Resource.Id.buttonPercent);
            Button buttonExp = FindViewById<Button>(Resource.Id.buttonExp);
            Button buttonLog = FindViewById<Button>(Resource.Id.buttonLog);
            Button buttonInvert = FindViewById<Button>(Resource.Id.buttonInverse);
            Button buttonRegular = FindViewById<Button>(Resource.Id.buttonRegular);

            buttonSin.Click += ButtonSin_Click;
            buttonCos.Click += ButtonCos_Click;
            buttonNeg.Click += ButtonNeg_Click;
            buttonTg.Click += ButtonTg_Click;
            buttonCtg.Click += ButtonCtg_Click;
            buttonAbs.Click += ButtonAbs_Click;
            buttonSquare.Click += ButtonSquare_Click;
            buttonSqrt.Click += ButtonSqrt_Click;
            buttonPercent.Click += ButtonPercent_Click;
            buttonExp.Click += ButtonExp_Click;
            buttonLog.Click += ButtonLog_Click;
            buttonInvert.Click += ButtonInvert_Click;
            buttonRegular.Click += ButtonRegular_Click;

            consoleS.Text = Intent.GetStringExtra("consoleState");
        }

        private void ButtonRegular_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("consoleState", consoleS.Text);
            StartActivity(intent);
        }

        private void ButtonInvert_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = (1 / double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonLog_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Log(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonExp_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Exp(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonPercent_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = (double.Parse(consoleS.Text) / 100).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Sqrt(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonSquare_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Pow(double.Parse(consoleS.Text), 2).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonAbs_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Abs(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonCtg_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = (1 / Math.Tan(double.Parse(consoleS.Text))).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonTg_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Tan(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonNeg_Click(object sender, EventArgs e)
        {
            if (consoleS.Text != "0")
            {
                if (consoleS.Text[0] == '-')
                {
                    consoleS.Text = consoleS.Text.Remove(0, 1);
                }
                else
                {
                    consoleS.Text = consoleS.Text.Insert(0, "-");
                }
            }
        }

        private void ButtonCos_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Cos(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }

        private void ButtonSin_Click(object sender, EventArgs e)
        {
            try
            {
                consoleS.Text = Math.Sin(double.Parse(consoleS.Text)).ToString();
            }
            catch
            {
                consoleS.Text = "0";
            }
        }
    }
}