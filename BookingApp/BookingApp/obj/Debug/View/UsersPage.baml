   M S B A M L   `   `   `  ����E  ABookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BookingApp.ViewBookingApp.View  5          BookingApp.View.UsersPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:BookingApp.View     5        N� Title$  	UsersPage��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��1* �6#    5      �� 5      $��3* �6    �� 5      $��1* �6    .+�5      �� $��2��6   $��Arial)�6,   
����� �
������ $��60(�6n   $��Center=�6|   $��Center=�6�   Users6�   �� 5      -   5        $��
SearchType��5   $   $��1��6   ��66   ��  �� Path$ Roles� �� SelectedValue 6Y   �� $ SelectedRole���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��� �68   �� 5       � ��$ 2q�6<   �� 5       � ��$ 1q�63   �� 5        � ��
 ��� �67   �� 5!       � ��$ Arial)�67   �� 5"       � ��$ 16(�65   5#      5%      �� 5'      -   5        $��Block��5'      $��1��6"   $��Block��62   $y�	Collapsed=�6V   ��5(      �� 5)      " ��6   .�5*      ��  � ��$
 Bold"�67   �� 5+       � ��$ Arial)�67   �� 5,       � ��$ 25(�65   �� 5-       � ��
 ��� �67   �� 5.       � ��
 �����67   �� 5/       � ��$ 0q�6<   �� 50       � ��$ 10q�63   51      53      54      &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ datagrid��55      	   AutoGenerateColumns	 .  $��2��6A   
������ 
   HorizontalGridLinesBrush

 ��� �   VerticalGridLinesBrush
 ��� ���6N   �� *Users+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� $ SelectedUser�   ColumnHeaderStyle 56      �� 57      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�58      ��  � ��$
 Bold"�63   �� 59       � ��$ Arial)�63   �� 5:       � ��
 ��� �63   �� 5;       � ��
 �����63   5<         	CellStyle 5>      �� 5?      *  $System.Windows.Controls.DataGridCell"  6   .�5@      ��  � ��
 �����63   �� 5A       � ��
 ��� �63   �� 5B       � ��$ Arial)�63   �� 5C       � ��
 ��� �64   5D         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$  JMBG��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *JMBG+  5H      $  EMAIL��6%   $ 2* 65    6A   �� *Email+  5I      $  NAME��6%   $ * 64    6?   �� *Name+  5J      $  SURNAME��6%   $ * 67    6B   �� *	Surname+  5K      $  ROLE��6%   $ 1* 64    6@   �� *Role+  5L      $  PHONE��6%   $ 2* 65    6A   �� *Phone+4  .System.Windows.Controls.DataGridCheckBoxColumn  5M      $  BLOCKED��6)   $
 0.8* 6;    6I   �� *	Blocked+5O      5P      5Q      