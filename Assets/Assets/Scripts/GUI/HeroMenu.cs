using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assembly_CSharp.Assets.Assets.Scripts.GUI
{
   public class HeroMenu : MonoBehaviour
   {
      #region MenuStats
      [SerializeField] private TextMeshProUGUI _nameLvl;
      [SerializeField] private TextMeshProUGUI _countHP;
      [SerializeField] private TextMeshProUGUI _freeattr;
      [SerializeField] private TextMeshProUGUI _countattr;
      [SerializeField] private TextMeshProUGUI _characters;
      #endregion MenuStats

      [SerializeField] private Hero _hero;
      [SerializeField] private GameObject _menuButton;

      public void ShowMenu()
      {
         WriteStats();
         _menuButton.SetActive(true);
      }
      public void CloseMenu()
      {
         _menuButton.SetActive(false);
      }

      public void WriteStats()
      {
         _nameLvl.text = _hero.Name + ", " + _hero.Level + " lvl";

         _countHP.text = _hero.CurrentHealth + "/" + _hero.MaxHealth
                         + "\n" + _hero.Expierence + "/" + _hero.MaxExpierence;

         _freeattr.text = _hero.FreeAttr + " free";

         _countattr.text = _hero.Strange + "\n" + _hero.Agility + "\n"
                         + _hero.Endurance + "\n" + _hero.Luck;

         _characters.text = _hero.Damage + "\n" + _hero.AttackSpeed + "\n" +
                         +_hero.KritChance + "\n" + _hero.DodgeChance + "\n"
                         + _hero.Defence;

      }
   }
}