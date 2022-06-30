using Assets._Scripts.Items;
using Assets._Scripts.Utility;
using Assets._Scripts.Utility.Mark4.Utility;
using System;
using System.Collections.Generic;

namespace Assets._Scripts.Data
{
    public static class ItemsDatabase
    {
        private const string ItemsLoadPath = "Data/items_list";
        private const string ItemsSavePath = "Assets/Resources/Data/items_list.json";
        private const string PlayerItemsLoadPath = "Data/player_items_list";
        private const string PlayerItemsSavePath = "Assets/Resources/Data/player_items_list.json";
        public static List<BaseItem> LoadItemsList()
        {
            return Load<BaseItem>(ItemsLoadPath);
        }

        public static List<int> PlayerLoadItemsList()
        {
            return Load<int>(PlayerItemsLoadPath);
        }
        public static void Save(List<BaseItem> items, string path)
        {
            new FileStreamer(path).Save(JsonSerializationHelper.SerializeObject(items, Newtonsoft.Json.Formatting.Indented));
        }
        private static List<T> Load<T>(string path)
        {
            string json = new FileStreamer().ReadFromResources(path);
            var result = JsonSerializationHelper.DeserializeObject<List<T>>(json);
            if (result == null)
            {
                return new List<T>();
            }
            else
            {
                return result;
            }
        }

        public static  void SaveItemsList(List<BaseItem> items)
        {
            new FileStreamer(ItemsSavePath).Save(JsonSerializationHelper.SerializeObject(items, Newtonsoft.Json.Formatting.Indented));
        }

        public static void PlayerSaveItemsList(List<int> items)
        {
            new FileStreamer(PlayerItemsSavePath).Save(JsonSerializationHelper.SerializeObject(items, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
