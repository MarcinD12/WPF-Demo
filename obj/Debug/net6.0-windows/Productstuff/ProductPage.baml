   M S B A M L   `   `   `  ????B  >WPF_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPF_AppWPF_App  5          WPF_App.ProductPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WPF_App     5        N? Title$  ProductPage??5	      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??20 ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??20 ?6    ? RowDefinitions 5   
   ?? 5      $??20 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??30 ?6   ?? 5      $??* ?6   .+?5   
   ?? -   5         ??Name$ addItem??5      $??Add new item??6"   $??2??69   $??2??6I   6o   ?? 5   
   -   5        $ 
deleteItem??5      $??Remove item??6%   $??3??6;   $??2??6K   6u   ?? 5    
   -   5        $ 	showItems??5       $??
Show items??6$   $??4??69   $??2??6I   6r   ?? 5!   
   -   5        $ editItem??5!      $??	Edit item??6#   $??5??67   $??2??6G   6o   ?? 5"   
   -   5        $ 
searchitem??5"      $??Search item-ID:??6%   $??1??6?   $??3??6O   6y   ?? 5#   
   -   5         ??Name$ 
idToSearch??5#      $??3??6&   $??2??63   6E   ?? 5%   
   -   5         ??Name$ SearchedItem??5%      $??4??6S   $??2??6`   $??4??6p   ??6*   ?? *productInfo+ ?? Mode$ OneWay=?6?   5&      5*      