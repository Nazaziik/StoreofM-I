   M S B A M L   `   `   `  ����E  AStoreofM-I, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:StoreofM_I.Windows.ControlsStoreofM_I.Windows.Controls  5   	   "    StoreofM_I.Windows.AddNewM_I   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:StoreofM_I.Windows.Controls     5   	     � Title$  	AddNewM_I��5   	   $	��600��6   $	��400��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.6* �6   6.   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6$    �� TextAlignment$ Center=�61   $��Center=�6H   
Owner Name6o   �� 5   
   -   5         ��Name$ NameBox��5      $��1��6#   $��0��63    �� TextAlignment$ Center=�6@   $��Center=�6W   $
��10pxq�6r   ��6�   �� *	OwnerName+�� 5   
   $��0��6   $��1��6$   $ Center=�61   $��Center=�6H   	Producent6n   �� 5    
   -   5        $ 
SurnameBox��5       $��1��6&   $��1��66   $ Center=�6C   $��Center=�6Z   $
��10pxq�6u   ��6�   �� *	Producent+�� 5#   
   $��0��6   $��2��6$   $ Center=�61   $��Center=�6H   Age6h   ,   &StoreofM_I.Windows.Controls.AgeControl  5$   
   -   5          Name$ AgeBox��5$      $��1��6+   $��2��6;   $ Center=�6H   $��Center=�6_   $
��10pxq�6z   ��6�   �� *Age+�� 5'   
   $��0��6   $��3��6$   $ Center=�61   $��Center=�6H   SerialNumber6q   5   /StoreofM_I.Windows.Controls.SerialNumberControl  5(   
   -   5          Name$ PeselBox��5(   $   $��1��66   $��3��6F   $ Center=�6S   $��Center=�6j   $
��10pxq�6�   ��6�   �� *SerialNumber+�� 5+   
   $��0��6   $��4��6$   $ Center=�61   $��Center=�6H   Produsing Date6s   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ 
DataPicker��5,      $��1��6)   $��4��69   $
��20pxq�6F   	   SelectedDate	 6T   �� *ProdusingDate+�� 5/   
   $��0��6   $��5��6$   $ Center=�61   $��Center=�6H   Type6i   �� 50   
   -   5        $ 	GenderBox��50      $��1��6%   $��5��65   $ Center=�6B   $��Center=�6Y   $
��10pxq�6t   ��6�   �� *TypeOf+�� 53   
   $��0��6   $��6��6$   $ Center=�61   $��Center=�6H   Image6j   � 54   
   $��1��6   $��6��6    55      �� 56      �� 57      .+�5;      �� -   5        
 ��Name$
 
imgDynamic��5;      $��UniformToFill=�6(   ��6@   �� *Image+ �� Mode$ OneWayToSource=��� 5>      -   5         ��Name$ ImageButton��5>      $��1��6*   $��Center=�6:   $��20px 10px 20px 10pxq�6U   .��6�   	Add Image6�   5@      �� 5C   
   -	   5        $��0��5C      $��7��6!   .��6F   Cancel6N   �� 5F   
   -
   5        $��1��5F      $��7��6!   .��6F   Submit6N   5H      5I      