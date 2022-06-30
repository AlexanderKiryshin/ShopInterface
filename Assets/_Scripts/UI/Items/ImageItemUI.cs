using Assets._Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Items
{
    public class ImageItemUI:BaseItemUI
    {
        [SerializeField] private Image _image;
        public override void Initialize(BaseItem item, int index)
        {
            base.Initialize(item, index);
            var itm = item as ImageItem;
            if (itm!=null)
            {
                if (itm.Image != null)
                {
                    _image.sprite = Sprite.Create(itm.Image, new Rect(0.0f, 0.0f, itm.Image.width, itm.Image.height), Vector2.one);
                }             
            }
        }
    }
}
