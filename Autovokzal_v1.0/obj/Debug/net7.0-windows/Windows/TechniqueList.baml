   M S B A M L   `   `   `  ????J  FAutovokzal_v1.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Autovokzal_v1._0.WindowsAutovokzal_v1._0.Windows  5   	   ,    &Autovokzal_v1._0.Windows.TechniqueList   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Autovokzal_v1._0.Windows     5   	     ? Title$!  Список техники??5   	   $	??450??6    $	??800??6-   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      ?? 5      $??50 ?6   .+?5   
   ?? -   5         ??Name$ techniqueList??5      ??6)   ?? ??5      ?? 5      .R?5      ?  ? ColumnDefinitions 5      ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   ?? 5      $
??Auto ?6/   .+?5      ?? $??13(?6:   $??0??6H   $??Center=?6X   ??6$   ?? *Mark+6X   ?? 5      $??13(?6;   $??1??6I   $??Center=?6Y   ??6$   ?? *Model+6Y   ?? 5      $??13(?6;   $??2??6I   $??Center=?6Y   ??6$   ?? *Color+6Y   ?? 5       $??13(?6?   $??3??6M   $??Center=?6]   ??6$   ?? *	GovNumber+6]   ?? 5!      $??13(?6:   $??4??6H   $??Center=?6X   ??6$   ?? *Type+6X   ?? 5"      $??13(?6<   $??5??6J   $??Center=?6Z   ??6$   ?? *Volume+6Z   ?? 5#      $??13(?6>   $??6??6L   $??Center=?6\   ??6$   ?? *
FuelCons+6\   ?? 5$      $??13(?68   $??7??6F   $??Center=?6V   ??6$   ?? *LC+6V   ?? 5%      $??13(?69   $??8??6G   $??Center=?6W   ??6$   ?? *VIN+6W   5&      5'      5)      ?? 5*   
   $??1??6    ?? Orientation$ 
Horizontal=?6"   $??Center=?6;   .+?5+      ?? -   5        $??Добавить??5+      $??10q?6(   64   ?? 5,      -   5        $??Изменить??5,      $??10q?6(   64   ?? 5-      -   5        $??Удалить??5-      $??10q?6'   63   5.      5/      50      