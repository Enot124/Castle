using UnityEngine;
using Assembly_CSharp.Assets.Assets.Scripts.AnimationManagers;

public abstract class Entity<T> : MonoBehaviour
   where T : Component
{
   public AnimationManagerBase<T> AnimationManager { get; set; }
   public LayerMask _layer;
}



