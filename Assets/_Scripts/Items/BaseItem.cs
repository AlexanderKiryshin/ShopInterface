using System;
using UnityEngine;

namespace Assets._Scripts.Items
{
    [Serializable]
    public abstract class BaseItem
    {
        public int Id { get; protected set; }
        public abstract string Name { get; }
        public abstract TypeSuggestion Suggestion { get; }
        protected string _price="0";
        
        public string Price
        {
            get { return _price; }
            set {
                try
                {
                    var test = Convert.ToInt32(value);
                    _price = value;
                }
                catch(FormatException e)
                {
                    Debug.LogError("Поле принимает только числовой формат");
                    _price = "0";
                }
            }
        } 
        public abstract void Draw();
    }
}
