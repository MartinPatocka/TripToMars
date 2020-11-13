using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] public float secondsToGameOver = 0.75f;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAfterDeath());
        FindObjectOfType<CoinManager>().LoadPlayerData();
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<CoinManager>().LoadPlayerData();
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator WaitAfterDeath()
    {
        yield return new WaitForSeconds(secondsToGameOver);
        SceneManager.LoadScene("GameOver");
    }
}
