   M S B A M L   `   `   `  ����E  AStoreofM-I, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:StoreofM_I.WindowsStoreofM_I.Windows  5   	   (    "StoreofM_I.Windows.DeleteM_IWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:StoreofM_I.Windows     5   	     � Title$  DeleteM_IWindow��5   	   $	��500��6!   $	��500��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      $
��1.3* �6   6,   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dltGrid��5   0   $��10px 10px 10px 0pxq�6      AutoGenerateColumns$ False��6A   $��2��6]   $��0��6n      
IsReadOnly$
 True��6{      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.8* 63   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� *	OwnerName+  5      $ 	Producent��6%   $ 1* 68   	 6C   �� *	Producent+  5      $ SerialNumber��6%   $ 1* 6;   	 6F   �� *SerialNumber+  5      $
 Type��6%   $
 0.6* 63   	 6@   �� *TypeOf+5!      �� 5$   
   $��2��6   $��200px 14px 200px 7pxq�6   $��Center=�6;   .��6_   	Producent6j   �� 5'   
   $��4��6   $��200px 14px 200px 7pxq�6   $��Center=�6;   .��6_   SerialNumber6m   �� 5*   
   $��6��6   $��198px 14px 198px 7pxq�6   $��Center=�6;   .��6_   Type6e   �� 5-   
   -   5        
 ��Name$
 SurenameDltBox��5-      $��3��6*   $��160px 8px 160px 17pxq�67   6U   �� 50   
   -   5        $
 PeselDltBox��50      $��5��6'   $��160px 10px 160px 15pxq�64   6S   �� 53   
   -   5        $
 DoBDltDatePicker��53      $��7��6,   $��160px 7px 160px 18pxq�69   6W   � 56   
   $��8��6    58      �� 59      6%   �� 5:      6%   .+�5>      �� -   5        $��0��5>      $��40px 5px 10px 10pxq�6%   .��6b   Cancel6j   �� 5A      -   5        $��1��5A      $��10px 5px 40px 10pxq�6%   .��6b   Delete6j   5C      5E      5F      