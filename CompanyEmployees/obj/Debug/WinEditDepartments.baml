   M S B A M L   `   `   `  ����K  GCompanyEmployees, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CompanyEmployeesCompanyEmployees  5   	   )    #CompanyEmployees.WinEditDepartments   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CompanyEmployees     5   	     � Title$  Отделы��5   	   $��186.5��6   $
��38.5��6'   $	��300��5	   	   $	��400��6    � WindowStyle$ 
ToolWindow=�6(      WindowBackgroundBrush#��[  5
   	    � 	Resources 5       �� Source�� 5   
   $ StylesDictionary.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $
��233* �6   �� 5      $	��73* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgDepartments��5      $��10q�6*      AutoGenerateColumns .     SelectionMode$ Single=�5      $   HorizontalScrollBarVisibility$ Disabled=�6*   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 №��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 10* 6G      MinWidth$ 20Q�6S      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *Id+6a     5      $
 
Отдел��6%   $	 90* 6M    .   64   �� *Name+6Y   5      �� 5   
   -   5         ��Name$ BtnOk��5      $��Ok��6    $��	0,0,10,10q�6-   $��23��6@   $��Bottom=�6L   $��1��6g    �� IsCancel . 6w   �� 5   
   -   5        $ BtnAddNewDepartment��5      $��Добавить��6.   $��	0,10,10,0q�6A   $��1��6T   $��23��6d   $	��Top=�6p   �� 5   
   -   5        $ BtnRemoveDepartment��5      $��Удалить��6.   $��	0,38,10,0q�6@   $��1��6S   $��23��6c   $	��Top=�6o   5      5      