   M S B A M L   `   `   `  ����  PixelQRGeneratorApp$    PixelQRGeneratorApp.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Pixel QR Generator��5   	   $	��600��6$   $	��640��61   ���#f4f4f4 � WindowStartupLocation$ CenterScreen=�6R   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� 
������� �� Padding$ 15q�6$    �� CornerRadius$ 10��61   $��0,0,0,10q�6C   ���#DDDDDD$��1q�6k   ._�5      ��  �� Orientation$ Vertical=�6   $��Stretch=�60   .+�5      �� -   5         ��Name$ 	InputText��5      $	��600��6-   $��0,0,0,10q�69   $��https://example.com��6K   
�������
���   ����#ccc$��14(�5   S   $��6q�6a   �� 5      $ 
Horizontal=�6   $��0,0,0,10q�66   $��Center=�6H   .+�5      �� $��Pixel Size:��6    $��Center=�63   $��0,0,10,0q�6N   $��13(�6`   �� 5      -   5         ��Name$ PixelSlider��5       � Minimum$ 2Q�62   	 � Maximum$	 20Q�6>   $	��180��6K   
 � Value$
 8Q�6W    �� TickFrequency$ 2Q�6a    �� IsSnapToTickEnabled$
 True��5      �� 5      $��10,0,0,0q�6U   $��13(�6g   ��6    ��  �� ElementName$ PixelSlider�� �� Path$ Value�6g   5      �� 5      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5      �� $��Pixel Shape:��6    $��Center=�64   $��0,0,10,0q�6O   $��13(�6a   �� 5      -   5         ��Name$ PixelShapeSelector��5      $	��160��6;    �� SelectedIndex$ 0��6G   .@�5      �� .��6'   Square6/   �� 5      .��6'   Circle6/   5      5      �� 5       $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5!      �� $��Pixel Color:��6    $��Center=�64   $��0,0,10,0q�6O   $��13(�6a   �� 5"      -   5        $ ColorSelector��5"      $	��120��66   $ 0��6B   .@�5#      �� $��Black��6'   �� 5$      $	��Red��6'   �� 5%      $��Green��6'   �� 5&      $
��Blue��6'   �� 5'      $��Orange��6'   �� 5(      $��Purple��6'   5)      5*      �� 5,      $ 
Horizontal=�6   .+�5-      �� -   5        $��Generate QR��5-      $	��150��63   $��0,0,10,0q�6?   ���#0078D7
�������$
��Bold"�5.   E   $��6q�6W   �� 5/      -   5        $��Save as SVG��5/      $	��150��63   ���#28a745
�������$
��Bold"�50   E   $��6q�6W   51      52      53      �� 55   
   $��1��6   $
��Auto=�6$   $
��Auto=�6I   .��56      �� -   5         ��Name$ MyCanvas��56      
�������$��0q�6:   57      58      59      