using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 1000;

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;





    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        
        if (numGameSessions > 1)
        {
            
            Destroy(gameObject);
            

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
        
    }

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ProcessPlayerDeath()
    {
        
        if (playerLives > 1)
        {
            TakeLife();
            
        }
        else
        {
            ResetGameSession();
        }

    }

    private void TakeLife()
    {
        
        playerLives--;
        StartCoroutine(LoadSameLevel());
        

        
        
        

        
    }
    IEnumerator LoadSameLevel()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
