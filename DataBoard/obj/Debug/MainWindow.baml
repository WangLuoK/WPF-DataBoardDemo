   M S B A M L   `   `   `  ����D  @DataBoard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DataBoard	DataBoard  5          DataBoard.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:DataBoard     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $
��1200��5	      $	��700��5
      ���#29282D � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � DataContext 5      ��    Locator �� Source# [   �� Path$
 Main�'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 45Q�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      	 � RowDefinitions	 5   
   �� 5      $��45 �6   �� 5      .+�5   
   �� $��2��6   ���#29282D
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          
BlurRadius$ 30Q�5!         Opacity$	 0.5Q�5"         ShadowDepth$ 0Q�5#         Color$ Black��5$      5&      �� 5(   
   $��2��5)      ���#313134$��0,0,0,2q�5+      �� 5-   
   ���#0C7D95._�5.      �� $��Center=�5/      $��Center=�50      $��24(�51      
�������$��数据看板��53      54      � 56   
   $��1��6    57      �� 58      �� 59      .+�5;      �� $��1��5<      $��0,0,15,0q�5=      $��Right=�5>      $��Center=�5?      $��15(�5@      
���������5B      �� *
SystemTime+5C      � 5F   
   $��1��6   $��0��6   	 5G      �� 5H      �� 5I      $
��auto �6    .+�5L      �� .+�5M      	� -   5        
 J� Uid$ 	IndexView��5N      $��首页��5P        RadioButtonMenuStyle#��[ 5Q      
 � Tag$	 ��5R      	� 5S      -   5        $ LineView��5T      $��	生产线��5V      #��[ 5W      $	 ��5X      	� 5Z      -   5        $ SubLineView��5[      $��子线��5]      #��[ 5^      $	 ��5_      	� 5`      -   5        $ StopTypeView��5a      $��停机类型��5c      #��[ 5d      $	 ��5e      	� 5f      -   5        $ HistoryView��5g      $��停机数据��5i      #��[ 5j      $	 ��5k      	� 5l      -   5        $ UserInfoView��5m      $��用户��5o      #��[ 5p      $	 ��5q      5s      � 5u      $��1��6    5v      �� 5w      $
��AUTO �6'   �� 5x      $
��auto �6'   .+�5z      �� $��5,5,5,20q�5{        HomePageButtonStyle#��[ 5}      $	 ��5~      ��5|      �� *AppData.CurrentUser.Name+5~      �� 5      $��1��5�      $��5,5,5,20q�5�      $��退出��5�      #��[ 5�      $	 ��5�      ��5�      �� *ExitCommand+5�      5�      5�      �� 5�   
   -   5         ��Name$ 	container��5�      $��1��5�      $��1��5�      5�      5�      