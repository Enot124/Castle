using Assembly_CSharp.Assets.Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.Managers
{
   public class MoveManager
   {
      public static void Move(ICanMove entity, Vector2 direction)
      {
         entity.Rigidbody2D.MovePosition(entity.Rigidbody2D.position
              + direction * entity.Speed);

         entity.MoveDirection = direction;
      }
      public static void Stop(ICanMove entity)
      {
         entity.MoveDirection = new Vector2(0, 0);
      }
   }
}