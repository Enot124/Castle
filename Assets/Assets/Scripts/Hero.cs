using UnityEngine;
using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;
using System;

public class Hero : Entity<Hero>,
   ICanMove,
   ICanAttack,
   IDamageable,
   IHaveAttr,
   IHaveBaseInfo
{

   #region ICanAttack
   [SerializeField] private Transform attackPoint;
   private DateTime LastAttackDT = DateTime.UtcNow;
   public float Damage { get => 10f; }
   public float KritChance { get => 0.1f; }
   public float AttackSpeed { get => 1f; }
   public bool IsCanAttack
   {
      get
      {
         return DateTime.UtcNow > LastAttackDT + TimeSpan.FromSeconds(1 / AttackSpeed);
      }
   }
   public Vector2 AttackPoint { get => attackPoint.position; }
   public Vector2 _attackRange;
   public Vector2 AttackRange { get => _attackRange; }
   public LayerMask OppositeLayer { get => _opossiteLayer; }
   public LayerMask _opossiteLayer;
   public event EventHandler Attacking;
   public void OnAttack()
   {
      Attacking?.Invoke(null, null);
      LastAttackDT = DateTime.UtcNow;
   }
   #endregion ICanAttack

   #region IDamageable      
   public float Defence { get => 0.1f; }
   public float DodgeChance { get => 0.1f; }
   public float _currentHP = 100;
   public float _maxHP = 100;
   public float CurrentHealth { get => _currentHP; set => _currentHP = value; }
   public float MaxHealth { get => _maxHP; set => _maxHP = value; }

   #endregion IDamageable  

   #region ICanMove
   public float Speed { get => 3.0f; }
   private Rigidbody2D _rigidBody;
   public Rigidbody2D Rigidbody2D { get => _rigidBody; set => _rigidBody = value; }
   public Vector2 MoveDirection { get; set; }
   #endregion ICanMove

   #region IHaveAttr
   private int _freeattr = 6;
   private int _strange = 1;
   private int _agility = 1;
   private int _endurance = 1;
   private int _luck = 1;
   public int FreeAttr { get => _freeattr; set => _freeattr = value; }
   public int Strange { get => _strange; set => _strange = value; }
   public int Agility { get => _agility; set => _agility = value; }
   public int Endurance { get => _endurance; set => _endurance = value; }
   public int Luck { get => _luck; set => _luck = value; }
   #endregion IHaveAttr

   #region IHaveBaseInfo
   public string Name { get => "Efreytor"; }
   public int Level { get => 1; set => value++; }
   public int _experience = 100;
   public int _maxExpierence = 200;
   public int Expierence { get => _experience; set => _experience = value; }
   public int MaxExpierence { get => _maxExpierence; set => _maxExpierence = value; }
   #endregion IHaveBaseInfo

   void Awake()
   {
      _rigidBody = GetComponent<Rigidbody2D>();
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireCube(attackPoint.position, AttackRange);
   }
}