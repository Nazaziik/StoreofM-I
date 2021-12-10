using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using StoreofM_I.Windows;

namespace StoreofM_I
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (!File.Exists($"{Environment.CurrentDirectory}\\M_IList.xml"))
            {
                M_I.M_IList = new List<M_I>();
            }
            else
            {
                M_I.M_IList = Serialization.DeserializeToObject<List<M_I>>($"{Environment.CurrentDirectory}\\M_IList.xml");
            }
            ctlGrid.ItemsSource = M_I.M_IList;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialization.SerializeToXml<List<M_I>>(M_I.M_IList, $"{Environment.CurrentDirectory}\\M_IList.xml");
        }

        private void ModifyButoon(object sender, RoutedEventArgs e)
        {
            if (ctlGrid.SelectedItem != null)
            {
                ModifyM_IWindow modifyM_I = new ModifyM_IWindow();
                M_I tempM_I = new M_I((M_I)ctlGrid.SelectedItem);
                modifyM_I.DataContext = tempM_I;
                modifyM_I.ShowDialog();

                if (modifyM_I.ModifySubmitted)
                {
                    int index = M_I.M_IList.IndexOf((M_I)ctlGrid.SelectedItem);
                    M_I.M_IList[index] = tempM_I;
                }
                ctlGrid.Items.Refresh();
            }
        }
    }
}
