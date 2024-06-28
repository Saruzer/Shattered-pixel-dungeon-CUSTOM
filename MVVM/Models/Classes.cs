
namespace Shattered_pixel_dungeon_CUSTOM.MVVM.Models
{
    public class Classes
    {
        public List<string> CLASSES;
        public string[] SubCLASSES = {"BERSERKER","GLADIATOR","BATTLEMAGE", "WARLOCK", "ASSASSIN", "FREERUNNER","SNIPER","WARDEN","CHAMPION","MONK"};
        public Classes()
        {
            CLASSES = new List<string>();
            CLASSES.Add("WARRIOR");
            CLASSES.Add("MAGE");
            CLASSES.Add("ROGUE");
            CLASSES.Add("DUELIST");
            CLASSES.Add("HUNTRESS");

        }
    }
   
}
