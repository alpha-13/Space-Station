   M S B A M L   `   `   `  ����B  >Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Station.GUIStation.GUI  5   	       Station.GUI.Tasks   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Station.GUI     5   	   $	��500��5   	   $	��800��6   $	��500��6"   $	��800��62     � WindowStartupLocation$  CenterScreen=�6A    � WindowState$ 	Maximized=�6f    � WindowStyle$
 None=�6~    � 
ResizeMode$ NoResize=�6�   
���������5	      �� 5
   
    �� ImageSource$, &/Station;component/Resources/Tasks.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      .+�5   
   �� $��
Send Tasks��6   $��Center=�6&   $��Center=�6C   $��40(�6^   $��Segoe UI Historic)�6l   � 5   
   $��1��6    5      �� 5      $��50 �6    �� 5      �� 5      $��50 �6    .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   .+�5      �� $��Title��6   $
��Left=�6)   $��Center=�6D   $��20,0,0,0q�6_   �� 5       -   5         ��Name$ 	txt_Title��5       $��Stretch=�6-   $��Center=�6K   $��	50,0,20,0q�6f    �� MaxLines$ 1��6y   	 �� 	MaxLength$		 100��6�   $��1��6�   $��Center=�6�   ���	#FF0040FF
���������6�   Z� 6�   �� 5!      $��1��6   $��Target��6,   $
��Left=�6:   $��Center=�6U   $��20,0,0,0q�6p   �� 5"      -   5        $ 
txt_Target��5"   *   $��1��6   {�.  $��Stretch=�6P   $��Center=�6n   $��	60,0,20,0q�6�   ���	#FF0040FF
���������6�   Z� 6�   5#      � 5%      $��1��6    5&      �� 5'      $��* �6'   �� 5(      $��4* �6'   .+�5*      � .+�5+      �� -   5        $ 
txt_Search��5+      $��Stretch=�62   $	��Top=�6P   $��25��6h   $��5,10,5,0q�6t   $��Center=�6�   $��2��6�   $ 1��6�   $	 50��6�   ���	#FF0040FF
���������6
  Z� 6   �� 5,      -   5        
 ��Name$

 Hint��5,       $��Search��6.   $
��Left=�6<   $	��Top=�6W   
�������$��	15,15,0,0q�6�    J� IsHitTestVisible .  6�   �� 5-      -   5         ��Name$ LV_Employees��5-      $��1��65   $��Stretch=�6B   $��Stretch=�6`   $��5,40,5,5q�6|    �� SelectionMode$ Single=�6�   $��3��6�   $��15(�6�   $��3q�6�   ���	#FF0040FF���	#3F000000
�������$	��1.5q�6?  5.      �� 5/      $��Task Description��6   $��15(�64   $��1��6B   $��Center=�6R   $	��Top=�6o   $��0,10,0,0q�6�   �� 50      -   5         ��Name$ rtb_Task��50      $��1��60   $��Stretch=�6@   $��Stretch=�6^   $��20,40,20,10q�6z   $��4��6�   $��3q�6�   $	��1.5q�6�   ���	#FF0040FF���	#3F000000$��15(�6�   
�������6�   51      � 53      $��2��6   .+�54      �� -   5        $
 txt_Message��54       �� TextAlignment$ Center=�61   $
��Wrap=�6H   $
��Left=�6\   $��Center=�6w   $��15(�6�   
�������$��20,0,0,0q�6�   ���	#FF575757 J� Opacity$ 0Q�6�   �� 55      -   5         ��Name$ btn_Send��55      $��_Send��6+   $	��100��6;   $��25��6G   $��Center=�6S   $��Center=�6p   $��5��6�   {�.  ���	#FF0040FF
���������6�   Z� 6�   �� 56      -	   5        $ 
btn_Cancel��56      $��_Cancel��6-   $	��100��6?   $��25��6K   $��Right=�6W   $��Center=�6s   $��0,0,20,0q�6�   $��6��6�   ���	#FF0040FF
���������6�   Z� 6�   57      58      59      5:      