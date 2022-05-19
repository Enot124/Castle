using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
   [SerializeField] private Slider _slider;
   [SerializeField] private Vector3 _offset;
   [SerializeField] private Enemy enemy;

   void Update()
   {
      //_slider.transform.position = enemy.transform.position + _offset;
      //SetHealthValue((int)enemy._currentHP, (int)enemy._maxHP);
   }

   public void SetHealthValue(int currentHealth, int maxHealth)
   {
      _slider.gameObject.SetActive(currentHealth < maxHealth && currentHealth != 0);
      _slider.value = currentHealth;
      _slider.maxValue = maxHealth;
   }
}
