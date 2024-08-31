using CombatPad.Models;
using CombatPad.Repositories.Interfaces;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CombatPad.Repositories
{
    public class FileRepository : IRepository
    {
        public DocumentDto Load(string filePath)
        {
            var content = File.ReadAllText(filePath);
            
            return JsonSerializer.Deserialize<DocumentDto>(content);
        }

        public void Save(DocumentDto document, string filePath)
        {
            var options = new JsonSerializerOptions 
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            var content = JsonSerializer.Serialize(document, options);
            File.WriteAllText(filePath, content);
        }
    }
}
