using UnityEngine;

public class Bot : Entity
{
   private Animator _animator;
   [SerializeField] private Transform attackPoint;
   [SerializeField] private LayerMask enemyLayer;
   public Transform Hero;
   private BotState _moveState
   {
      get { return (BotState)_animator.GetInteger("state"); }
      set { _animator.SetInteger("state", (int)value); }
   }


   private void Awake()
   {
      _animator = GetComponent<Animator>();
      CalculateStats();
   }
   private void FixedUpdate()
   {
      if (_timer > 0)
         _timer -= Time.deltaTime;
      Idle();
      float distanceToPlayer = Vector2.Distance(attackPoint.position, Hero.position);
      if (distanceToPlayer <= _attackRange)
      {
         _isAttack = true;
         Attack();
      }
      else
      {
         if (_isAttack)
            Invoke("IsNoAttack", 4f);
      }
   }
   protected override void Attack()
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
         enemy.GetComponent<Entity>().TakeDamage(damage);
         Debug.Log(enemy.name + " was delt " + damage + " damage!");
      }
   }
   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
   }


   private void Idle()
   {
      _moveState = BotState.Idle;
   }
   private void IsNoAttack()
   {
      _isAttack = false;
   }
}

enum BotState
{
   Idle,
   Walk
}
