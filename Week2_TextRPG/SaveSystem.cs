// SaveSystem.cs
using System.Text.Json;
using Week2_TextRPG.Data;
using Week2_TextRPG.PlayerSystem;

namespace Week2_TextRPG.Core
{
    internal static class SaveSystem
    {
        private static string savePath = "save.json";

        public static void Save(Player player, List<Item> items)
        {
            SaveData data = new SaveData(player, items);
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(savePath, json);
            Console.WriteLine("저장이 완료되었습니다.");
        }

        public static SaveData Load()
        {
            if (!File.Exists(savePath)) return null;

            string json = File.ReadAllText(savePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }
    }
}
