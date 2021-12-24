using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceHero.Models
{
    public class Hero : BaseModel
    {
        public string Job = "Aventureiro";
        public int Level = 1;

        public void LevelUp()
        {
            Level++;
            this.Hp = ((Level - 1) * 2) + 10;
        }

    }
}
