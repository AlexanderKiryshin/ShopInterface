using Assets._Scripts;
using Assets._Scripts.Data;
using Assets._Scripts.Items;
using Assets._Scripts.UI.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseVisualizer : MonoBehaviour
{
    [SerializeField] private ImageItemUI _imageItem;
    [SerializeField] private ImageWithTextUI _imageWithTextItem;
    [SerializeField] private TextItemUI _textItem;
    [SerializeField] private TwoImagesItemUI _twoImagesItem;
    [SerializeField] private TwoTextItemUI _twoTextItem;
    [SerializeField] private VirtualCurrencyItemUI _virtualCurrencyItem;
    [SerializeField] private Transform _content;
    [SerializeField] private TransactionController _transController;
    [SerializeField] private WarningWindow _warningWindow;
    private List<BaseItemUI> _itemsUIList;
    private List<int> _playerItems;
    private BaseItemUI _selectedItem;
    void Start()
    {
        _warningWindow.onBuyButtonClicked += BuyItem;
        var itemsList = ItemsDatabase.LoadItemsList();
        _itemsUIList = new List<BaseItemUI>();
        _playerItems = ItemsDatabase.PlayerLoadItemsList();
        int index = 1;
        for (int i=0;i<itemsList.Count;i++)
        {
            if (!_playerItems.Contains(itemsList[i].Id))
            {
                BaseItemUI baseItem = null;
                switch (itemsList[i].Suggestion)
                {
                    case TypeSuggestion.Image: baseItem = Instantiate(_imageItem, _content); break;
                    case TypeSuggestion.ImageWithText: baseItem = Instantiate(_imageWithTextItem, _content); break;
                    case TypeSuggestion.Text: baseItem = Instantiate(_textItem, _content); break;
                    case TypeSuggestion.TwoTexts: baseItem = Instantiate(_twoTextItem, _content); break;
                    case TypeSuggestion.VirtualCurrency: baseItem = Instantiate(_virtualCurrencyItem, _content); break;
                    case TypeSuggestion.TwoImages: baseItem = Instantiate(_twoImagesItem, _content); break;
                }
                if (i == 0)
                {
                    _selectedItem = baseItem;
                    baseItem.SelectItem(true);
                }
                baseItem.onButtonClick += ChangeSelection;
                baseItem.Initialize(itemsList[i], index++);
                _itemsUIList.Add(baseItem);
            }
        }
    }

    private void ChangeSelection(BaseItemUI item)
    {
        _selectedItem?.SelectItem(false);
        _selectedItem = item;
    }
    
    public void OnButtonClick()
    {
        if (_selectedItem ==null)
        {
            return;
        }
        var price = Convert.ToInt32(_selectedItem.Item.Price);
        if (price == 0)
        {
            BuyItem();
            return;
        }
        if (_transController.CheckSufficiencyMoney(price))
        {
            _warningWindow.ShowConfirmMessage();
        }
        else
        {
            _warningWindow.ShowWarningMessage();
        }
    }

    private void BuyItem()
    {
        if (_transController.TryBuyItem(_selectedItem.Item))
        {
            _playerItems.Add(_selectedItem.Item.Id);
            Destroy(_selectedItem.gameObject);
            _selectedItem = null;
            ItemsDatabase.PlayerSaveItemsList(_playerItems);
            int index = 1;
            foreach (var item in _itemsUIList)
            {
                if (!_playerItems.Contains(item.Item.Id))
                {
                    item.SetIndex(index++);
                }
            }
        }
    }
    private void OnDestroy()
    {
        _warningWindow.onBuyButtonClicked -= BuyItem;
        foreach (var item in _itemsUIList)
        {
            item.onButtonClick-= ChangeSelection;
        }
    }
}
