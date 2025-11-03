using System;
using System.Collections.Generic;

namespace GameOOP
{
    // Base class (Object)
    public class GameObject
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }

        public GameObject(int x, int y, int health, int speed)
        {
            PositionX = x;
            PositionY = y;
            Health = health;
            Speed = speed;
        }

        public virtual void Move(int dx, int dy)
        {
            PositionX += dx * Speed;
            PositionY += dy * Speed;
            Console.WriteLine($"{this.GetType().Name} moved to ({PositionX}, {PositionY})");
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{this.GetType().Name} took {amount} damage. Health = {Health}");
        }

        public virtual void Draw()
        {
            Console.WriteLine($"{this.GetType().Name} is drawn at ({PositionX}, {PositionY})");
        }
    }

    // Derived class Player
    public class Player : GameObject
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<string> Inventory { get; set; }

        public Player(string name, int x, int y, int health, int speed)
            : base(x, y, health, speed)
        {
            Name = name;
            Score = 0;
            Inventory = new List<string>();
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"{Name} attacks {enemy.Type}!");
            enemy.TakeDamage(10);
            Score += 10;
        }

        public void CollectItem(string item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{Name} collected: {item}");
        }

        public void LevelUp()
        {
            Score += 50;
            Health += 20;
            Console.WriteLine($"{Name} leveled up! Score = {Score}, Health = {Health}");
        }
    }

    // Derived class Enemy
    public class Enemy : GameObject
    {
        public string Type { get; set; }
        public int Damage { get; set; }
        public int Aggressiveness { get; set; }

        public Enemy(string type, int x, int y, int health, int speed, int damage, int aggressiveness)
            : base(x, y, health, speed)
        {
            Type = type;
            Damage = damage;
            Aggressiveness = aggressiveness;
        }

        public void AttackPlayer(Player player)
        {
            Console.WriteLine($"{Type} attacks {player.Name}!");
            player.TakeDamage(Damage);
        }

        public void Patrol()
        {
            Console.WriteLine($"{Type} is patrolling...");
            Move(1, 0);
        }

        public void Die()
        {
            Console.WriteLine($"{Type} has been defeated!");
        }
    }

    // Test Program
    public class Program
    {
        public static void Main(string[] args)
        {
            Player player = new Player("Hero", 0, 0, 100, 2);
            Enemy enemy = new Enemy("Goblin", 5, 5, 50, 1, 8, 3);

            player.Draw();
            enemy.Draw();

            player.Move(1, 1);
            enemy.Patrol();

            player.Attack(enemy);
            enemy.AttackPlayer(player);

            player.CollectItem("Sword");
            player.LevelUp();

            Console.WriteLine("\n--- INVENTORY ---");
            foreach (var item in player.Inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}


/*
1. Class chính và quan hệ
Class Object (cha / base class)

Thuộc tính (Attributes):

PositionX, PositionY

Health

Speed

Phương thức (Methods):

Move()

TakeDamage()

Draw()

Class Player (kế thừa từ Object)

Thuộc tính riêng:

Name

Score

Inventory (danh sách vật phẩm)

Phương thức riêng:

Attack(Enemy enemy)

CollectItem(string item)

LevelUp()

Class Enemy (kế thừa từ Object)

Thuộc tính riêng:

Type

Damage

Aggressiveness

Phương thức riêng:

AttackPlayer(Player player)

Patrol()

Die()

⚙️2. Quan hệ giữa các class
Quan hệ	Mô tả
Kế thừa (Inheritance)	Player : Object, Enemy : Object
Tương tác (Interaction)	Player ↔ Enemy (tấn công qua lại)
Sở hữu (Has-a)	Player có Inventory chứa các Object hoặc item
Đa hình (Polymorphism)	Move() và TakeDamage() được override hoặc dùng khác nhau
 3. Test Case cần kiểm tra
Mục tiêu	Mô tả
Kiểm tra kế thừa	Player và Enemy có thể dùng Move() và TakeDamage()
Kiểm tra tấn công	Player.Attack(enemy) và Enemy.AttackPlayer(player)
Kiểm tra đa hình	Gọi Move() cho cả hai đối tượng xem hoạt động khác nhau
Kiểm tra hành vi	Sau khi CollectItem(), kiểm tra Inventory
Kiểm tra máu giảm	Sau khi TakeDamage(), máu có giảm đúng không?

*/