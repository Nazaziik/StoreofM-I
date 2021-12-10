using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace StoreofM_I.Windows
{
    public partial class ModifyM_IWindow : Window
    {
        public bool ModifySubmitted { get; set; }

        public ModifyM_IWindow()
        {
            InitializeComponent();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ModifySubmitted = false;
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ModifySubmitted = true;
            this.Close();
        }
    }
}
