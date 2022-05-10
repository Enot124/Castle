using UnityEngine;
using TMPro;

public class Hero : Entity
{
   private float speed = 3f;
   private Vector2 dir;
   public int _maxExpierence = 100;
   public int _levelStats = 0;
   public GameObject parametresButtons;
   public GameObject menu;
   public Transform enemy;
   private bool _isKrit;

   private MoveState _moveState
   {
      get { return (MoveState)_animator.GetInteger("state"); }
      set { _animator.SetInteger("state", (int)value); }
   }
   [SerializeField] private TextMeshProUGUI nickname;
   [SerializeField] private TextMeshProUGUI hpExp;
   [SerializeField] private TextMeshProUGUI parametresStats;
   [SerializeField] private TextMeshProUGUI charactersStats;
   [SerializeField] private TextMeshProUGUI levelFreeStats;
   private Animator _animator;
   [SerializeField] private Transform attackPoint;
   [SerializeField] private LayerMask enemyLayer;
   private Rigidbody2D rb;
   void Awake()
   {
      _animator = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      _ownHealth = 15;
      CalculateStats();
      _currentHP = _maxHP;
      WriteStats();
   }

   void Update()
   {
      dir.x = Input.GetAxisRaw("Horizontal");
      dir.y = Input.GetAxisRaw("Vertical");
      if (dir.x == 0)
         Idle();
      else
         MoveLeftRight();
      if (dir.y != 0)
         MoveUpDown();
      if (Input.GetMouseButtonDown(1))
         Attack();
      if (_expierence >= _maxExpierence)
         LevelUp();
      if (_currentHP >= _maxHP)
         _currentHP = _maxHP;

      float distanceToPlayer = Vector2.Distance(attackPoint.position, enemy.position);
      if (distanceToPlayer <= _attackRange * 3)
      {
         _isAttack = true;
      }
      else
      {
         if (_isAttack)
            Invoke("IsNoAttack", 4f);
      }
   }

   private void FixedUpdate()
   {
      rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
      if (_currentHP < _maxHP && !_isAttack)
      {
         _currentHP += _maxHP * 0.0003f;
         WriteStats();
      }
      if (_timer > 0)
         _timer -= Time.deltaTime;
   }

   private void MoveLeftRight()
   {
      transform.localScale = new Vector3(dir.x, transform.localScale.y, transform.localScale.z);
      _moveState = MoveState.Walk;
   }

   private void MoveUpDown()
   {
      _moveState = MoveState.Walk;
   }
   private void Idle()
   {
      _moveState = MoveState.Idle;
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

   private void IsNoAttack()
   {
      _isAttack = false;
   }

   private void WriteStats()
   {
      nickname.text = _name + ", " + _level + " lvl";
      hpExp.text = (int)_currentHP + "/" + (int)_maxHP + "\n" + _expierence + "/" + _maxExpierence;
      levelFreeStats.text = _levelStats.ToString() + " free";
      parametresStats.text = _strange.ToString() + "\n" + _agility.ToString() + "\n"
                           + _endurance.ToString() + "\n" + _luck.ToString();
      charactersStats.text = _attack.ToString() + "\n"
                           + _attackSpeed.ToString() + "\n" + _dodgeChance.ToString()
                           + "\n" + _defence.ToString() + "\n" + _kritChance.ToString();
   }

   ////////////////////////////////////////////////////////////////////////////
   ///////////////////////////////////////////////////////////////////////////
   //////////Система лвлов и распределения характеристик/////////////////////
   private void LevelUp()
   {
      if (_level < 40)
      {
         _level++;
         _ownHealth = _ownHealth + _ownHealth * 0.1f;
         CalculateStats();
         _currentHP = _maxHP;
         int currentExpierence = _expierence - _maxExpierence;
         _maxExpierence = (int)(_maxExpierence + _maxExpierence * 0.1f);
         _expierence = currentExpierence;
         _levelStats += 8;
         WriteStats();
         if (menu.activeSelf == true)
         { parametresButtons.SetActive(true); }
      }
   }

   public void AddStrange()
   {
      _strange++;
      AddParameter();
   }
   public void AddAgility()
   {
      _agility++;
      AddParameter();
   }
   public void AddEndurance()
   {
      _endurance++;
      AddParameter();
   }
   public void AddLuck()
   {
      _luck++;
      AddParameter();
   }

   private void AddParameter()
   {
      _levelStats--;
      CalculateStats();
      WriteStats();
      if (_levelStats == 0)
      {
         parametresButtons.SetActive(false);
         levelFreeStats.text = null;
      }
   }
   //////////Конец cистемы лвлов и распределения характеристик//////////////////
   ////////////////////////////////////////////////////////////////////////////
   ///////////////////////////////////////////////////////////////////////////


}
enum MoveState
{
   Idle,
   Walk
}