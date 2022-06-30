using Assets._Scripts.Items;
using Assets._Scripts.UI.Items;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Scripts
{
    public class TransactionController:MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _moneyText;
        private int _money;
        public int Money => _money;

        private void Awake()
        {
            _moneyText.text = 0 + BaseItemUI.Currency;
        }
        
        public bool CheckSufficiencyMoney(int price)
        {
            return _money >= price;
        }

        public bool TryBuyItem(BaseItem baseItem)
        {
            int price = Convert.ToInt32(baseItem.Price);
            if (price <= Money)
            {
                _money -= price;
                var currencyItem = baseItem as VirtualCurrencyItem;
                if (currencyItem !=null)
                {
                    _money += currencyItem.GetMoney();                  
                }
                _moneyText.text = _money.ToString() + BaseItemUI.Currency;
                return true;
            }
            return false;
        }
    }
}
