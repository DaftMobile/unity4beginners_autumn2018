using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour, ILifeManager
{
    public int CurrentLife { get; private set; }
    
    private Image lifeBar;
    private float maxLife;
    private float spriteWidth;
    private GameObject ship;

    private IGameEnding gameEnding;
      
    public void Initialize(Image lifeBar, int currentLife,
        GameObject ship, IGameEnding gameEnding)
    {
        this.lifeBar = lifeBar;
        CurrentLife = currentLife;
        maxLife = currentLife;
        spriteWidth = lifeBar.rectTransform.sizeDelta.x;
        this.ship = ship;
        this.gameEnding = gameEnding;
    }
    
    public void DealDamage(int damage)
    {
        CurrentLife -= damage;

        lifeBar.rectTransform.sizeDelta = 
            new Vector2 (CurrentLife / maxLife * spriteWidth,
                lifeBar.rectTransform.sizeDelta.y);

        if (CurrentLife <= 0)
        {
           gameEnding.EndGame();
        }
    }
}