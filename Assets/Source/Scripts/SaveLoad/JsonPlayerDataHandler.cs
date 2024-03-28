using System.IO;
using Source.Scripts.Reactive;
using UnityEngine;

namespace Source.Scripts.SaveLoad
{
    public class JsonPlayerDataHandler : IPlayerDataHandler<PlayerData>
    {
        public ReactiveVariable<PlayerData> Data { get; }

        private readonly string _saveFilePath; 
        
        public JsonPlayerDataHandler()
        {
            _saveFilePath = Application.persistentDataPath + '/' + FilePaths.PlayerData + ".json";
            Data = new ReactiveVariable<PlayerData>(Load());
        }
        
        public PlayerData Load()
        {
            if (File.Exists(_saveFilePath))
            {
                string loadedPlayerData = File.ReadAllText(_saveFilePath);
                return JsonUtility.FromJson<PlayerData>(loadedPlayerData);
            }
            
            return new PlayerData();
        }

        public void Save()
        {
            File.WriteAllText(_saveFilePath, JsonUtility.ToJson(Data.Value));
        }
    }
}