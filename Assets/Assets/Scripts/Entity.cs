using UnityEngine;
using TMPro;
using Assembly_CSharp.Assets.Assets.Scripts.AnimationManagers;

public abstract class Entity<T> : MonoBehaviour
   where T : Component
{
    public AnimationManagerBase<T> AnimationManager { get; set; }
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

    public void TakeDamage(int damage)
    {
        if (!DodgeChance((int)_dodgeChance))
        {
            damage -= (int)(damage * _defence);
            _currentHP -= damage;
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



