using System;
using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
   public interface ICanAttack
   {
      public float Damage { get; }
      public float KritChance { get; }
      public float AttackSpeed { get; }
      public bool IsCanAttack { get; }
      public Vector2 AttackPoint { get; }
      public Vector2 AttackRange { get; }
      public LayerMask OppositeLayer { get; }
      public event EventHandler Attacking;
      public void OnAttack();
   }
}