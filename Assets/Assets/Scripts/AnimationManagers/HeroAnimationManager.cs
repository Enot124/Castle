using System;
using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.AnimationManagers
{
    public class HeroAnimationManager : AnimationManagerBase<Hero>
    {
        private Hero _hero { get => _target; }
        private Animator _animator;
        private bool _isAttack = false;
        public void Awake()
        {
            _hero.Attacking += OnAttack;//TODO -=
            _animator = _hero.GetComponent<Animator>();
        }
        public void FixedUpdate()
        {
            UpdateAnimation();
        }
        public void OnAttack(object sender, EventArgs e)
        {
            _isAttack = true;
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

            if (_isAttack)
            {
                _animator.SetTrigger("Attack");
                _isAttack = false;
            }

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