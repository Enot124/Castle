using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assembly_CSharp.Assets.Assets.Scripts.GUI
{
   public class HeroMenu : MonoBehaviour
   {
      [SerializeField] private Hero _hero;
      [SerializeField] private GameObject _menuButton;
      #region MenuStats
      [SerializeField] private TextMeshProUGUI _nameLvl;
      [SerializeField] private TextMeshProUGUI _countHP;
      [SerializeField] private TextMeshProUGUI _freeattr;
      [SerializeField] private TextMeshProUGUI _countattr;
      [SerializeField] private TextMeshProUGUI _characters;
      #endregion MenuStats

      public void ShowMenu()
      {
         _menuButton.SetActive(true);
      }
      public void CloseMenu()
      {
         _menuButton.SetActive(false);
      }

      public void WriteStats()
      {

      }
   }
}