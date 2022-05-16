using UnityEngine;
using Assembly_CSharp.Assets.Assets.Scripts.AnimationManagers;

public abstract class Entity<T> : MonoBehaviour
   where T : Component
{
   public AnimationManagerBase<T> AnimationManager { get; set; }
   public string _name;
   public Vector2 _attackRange;
   public LayerMask _layer;
   public int _expierence;
   public int _level;
   public float _speed = 3f;

   #region  Attributes
   public int _strange = 1;
   public int _agility = 1;
   public int _endurance = 1;
   public int _luck = 1;
   public int _magic = 1;
   #endregion Attributes

   #region  Stats
   public float _attackSpeed;
   public float _maxHP;
   public float _ownHealth;
   public float _currentHP;
   public float _attack;
   public float _kritChance;
   public float _dodgeChance;
   public float _defence;
   #endregion Stats


   #region  Constants
   private const float factorAttack = 2;
   private const float factorHealth = 12;
   private const float factorAttackSpeed = 0.0067f;
   private const float factorKritChance = 0.5f;
   private const float factorDodgeChance = 0.2f;
   #endregion Constants

   public void CalculateStats()
   {
      _maxHP = _ownHealth + _endurance * factorHealth;
      _attack = _strange * factorAttack;
      _attackSpeed = 0.5f + _agility * factorAttackSpeed;
      _kritChance = _luck * factorKritChance;
      _dodgeChance = _agility * factorDodgeChance;
   }

   virtual protected void Die()
   {
      //Смерть челика
   }
}



