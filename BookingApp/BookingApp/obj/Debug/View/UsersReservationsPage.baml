   M S B A M L   `   `   `  ����E  ABookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BookingApp.ViewBookingApp.View  5      +    %BookingApp.View.UsersReservationsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:BookingApp.View     5        N� Title$  UsersReservationsPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��1* �6#    5      �� 5      $��3* �6    �� 5      $��1* �6    .+�5      �� $��2��6   $��Arial)�6,   
����� �
������ $��60(�6n   $��Center=�6|   $��Center=�6�   My Reservations6�   �� 5      -   5        $��Cancel��5      $��1��6#   $��Cancel��63   {�.  ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$
 Bold"�67   �� 5       � ��$ Arial)�67   �� 5       � ��$ 25(�65   �� 5        � ��
 ��� �67   �� 5!       � ��
 �����67   �� 5"       � ��$ 0q�6<   �� 5#       � ��$ 10q�63   5$      5&      �� 5'      -   5        $��ReservatinsFilter��5'      $��1��6~   $��Arial)�6�   
����� �$��3q�6�   
����� �
�������$��16(�6�   $��	170 0 0 0q�6   $��Center=�6  ��60   �� *	Filters+ �� SelectedValue 6P   ��  �� Path$ SelectedFilter�5)      5*      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ datagrid��5+      	   AutoGenerateColumns	 .  $��2��6A   
������ 
   HorizontalGridLinesBrush

 ��� �   VerticalGridLinesBrush
 ��� ���6N   �� *Reservations+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� $ SelectedReservation�   ColumnHeaderStyle 5,      �� 5-      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5.      ��  � ��$
 Bold"�63   �� 5/       � ��$ Arial)�63   �� 50       � ��
 ��� �63   �� 51       � ��
 �����63   52         	CellStyle 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6   .�56      ��  � ��
 �����63   �� 57       � ��
 ��� �63   �� 58       � ��$ Arial)�63   �� 59       � ��
 ��� �64   5:         Columns 5<      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$  DATE��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Date+  5>      $  HOTEL NAME��6%   $ * 6:    6E   �� *	HotelCode+  5?      $  APARTMENT NAME��6%   $ * 6>    6I   �� *ApartmentName+4  .System.Windows.Controls.DataGridTemplateColumn  5@      $  STATUS��6)   $ 0.33* 6:      CellTemplate 5A      �� 5B      .R�5C      �� $��Details��6%   -   5        $
��Show��5C   4   ��5D   "   �� 5E   &   " ��6,   .�5F   *   ��  � ��$
 Bold"�6G   �� 5G   *    � ��$ Arial)�6G   �� 5H   *    � ��
 ��� �6G   �� 5I   *    � ��
 �����6G   �� 5J   *    � ��$ 0q�6L   5K   '   5M      5N      5P      5R      5S      5T      