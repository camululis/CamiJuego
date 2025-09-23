using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel 1");
        CoinsManager.Instance.ResetScore();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            StartCoroutine(LoadDefeatSceneAfterDelay(2f));
        }
    }

    private IEnumerator LoadDefeatSceneAfterDelay (float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Defeat");
    }
}
