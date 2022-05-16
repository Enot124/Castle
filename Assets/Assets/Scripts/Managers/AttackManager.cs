using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.Managers
{
   public class AttackManager
   {
      public static void Attack(ICanAttack entity)
      {
         if (entity.IsCanAttack)
         {
            float damage = entity.Damage;
            if (KritChance((int)entity.KritChance))
            {
               damage *= 2;
            }
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(entity.AttackPoint, entity.AttackRange, entity.OppositeLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
               enemy.GetComponent<Entity<Enemy>>().TakeDamage(damage, enemy);
               Debug.Log(enemy.name + " was delt " + damage + " damage!");
            }
         }
         /*
   if (_timer <= 0)
   {
      _animator.SetTrigger("Attack");
      _timer = 1 / _attackSpeed;
   }
}
public void OnAttack()
{
   int damage = (int)_attack;
   if (KritChance((int)_kritChance))
   {
      damage *= 2;
   }
   Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, enemyLayer);
   foreach (Collider2D enemy in hitEnemies)
   {
      enemy.GetComponent<Entity<Hero>>().TakeDamage(damage);
      Debug.Log(enemy.name + " was delt " + damage + " damage!");
   }
}*/
      }


      private static bool KritChance(int chance)
      {
         return Random.Range(0, 100) < chance;
      }

      public static bool DodgeChance(int chance)
      {
         return Random.Range(0, 100) < chance;
      }

      public static void TakeDamage(int damage, IDamageable entity)
      {
         if (!DodgeChance((int)entity.DodgeChance))
         {
            damage -= (int)(damage * entity.Defence);
            entity.CurrentHealth -= damage;
            if (entity.CurrentHealth <= 0)
            {
               entity.CurrentHealth = 0;
               //Die();
            }
         }

      }
   }
}