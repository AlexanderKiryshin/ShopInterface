using Assets._Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Items
{
    public class ImageWithTextUI:BaseItemUI
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        public override void Initialize(BaseItem item, int index)
        {
            base.Initialize(item, index);
            var itm = item as ImageWithTextItem;
            if (itm != null)
            {
                _image.sprite  = Sprite.Create(itm.Image, new Rect(0.0f, 0.0f, itm.Image.width, itm.Image.height), Vector2.one);
                _text.text = itm.text;
            }
        }
    }
}
