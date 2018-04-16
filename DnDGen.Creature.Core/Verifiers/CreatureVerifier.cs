using DnDGen.Creature.Core.Creatures;
using DnDGen.Creature.Core.Tables;
using DnDGen.Core.Selectors.Collections;
using System.Linq;

namespace DnDGen.Creature.Core.Verifiers
{
    internal class CreatureVerifier : ICreatureVerifier
    {
        private readonly ICollectionSelector collectionsSelector;

        public CreatureVerifier(ICollectionSelector collectionsSelector)
        {
            this.collectionsSelector = collectionsSelector;
        }

        public bool VerifyCompatibility(string creatureName, string templateName)
        {
            if (templateName == CreatureConstants.Templates.None)
                return true;

            var templateCreatures = collectionsSelector.Explode(TableNameConstants.Set.Collection.CreatureGroups, templateName);
            return templateCreatures.Contains(creatureName);
        }
    }
}