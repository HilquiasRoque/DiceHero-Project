using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceHero.Models
{
    public class BaseModel
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public bool Alive = true;

        public void AttackInfo()
        {
            Console.WriteLine("    | 1-2 = miss! (0 dmg)   |");
            Console.WriteLine("    | 3-5 = hit!  (1-2 dmg) |");
            Console.WriteLine("    | 6   = crit! (3-4 dmg) |");
            Console.WriteLine();
        }
        public int Attack()
        {
            Random roll = new Random();
            int dice = roll.Next(1, 7);
            int dmg = 0;

            if (dice < 3)
            {
                Console.WriteLine($"O dado caiu em ({dice}). {Name} errou o ataque!");
                return dmg;
            }
            else if (dice > 2 && dice < 6)
            {
                dmg = roll.Next(1, 3);
                Console.WriteLine($"O dado caiu em ({dice}). {Name} acertou o ataque!");
                return dmg;
            }
            else
            {
                dmg = roll.Next(3, 5);
                Console.WriteLine($"O dado caiu em ({dice}). {Name} fez um ataque crítico!!!");
                return dmg;
            }
        }
        public bool Injury(int dmgReceived)
        {
            this.Hp -= dmgReceived;
            Console.WriteLine($"{Name} recebeu {dmgReceived} de dano.");

            if (Hp <= 0)
            {
                return Alive = false;
            }
            return Alive;
        }
    }
}
