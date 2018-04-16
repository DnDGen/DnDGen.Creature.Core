namespace DnDGen.Creature.Core.Verifiers
{
    public interface ICreatureVerifier
    {
        bool VerifyCompatibility(string creatureName, string templateName);
    }
}