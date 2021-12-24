using DiceHero.Models;
using System;

namespace DiceHero
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|            BEM-VINDO ao DICE HERO!            |");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("       Escolha um nome para o seu herói!");
            string newname = Console.ReadLine();

            hero.Name = newname;
            hero.Hp = 10;

            while (hero.Alive)
            {
                Enemy enemy = new Enemy();
                enemy.Name = "Goblim";
                enemy.DefineHp(hero.Hp, hero.Level);

                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"{hero.Name} está começando uma nova aventura!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>>Pressione uma tecla para continuar.");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Um {enemy.Name} apareceu! Hora de lutar!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>>Pressione uma tecla para continuar.");
                Console.ReadKey();

                while (enemy.Alive)
                {
                    Console.Clear();
                    Console.WriteLine("          É SUA VEZ DE ATACAR!");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"{hero.Name} (HP {hero.Hp})   o=[===>   {enemy.Name} (HP {enemy.Hp})");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(">>>Role os dados! (pressione uma tecla)");
                    Console.WriteLine();
                    Console.ReadKey();

                    int damage = hero.Attack();
                    Console.ReadKey();
                    enemy.Injury(damage);
                    Console.ReadKey();

                    if (enemy.Alive == false)
                    {
                        hero.LevelUp();
                        Console.Clear();
                        Console.WriteLine($"*PARABÉNS, VOCÊ DERROTOU O {enemy.Name}!*");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($" Seu nível aumentou! {hero.Level - 1} -> {hero.Level}");
                        Console.WriteLine($" Seu HP aumentou! {hero.Hp - 2} -> {hero.Hp}");
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine(">>>Pressione uma tecla para continuar");
                        Console.ReadKey();
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("         O INIMIGO VAI ATACAR!");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine($"{hero.Name} (HP {hero.Hp})   <===]=o   {enemy.Name} (HP {enemy.Hp})");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(">>>Pressione uma tecla para continuar.");
                    Console.WriteLine();
                    Console.ReadKey();

                    int damage2 = enemy.Attack();
                    Console.ReadKey();
                    hero.Injury(damage2);
                    Console.ReadKey();

                    if (hero.Alive == false)
                    {
                        break;
                    }
                }

            }

            if (hero.Alive == false)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"{hero.Name} lutou bravamente, mas morreu!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("         >>> FIM DE JOGO! <<<");
            }
        }
    }
}
