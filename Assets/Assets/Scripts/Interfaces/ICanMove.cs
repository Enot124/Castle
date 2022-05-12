using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
    public interface ICanMove
    {
        public Vector2 MoveDirection { get; set; }
        public float Speed { get; }
        public Rigidbody2D Rigidbody2D { get; set; }
    }
}