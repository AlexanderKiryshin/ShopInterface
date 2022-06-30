using Assets._Scripts.Items;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Items
{
    public abstract class BaseItemUI:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _indexText;
        [SerializeField] protected TextMeshProUGUI _priceText;
        [SerializeField] private Image background;
        [SerializeField] private Button button;
        [SerializeField] private Color selected;
        [SerializeField] private Color unselected;
         private BaseItem _item;
        public BaseItem Item => _item;
        public const string Free = "FREE";
        public const string Zero = "0";
        public const string Currency = "$";
        public Action<BaseItemUI> onButtonClick; 
        public virtual void Initialize(BaseItem item,int index)
        {
            _item = item;
            _indexText.text = index.ToString();
            SetPrice(item);
            button.onClick.AddListener(OnButtonClick);
        }

        public void SetIndex(int index)
        {
            _indexText.text = index.ToString();
        }

        protected void SetPrice(BaseItem item)
        {
            if (item == null)
                return;
            if (item.Price == Zero)
            {
                _priceText.text = Free;
            }
            else
            {
                _priceText.text = item.Price + Currency;
            }
        }

        public void SelectItem(bool isSelect)
        {
            background.color = isSelect ? selected : unselected;
        }
        private void OnButtonClick()
        {
            SelectItem(true);
            onButtonClick?.Invoke(this);
        }
    }
}
