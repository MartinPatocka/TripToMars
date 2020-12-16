using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] public float secondsToGameOver = 0.75f;
    private int prewiousScene = 0;

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

    public void LoadBackToTheFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAfterDeath());
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadShopScene()
    {
        prewiousScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(prewiousScene);
        SceneManager.LoadScene("Shop");
    }

    public void LoadCoinShopScene()
    {
        prewiousScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(prewiousScene);
        SceneManager.LoadScene("CoinShop");
    }

    public void LoadBackToScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch(prewiousScene)
        {
            case 0:
                Debug.Log(prewiousScene);
                LoadBackToTheFirstScene();
                break;
            case 2:
                Debug.Log(prewiousScene);
                SceneManager.LoadScene(2);
                break;
        }

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
