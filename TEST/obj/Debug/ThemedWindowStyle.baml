   M S B A M L   `   `   `  ����T  PCustom Window Chrome Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Custom_Window_Chrome_DemoCustom_Window_Chrome_Demo  5      %    Custom_Window_Chrome_Demo.CloseR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 	  Style  �� 
TargetType �� Property �� Value �� 
TargetType �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty	 �� 
TargetName
 R� KeyTime R� Value �� Color8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value ��Name J� SnapsToDevicePixels �� TextAlignment �� Padding �� Triggers P� Property P� Value,   &Custom_Window_Chrome_Demo.ThemedWindow  ThemedWindowStyle �� 	Resources  Key � ColumnDefinitions � RowDefinitions ��Name  BorderBrush  CaptionBackgroundBrush �� Orientation ��Name ��Name ��Name �� EdgeMode �� BaselineAlignment  � Title  CaptionForegroundBrush! P� 
SourceName" �� 
TargetName   5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1local'clr-namespace:Custom_Window_Chrome_Demo  5      %�  &	        &	 �    �� 5      "  ��6   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5	      � $
 grid��6   ���	#FFEA2B4A 5
        5      CommonStates��. 5   "     
Normal��. 5   &   �� .��5   *   T� $ (UIElement.OpacityMask)�6H   $
	 grid��6|   ..�5   .   i� $
 0��6E    5   2   �� 5   6   $ 	#D7B08484��6F   5   /   5   +   5   '   5   #     5   "   	MouseOver��6.     5   "   Pressed��. 5   &   �� .��5   *   �� $0 *(Panel.Background).(SolidColorBrush.Color)�6G   $
	 grid��6�   .g�5   .     $ 0��6B   $ 	#FF9E1C31��6N   5   +   5   '   5   #     5   "   Disabled��6.   5       .+�5"      �� $ contentPresenter��6+   ��. # z 6`   $�� ��6�   �� 5#      $
��Left=�6$   $��25��6?   $
��Wrap=�6K   $	��Top=�6_   $��50��6w   $��0q�6�   $ Center=�6�   $��16(�6�   $ 0,1,0,0q�6�   
��������� 6�   $	�❌��6�   6�   5$       5%      P� 5&       �@J�	IsFocused . 67   P� 5'       �@��IsDefaulted . 69   P� 5(       �@J�IsMouseOver . 69   P� 5)       � �� . 67   P� 5*       � {� .  67   5,      5.      5/      �� 50      "   6    51   
   ���� 52      BorderBrush $ 	#FF1a1a1d��62   �� 53      CaptionBackgroundBrush $ #1a1a1d��6=   �� 54      CaptionForegroundBrush $ White��6=   �� 55      
button $	 red��6-   56      .�58   
   ��  � ��
 �����6'   �� 59   
    �@�AllowsTransparency . 6/   �� 5:   
    � ��$	 100��6%   �� 5;   
    � ��$	 100��6&   �� 5<   
    �@�WindowStyle$
 None=�6(   �� 5=   
    � �� 5>      �� 5?      "  6"   PART_WindowTemplate��.R�5@      � $ PART_WindowFrame��6    5A      �� 5B      $��3 �6/   �� 5C      $��* �6/   �� 5D      $��3 �6/    5G      �� 5H      $��0 �6,   �� 5I      $��30 �6,   �� 5J      $��* �6,   �� 5K      $��3 �6,   .+�5N      �� $ PART_WindowBorderLeft��6L   #���  6!   $��0��6k   $��1��6{   $��2��6�   �� 5O      $ PART_WindowBorderTopLeft��6L   #���  6!   $��0��6n   $��0��6~   �� 5P      $ PART_WindowBorderTop��6L   #���  6!   $��1��6j   $��0��6z   �� 5Q      $ PART_WindowBorderTopRight��6L   #���  6!   $��2��6o   $��0��6   �� 5R      $ PART_WindowBorderRight��6L   #���  6!   $��2��6l   $��1��6|   $��2��6�   �� 5S      $" PART_WindowBorderBottomRight��6L   #���  6!   $��2��6r   $��3��6�   �� 5T      $ PART_WindowBorderBottom��6L   #���  6!   $��1��6m   $��3��6}   �� 5U      $! PART_WindowBorderBottomLeft��6L   #���  6!   $��0��6q   $��3��6�   �� 5W      $ PART_WindowCaption��6!   $��1��6=   $��1��6M   #���  6Z   ._�5X      ]� ��. .+�5Y   "   �� $��Right=�6-   $ 
Horizontal=�6D   $	��Top=�6]   .+�5[   &   �� $# PART_WindowCaptionCloseButton��6-   -   5        #���   5[   T   $��0,0,4,0q�6u   $	��Top=�6�   6�   5]   #   �� 5^   "   $ PART_WindowCaptionText��6,   $
��Left=�6L   $��0,0,0,0q�6b   $ 5q�6s   �� 5_   &   $ PART_WindowCaptionIcon��6,   $��0��5`   ,   $��30��5a   ,   $��0,0,0,0q�5b   ,    . $ Aliased=�5e   ,   ��5c   ,   Z� 5e   ,    �� 5f   &   $ Center=�6*   #�z  5g   *   $��16(�6I   #���  5h   *   $��SemiBold"�6`   5i   #   5j      5k      ]� 5m      #��z��6$   $��2��6N   $��1��6[   .+�5n      �� 5o      5p       5r      P� 5s      $! PART_WindowCaptionIcon��6"    6X   Z�  � ��. �5t      �� $" PART_WindowCaptionText��6%    � ��$ 0q�6[   5u      5w      5y      5z      5|      