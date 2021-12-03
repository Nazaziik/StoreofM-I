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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StoreofM_I.Windows;

namespace StoreofM_I
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bool fileExists = File.Exists($"{Environment.CurrentDirectory}\\PersonsList.xml");
            if (!fileExists)
            {
                M_I.PersonsList = new List<M_I>();
            }
            else
            {
                M_I.PersonsList = Seriazation.DeserializeToObject<List<M_I>>($"{Environment.CurrentDirectory}\\PersonsList.xml");
            }
            ctlGrid.ItemsSource = M_I.PersonsList;
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddNewM_I addNewPersonWindow = new AddNewM_I();
            addNewPersonWindow.ShowDialog();
            ctlGrid.Items.Refresh();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            DeleteM_IWindow deletePersonWindow = new DeleteM_IWindow();
            deletePersonWindow.ShowDialog();
            ctlGrid.Items.Refresh();
        }

        private void NeedSerializeData(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Seriazation.SerializeToXml<List<M_I>>(M_I.PersonsList, $"{Environment.CurrentDirectory}\\PersonsList.xml");
        }
    }
}
