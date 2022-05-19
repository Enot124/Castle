using System;
using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
    public interface ICanAttack
    {
        public float Cooldown { get; }
        public float Damage { get; }
        public float KritChance { get; }
        public bool IsCanAttack { get; set; }
        public Vector2 AttackPoint { get; }
        public Vector2 AttackRange { get; }
        public LayerMask OppositeLayer { get; }
        public event EventHandler Attacking;
        public void OnAttack();
    }
}