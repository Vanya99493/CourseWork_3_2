   M S B A M L   `   `   `  ����O  KDictionaryTranslator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:DictionaryTranslator.Pages.MainContentSubpages.DictionaryTranslator.Pages.MainContentSubpages  5      B    <DictionaryTranslator.Pages.MainContentSubpages.FavoritesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:DictionaryTranslator.Pages.MainContentSubpages     5        N� FontSize$  15(�5	       N� Title$ FavoritesPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��8* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��3* �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ TextBox_CustomQuery��5       �� TextWrapping$
 Wrap=�6/   " �� VerticalScrollBarVisibility$ Visible=�6C    �� AcceptsReturn . $��5 5 0 0q�6~   $��0��6�   $��0��6�   $��2��6�   
�������6�   �� 5   
   -   5        $��SELECT��5   2   $��15(�6C   $��5 5 5 0q�6Q   $��0��6b   $�� 2��6o   $��0q�6�   
�����F�
�������6�   �� 5   
   -   5         ��Name$ ComboBox_FavoritesLists��5      $��5 5 0 0q�64   $��1��6E   $��0��6R   $��1��6b   
�������6v   �� 5   
   -   5        $��SELECT LIBRARY��5   4   $��15(�6M   $��5 5 0 0q�6[   $��1��6l   $��1��6y   $��0q�6�   
�����F�
�������6�   � 5   
   $��1��6   $��2��6   $��5 5 5 0q�6,    5      �� 5      �� 5       .+�5#      �� -   5        $ TextBox_NewLibraryName��5#      $��0��66   $��2q�6C   �� 5$      -   5        $��1��5$   2   $	��ADD��6?   $��15(�6M   $��0q�6[   
�����F�
�������6�   5%      &   System.Windows.Controls.DataGrid  5'   
   -   5        	  Name$	 DataGrid_DataView��5'      $��5q�6.   $��2��69   $��0��6F   $��3��6V   
������6j   5(      5)      