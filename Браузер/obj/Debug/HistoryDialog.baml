   M S B A M L   `   `   `  ����I  EБраузер, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:БраузерБраузер  5   	   "    Браузер.HistoryDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Браузер     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962a@material1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  HistoryDialog��5	   	   $	��450��6   $	��800��6,   .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   
����  � � ColumnDefinitions 5      �� 5      $	��10* �6#   �� 5      .+�5      �� $%��История браузера��6   $
��Bold"�60   $��Center=�6B   $��0��6_   $��Center=�6o   $��25(�6�   
��� ���6�   �� 5      -   5         ��Name$ btDeleteElement��5      $��Right=�6.   $��0q�6o   $��1��6{    � ToolTip$8 2Удалить выбранные элементы��6�   ��6E   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ Delete=�6�   5      �� 5   
   -   5        $��historyKList��5      $��1��6G   ��6'   �� *	History+ �� View 5      �� 5       .P�5"      ��  �� Width$	 100��6P    �� DisplayMemberBinding 6%   �� 	 �� Path$
	 Date�.��6\   Date6b   �� 5#      $	 100��6P    6%   �� $
	 Time�.��6\   Time6b   �� 5$       6%   �� $		 URL�.��6O   URL6T   5%      5'      �� 5(   
   -   5        $��
btCloseAll��5(      $%��Очистить историю��6#   $��2��6>   $��20(�6K   $��150,0,150,0q�6Y   +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 15��6n   $��0q�6�      PrimaryHueDarkBrush#��[  6�   6�   �� 5)   
   -   5        $��btGoHome��5)      $8��2Закрыть историю просмотров��6!   $��3��6F   $��20(�6S   $��100,0,100,0q�6a   $
 15��6v   $��0q�6�   6�   5*      5+      