namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
   public interface ICanAttack
   {
      public float Cooldown { get; }
      public float Damage { get; }
      public float KritChance { get; }
      public bool IsCanAttack { get; set; }
   }
}