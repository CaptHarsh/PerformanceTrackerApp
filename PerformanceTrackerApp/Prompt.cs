using System.Windows.Forms;

namespace PerformanceTrackerApp
{
    public static class InputHelper
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 10, Top = 20, Text = text, AutoSize = true };
            TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 360 };
            Button confirmation = new Button() { Text = "Ok", Left = 290, Width = 80, Top = 80, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
    }
}
