using Rocket.API.Collections;
using Rocket.Core.Plugins;

namespace ExeRestrctor
{
    public class Plugin : RocketPlugin<Config>
    {
        public override TranslationList DefaultTranslations => new TranslationList
        {
          { "cant_equipment", "Вы можете взять этот предмет только при надетом сете {0}" },
          { "cant_cloth", "Вы можете надеть эту одежду только при надетом сете {0}" }
        };


        public static Plugin Instance { get; set; }

        protected override void Load()
        {
            Instance = this;
        }

        protected override void Unload()
        {
            
        }
    }
}
