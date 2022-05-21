using UnityEngine;
using TMPro;
using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;

public class Enemy : Entity<Enemy>,
   IDamageable
{
   private Animator _animator;
   [SerializeField] private Transform attackPoint;
   [SerializeField] private LayerMask enemyLayer;
   public Transform Hero;
   private EnemyState _moveState
   {
      get { return (EnemyState)_animator.GetInteger("state"); }
      set { _animator.SetInteger("state", (int)value); }
   }
   public float Defence => 0;
   public float DodgeChance => 0;
   public float _currentHP = 100;
   public float _maxHP = 100;
   public float CurrentHealth { get => _currentHP; set => _currentHP = value; }
   public float MaxHealth { get => _maxHP; set => _maxHP = value; }
   private void Awake()
   {

   }


   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      //Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
   }
}

enum EnemyState
{
   Idle,
   Walk
}
