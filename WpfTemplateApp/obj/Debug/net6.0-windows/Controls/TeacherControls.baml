   M S B A M L   `   `   `  ����I  EWpfTemplateApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfTemplateApp.ControlsWpfTemplateApp.Controls  5      -    'WpfTemplateApp.Controls.TeacherControls   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5      1local%clr-namespace:WpfTemplateApp.Controls  5      .��5
      � ���#47474A$��1q�5   	     � ColumnDefinitions  5   
   �� 5      $
��1.2* �6   �� 5      �� 5      $
��0.8* �6   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ TextBlockUsername��5      $��0��5      $
��Left=�5       �� Padding$ 5q�5      $��22(�5      5      �� 5   
   -   5        $ TextBlockEmail��5      $��1��5      $
��Left=�5      $ 5q�5      $��22(�5      5      �� 5    
   -   5        $ TextBlockPhone��5$      $��2��5       $
��Left=�5!      $ 5q�5"      $��22(�5#      5$      �� 5%   
   -   5        $ TextBlockInfo��5)      $��3��5%      $
��Left=�5&      $ 5q�5'      $��22(�5(      5)      � 5+   
   $��4��6   .+�5,      �� -   5         ��Name$ 	UpdateBtn��50      $��2q�5-      $��Right=�5.      $��75��5/      $��75��53       $   MaterialDesignOutlinedDarkButton#��[  54       � ToolTip$" MaterialDesignOutlinedButton��55      ��51      �� *	MyCommand+��52      �� *Id+{�56      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��57      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Update=�58      $��30��59      $��30��5:      5;      �� 5<      -   5        $��2 2 78 2q�5>      $��Right=�5?      $��75��5@      $��75��5A      #��[  5B      $" MaterialDesignOutlinedButton��5C      {�5D      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5E        $ Delete=�5F      $��30��5G      $��30��5H      5I      5J      5K      5L      