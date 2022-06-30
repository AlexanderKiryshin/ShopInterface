using Assets._Scripts;
using Assets._Scripts.Data;
using Assets._Scripts.Items;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShopListEditor : EditorWindow
{
    public enum TypeSuggestion
    {
        Image,
        Text,
        TwoImages,
        ImageWithText,
        TwoTexts,
        VirtualCurrency
    }

    public class Data
    {
        public int index;
        public TypeSuggestion suggestion;
        public Data(int index,TypeSuggestion suggestion)
        {
            this.index = index;
            this.suggestion = suggestion;
        }
    }
    private static List<BaseItem> itemsList;

    //  private List<IITem> items;
    [MenuItem("ShopList/ShopList")]
    public static ShopListEditor ShowWindow()
    {
        var window = GetWindow<ShopListEditor>();
        window.titleContent = new GUIContent("ShopList");
        if (itemsList == null)
        {
            itemsList = ItemsDatabase.LoadItemsList();
        }
        return window;
    }   
    public  void OnGUI()
    {
        DrawWindow();
    }
    Vector2 scrollPosition;
    void DrawWindow()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        if (itemsList!=null && itemsList.Count > 0)
        {
            for(int i=0;i< itemsList.Count; i++)
            {
               
                EditorGUILayout.BeginVertical("box");
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("X", GUILayout.Width(15), GUILayout.Height(15)))
                {
                    itemsList.RemoveAt(i);
                    ItemsDatabase.SaveItemsList(itemsList);
                }

                if (itemsList.Count<= i)
                {
                    break;
                }
                EditorGUILayout.EndHorizontal();
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent(ImageItem.name), false, HandleItemClicked,new Data(i, TypeSuggestion.Image));
                menu.AddItem(new GUIContent(TwoTextItem.name), false, HandleItemClicked, new Data(i, TypeSuggestion.TwoTexts));
                menu.AddItem(new GUIContent(TwoImagesItem.name), false, HandleItemClicked, new Data(i, TypeSuggestion.TwoImages));
                menu.AddItem(new GUIContent(TextItem.name), false, HandleItemClicked, new Data(i, TypeSuggestion.Text));
                menu.AddItem(new GUIContent(ImageWithTextItem.name), false, HandleItemClicked, new Data(i, TypeSuggestion.ImageWithText));
                menu.AddItem(new GUIContent(VirtualCurrencyItem.name), false, HandleItemClicked, new Data(i, TypeSuggestion.VirtualCurrency));
                if (EditorGUILayout.DropdownButton(new GUIContent(itemsList[i].Name), FocusType.Passive))
                {
                    menu.ShowAsContext();                    
                }
                itemsList[i].Draw();
                EditorGUILayout.EndVertical();
            }
        }
        else EditorGUILayout.LabelField("Нет элементов в списке!");
        if (GUILayout.Button("Добавить элемент", GUILayout.Height(30)))
        {
            if (itemsList== null)
            {
                itemsList = new List<BaseItem>();
            }
            itemsList.Add(new ImageItem(itemsList.Count));
            ItemsDatabase.SaveItemsList(itemsList);
        }
        GUILayout.EndScrollView();
    }
    void HandleItemClicked(object parameter)
    {
        var data = (Data)parameter;
        
        switch (data.suggestion)
        {
            case TypeSuggestion.Image: itemsList[data.index] = new ImageItem(data.index); break;
            case TypeSuggestion.ImageWithText: itemsList[data.index] = new ImageWithTextItem(data.index); break;
            case TypeSuggestion.TwoImages: itemsList[data.index] = new TwoImagesItem(data.index); break;
            case TypeSuggestion.TwoTexts: itemsList[data.index] = new TwoTextItem(data.index); break;
            case TypeSuggestion.VirtualCurrency: itemsList[data.index] = new VirtualCurrencyItem(data.index); break;
            case TypeSuggestion.Text: itemsList[data.index] = new TextItem(data.index); break;
        }           
    }

    private void OnDestroy()
    {
        ItemsDatabase.SaveItemsList(itemsList);
    }
}

