   M S B A M L   `   `   `  ����B  >Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Station.GUIStation.GUI  5   	       Station.GUI.Check_Balance   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Station.GUI     5   	   $	��300��5   	   $	��400��6   $	��300��6"   $	��400��62     � WindowStyle$
  None=�6A    � WindowStartupLocation$ CenterScreen=�6T    � 
ResizeMode$ NoResize=�6y   $��2q�6�   ���	#7F005DFF � AllowsTransparency . ���	#CC000000
�������.��5	      � .+�5
   
   �� $��Deposit Money��6   $��Center=�6)   $	��Top=�6F   $��0,10,0,0q�6^   $��25(�6p   $��Oblique$�6~   $��Medium"�6�   $��
Harrington)�6�   �� 5   
   $��	Credit ID��6   $
��Left=�6%   $	��Top=�6@   $��
20,63,0,50q�6X   �� 5   
   -   5         ��Name$ txt_ID��5      $��22��6"   $��15(�6.   $��Stretch=�6<   $	��Top=�6Z   $��80,60,20,50q�6r   $��1��6�   $��Center=�6�    �� MaxLines$ 1��6�    �� 	MaxLength$ 50��6�   ���	#FF0040FF
���������6�   Z� 6'  �� 5   
   $��Password��6   $
��Left=�6$   $	��Top=�6?   $��	20,98,0,0q�6W   G� 5   
   -   5         G�Name$ txt_Pass��5      $��22��6(   $��15(�64   $��Stretch=�6B   $	��Top=�6`   $��
80,95,20,0q�6x   $��2��6�   $��Center=�6�    G� 	MaxLength$ 50��6�   ���	#FF0040FF
���������6�   Z� 6!  �� 5   
   -   5        $
��Cost��5      $
��Left=�6    $	��Top=�6;   $��
20,144,0,0q�6S   6g   �� 5   
   -   5        $ txt_Cost��5      $��22��6$   $��15(�60   $��Stretch=�6>   $	��Top=�6\   $��80,140,20,0q�6t   $��3��6�   $��Center=�6�   $ 1��6�   $ 25��6�   ���	#FF0040FF
���������6�   Z� 6  �� 5   
   $��Balance��6   $
��Left=�6#   $��Center=�6>   $��20,106,0,35q�6Y   �� 5   
   -   5        $ txt_Balance��5      $��22��6'   $��15(�63   $��Stretch=�6A   $��Center=�6_   {�.  $��80,105,20,35q�6�   $��Center=�6�   ���	#FF0040FF
���������6�   Z� 6�   �� 5   
   -   5        	 ��Name$	 txt_Message��5      
 �� TextAlignment$
 Center=�6)   $
��Wrap=�6@   $��Center=�6T   $��Bottom=�6q   $��15(�6�   
�������$��0,0,0,65q�6�   ���	#FF575757 J� Opacity$ 0Q�6�   �� 5   
   -   5         ��Name$ btn_Deposit��5      $��_Deposit��6&   $	��100��69   $��25��6E   $
��Left=�6Q   $��Bottom=�6l   $��	20,0,0,20q�6�   $��4��6�   ���	#BFDDDDDD$��13(�6�   ���	#FF005DFF6�   �� 5   
   -   5        $ 	btn_Check��5      $��_Check��6$   $	��100��65   $��25��6A   $��Center=�6M   $��Bottom=�6j   $��0,0,0,20q�6�   $��5��6�   ���	#BFDDDDDD$��13(�6�   ���	#FF005DFF6�   �� 5   
   -	   5        $ 
btn_Cancel��5      $��Cancel��6%   $	��100��66   $��25��6B   $��Right=�6N   $��Bottom=�6j   $��	0,0,20,20q�6�   $��6��6�   ���	#BFDDDDDD$��13(�6�   ���	#FF005DFF6�   5      5      