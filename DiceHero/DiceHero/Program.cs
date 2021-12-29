using DiceHero.Models;
using System;

namespace DiceHero
{
    public class Program
    {
        static void Main(string[] args)
        {
            static string StartGame()
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("|            BEM-VINDO ao DICE HERO!            |");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("       Escolha um nome para o seu herói!");
                string nome = Console.ReadLine().ToString();
                return nome;
            }

            static void EndGame(string heroName)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"{heroName} lutou bravamente, mas morreu!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("         >>> FIM DE JOGO! <<<");
            }

            static void StartNewAdv(string name)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"{name} está começando uma nova aventura!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>>Pressione uma tecla para continuar.");
                Console.ReadKey();
            }

            static void ShowNewEnemy(string name)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($" Um {name} apareceu! Hora de lutar!");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>>Pressione uma tecla para continuar.");
                Console.ReadKey();
            }

            static void HeroTurn(string hName, int hHp, string eName, int eHp)
            {
                Console.Clear();
                Console.WriteLine("          É SUA VEZ DE ATACAR!");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{hName} (HP {hHp})   o=[===>   {eName} (HP {eHp})");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(">>>Role os dados! (pressione uma tecla)");
            }

            static void EnemyTurn(string hName, int hHp, string eName, int eHp)
            {
                Console.Clear();
                Console.WriteLine("         O INIMIGO VAI ATACAR!");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"{hName} (HP {hHp})   <===]=o   {eName} (HP {eHp})");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(">>>Pressione uma tecla para continuar.");
            }

            static void LevelingMsg(string name, int hp, int level)
            {
                Console.Clear();
                Console.WriteLine($"*PARABÉNS, VOCÊ DERROTOU O {name}!*");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($" Seu nível aumentou! {level - 1} -> {level}");
                Console.WriteLine($" Seu HP aumentou! {hp - 2} -> {hp}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(">>>Pressione uma tecla para continuar");
                Console.ReadKey();
            }

            ////////////////////////////////////////////////////////////////////////

            var hero = new Hero();

            string newname = StartGame();

            hero.Name = newname;
            hero.Hp = 10;

            while (hero.Alive)
            {
                Enemy enemy = new();
                enemy.DefineHp(hero.Hp, hero.Level);

                StartNewAdv(hero.Name);

                ShowNewEnemy(enemy.Name);

                while (enemy.Alive)
                {
                    HeroTurn(hero.Name, hero.Hp, enemy.Name, enemy.Hp);
                    hero.AttackInfo();
                    Console.WriteLine();
                    Console.ReadKey();

                    int damage = hero.Attack();
                    Console.ReadKey();
                    enemy.Injury(damage);
                    Console.ReadKey();

                    if (enemy.Alive == false)
                    {
                        hero.LevelUp();
                        LevelingMsg(hero.Name, hero.Hp, hero.Level);
                        break;
                    }

                    EnemyTurn(hero.Name, hero.Hp, enemy.Name, enemy.Hp);
                    enemy.AttackInfo();
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
                EndGame(hero.Name);
            }
        }
    }
}
