namespace Assets._Scripts.Utility
{
    using System.IO;
    using UnityEngine;

    public class FileStreamer
    {
        private readonly string _path;

        public FileStreamer()
        {

        }

        public FileStreamer(string path)
        {
            this._path = path;
        }

        public string Read()
        {
            if (!File.Exists(_path))
            {
                return string.Empty;
            }

            StreamReader reader = new StreamReader(_path);
            var data = reader.ReadToEnd();
            reader.Close();

            return data;
        }

        public string ReadFromResources()
        {
            var textAsset = Resources.Load<TextAsset>(_path);
            if (textAsset == null)
                return string.Empty;
            var data = textAsset.text;
            Resources.UnloadAsset(textAsset);

            return data;
        }

        public string ReadFromResources(string path)
        {           
            var textAsset = Resources.Load<TextAsset>(path);
            if (textAsset == null)
                return string.Empty;
            var data = textAsset.text;
            Resources.UnloadAsset(textAsset);
            return data;
        }

        public void Save(string data)
        {
            StreamWriter writer = new StreamWriter(_path);
            writer.WriteLine(data);         
            writer.Close();
        }
        //
    }
}
