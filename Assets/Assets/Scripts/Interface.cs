using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
   public GameObject menu;
   public GameObject parametresButtons;
   public Slider sliderHealth;
   public Slider sliderExpierence;
   public Hero Hero;

   private void Update()
   {
      //SetHealthValue((int)Hero._currentHP, (int)Hero._maxHP);
      //SetExpierenceValue(Hero._expierence, Hero._maxExpierence);
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

   public void ShowMenu()
   {
      // menu.SetActive(true);
      // if (Hero._levelStats != 0)
      //    parametresButtons.SetActive(true);
   }

   public void CloseMenu()
   {
      menu.SetActive(false);
   }
}
