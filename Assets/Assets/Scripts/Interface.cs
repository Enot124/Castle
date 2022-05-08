using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
   public GameObject menu;
   public GameObject parametresButtons;
   public Slider sliderHealth;
   public Slider sliderExpierence;
   public Hero Hero;

   private void Start()
   {
      SetMaxhealth((int)Hero._maxHP);
   }

   private void Update()
   {
      SetMaxhealth((int)Hero._maxHP);
      SetHealth((int)Hero._currentHP);
      SetMaxExpierence(Hero._maxExpierence);
      SetExpierence(Hero._expierence);
   }

   public void SetMaxhealth(int health)
   {
      sliderHealth.maxValue = health;
   }
   public void SetHealth(int health)
   {
      sliderHealth.value = health;
   }

   public void SetMaxExpierence(int exp)
   {
      sliderExpierence.maxValue = Hero._maxExpierence;
   }
   public void SetExpierence(int exp)
   {
      sliderExpierence.value = Hero._expierence;
   }

   public void ShowMenu()
   {
      menu.SetActive(true);
      if (Hero._levelStats != 0)
         parametresButtons.SetActive(true);
   }

   public void CloseMenu()
   {
      menu.SetActive(false);
   }
}
