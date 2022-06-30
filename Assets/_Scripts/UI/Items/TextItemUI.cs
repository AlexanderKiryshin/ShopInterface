using Assets._Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Items
{
    public class TextItemUI:BaseItemUI
    {
        [SerializeField] private TextMeshProUGUI _text;

        public override void Initialize(BaseItem item, int index)
        {
            base.Initialize(item, index);
            var itm = item as TextItem;
            if (itm != null)
            {
                _text.text = itm.Text;
            }
        }
    }
}
