   M S B A M L   `   `   `  ����O  KDictionaryTranslator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:DictionaryTranslator.Pages.MainContentSubpages.DictionaryTranslator.Pages.MainContentSubpages  5      C    =DictionaryTranslator.Pages.MainContentSubpages.TranslatorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:DictionaryTranslator.Pages.MainContentSubpages     5        N� FontSize$  15(�5       N� Title$ TranslatorPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��2* �6   �� 5      -   5         ��Name$ Row_InputOutputBlocks��5   )   $	��14* �6   6)   �� 5      -   5        $ Row_CategoriesController��5   (   $��2* �6   6(   �� 5      -   5        $ Row_AddNewLanguage��5   (   $��2* �6   6(   �� 5      -   5        $ Row_AddToFavorite��5   (   $��2* �6   6(    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ Button_ExecuteAction��5   %   $��	TRANSLATE��6   $��0��6Y   $��0��6f   $��20 15q�6v   $��10q�6�   $��0q�6�   $
��Left=�6�   $��Center=�6�   
�����F�
�������6�   �� 5   
   -   5        $  Button_SwitchTranslateMode��5   "   $��TO ADD��6   $��0��6b   $��1��6o   $��20 15q�6   $��10q�6�   $��0q�6�   $��Right=�6�   $��Center=�6�   
�����F�
�������6�   �� 5!   
   -   5         ��Name$! ComboBox_SourceWordLanguage��5!      $��1��68   $��0��6E   $
��10 5q�6U   �� 5"   
   -   5        $! ComboBox_TargetWordLanguage��5"      $��1��68   $��1��6E   $
��10 5q�6U   �� 5$   
   -	   5         ��Name$ TextBox_EnterSourceWord��5$      $��2��63   $��0��6@    �� TextWrapping$
 Wrap=�6Q   $��10q�6e   $��10q�6r   
�������6�   �� 5%   
   -
   5        $ TextBox_EnterTargetWord��5%      $��2��63   $��1��6@   $
 Wrap=�6P   $��10q�6d   $��10q�6q   $y�	Collapsed=�6}   
�������6�   �� 5&   
   -   5        	 ��Name$ 	 TextBlock_OutputTargetWord��5&      $��2��69   $��1��6F   $
��Wrap=�6V   
 �� Padding$
 10q�6j   $��10q�6w   $y�Visible=�6�   
�������6�   � 5(   
   $��3��6   $��0��6   $��2��6,   $��5 0 5 5q�6@    5)      �� 5*      $��3* �6#   �� 5+      $��2* �6#   �� 5,      $��2* �6#   �� 5-      $��3* �6#   .+�50      �� -   5        $! ComboBox_SourceWordCategory��50      $��0��6<   $��0 0 5 0q�6L   �� 51      -   5        $ TextBox_NewCategoryField��51      $��1��68   
�������6H   �� 52      -   5        $��2��52   3   $��ADD CATEGORY��6C   $��15(�6Z   $��0q�6i   
�����F�
�������6�   �� 53      -   5        $! ComboBox_TargetWordCategory��53      $��3��6<   $��5 0 0 0q�6L   54      ]� 56   
   $��4��6   $��2��6!   .+�57      �� -   5        $��ADD LANGUAGE��57   3   $
��Left=�6J   $	��8 4q�6`   $��5 0 5 2q�6n   $��0q�6   
�����F�
�������6�   �� 58      -   5        $ TextBox_NewLanguageField��58      $
��Left=�68   $
 Wrap=�6N   
�������$	��8 4q�6y   $��0 0 5 2q�6�   59      �� 5;   
   -   5        $ ComboBox_Libraries��5;      $��5��6/   $��0��6<   $	��8 4q�6L   $	��5 2q�6Z   
�������6g   �� 5<   
   -   5        $��SAVE TO FAVORITE��5<      $��5��6J   $��1��6W   $
��10 4q�6g   $	��0 2q�6v   $��15(�6�   $��0q�6�   $
��Left=�6�   
�����F�
�������6�   5=      5>      