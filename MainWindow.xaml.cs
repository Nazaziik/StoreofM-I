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
                //DataBaseConnection dataBaseConnection = new DataBaseConnection(@"Data Source=DESKTOP-JVU6NMI\\SQLEXPRESS;Initial Catalog=M_IDataBase;User ID=asds;Password=asd");
                //M_I.M_IList = dataBaseConnection.SelectAll();
            }
            else
            {
                M_I.M_IList = Serialization.DeserializeToObject<List<M_I>>($"{Environment.CurrentDirectory}\\M_IList.xml");
            }

            ctlGrid.ItemsSource = M_I.M_IList;

            #region Reports
            this.ReportViewer.ReportLoaded += (sen, arg) =>
            {
                List<BoldReports.Windows.DataSourceCredentials> dataSourceCrdentials = new List<BoldReports.Windows.DataSourceCredentials>();

                foreach (var dataSource in this.ReportViewer.GetDataSources())
                {
                    BoldReports.Windows.DataSourceCredentials crdentials = new BoldReports.Windows.DataSourceCredentials();
                    crdentials.Name = dataSource.Name;
                    crdentials.UserId = null;
                    crdentials.Password = null;
                    crdentials.IntegratedSecurity = true;
                    dataSourceCrdentials.Add(crdentials);
                }

                this.ReportViewer.SetDataSourceCredentials(dataSourceCrdentials);
            };
            this.ReportViewer.ReportServerUrl = "http://M212S:80/ReportServer";
            this.ReportViewer.ReportServerCredential = System.Net.CredentialCache.DefaultCredentials;
            this.ReportViewer.ReportPath = @"/Reports/Report1.rdl";
            this.ReportViewer.RefreshReport();
            #endregion
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
            if (ctlGrid.SelectedItem != null)
            {
                ModiffyButton.IsEnabled = true;
                ModifyM_IWindow modifyM_I = new ModifyM_IWindow();
                M_I tempM_I = new M_I((M_I)ctlGrid.SelectedItem);
                modifyM_I.DataContext = tempM_I;
                modifyM_I.ShowDialog();

                if (modifyM_I.ModifySubmitted)
                {
                    int index = M_I.M_IList.IndexOf((M_I)ctlGrid.SelectedItem);
                    //DataBaseConnection dataBaseConnection = new DataBaseConnection(@"Data Source=DESKTOP-JVU6NMI\\SQLEXPRESS;Initial Catalog=M_IDataBase;User ID=asds;Password=asd");
                    //dataBaseConnection.ModifyElement(tempM_I);
                    M_I.M_IList[index] = tempM_I;
                }
                ctlGrid.Items.Refresh();
            }
        }
        #endregion

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serialization.SerializeToXml<List<M_I>>(M_I.M_IList, $"{Environment.CurrentDirectory}\\M_IList.xml");
        }
    }
}
