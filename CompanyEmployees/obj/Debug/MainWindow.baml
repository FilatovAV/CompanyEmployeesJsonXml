   M S B A M L   `   `   `  ����K  GCompanyEmployees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CompanyEmployeesCompanyEmployees  5   	   !    CompanyEmployees.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CompanyEmployees     5   	     � Title$  XML база данных��5   	   $	��360��6!   $	��560��6.   $	��300��6:   $	��400��6J      WindowBackgroundBrush#��[  5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��75* �6   �� 5      $	��25* �6   .+�5   
   �� -   5         ��Name$ CbDepartment��5      $��23��6)    �� Text$  ��65   $	��Top=�6=   $��128,10,43,0q�5       �� DisplayMemberPath$
 Name��6(   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
DgEmployee��5      $��10,85,10,10q�6'      AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Disabled=�6X      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Имя��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 45* 6K      MinWidth$ 15Q�6W      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Name+6e     5      $	 
Отдел��6%   $	
 25* 6X    .  64   �� *Department.Name+6d     5      $	 Зарплата��6%   $	
 15* 6R    .   67   �� *Salary+6^     5      $	 Возраст��6%   $	
 10* 6N    .   66   �� *Age+6Z   5      �� 5   
   -   5         ��Name$ BtnDepartmentsEdit��5      $��Отделы��6-   $��23��6>   $��	0,10,10,0q�6J   $	��Top=�6]   $��1��6u   �� 5   
   -   5        $ BtnAddNewEmployee��5      $��Добавить��6,   $��	0,0,10,38q�6?   $��23��6R   $��Bottom=�6^   $��1��6y   �� 5   
   -   5        $ BtnRemoveEmployee��5      $��Удалить��6,   $��	0,0,10,10q�6>   $��23��6Q   $��Bottom=�6]   $��1��6x   �� 5   
   -   5        $ BtnSelectDepartment��5      $��Указать отдел��5      $��23��5      $��	0,38,10,0q�5       $	��Top=�5!      $��1��5"      $y�Hidden=�5#      �� 5$   
   -   5        $ 	BtnSaveDB��5$      $"��Сохранить как...��6$   $��23��5%      $��
0,141,10,0q�5&      $	��Top=�5'      $��1��5(      �� 5)   
   -   5        $ BtnSerializeOpenDB��5)      $��Открыть��5*      $��23��5+      $��	0,85,10,0q�6   $	��Top=�5,      $��1��5-      �� 5.   
   -	   5        $ BtnResetFilter��5.      $��X��5/      $��23��50      $��	0,10,10,0q�51      $	��Top=�52      $��0��53      $��Right=�6   $��28��69   �� 54   
   $
��Left=�6   $��23��6/   $��	10,14,0,0q�6;   $
��Wrap=�6N   $%��Фильтр по отделу:��6b   $	��Top=�6{   $	��113��6�   �� 55   
   -
   5        $ CbDepartmentSet��55      $��23��56      $	��Top=�57      $��151,57,10,0q�58      $
 Name��59      ��5:      �� 5;       �� 
TargetType" ��6   .�5<      ��  �� Property � {� �� Value . 6E   �� 5=       � ��# [  63    �� Triggers 5>      �� 5?       �� Binding 6&   ��  �� ElementName$ 
DgEmployee�� �� Path$ SelectedIndex� �� Value -16k   .a�5@      ��  � {� .  6N   5A      5C      5E      �� 5G   
   $
��Left=�6   $��23��6/   $��	10,62,0,0q�6;   $
��Wrap=�6N   $+��%Переместить в отдел:��6b   $	��Top=�6~   $	��136��6�   �� 5H   
   -   5        $ BtnSaveCurDB��5H      $��Сохранить��6'   $��23��5I      $��
0,113,10,0q�5J      $	��Top=�5K      $��1��5L      5M      5N      