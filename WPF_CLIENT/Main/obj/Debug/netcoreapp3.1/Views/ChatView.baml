   M S B A M L   `   `   `  ����?  ;Main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Main.Views
Main.Views  5   	   1clr-namespace:Main.ViewModelsMain.ViewModels  5   	       Main.Views.ChatView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Main.Views     5   	   ,vmclr-namespace:Main.ViewModels     5   	     � Title$  CHAT BOT��5	      $	��341��6   $	��512��6&   ���	#FF7CA0FF � 
ResizeMode$ 	CanResize=�6I    � 	Resources 5
      #   Main.ViewModels.ChatViewModel   k��%   &	          5   
   6   5      .��5      � $��0,0,-56,-39q�6    � DataContext 6    ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��20(�6   $
��Bold"�6"   $��10,15,91,20q�64   $��2��6I   $��2��6]   ��5      �� 5       �� Color# � ��6"   $"FIND YOUR PATIENT MONITOR HERE!!!!5      �� 5   
   $��1��6   
��� ���$��38,59,142,119q�6W   $��2��6n   $��2��6   ��66   �� *
Messages+��5       �� 5!      .R�5"      ��  �� Orientation$ Vertical=�6!   .+�5#      �� $
��Wrap=�6$   $��18(�68   $��Stretch=�6F   $��Stretch=�6b   ��6�   �� *Name+��6�   �� *
LineColour+5$      5%      5'      �� 5(   
   -   5        $��label5��5(   �   $��2��6   $y�Visible=�6   $
��Left=�64   $��Bottom=�6O   $��Message:��6j   $��43��6}   	 J� RenderTransformOrigin$	 0.567,-0.218&�6�   $��	20,0,0,58q�6�   $��88��6�   z�5)      V� 5*      .~�5+      �� �� 5,      
 �� AngleX$
 -1.821Q�6$   �� 5-      T� 5.       T� X$ 0.194Q�6)   5/      51      �� 52   
   -   5         ��Name$ 	txtFields��52   Q   $��2��6   $y�Visible=�6   $��Bottom=�65   $	 -0.106,-0.805&�6�   $��81,0,195,67q�6�   $��30��6�   $��2��6�   ��6d   �� *TextProperty+ �� Mode$ TwoWay=�6�   �� 53   
   $��2��6   $��Right=�6    $��Bottom=�6=   $y�Visible=�6�   $
��Send��6�   $	 0.674,0.912&�6�   $��
0,0,142,67q�6�   $��30��6�   $��46��6  $��1��6  ��6X   �� # [   �� Path$ SubmitCommand�6  �� 54   
   $��2��6   $��Right=�6    $��Bottom=�6=   $y�Visible=�6�   $��
Clear Chat��6�   $	 0.674,0.912&�6�   $��30��6�   $��64��6�   $��1��6  $��	0,0,73,67q�6  ��6X   �� # [  $ ClearChatCommand�6  55      56      