   M S B A M L   `   `   `  ����F  BFlash Cards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Flash_Cards.ViewsFlash_Cards.Views  5      $    Flash_Cards.Views.CardPractice   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Flash_Cards.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5        
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��5 �6   .+�5   
   � $��1��6   $��1��6   .+�5      �� -   5         ��Name$ CardBoxFront��5       
�������$
��Test��5#      $��30(�5$       J� RenderTransformOrigin$ 0.5, 0.5&�5%      $y�Visible=�5&      �� 5'      -   5        $ CardBoxBack��5(      
�������$
��Test��5+      $��30(�5,      $ 0.5, 0.5&�5-      $y�Hidden=�5.      5/      �� 55   
   -   5        $ btnLeft��56      $��2��57      $��1��58      $	��150��59      $
��Left=�5:      
�������.��5<   #   LEFT5>      �� 5?   
   -   5        $ btnRight��5@      $��2��5A      $��1��5B      $	��150��5C      $��Right=�5D      
�������.��5F   $   Right5H      5I      5J      