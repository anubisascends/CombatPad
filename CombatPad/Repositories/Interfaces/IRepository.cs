using CombatPad.Models;

namespace CombatPad.Repositories.Interfaces
{
    public interface IRepository
    {
        void Save(DocumentDto document, string filePath);

        DocumentDto Load(string filePath);
    }
}
