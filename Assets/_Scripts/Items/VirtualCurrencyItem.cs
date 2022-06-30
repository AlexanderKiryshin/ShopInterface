using System;
using UnityEditor;
using UnityEngine;

namespace Assets._Scripts.Items
{
    [Serializable]
    public class VirtualCurrencyItem:BaseItem
    {
        private string _currencyText;
        public string CurrencyText
        {
            get { return _currencyText; }
            set
            {
                try
                {
                    _currencyText = value;
                }
                catch (FormatException e)
                {
                    Debug.LogError("Поле принимает только числовой формат");
                    _currencyText = "0";
                }
            }
        }
        public const string name = "Виртуальная валюта";
        public override string Name => name;
        public const TypeSuggestion SuggestionC = TypeSuggestion.VirtualCurrency;
        public override TypeSuggestion Suggestion => SuggestionC;

        public VirtualCurrencyItem(int id)
        {
            Id = id;
        }

        public int GetMoney()
        {
            return Convert.ToInt32(CurrencyText);
        }

        public override void Draw()
        {
            CurrencyText = EditorGUILayout.TextField("Валюта", CurrencyText);
        }
    }
}
