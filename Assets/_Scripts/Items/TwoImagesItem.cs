
using Assets._Scripts.Data;
using System;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

namespace Assets._Scripts.Items
{
    [Serializable]
    public class TwoImagesItem:BaseItem, ISerializable
    {
        private Texture2D _image;
        private Texture2D _secondImage;
        public const string name = "Два изображения";
        public override string Name => name;
        public const TypeSuggestion SuggestionC = TypeSuggestion.TwoImages;
        public override TypeSuggestion Suggestion => SuggestionC;

        private SerializeTexture serializeTexture = new SerializeTexture();
        private SerializeTexture secondSerializeTexture = new SerializeTexture();
        public Texture2D Image
        {
            get { return _image; }
            set
            {
                _image = value;
                if (_image != null)
                {
                    serializeTexture.x = _image.width;
                    serializeTexture.y = _image.height;
                    serializeTexture.bytes = ImageConversion.EncodeToPNG(_image);

                }
            }
        }
        public Texture2D SecondImage
        {
            get { return _secondImage; }
            set
            {
                _secondImage = value;
                if (_secondImage != null)
                {
                    secondSerializeTexture.x = _secondImage.width;
                    secondSerializeTexture.y = _secondImage.height;
                    secondSerializeTexture.bytes = ImageConversion.EncodeToPNG(_secondImage);

                }
            }
        }
        public TwoImagesItem(int id)
        {
            Id = id;
        }

        public TwoImagesItem(SerializationInfo info, StreamingContext context)
        {
            serializeTexture = (SerializeTexture)info.GetValue("serializeTexture", typeof(SerializeTexture));
            _image = new Texture2D(serializeTexture.x, serializeTexture.y);
            ImageConversion.LoadImage(_image, serializeTexture.bytes);
            secondSerializeTexture = (SerializeTexture)info.GetValue("secondSerializeTexture", typeof(SerializeTexture));
            _secondImage = new Texture2D(secondSerializeTexture.x, secondSerializeTexture.y);
            ImageConversion.LoadImage(_secondImage, secondSerializeTexture.bytes);
            Id = (int)info.GetValue("id", typeof(int));
            _price = (string)info.GetValue("price", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("serializeTexture", serializeTexture, typeof(SerializeTexture));
            info.AddValue("secondSerializeTexture", secondSerializeTexture, typeof(SerializeTexture));
            info.AddValue("price", _price, typeof(string));
            info.AddValue("id", Id, typeof(int));
        }
        public override void Draw()
        {
            Image = (Texture2D)EditorGUILayout.ObjectField("Изображение", Image, typeof(Texture2D), false);
            SecondImage = (Texture2D)EditorGUILayout.ObjectField("Изображение", SecondImage, typeof(Texture2D), false);
            Price = EditorGUILayout.TextField("Стоимость", Price);
        }
    }
}
