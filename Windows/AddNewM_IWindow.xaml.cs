using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StoreofM_I.Windows
{
    public partial class AddNewM_I : Window
    {
        public AddNewM_I()
        {
            InitializeComponent();
            this.DataContext = m_i;
        }
        private M_I m_i = new M_I();

        private void SubmitAddButton(object sender, RoutedEventArgs e)
        {
            if (M_I.M_IList.Count != 0)
            {
                bool samePerson = false;
                for (int i = 0; i < M_I.M_IList.Count; i++)
                {
                    if (M_I.M_IList[i].SerialNumber == m_i.SerialNumber)
                    {
                        samePerson = true;
                        MessageBox.Show($"You already have instrument with that serial number {m_i.SerialNumber}");
                        break;
                    }
                }
                if (!samePerson)
                {
                    M_I.M_IList.Add(m_i);
                }
            }
            else
                M_I.M_IList.Add(m_i);

            this.Close();
        }

        private void CancelAddButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenFileDialogButton(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                Uri fileUri = new Uri(fileName);
                imgDynamic.Source = new BitmapImage(fileUri);
            }
        }
    }
}
