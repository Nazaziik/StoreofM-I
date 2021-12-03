using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace StoreofM_I.Windows
{
    /// <summary>
    /// Interaction logic for AddNewM_I.xaml
    /// </summary>
    public partial class AddNewM_I : Window
    {
        public AddNewM_I()
        {
            InitializeComponent();
            this.DataContext = os;
        }
        readonly M_I os = new M_I();

        private void SubmitAddButton(object sender, RoutedEventArgs e)
        {
            if (M_I.PersonsList.Count != 0)
            {
                bool samePerson = false;
                for (int i = 0; i < M_I.PersonsList.Count; i++)
                {
                    if (M_I.PersonsList[i].SerialNumber == os.SerialNumber)
                    {
                        samePerson = true;
                        MessageBox.Show($"You already have person with that pesel {os.SerialNumber}");
                        break;
                    }
                }
                if (!samePerson)
                {
                    M_I.PersonsList.Add(os);
                }
            }
            else
                M_I.PersonsList.Add(os);

            this.Close();
        }

        private void CancelAddButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenFileDialogButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
}
