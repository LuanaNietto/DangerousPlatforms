using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public enum GamePhase
    {
        Menu,
        Jogo,
        Pausa,
        GameOver
    }

    public int totalScore;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    [SerializeField]
    public GameObject gameOver;

    public GamePhase currentPhase;
    public int currentLevel;

    public static GameController instance;

    void Awake()
    {
        //if (instance == null)
        //{
            instance = this;
            DontDestroyOnLoad(gameObject); 
        //}
    }

    void Start()
    {
        currentPhase = GamePhase.Menu;
        currentLevel = 1;
        instance = this;        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif
        }

    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {        
        gameOver.SetActive(true);
        if (currentLevel == 1)
        {
            SceneManager.LoadScene("nivel_1");
        }
        if (currentLevel == 2)
        {
            SceneManager.LoadScene("nivel_2");
        }
        if (currentLevel == 3)
        {
            SceneManager.LoadScene("nivel_3");
        }
        if (currentLevel == 4)
        {
            SceneManager.LoadScene("nivel_4");
        }
        if (currentLevel == 5)
        {
            SceneManager.LoadScene("nivel_5");
        }
    }

    public void ReiniciarJogo(string nivelJogo) 
    {
        SceneManager.LoadScene(nivelJogo);    
    }
}
