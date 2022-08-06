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
            entity.OnAttack();
            float damage = entity.Damage;
            if (KritChance((int)entity.KritChance))
            {
               damage *= 2;
            }
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
               entity.AttackPoint, entity.AttackRange, 0, entity.OppositeLayer);
            foreach (Collider2D enemy in hitEnemies)
            {
               var enemyDamageable = enemy.GetComponent<IDamageable>();
               if (enemyDamageable != null)
               {
                  TakeDamage((int)damage, enemyDamageable);
                  Debug.Log(enemy.name + " was delt " + damage + " damage!");
               }
            }
         }
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

      private static bool KritChance(int chance)
      {
         return UnityEngine.Random.Range(0, 100) < chance;
      }

      public static bool DodgeChance(int chance)
      {
         return UnityEngine.Random.Range(0, 100) < chance;
      }
   }
}