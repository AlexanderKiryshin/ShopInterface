using Assets._Scripts.Data;
using System;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

namespace Assets._Scripts.Items
{
    [Serializable]
    public class ImageWithTextItem:BaseItem, ISerializable
    {
        public string text;
        private Texture2D _image;

        public const string name = "Изображение с описанием";
        public override string Name => name;
        public const TypeSuggestion SuggestionC = TypeSuggestion.ImageWithText;
        public override TypeSuggestion Suggestion => SuggestionC;
        private SerializeTexture serializeTexture = new SerializeTexture();
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

        public ImageWithTextItem(int id)
        {
            Id = id;
        }

        public ImageWithTextItem(SerializationInfo info, StreamingContext context)
        {
            serializeTexture = (SerializeTexture)info.GetValue("serializeTexture", typeof(SerializeTexture));
            _image = new Texture2D(serializeTexture.x, serializeTexture.y);
            ImageConversion.LoadImage(_image, serializeTexture.bytes);
            Id = (int)info.GetValue("id", typeof(int));
            _price = (string)info.GetValue("price", typeof(string));
            text = (string)info.GetValue("text", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("serializeTexture", serializeTexture, typeof(SerializeTexture));
            info.AddValue("price", _price, typeof(string));
            info.AddValue("text", text, typeof(string));
            info.AddValue("id", Id, typeof(int));
        }
        public override void Draw()
        {
            text = EditorGUILayout.TextField("Текст", text);
            Image = (Texture2D)EditorGUILayout.ObjectField("Изображение", Image, typeof(Texture2D), false);
            Price = EditorGUILayout.TextField("Стоимость", Price);
        }
    }
}
