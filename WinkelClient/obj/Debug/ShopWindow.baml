   M S B A M L   `   `   `  ����G  CWinkelClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WinkelClientWinkelClient  5   	   G(clr-namespace:WinkelClient.WinkelServiceWinkelClient.WinkelService  5   	       WinkelClient.ShopWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WinkelClient     5   	   BWinkelService(clr-namespace:WinkelClient.WinkelService     5   	     � Title$  
ShopWindow��5	   	   $��321.203��6   $��493.985��6-   .��5
      �  � RowDefinitions 5   
   �� 5      $	��37* �6   �� 5      $
��233* �6   .+�5   
   �� -   5         ��Name$ 
SaldoLabel��5      $��Placeholder saldo��6$   $
��Left=�6@   $��30,173.5,0,0q�6[   $��1��6q   $	��Top=�6~   �� 5   
   -   5        $	��Buy��5      $
��Left=�6   $��400,191,0,0q�6:   $��1��6O   $	��Top=�6\   $��66��6t   $��32��6   6�   �� 5   
   $��	Inventory��6   $
��Left=�6$   $��	30,19,0,0q�6?   $��2��6R   $	��Top=�6c   �� 5   
   $��Products��6   $
��Left=�6#   $��
247,19,0,0q�6>   $	��Top=�6R   $��2��6j   �� 5   
   -   5        $��Refresh��5      $
��Left=�6#   $��310,191,0,0q�6>   $��1��6S   $	��Top=�6`   $��71��6x   $��32��6�   6�   �� 5   
   -   5         ��Name$ InventoryList��5      $
��Left=�6*   $	��166��6E   $��30,0,0,0q�6R   $	��Top=�6d   $	��201��6|   $��1��6�    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -   5        $ 	listView1��5      $
��Left=�6&   $	��166��6A   $��	247,0,0,0q�6N   $	��Top=�6a   $	��201��6y   $��1��6�    5      �� 5      .P�5      �� 5      5!      �� 5"   
   -   5         ��Name$ Back_Button��5"      $
��Back��6&   $
��Left=�65   $��
30,212,0,0q�6P   $��1��6d   $	��Top=�6q   $��71��6�   $��32��6�   6�   5$      5%      