using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceHero.Models
{
    public class Enemy : BaseModel
    {
        public void DefineHp(int heroHp, int heroLevel)
        {
            Random roll = new Random();
            int dice = roll.Next(1, 7);

            if (heroLevel <= 5)
            {
                if (dice < 4)
                {
                    this.Hp = (heroHp / 3) * 2;
                }
                else if (dice > 3 && dice < 6)
                {
                    this.Hp = heroHp;
                }
                else
                {
                    this.Hp = (heroHp / 3) + heroHp;
                }
            }
        }
    }
}
