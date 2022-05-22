using UnityEngine;

namespace Assembly_CSharp.Assets.Assets.Scripts.Managers
{
   public class LevelManager
   {
      private const int _freeattr = 6;
      [SerializeField] private Hero _hero;
      public void TryLevelUp()
      {
         if (_hero.Expierence >= _hero.MaxExpierence)
         {
            LevelUp();
         }
      }
      public void LevelUp()
      {
         _hero.Level++;
         _hero.FreeAttr += _freeattr;
         _hero.Expierence -= _hero.MaxExpierence;
         if (_hero.Level % 10 == 0)
         { _hero.MaxExpierence = _hero.MaxExpierence + _hero.MaxExpierence * 10; }
         else
         { _hero.MaxExpierence = (int)(_hero.MaxExpierence * 0.1f); }
      }

   }
}