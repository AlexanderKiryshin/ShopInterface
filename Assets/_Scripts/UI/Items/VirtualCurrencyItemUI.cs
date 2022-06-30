using Assets._Scripts.Items;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.UI.Items
{
    public class VirtualCurrencyItemUI:BaseItemUI
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public override void Initialize(BaseItem item, int index)
        {
            base.Initialize(item, index);
            var itm = item as VirtualCurrencyItem;
            if (itm != null)
            {
                _text.text = itm.CurrencyText;
            }
        }
    }
}
