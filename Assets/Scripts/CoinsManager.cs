using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CoinsManager : MonoBehaviour
{
    private static CoinsManager instance;
    public static CoinsManager Instance => instance;
    private static int score = 0;
    [SerializeField] private int inspectorScore;

    public int Score
    {
        get => score;
        private set
        {
            score = value;
            inspectorScore = score;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int newScore)
    {
        Score += newScore;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
