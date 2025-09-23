using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // List y polimorfismo
    List<Enemy> enemies = new List<Enemy>();

    private static GameManager instance;
    public static GameManager Instance => instance;

    private bool defeatSceneLoading = false;

    private void OnEnable()
    {
        HealthManager.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        HealthManager.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        defeatSceneLoading = false;
    }

    void Start()
    {
        enemies = new List<Enemy>(FindObjectsByType<Enemy>(FindObjectsSortMode.None));
    }

    void Update()
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null && Input.GetKeyDown(KeyCode.K))
            {
                enemy.TakeDamage(1);
            }
        }
    }

    private void HandlePlayerDeath()
    {
        if (!defeatSceneLoading)
        {
            defeatSceneLoading = true;
            StartCoroutine(LoadDefeatSceneAfterDelay(2f));
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void UnRegisterEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    private IEnumerator LoadDefeatSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Defeat");
    }
}
