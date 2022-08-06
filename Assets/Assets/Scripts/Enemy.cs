using UnityEngine;
using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;
using System;

public class Enemy : Entity<Enemy>,
   ICanMove,
   IDamageable,
   ICanAttack
{
   private Animator _animator;

   #region ICanMove
   public float Speed { get => 3.0f; }
   private Rigidbody2D _rigidBody;
   public Rigidbody2D Rigidbody2D { get => _rigidBody; set => _rigidBody = value; }
   public Vector2 MoveDirection { get; set; }
   #endregion ICanMove

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
   public float Defence => 0;
   public float DodgeChance => 0;
   public float _currentHP = 100;
   public float _maxHP = 100;
   public float CurrentHealth { get => _currentHP; set => _currentHP = value; }
   public float MaxHealth { get => _maxHP; set => _maxHP = value; }
   #endregion IDamageable
   void Awake()
   {
      _rigidBody = GetComponent<Rigidbody2D>();
   }
}