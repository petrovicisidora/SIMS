   M S B A M L   `   `   `  ����E  ABookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BookingApp.ViewBookingApp.View  5      "    BookingApp.View.MyHotelsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:BookingApp.View     5        N� Title$  MyHotelsPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   � $��0��6   $��	10 0 10 8q�6    � ColumnDefinitions 5      �� 5      $
��1.5* �6#   �� 5      $��3* �6#   �� 5      �� 5      .+�5      �� -   5        $��Reservations��5      $��0��6)   $��Reservations��69   {�.  ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$
 Bold"�67   �� 5       � ��$ Arial)�67   �� 5       � ��$ 25(�65   �� 5       � ��
 ��� �67   �� 5       � ��
 �����67   �� 5       � ��$ 0q�6<   �� 5        � ��$ 10q�63   5!      5#      �� 5$      $��0��6   $��5��6(   $��Arial)�6<   
����� �
������ $��60(�6~   $��Center=�6�   $��Center=�6�   	My Hotels6�   �� 5%      -   5        $��Approve��5%      $��2��6$   $��Approve��64   {�.  ��5&      �� 5'      " ��6   .�5(      ��  � ��$
 Bold"�67   �� 5)       � ��$ Arial)�67   �� 5*       � ��$ 25(�65   �� 5+       � ��
 ��� �67   �� 5,       � ��
 �����67   �� 5-       � ��$ 0q�6<   �� 5.       � ��$ 10q�63   5/      51      �� 52      -   5        $��Delete��52      $��3��6#   $��Delete��63   {�.  ��53      �� 54      " ��6   .�55      ��  � ��$
 Bold"�67   �� 56       � ��$ Arial)�67   �� 57       � ��$ 25(�65   �� 58       � ��
 ��� �67   �� 59       � ��
 �����67   �� 5:       � ��$ 0q�6<   �� 5;       � ��$ 10q�63   5<      5>      5?      &   System.Windows.Controls.DataGrid  5@   
   -   5          Name$ datagrid��5@         AutoGenerateColumns .  $��2��6A   
������    HorizontalGridLinesBrush
 ��� �	   VerticalGridLinesBrush
	 ��� ���6N   �� *Hotels+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem 6�   ��  �� Path$ SelectedHotel�   ColumnHeaderStyle 5A      �� 5B      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5C      ��  � ��$
 Bold"�63   �� 5D       � ��$ Arial)�63   �� 5E       � ��
 ��� �63   �� 5F       � ��
 �����63   5G         	CellStyle 5I      �� 5J      *  $System.Windows.Controls.DataGridCell"  6   .�5K      ��  � ��
 �����63   �� 5L       � ��
 ��� �63   �� 5M       � ��$ Arial)�63   �� 5N       � ��
 ��� �64   5O         Columns 5Q      0  *System.Windows.Controls.DataGridTextColumn  5R      ,  &System.Windows.Controls.DataGridColumn   Header$  CODE��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.5* 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Code+  5S      $  NAME��6%   $ 3* 64    6@   �� *Name+  5T      $  YEAR OF BUILDING��6%   $ 2* 6@    6L   �� *YearOfBuilding+  5U      $  STARS��6%   $ 1* 65    6A   �� *StarsRating+4  .System.Windows.Controls.DataGridCheckBoxColumn  5V      $ 	 ACCEPTED��6)   $ 1* 6<      
IsReadOnly .  6H   �� *
Accepted+6e   5X      5Y      5Z      