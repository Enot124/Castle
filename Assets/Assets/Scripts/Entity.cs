using UnityEngine;

public class Entity : MonoBehaviour
{
   public string _name;
   public float _attackRange = 0.5f;
   public int _expierence;
   public int _level;
   public float _timer;
   public bool _isAttack;
   //Атрибуты персонажа
   public int _strange = 1;
   public int _agility = 1;
   public int _endurance = 1;
   public int _luck = 1;
   public int _magic = 1;

   //Статы персонажа
   public float _attackSpeed;
   public float _maxHP;
   public float _ownHealth;
   public float _currentHP;
   public float _attack;
   public float _kritChance;
   public float _dodgeChance;
   public float _defence;

   public void CalculateStats()
   {
      _maxHP = _ownHealth + _endurance * 12;
      _attack = _strange * 2;
      _attackSpeed = 0.5f + _agility * 0.0067f;
      _kritChance = _luck * 0.5f;
      _dodgeChance = _agility * 0.2f;
   }

   virtual protected void Attack()
   {
      //Анимация удара, поиск коллизий, удар
   }

   public void TakeDamage(int damage)
   {
      //CalculateStats();
      if (!DodgeChance((int)_dodgeChance))
      {
         _currentHP -= damage - damage * _defence;
         if (_currentHP <= 0)
         {
            _currentHP = 0;
            Die();
         }
      }
   }

   public bool KritChance(int chance)
   {
      return Random.Range(0, 100) < chance;
   }

   public bool DodgeChance(int chance)
   {
      return Random.Range(0, 100) < chance;
   }

   virtual protected void Die()
   {
      //Смерть челика
   }
}



