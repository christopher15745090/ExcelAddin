   M S B A M L   `   `   `  ����N  JPrimeAnalyticsAddin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PrimeAnalyticsAddin.UserControls PrimeAnalyticsAddin.UserControls  5      5    /PrimeAnalyticsAddin.UserControls.ExecuteProcess   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:PrimeAnalyticsAddin.UserControls     5      -   5          � Title$  Submit Data to Process��5   P    � 
ResizeMode$ NoResize=�6o    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � .+�5
   
   �� -   5         ��Name$ btCancel��5
      $��Cancel��6#   $��	0,0,10,10q�64   $��20��6^   $��Bottom=�6j   $��Right=�6�   $��75��6�   �� 5   
   -   5        $ btSubmit��5      $��Submit��6#   $��	0,0,90,10q�64   $��20��6G   $��Bottom=�6S   $��Right=�6n   $��75��6�   �� 5   
   -   5         ��Name$ cbProcesses��5      $
��Left=�6(   $��
114,14,0,0q�6C   $	��Top=�6W   $	��280��6o   6{   �� 5   
   -   5         ��Name$ label��5      $��Select Process��6   $
��Left=�68   $��	24,12,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ btnDescription��5      $��Description��6)   $
��Left=�6?   $��
414,15,0,0q�6Z   $	��Top=�6n   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��	0,66,0,35q�6%   5      5      