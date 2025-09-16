using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPPlayer : Character
    {
        public Inventory inventory;
        public override void SetUP()
        {
            base.SetUP();
            PrintInfo();
            GetRemainEnergy();
            inventory = GetComponent<Inventory>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseFireStorm();
            }
        }
        public override void Move(Vector2 direction)
        {
            base.Move(direction);
            mapGenerator.MoveEnemies();
        }

        public void UseFireStorm()
        {
            if (inventory.HasItem("FireStorm",1))
            {
                //stundent exercise: use FireStorm to attack 3 lower energy enemies on map
                inventory.UseItem("FireStorm", 1);
                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy1();
                int count = 3;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
                for (int i = 0; i < count; i++)
                {
                    enemies[i].TakeDamage(10);
                }
            }
            else
            {
                Debug.Log("No FireStorm in inventory");
            }
        }
        public OOPEnemy[] SortEnemiesByRemainningEnergy1()
        {
            var enemies = mapGenerator.GetEnemies();
            //stundent exercise: sort enemies by remainning energy
            
            // แบบทฤษฎี
            /*for (int i = 0; i < enemies.Length - 1; i++)
            {
                int minIndex = 1;
                for (int j = i + 1; j < enemies.Length; j++)
                {
                    if (enemies[j].energy < enemies[minIndex].energy)
                    {
                        minIndex = j;
                    }
                }
                // var temp = enemies[i];
                // enemies[i] = enemies[minIndex];
                // enemies[i] = temp;
                (enemies[i], enemies[minIndex]) = (enemies[minIndex], enemies[i]);
            }*/

            // แบบใช้งานจริง
            Array.Sort(enemies, (a,b) => a.energy.CompareTo(b.energy));
            return enemies;
        }

        public OOPEnemy[] SortEnemiesByRemainningEnergy2()
        {
            var enemies = mapGenerator.GetEnemies();
            //stundent exercise: sort enemies by remainning energy

            return enemies;
        }
        public void Attack(OOPEnemy _enemy)
        {
            _enemy.TakeDamage(AttackPoint);
            Debug.Log(_enemy.name + " is energy " + _enemy.energy);
        }
        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }

    }

}