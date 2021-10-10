using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        Brick.OnBrickBreak += CheckGameOver;
        Ball.OnBallDestroy += CheckGameOver;
    }

    private void OnDisable()
    {
        Brick.OnBrickBreak -= CheckGameOver;
        Ball.OnBallDestroy -= CheckGameOver;
    }

    private void CheckGameOver()
    {
        if (Brick.NoBrick) Debug.Log("WIN");
        else if (Ball.NoBall) Debug.Log("LOSE");
    }
}