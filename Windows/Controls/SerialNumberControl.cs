using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace StoreofM_I.Windows.Controls
{
    internal class SerialNumberControl : TextBox
    {
        public SerialNumberControl()
        {
            this.TextChanged += PeselBox_TextChanged;
            this.PreviewTextInput += PeselBox_PreviewTextInput;
            this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
        }

        private Regex mvarRegex = new Regex(@"\b\d{1,11}\b");

        private void PeselBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string lvarTextToCheck = string.Empty;

            if (this.SelectionLength >= 1)
            {
                lvarTextToCheck = this.Text;
                lvarTextToCheck = lvarTextToCheck.Remove(this.SelectionStart, this.SelectionLength);
                lvarTextToCheck = lvarTextToCheck.Insert(this.SelectionStart, e.Text);
            }
            else
                lvarTextToCheck = this.Text.Insert(this.SelectionStart, e.Text);

            if (!mvarRegex.IsMatch(lvarTextToCheck))
                e.Handled = true;
        }

        private void PeselBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string lvarText = "";
            int lvarPosition = this.SelectionStart;

            foreach (var lvarChar in this.Text)
            {
                if (char.IsDigit(lvarChar))
                    lvarText = lvarText + lvarChar;
                if (!mvarRegex.IsMatch(lvarText))
                    lvarText = lvarText.Substring(0, lvarText.Length - 1);
            }

            if (this.Text != lvarText)
            {
                this.Text = lvarText;
                if (lvarPosition >= 1)
                    this.SelectionStart = lvarPosition - 1;
                else
                    this.SelectionStart = 0;
            }
        }
    }
}
