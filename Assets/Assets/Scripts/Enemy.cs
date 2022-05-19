using UnityEngine;
using TMPro;
using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;

public class Enemy : Entity<Enemy>,
   IDamageable
{
    private Animator _animator;
    private bool _isDied = false;
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

    public float CurrentHealth { get => _currentHP; set => _currentHP = value; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        CalculateStats();
        _currentHP = _maxHP;
    }

    private void Update()
    {
        /*if (!_isDied)
        {
           float distanceToPlayer = Vector2.Distance(attackPoint.position, Hero.position);
           if (distanceToPlayer <= _attackRange)
           {
              _isAttack = true;
              //Attack();
           }
           else
           {
              if (_isAttack)
                 Invoke("IsNoAttack", 4f);
           }
        }*/
    }
    private void FixedUpdate()
    {
        /*if (!_isDied)
        {
           if (_timer > 0)
              _timer -= Time.deltaTime;
           Idle();

           if (_currentHP < _maxHP && !_isAttack)
           {
              _currentHP += _maxHP * 0.0003f;
           }
        }*/
    }
    /*protected void Attack()
    {
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
    }

    protected override void Die()
    {
        _isDied = true;
        _animator.SetTrigger("Die");
    }


    private void Idle()
    {
        _moveState = EnemyState.Idle;
    }
    /*private void IsNoAttack()
    {
       _isAttack = false;
    }*/
}

enum EnemyState
{
    Idle,
    Walk
}
