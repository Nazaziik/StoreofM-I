   M S B A M L   `   `   `  ����E  AStoreofM-I, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StoreofM_I
StoreofM_I  5   	   Z VBoldReports.Wpf, Version=3.3310.27.0, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89R:clr-namespace:BoldReports.UI.Xaml;assembly=BoldReports.WpfBoldReports.UI.Xaml 5   	       StoreofM_I.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:StoreofM_I     5   	   RBoldReports:clr-namespace:BoldReports.UI.Xaml;assembly=BoldReports.Wpf     5   	   -   5          � Title$  
MainWindow��5	   	   $
��1000��6   $	��600��6*   .��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��1.5* �6   6,   �� 5      $
��0.2* �6   6,   �� 5      $
��0.2* �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ctlGrid��5   0   $��10px 20px 10px 0pxq�6      AutoGenerateColumns$ False��6A      
IsReadOnly$
 True��6]   $��2��6o      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Photo��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 68   	   CellTemplate	 5      �� 5      .R�5       �� $��Uniform=�6=   $��50��6O   ��6$   �� *Image+6O   5"      5$      0  *System.Windows.Controls.DataGridTextColumn  5'      $ 
Owner Name��6%   $ 1* 69   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6D   �� *	OwnerName+  5*      $ 	Producent��6%   $ 1* 68   
 6C   �� *	Producent+  5-      $ Serial Number��6%   $ 1* 6<   
 6G   �� *SerialNumber+  50      $	 Age��6%   $
 0.4* 62   
 6?   �� *Age+53      �� 56   
   -   5        $��0��56      $��1��6!   $��20px 20px 10px 10pxq�6.   $��25(�6]   .��6k   Add6p   �� 59   
   -   5        $��1��59      $��1��6!   $��10px 20px 40px 10pxq�6.   $��25(�6`   .��6n   Delete6v   �� 5<   
   -   5         ��Name$ ModiffyButton��5<      $��2��6(   $��2��6<   $�� 90 15 90 15q�6I   $��25(�6t   ${�False��6�   .��6�   Modify6�   5>      5?      