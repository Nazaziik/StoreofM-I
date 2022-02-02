using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using StoreofM_I.Windows;

namespace StoreofM_I
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataBaseConnection dataBaseConnection = new DataBaseConnection("Data Source=DESKTOP-JVU6NMI\\SQLEXPRESS;Initial Catalog=M_IDataBase;User ID=asds;Password=asd");
            M_I.M_IList = dataBaseConnection.SelectAll();

            ctlGrid.ItemsSource = M_I.M_IList;

            ctlGrid.SelectionChanged += delegate (object sender, SelectionChangedEventArgs e) { ModiffyButton.IsEnabled = true; };
        }

        #region Buttons actions
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

        private void ModifyButoon(object sender, RoutedEventArgs e)
        {
            ModifyM_IWindow modifyM_I = new ModifyM_IWindow();
            M_I tempM_I = new M_I((M_I)ctlGrid.SelectedItem);
            modifyM_I.DataContext = tempM_I;
            modifyM_I.ShowDialog();

            if (modifyM_I.ModifySubmitted)
            {
                int index = M_I.M_IList.IndexOf((M_I)ctlGrid.SelectedItem);
                DataBaseConnection dataBaseConnection = new DataBaseConnection("Data Source=DESKTOP-JVU6NMI\\SQLEXPRESS;Initial Catalog=M_IDataBase;User ID=asds;Password=asd");
                dataBaseConnection.ChangeTable(tempM_I, 2);
                M_I.M_IList[index] = tempM_I;
            }
            ctlGrid.Items.Refresh();
        }

        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialization.SerializeToXml<List<M_I>>(M_I.M_IList, $"{Environment.CurrentDirectory}\\M_IList.xml");
        }
    }
}