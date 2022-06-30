using System;
using System.Runtime.Serialization;
using UnityEditor;
using UnityEngine;

namespace Assets._Scripts.Items
{
    [Serializable]
    public class TextItem:BaseItem, ISerializable
    {
        private string _text;
        public string Text => _text;
        public const string name = "Описание";
        public override string Name => name;
        public const TypeSuggestion SuggestionC = TypeSuggestion.Text;
        public override TypeSuggestion Suggestion => SuggestionC;

        public TextItem(int id)
        {
            Id = id;
        }

        public TextItem(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("id", typeof(int));
            _price = (string)info.GetValue("price", typeof(string));
            _text = (string)info.GetValue("_text", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("price", _price, typeof(string));
            info.AddValue("_text", _text, typeof(string));
            info.AddValue("id", Id, typeof(int));
        }
        public override void Draw()
        {
            _text=EditorGUILayout.TextField("Текст", _text);
            Price = EditorGUILayout.TextField("Стоимость", Price);
        }
    }
}
