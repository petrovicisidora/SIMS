   M S B A M L   `   `   `  ����E  ABookingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BookingApp.ViewBookingApp.View  5   	   ,    &BookingApp.View.DecliningMessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BookingApp.View     5   	     � Title$  DecliningMessageWindow��5   	   $	��400��6(   $	��300��65   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��2* �6   �� 5      .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��0��6   $��Arial)�6%   
����� �
������ $��20(�6g   $��
20 10 20 0q�6u   $��Bottom=�6�   Declining Reservation6�   �� 5      -   5        $��ReservationDate��5      $��0��6/   $��Arial)�6<   
����� �
������ $��15(�6~   $
��20 0q�6�   $��Bottom=�6�   $
��Wrap=�6�   Date:6�   �� 5      -   5        $��ReservationHotel��5      $��0��60   $��Arial)�6=   
����� �
������ $��15(�6   $
��20 0q�6�   $��Bottom=�6�   $
��Wrap=�6�   Hotel:6�   �� 5      -   5        $��ReservationApartment��5      $��0��64   $��Arial)�6A   
����� �
������ $��15(�6�   $
��20 0q�6�   $��Bottom=�6�   $
��Wrap=�6�   
Apartment:6�   5      �� 5   
   $��1��6   $��Arial)�6!   
����� �
������ $��20(�6c   $��20 10q�6q   $	��Top=�6�   $
��Wrap=�6�   
Message:6�   �� 5   
   -   5        $��MessageInput��5      $��1��6&   $��Arial)�63   
����� �$��3q�6\   
����� �
�������$��25(�6�   $��5 40 5 5q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $��Confirm��5      $��2��66   $��80 15q�6C   $��5q�6R   
����� �$��Arial)�6}   
�������
����� �$��30(�6�   .��6�   	Confirm6�   5      5      