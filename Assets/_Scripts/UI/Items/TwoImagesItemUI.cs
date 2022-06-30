using Assets._Scripts.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts.UI.Items
{
    public class TwoImagesItemUI:BaseItemUI
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _secondImage;

        public override void Initialize(BaseItem item, int index)
        {
            base.Initialize(item, index);
            var itm = item as TwoImagesItem;
            if (itm != null)
            {
                _image.sprite = Sprite.Create(itm.Image, new Rect(0.0f, 0.0f, itm.Image.width, itm.Image.height), Vector2.one);
                _secondImage.sprite = Sprite.Create(itm.SecondImage, new Rect(0.0f, 0.0f, itm.SecondImage.width, itm.SecondImage.height), Vector2.one);
            }
        }
    }
}
