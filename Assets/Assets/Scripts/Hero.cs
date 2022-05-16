using UnityEngine;
using TMPro;
using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;

public class Hero : Entity<Hero>, ICanMove, ICanAttack, IDamageable
{
   public int _maxExpierence = 100;
   public int _levelStats = 0;
   public Transform enemy;

   #region Attack
   public float Cooldown { get => 1 / _attackSpeed; }
   public float Damage { get => _attack; }
   public float KritChance { get => _kritChance; }
   public bool IsCanAttack { get; set; }
   public Vector2 AttackPoint { get => attackPoint.position; }
   public Vector2 AttackRange { get => _attackRange; }
   public LayerMask OppositeLayer { get => _layer; }
   #endregion Attack

   #region OnAttack      
   public float Defence { get => _defence; }
   public float DodgeChance { get => _dodgeChance; }
   public float CurrentHealth { get => _currentHP; set => _currentHP = value; }
   #endregion OnAttack  

   #region Movement
   public float Speed { get => _speed; }
   private Rigidbody2D _rigidBody;
   public Rigidbody2D Rigidbody2D { get => _rigidBody; set => _rigidBody = value; }
   public Vector2 MoveDirection { get; set; }
   #endregion Movement


   #region Menu
   public GameObject parametresButtons;
   public GameObject menu;
   [SerializeField] private TextMeshProUGUI nickname;
   [SerializeField] private TextMeshProUGUI hpExp;
   [SerializeField] private TextMeshProUGUI parametresStats;
   [SerializeField] private TextMeshProUGUI charactersStats;
   [SerializeField] private TextMeshProUGUI levelFreeStats;
   [SerializeField] private LayerMask enemyLayer;
   [SerializeField] private Transform attackPoint;
   #endregion Menu



   void Awake()
   {
      _rigidBody = GetComponent<Rigidbody2D>();
      _ownHealth = 15;
      CalculateStats();
      _currentHP = _maxHP;
      WriteStats();
   }

   void Update()
   {
      //var sword = transform.Find("Sword");
      // dir.x = Input.GetAxisRaw("Horizontal");
      // dir.y = Input.GetAxisRaw("Vertical");
      // if (dir.x == 0)
      //    Idle();
      // else
      //    MoveLeftRight();
      // if (dir.y != 0)
      //    MoveUpDown();
      // if (Input.GetMouseButtonDown(1))
      //    Attack();
      // if (_expierence >= _maxExpierence)
      //    LevelUp();
      // if (_currentHP >= _maxHP)
      //    _currentHP = _maxHP;

      // float distanceToPlayer = Vector2.Distance(attackPoint.position, enemy.position);
      // if (distanceToPlayer <= _attackRange * 3)
      // {
      //    _isAttack = true;
      // }
      // else
      // {
      //    if (_isAttack)
      //       Invoke("IsNoAttack", 4f);
      // }
   }

   private void FixedUpdate()
   {
      /*rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
      if (_currentHP < _maxHP && !_isAttack)
      {
         _currentHP += _maxHP * 0.0003f;
         WriteStats();
      }
      if (_timer > 0)
         _timer -= Time.deltaTime;*/
   }

   /*public void OnAttack()
   {
      int damage = (int)_attack;
      if (KritChance((int)_kritChance))
      {
         damage *= 2;
      }
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, _attackRange, enemyLayer);
      foreach (Collider2D enemy in hitEnemies)
      {
         enemy.GetComponent<Entity<Bot>>().TakeDamage(damage);
         Debug.Log(enemy.name + " was delt " + damage + " damage!");
      }
   }*/

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      //Gizmos.DrawWireSphere(attackPoint.position, _attackRange);
   }

   /*private void IsNoAttack()
   {
      _isAttack = false;
   }*/


   #region LevelSystem
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
   #endregion LevelSystem

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

}