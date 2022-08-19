using Assembly_CSharp.Assets.Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assembly_CSharp.Assets.Assets.Scripts.Controllers
{
   public class KeyboardController : MonoBehaviour
   {
      [SerializeField] private Hero _hero;
      void Update()
      {
         if (Input.GetMouseButtonDown(0))
         {
            AttackManager.Attack(_hero);
         }
      }

      void FixedUpdate()
      {
         Vector2 dir;

         dir.x = Input.GetAxisRaw("Horizontal");
         dir.y = Input.GetAxisRaw("Vertical");

         //dir.Normalize();
         if (dir.x != 0 || dir.y != 0)
            MoveManager.Move(_hero, dir * Time.fixedDeltaTime);
         else
            MoveManager.Stop(_hero);


      }
   }
}