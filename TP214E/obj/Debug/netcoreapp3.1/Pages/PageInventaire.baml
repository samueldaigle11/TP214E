   M S B A M L   `   `   `  ����A  =TP214E, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TP214ETP214E  5          TP214E.PageInventaire   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:TP214E     5        N� Title$  
Inventaire��5	      .��5      � 
���   � � ColumnDefinitions 5   
   �� 5      $	��180 �6   �� 5      $��* �6   �� 5      $	��180 �6    � RowDefinitions 5   
   �� 5      $
��0.2* �6   �� 5      $��* �6   �� 5      $
��0.2* �6   .+�5   
   �� $��0��6   $��1��6   $��Inventaire du FoodTruck��6-   ���	#FF5F8C5A$��Center=�6f   $��Center=�6�   $��Rockwell)�6�   $��36(�6�   $��Normal"�6�   �� 5   
   -   5        $��lstObjetsInventaire��5   /   $��1��6   $��1��6   $��	0,0,10,10q�6J   5      �� 5   
   -   5        $��bt_retourAccueil��5      $��Retour vers l'Accueil��6)   $��1��6I   $��3��6Y   $��Center=�6f   ���	#CC5F8C5A
�������
���   �$��2,2,2,2q�6�   $
��10,5q�6�   $��24(�6�   $	��320��6�   $
��Bold"�6  $��Rockwell)�6  $��0,0,0,0q�6,   � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 5��65   5      5      5      �� 5    
   $��1��6   $��2��6"   $	��Top=�62   $��Center=�6J   .+�5!      �� -   5         ��Name$ bt_ajouterObjet��5!      $��Ajouter un objet/aliment��6.   ���	#CC5F8C5A
�������
���   �$��2,2,2,2q�6�   $��12(�6�   $��30��6�   $
��Bold"�6�   $��Tahoma)�6�    5"      ��%^   '��       �� 5#      " ��6   .�5$      ��  �@��CornerRadius$ 5��69   5%      5&      5'      �� 5(      -   5        $ bt_supprimerObjet��5(      $ ��Supprimer un objet/aliment��60   ���	#CC5F8C5A
�������
���   �$��2,2,2,2q�6�   $��12(�6�   $��30��6�   $
��Bold"�6�   $��Tahoma)�6�   $
��0,10q�6�    5)      ��%^   '��       �� 5*      " ��6   .�5+      ��  �@��CornerRadius$ 5��69   5,      5-      5.      �� 5/      -   5        $ bt_modifierObjet��5/      $��Modifier un objet/aliment��6/   ���	#CC5F8C5A
�������
���   �$��2,2,2,2q�6�   $��12(�6�   $��30��6�   $
��Bold"�6�   $��Tahoma)�6�    50      ��%^   '��       �� 51      " ��6   .�52      ��  �@��CornerRadius$ 5��69   53      54      55      56      57      58      