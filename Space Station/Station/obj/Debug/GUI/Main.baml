   M S B A M L   `   `   `  ����B  >Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Station.GUIStation.GUI  5   	       Station.GUI.Main   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Station.GUI     5   	     � Title$
  Main��5      $	��500��6   $	��800��6"    � WindowState$ 	Maximized=�6.    � WindowStartupLocation$ CenterScreen=�6F   $	��800��6k   $	��500��6z    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�   ��5	      �� 5
   
    �� ImageSource$+ %/Station;component/Resources/Main.jpg��6   .��5      � .+�5   
   �� -   5         ��Name$ txt_userName��5      $��Center=�6(   $��Center=�6E   $��0,0,0,50q�6`   $	��200��6r   $��30��6~   $��16(�6�   $��Center=�6�    �� MaxLines$ 1��6�    �� 	MaxLength$ 45��6�   $��1��6�   ���	#FF0040FF���	#7F000000
�������6]  G� 5   
   -   5        	 G�Name$	 txt_password��5      $��Center=�6,   $��Center=�6I   $��0,50,0,0q�6d   $	��200��6v   $��30��6�   $��16(�6�   $��Center=�6�   
 G� 	MaxLength$
 95��6�   $��2��6�   ���	#FF0040FF
����������	#7F0000006a  �� 5   
   -   5         ��Name$ txtUserName��5      $��	User Name��6)   $��Center=�6:   $��Center=�6W   $��
0,0,120,50q�6r   
������� J� IsHitTestVisible .  6�   �� 5   
   -   5        $ txtPassword��5      $��Password��6)   $��Center=�69   $��Center=�6V   $��
0,50,130,0q�6q   
������� .  6�   �� 5   
   -   5        $ UN_Hint��5      $��*��6%   $��Center=�6.   $��Center=�6K   $��
180,0,0,50q�6f    �� Padding$ 0,15,0,0q�6z   
���  ��$��30(�6�   $��Microsoft Himalaya)�6�    .  $y�Hidden=�6�   �� 5   
   -   5        $ 	Pass_Hint��5      $��*��6'   $��Center=�60   $��Center=�6M   $��
180,50,0,0q�6h   $ 0,15,0,0q�6|   
���  ��$��30(�6�   $��Microsoft Himalaya)�6�    .  $y�Hidden=�6�   �� 5   
   -   5         ��Name$ 	btn_login��5      $��_Login��6$   $	��100��65   $��25��6A   $��Center=�6M   $��Center=�6j   $��	0,150,0,0q�6�   $��3��6�   ���	#FF1700FF$��1q�6�   
�������$��14(�6  $��Medium"�6   ��6�   Z� 6   �� 5   
   -   5        $ btn_register��5      $��	_Register��6'   $	��100��6;   $��25��6G   $��Center=�6S   $��Center=�6p   $��	0,220,0,0q�6�   $��4��6�   ���	#FF1700FF
�������$��14(�6  $��Medium"�6  ��6�   Z� 6  � 5   
   -	   5         �Name$ Slider��5      $��Stretch=�6   $��Bottom=�6=   $��25��6X   $��
20,0,20,25q�6d    .  .+�5      �� -
   5        $ 	txtb_News��5      $��Stretch=�6)   $��Bottom=�6G   
����ح�$��25��6y   $��Center=�6�   $��10,0,0,0q�6�   $��0q�6�   $��	25,0,25,0q�6�    J� Opacity$	 0.8Q�6�   ��.  6�   �� 5      -   5        $ 
txtb_News2��5      $��Stretch=�6*   $	��Top=�6H   
�������$��25��6x   $��Center=�6�   $��10,0,0,0q�6�   $��0q�6�   $��
25,25,25,0q�6�   $	 0.8Q�6�   ��.  6�   5      5      5      