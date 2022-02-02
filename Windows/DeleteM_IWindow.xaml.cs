using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StoreofM_I.Windows
{
    public partial class DeleteM_IWindow : Window
    {
        public DeleteM_IWindow()
        {
            InitializeComponent();
            dltGrid.ItemsSource = M_I.M_IList;
        }

        private void SubmitDeleteButton_click(object sender, RoutedEventArgs e)
        {
            int index = M_I.M_IList.IndexOf(dltGrid.SelectedItem as M_I);

            if (index > -1)
            {
                M_I tempMI = M_I.M_IList[index];
                DataBaseConnection dataBaseConnection = new DataBaseConnection("Data Source=DESKTOP-JVU6NMI\\SQLEXPRESS;Initial Catalog=M_IDataBase;User ID=asds;Password=asd");
                dataBaseConnection.ChangeTable(tempMI, 3);
                M_I.M_IList.RemoveAt(index);
            }

            SurenameDltBox.Text = String.Empty;
            PeselDltBox.Text = String.Empty;
            DoBDltDatePicker.Text = String.Empty;

            dltGrid.ItemsSource = M_I.M_IList;

            dltGrid.Items.Refresh();
        }

        private void CancelDeleteButton_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterData_textChanged(object sender, TextChangedEventArgs e)
        {
            if (SurenameDltBox.Text == "" && PeselDltBox.Text == "" && DoBDltDatePicker.Text == "")
            {
                dltGrid.ItemsSource = M_I.M_IList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text == "" && DoBDltDatePicker.Text == "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text == "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text == "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereSerNum(PeselDltBox.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text == "" && PeselDltBox.Text == "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereType(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text == "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text) && a.WhereSerNum(PeselDltBox.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text == "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereSerNum(PeselDltBox.Text) && a.WhereType(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text == "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text) && a.WhereType(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text) && a.WhereSerNum(PeselDltBox.Text) && a.WhereType(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
        }
    }
}
