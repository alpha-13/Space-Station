   M S B A M L   `   `   `  ����B  >Station, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Station.GUIStation.GUI  5   	       Station.GUI.Login_Shuttle   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Station.GUI     5   	     � Title$  Login_Shuttle��5   	   $	��300��6   $	��350��6,   $	��300��68   $	��350��6H   $	��300��6W   $	��350��6g    � WindowStartupLocation$ CenterScreen=�6v    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�   ���	#7F002EFF$��2q�6�   ���	#99000000
������� � AllowsTransparency . .��5	      � .+�5
   
   �� $��Login Shuttle��6   $��30(�6)   $��Center=�67   $	��Top=�6T   $��0,30,0,0q�6l   $��Script MT Bold)�6~   �� 5   
   $��	User Name��6   $
��Left=�6%   $��Center=�6@   $��	30,0,0,50q�6[   �� 5   
   $��Password��6   $
��Left=�6$   $��Center=�6?   $��	30,50,0,0q�6Z   �� 5   
   -   5         ��Name$ ShuttleUserName��5      $��25��6+   $��Stretch=�67   $��Center=�6U   $��100,0,20,50q�6p    �� MaxLines$ 1��6�   $��1��6�   $��Center=�6�   $��15(�6  ���	#7F000000���	#FF0040FF
�������6H  �� 5   
   -   5         ��Name$ 	Name_Hint��5      $��*��6'   $��25��60   $��Right=�6<   $��Center=�6X   $��	0,0,25,41q�6s   
���  ��$��30(�6�   $��Microsoft Himalaya)�6�    J� IsHitTestVisible .  $y�Hidden=�6�   G� 5   
   -   5        	 G�Name$	 ShuttlePassword��5      $��25��6/   $��Stretch=�6;   $��Center=�6Y   $��100,50,20,0q�6t   $��2��6�   $��Center=�6�   $��15(�6  ���	#7F000000���	#FF0040FF
�������6X  �� 5   
   -   5        $ 	Pass_Hint��5      $��*��6'   $��25��60   $��Right=�6<   $��Center=�6X   $��	0,58,25,0q�6s   
���  ��$��30(�6�   $��Microsoft Himalaya)�6�    .  $y�Hidden=�6�   �� 5   
   -   5        
 ��Name$
 Login��5      $��_Login��6    $	��100��61   $��25��6=   $��Center=�6I   $��Bottom=�6f   $��0,0,0,75q�6�   $��3��6�   ���	#BFDDDDDD$��13(�6�   ���	#FF005DFF6�   �� 5   
   -   5        $
 Cancel��5      $��_Cancel��6!   $	��100��63   $��25��6?   $��Center=�6K   $��Bottom=�6h   $��0,0,0,30q�6�   $��4��6�   ���	#BFDDDDDD$��13(�6�   ���	#FF005DFF6�   5      5      