public interface ILifeManager
{
    int CurrentLife { get; }
    
    void DealDamage(int damage);
}