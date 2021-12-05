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

            if (!File.Exists($"{Environment.CurrentDirectory}\\M_IList.xml"))
            {
                M_I.M_IList = new List<M_I>();
            }
            else
            {
                //M_I.M_IList = Seriazation.DeserializeToObject<List<M_I>>($"{Environment.CurrentDirectory}\\M_IList.xml");
                M_I.M_IList = new List<M_I>();
                M_I m_I = new M_I();
                Type[] types = new Type[] { typeof(string), typeof(byte[]), typeof(bool), typeof(int) };
                while (Serialization.LoadFromDocumentFormat<M_I>(m_I, types, $"{Environment.CurrentDirectory}\\M_IList.xml") != null)
                {
                    M_I.M_IList.Add(Serialization.LoadFromDocumentFormat<M_I>(m_I, types, $"{Environment.CurrentDirectory}\\M_IList.xml"));
                }
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

        private void NeedSerializeData(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Seriazation.SerializeToXml<List<M_I>>(M_I.M_IList, $"{Environment.CurrentDirectory}\\PersonsList.xml");
            Type[] types = new Type[] { typeof(string), typeof(byte[]), typeof(bool), typeof(int) };
            foreach (M_I item in M_I.M_IList)
            {
                Serialization.SaveToDocumentFormat<M_I>(item, types, $"{Environment.CurrentDirectory}\\PersonsList.xml");
            }
        }
    }
}
