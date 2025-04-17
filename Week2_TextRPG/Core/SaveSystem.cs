// SaveSystem.cs
using System.Text.Json;
using Week2_TextRPG.Data;
using Week2_TextRPG.PlayerSystem;
using Newtonsoft.Json;

namespace Week2_TextRPG.Core
{
    public static class SaveSystem
    {
        private static string savePath = "save.json";

        public static void Save(Player player)
        {
            var data = new SaveData(player);
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("save.json", json);
            Console.WriteLine("저장되었습니다.");
        }

        public static SaveData Load()
        {
            if (!File.Exists("save.json"))
            {
                Console.WriteLine("저장 파일이 없습니다.");
                return null;
            }

            string json = File.ReadAllText("save.json");
            var data = JsonConvert.DeserializeObject<SaveData>(json);
            Console.WriteLine("저장 데이터를 불러왔습니다.");
            return data;
        }
    }
}
