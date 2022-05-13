namespace Assembly_CSharp.Assets.Assets.Scripts.Interfaces
{
    public interface ICanAttack
    {
        public float Cooldown { get; set; }
        public bool IsCanAttack { get; set; }
    }
}