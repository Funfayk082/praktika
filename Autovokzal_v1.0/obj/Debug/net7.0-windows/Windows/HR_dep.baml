   M S B A M L   `   `   `  ????J  FAutovokzal_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Autovokzal_v1._0Autovokzal_v1._0  5   	       Autovokzal_v1._0.HR_dep   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Autovokzal_v1._0     5   	     ? Title$  Отдел кадров??5   
   $	??450??6   $	??800??6,   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      ?? 5      $??50 ?6   .+?5   
   ?? -   5         ??Name$ personalList??5      ???	#FFF3F3F3??6(   ?? ??5      ?? 5      .R?5      ?  ? ColumnDefinitions 5      ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   .+?5      ?? $??13(?6>   $??Center=?6L   $??5q?6i   ??6$   ?? *
Short_Id+6i   ?? 5      $??13(?6:   $??1??6H   $??Center=?6X   $??5q?6u   ??6$   ?? *Name+6u   ?? 5      $??13(?6=   $??2??6K   $??Center=?6[   $??5q?6x   ??6$   ?? *	Surname+6x   ?? 5      $??13(?6@   $??3??6N   $??Center=?6^   $??5q?6{   ??6$   ?? *
Patronymic+6{   ?? 5      $??13(?6:   $??4??6H   $??Center=?6X   $??5q?6u   ??6$   ?? *Date+6u   ?? 5       $??13(?6;   $??5??6I   $??Center=?6Y   $??5q?6v   ??6$   ?? *Otdel+6v   ?? 5!      $??13(?6;   $??6??6I   $??Center=?6Y   $??5q?6v   ??6$   ?? *Phone+6v   5"      5#      5%      ?? 5&   
    ?? Orientation$ 
Horizontal=?6   $??Center=?6.   $??2??6K   $	??800??6X   .+?5'      ?? -   5        $??Добавить??5'      $??10q?6(   64   ?? 5(      -   5        $??Изменить??5(      $??10q?6(   64   ?? 5)      -   5        $??Удалить??5)      $??10q?6'   63   ?? 5*      -   5         ??Name$ 	RF_choose??5*      $??10q?6X   $??40??6d   .@?5+      ?? -   5         ??Name$
 xlsx??5+      .??6-   Excel64   ?? 5,      -   5        $
 json??5,      .??6-   JSON63   5-      ?? 5.      -   5        $#??Составить отчёт??5.      $??10q?6/   
???/???6k   ?? 5/      $??
Найти??6   $??250 10 10 10q?6%   6=   ?? 50      -	   5        $??Сортировать??50      $??10 10 10 10q?6+   6U   51      52      53      