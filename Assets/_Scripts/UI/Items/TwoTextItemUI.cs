using Assets._Scripts.Items;
using TMPro;
using UnityEngine;

namespace Assets._Scripts.UI.Items
{
    public class TwoTextItemUI:BaseItemUI
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TextMeshProUGUI _secondText;       
        public override void Initialize(BaseItem item, int index)
        {
            base.Initialize(item, index);
            var itm = item as TwoTextItem;
            if (itm != null)
            {
                _text.text = itm.Text;
                _secondText.text = itm.SecondText;
            }
        }
    }
}
