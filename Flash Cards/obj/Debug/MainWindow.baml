   M S B A M L   `   `   `  ����F  BFlash Cards, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Flash_CardsFlash_Cards  5      ?$clr-namespace:Flash_Cards.ViewModelsFlash_Cards.ViewModels  5      5clr-namespace:Flash_Cards.ViewsFlash_Cards.Views  5	          Flash_Cards.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Flash_Cards     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;
viewmodels$clr-namespace:Flash_Cards.ViewModels     5      1viewsclr-namespace:Flash_Cards.Views     5	        � Title$  
MainWindow��5
      $	��800��5      $	��450��5       � 	Resources 5       �� DataType'   !Flash_Cards.ViewModels.CardCreate"   Flash_Cards.Views.CardCreate � DataContext)   #Flash_Cards.ViewModels.CardPractice$   Flash_Cards.Views.CardPractice��%�   (��       5   +   *, +)(�� O     5   -   *, +)�� 5   
   
CardCreate��"  6+   .R�5         6   �� 5      �� 5   
   CardPractice��"  6-   .R�5         6!   �� 5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��5 �6    � ColumnDefinitions 5    
   �� 5!      $��5 �6   �� 5"      $	��250 �6   �� 5#      $��5 �6   �� 5$      $��* �6   �� 5%      $��5 �6   .+�5(   
   �� -   5         ��Name$ DeckList��5)      $��1��5*      $��1��5+      ��5,      �� 5-       �� 
TargetType" ��6   .�5.      -   5        50      .@�52      �� -   5         ��Name$ NewCardDeck��53      $��Center=�54      
��� � �.��55   $   Create new card deck57      58      �� 5:   
   -   5        	 ��Name$	 DisplayWindow��5;      $��1��5<      $��2��5=      $��3��5>      ��5?      �� �� 5A   
   -   5        
 ��Name$
 ModeSwitching��5B      $��2��5C      $��1��5D      $��3q�5E      
�������$��
MODE: EDIT��5H      5I      5J      