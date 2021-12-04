﻿using System;
using System.Collections.Generic;
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
    /// Interaction logic for DeleteM_IWindow.xaml
    /// </summary>
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
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProdDate(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text == "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text) && a.WhereSerNum(PeselDltBox.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text == "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereSerNum(PeselDltBox.Text) && a.WhereProdDate(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text == "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text) && a.WhereProdDate(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
            else if (SurenameDltBox.Text != "" && PeselDltBox.Text != "" && DoBDltDatePicker.Text != "")
            {
                List<M_I> tempFilterList = (List<M_I>)M_I.M_IList.Where(a => a.WhereProducent(SurenameDltBox.Text) && a.WhereSerNum(PeselDltBox.Text) && a.WhereProdDate(DoBDltDatePicker.Text)).ToList();
                dltGrid.ItemsSource = tempFilterList;
            }
        }
    }
}
