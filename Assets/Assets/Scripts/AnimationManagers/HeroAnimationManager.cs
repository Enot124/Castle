using System;
using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.AnimationManagers
{
   public class HeroAnimationManager : AnimationManagerBase<Hero>
   {
      private Hero _hero { get => _target; }
      private Animator _animator;
      public void Awake()
      {
         //_hero = gameObject;
         _animator = _hero.GetComponent<Animator>();
      }
      public void FixedUpdate()
      {
         _animator.SetTrigger("Attack");
         UpdateAnimation();
      }
      public override void UpdateAnimation()
      {
         if (_hero.MoveDirection.x != 0 || _hero.MoveDirection.y != 0)
            MoveState = MoveState.Walk;
         else
            MoveState = MoveState.Idle;
         var x = _target.MoveDirection.x > 0 ? 1 : -1;
         if (_target.MoveDirection.x != 0)
            _target.transform.localScale = new Vector3(
                x,
                transform.localScale.y,
                transform.localScale.z);

      }
      private MoveState MoveState
      {
         get { return (MoveState)_animator.GetInteger("state"); }
         set { _animator.SetInteger("state", (int)value); }
      }

   }
   enum MoveState
   {
      Idle,
      Walk
   }
}