using System.Collections;
using UnityEngine;

public class GameEnding : IGameEnding
{
    private GameObject ship;
    private Initiator coroutineRunner;
    private GameObject GameOverObject;
    private float endGameDelay;

    public GameEnding(GameObject ship, Initiator coroutineRunner,
        GameObject gameOverObject, float endGameDelay)
    {
        this.ship = ship;
        this.coroutineRunner = coroutineRunner;
        GameOverObject = gameOverObject;
        this.endGameDelay = endGameDelay;
    }

    public void EndGame()
    {
        GameOverObject.SetActive(true);
        Object.Destroy(ship);
        coroutineRunner.StartCoroutine(DelayDisplay());
    }

    private IEnumerator DelayDisplay()
    {
        yield return new WaitForSeconds(endGameDelay);
        Application.LoadLevel(Application.loadedLevel);
    }
}