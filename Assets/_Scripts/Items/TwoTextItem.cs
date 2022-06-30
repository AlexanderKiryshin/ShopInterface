using System;
using System.Runtime.Serialization;
using UnityEditor;

namespace Assets._Scripts.Items
{
    [Serializable]
    public class TwoTextItem:BaseItem, ISerializable
    {
        private string _text;
       
        private string _secondText;
        public string Text => _text;
        public string SecondText => _secondText;
        public const string name = "Два описания";
        public override string Name => name;
        public const TypeSuggestion SuggestionC = TypeSuggestion.TwoTexts;
        public override TypeSuggestion Suggestion => SuggestionC;

        public TwoTextItem(int id)
        {
            Id = id;
        }
        public TwoTextItem(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("id", typeof(int));
            _price = (string)info.GetValue("price", typeof(string));
            _text = (string)info.GetValue("_text", typeof(string));
            _secondText = (string)info.GetValue("_secondText", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("price", _price, typeof(string));
            info.AddValue("_text", _text, typeof(string));
            info.AddValue("_secondText", _secondText, typeof(string));
            info.AddValue("id", Id, typeof(int));
        }
        public override void Draw()
        {
            _text = EditorGUILayout.TextField("Текст", _text);
            _secondText = EditorGUILayout.TextField("Текст", _secondText);
            Price = EditorGUILayout.TextField("Стоимость", Price);
        }
    }
}
