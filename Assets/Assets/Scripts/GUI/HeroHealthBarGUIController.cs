using UnityEngine;
using UnityEngine.UI;

namespace Assembly_CSharp.Assets.Assets.Scripts.GUI
{
   public class HeroHealthBarGUIController : MonoBehaviour
   {
      public Slider sliderHealth;
      public Slider sliderExpierence;
      public Hero Hero;

      private void Update()
      {
         SetHealthValue((int)Hero._currentHP, (int)Hero._maxHP);
         SetExpierenceValue(Hero._experience, Hero._maxExpierence);
      }

      public void SetHealthValue(int health, int maxHealth)
      {
         sliderHealth.value = health;
         sliderHealth.maxValue = maxHealth;
      }

      public void SetExpierenceValue(int expierence, int maxExpierence)
      {
         sliderExpierence.value = expierence;
         sliderExpierence.maxValue = maxExpierence;
      }
   }
}