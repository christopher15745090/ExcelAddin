   M S B A M L   `   `   `  ����N  JPrimeAnalyticsAddin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PrimeAnalyticsAddin.UserControls PrimeAnalyticsAddin.UserControls  5      5    /PrimeAnalyticsAddin.UserControls.PushToCloudNew   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:PrimeAnalyticsAddin.UserControls     5      -   5          �Name$  PushNew��5   	    � Title$( "Push To Cloud Controls (New Table)��5       � WindowStartupLocation$ CenterScreen=�6J   $	��700��5   (    � WindowStyle$ ThreeDBorderWindow=�65   $	��760��6V   .��5      � .+�5   
   �� -   5         ��Name$ listBoxLeft��5      $��
32,148,0,0q�6'   $	��461��6;   $	��Top=�6H   $
��Left=�6`   $	��300��6{    J� 	AllowDrop . 6�   �� 5   
   -   5         ��Name$ 
btnInclude��5      $��>��6%   $��348,271,0,0q�64   $
��Left=�6I   $��46��6d   $��20��6o   $	��Top=�6{   6�   �� 5   
   -   5        $ 
btnExclude��5      $��<��6%   $��348,296,0,0q�64   $	��Top=�6I   $
��Left=�6a   $��46��6|   6�   �� 5   
   -   5        $ listBoxRight��5      $��410,148,0,0q�6(   $	��461��6=   $	��Top=�6J   $
��Left=�6b   $	��300��6}    . 6�   �� 5   
   -   5         ��Name$ cbSheetName��5      $
��Left=�6(   $��
161,10,0,0q�6C   $	��Top=�6W   $	��329��6o   6�   �� 5   
   -   5         ��Name$ label��5      $��Worksheet Name��6   $
��Left=�68   $��	32,10,0,0q�6S   $	��Top=�6f   	 J� RenderTransformOrigin$	 -0.329,0.635&�6~   $	��124��6�   �� 5   
   -   5        $ label1��5      $��
Table Name��6    $
��Left=�65   $��	32,41,0,0q�6P   $	��Top=�6c   $	��124��6{   �� 5   
   -	   5        
 ��Name$
 	tableName��5      $
��Left=�6%   $��23��6@   $��
161,44,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��329��6�   �� 5   
   -
   5        $ btCreateNewTable��5      $��Create New Table��6+   $
��Left=�6F   $��112,623,0,0q�6a   $	��Top=�6v   $	��115��6�   $	 -0.23,0&�6�   $��27��6�   6�   �� 5   
   -   5        $ label2��5      $��Data Table Headers��6    $
��Left=�6=   $��
32,117,0,0q�6X   $	��Top=�6l   $	��210��6�   �� 5   
   -   5        $ label3��5      $��New Table Headers��6    $
��Left=�6<   $��414,117,0,0q�6W   $	��Top=�6l   $	��264��6�   �� 5   
   -   5        $ 
btnPreview��5      $��Preview��6%   $
��Left=�67   $��
32,623,0,0q�6R   $	��Top=�6f   $��75��6~   $��27��6�   6�   �� 5   
   -   5        $ button��5      $��Cancel��6!   $
��Left=�62   $��635,623,0,0q�6M   $	��Top=�6b   $��75��6z   $��27��6�   6�   �� 5   
   -   5        $ btnIncludeAll��5      $��>>��6(   $��348,354,0,0q�6;   $	��Top=�6P   $
��Left=�6h   $��46��6�   6�   �� 5   
   -   5        $ btnExcludeAll��5      $��<<��6(   $��348,379,0,0q�6;   $	��Top=�6P   $
��Left=�6h   $��46��6�   6�   5      5      