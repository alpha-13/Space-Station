   M S B A M L   `   `   `  ����B  >Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Station.GUIStation.GUI  5   	       Station.GUI.Reporting   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Station.GUI     5   	   $	��500��5   	   $	��800��6   $	��500��6"   $	��800��62     � WindowStyle$
  None=�6A    � WindowStartupLocation$ CenterScreen=�6T    � WindowState$ 	Maximized=�6y   
���������5	      �� 5
   
    �� ImageSource$0 */Station;component/Resources/Reporting.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $��50 �6   .+�5   
   � .+�5      �� $��Title��6   $
��Left=�6%   $��Center=�6@   $��5,0,0,0q�6[   �� 5      -   5         ��Name$ 	txt_Title��5      $��Stretch=�6)   $��Center=�6G   $��	50,5,20,5q�6b   $��22��6u    �� IsReadOnlyCaretVisible . * �� #IsInactiveSelectionHighlightEnabled .  �� MaxLines$ 1��6�   	 �� 	MaxLength$	 50��6�   $��Center=�6�   $��1��6  ���	#FF0040FF���	#7F000000
 �� SelectionBrush
 �	#FF2B49D3
�������6�  �� 5      -   5         ��Name$ 
Title_Hint��5      $��20��6(   $��Right=�64   $��Center=�6P   $��0,0,20,0q�6k    J� IsHitTestVisible .  $y�Hidden=�6�   $.��(/Station;component/Resources/Wrong 2.png��6�   5      � 5   
   $��1��6   $��10,10,10,10q�6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      .+�5      �  5      �� 5      �� 5      $��7* �6$   .+�5!      �� -   5        $ Search��5!      $��Stretch=�6*   $��Center=�6H   $��25��6c   $��0,0,5,0q�6�   $��2��6�   $��Center=�6�   $ 1��6�   $	 50��6�   
����������	#FF0040FF���	#BF0000006  �� 5"      -   5         ��Name$
 Hint��5"      $��Search��6*   $
��Left=�68   $��Center=�6S   $��10,0,0,0q�6n    .  
�������6�   �� 5#      -   5         ��Name$ LV_Tasks��5#      $��1��6-   $��Stretch=�6:   $��Stretch=�6X   $��	0,10,5,40q�6t   $��3��6�    �� SelectionMode$ Single=�6�   $��Hidden=�6�   ���	#4B000000
����������	#FF0040FF$	��1.5q�6N  �� 5$      -   5         ��Name$	 New��5$      $
��_New��6&   $��30��65   $��1��6A   $��Stretch=�6N   $��Bottom=�6l   $��	10,0,10,5q�6�   $��4��6�   ���	#FF0040FF��6�   Z� 6�   5%      �� 5&      $��Report��6   $��1��6&   $��20(�66   $��Center=�6D   $	��Top=�6a   $��0,10,0,0q�6y   �� 5'      -   5         ��Name$ 
rtb_Report��5'      $��1��6.   $��5��6>   " �� VerticalScrollBarVisibility$
 Auto=�6K   $��	0,55,0,40q�6n   ���	#59000000���	#FF0040FF
�������$	��1.5q�6�   � 5(      -   5         �Name$ RDate��5(      $��1��6"   $y�Hidden=�62   .+�5)      �� $��Report Date��6   $
��Left=�6/   $��Bottom=�6J   $��0,0,0,9q�6e   (  "System.Windows.Controls.DatePicker  5*      -	   5          Name$ 
ReportDate��5*      $
��Left=�61   $��Bottom=�6L   $��80,0,0,5q�6g    .  6y   5+      � 5,      -
   5        $ Modify��5,      $��1��6#   $y�Hidden=�63   $��Bottom=�6G   .+�5-      �� $��Modify Date��6   $��Right=�6/   $��Bottom=�6K   $��	0,0,150,9q�6f     5.      -   5        $ 
ModifyDate��5.      $��Right=�61   $��Bottom=�6M   $��	80,0,35,5q�6h    .  6{   5/      50      �� 51   
   -   5        $ 	btn_Print��51      $��3��6$   $��_Print��61   $	��100��6B   $��25��6N   $
��Left=�6Z   $��Center=�6u   $��50,0,0,0q�6�   $��6��6�   ���	#FF0040FF��6�   Z� 6�   �� 52   
   -   5        $ btn_Save��52      $��2��6#   $��_Save��60   $	��100��6@   $��25��6L   $��Center=�6X   $��Center=�6u   $��7��6�   ���	#FF0040FF��6�   Z� 6�   �� 53   
   -   5        $ 	btn_Close��53      $��3��6$   $��_Close��61   $	��100��6B   $��25��6N   $��Right=�6Z   $��Center=�6v   $��0,0,50,0q�6�   $��8��6�   ���	#FF0040FF��6�   Z� 6�   54      55      