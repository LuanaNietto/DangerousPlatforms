using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    public string levelName;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int totalScore = GameController.instance.totalScore;
            int currentLevel = GameController.instance.currentLevel;


            //if (currentLevel == 1 && totalScore < 10)
            //{
              // GameController.instance.currentLevel = 1;
              // SceneManager.LoadScene("nivel_1");
           //     Destroy(gameObject);
            //}
           // else
           // {
                GameController.instance.currentLevel++;
                SceneManager.LoadScene(levelName);
            //}

        }
    }
}
