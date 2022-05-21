namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
   public interface IDamageable
   {
      public float Defence { get; }
      public float DodgeChance { get; }
      public float CurrentHealth { get; set; }
      public float MaxHealth { get; set; }
   }
}