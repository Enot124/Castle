namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
   public interface IHaveBaseInfo
   {
      public string Name { get; }
      public int Level { get; set; }
      public int Expierence { get; set; }
      public int MaxExpierence { get; set; }
   }
}