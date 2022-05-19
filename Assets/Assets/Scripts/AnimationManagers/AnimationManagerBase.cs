using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.AnimationManagers
{
    public abstract class AnimationManagerBase<T> : MonoBehaviour
        where T : Component
    {
        [SerializeField] protected T _target;
        //public abstract void Initialize(T component);
        public abstract void UpdateAnimation();
    }
}