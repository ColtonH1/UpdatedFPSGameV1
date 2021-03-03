/*
 * V2
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;

    //pause menu
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject WinScreenUI;
    public GameObject SlowDownUI;
    public GameObject reticle;
    public GameObject[] treasureChest;
    public int treasureCount;
    public static float currentTime;
    public static bool showed;


    int _currentScore;

    //RaycastShoot raycastShoot;

    void Start()
    {
        showed = false;
        treasureChest = GameObject.FindGameObjectsWithTag("Treasure");
        SetHighScore();
        SetCurrentTime(1);
        //EnemyController.ResetScore();
        Resume(); //calls the function so game isn't pause from the beginning
    }
    // Update is called once per frame
    void Update()
    {
        if(!GameIsPaused)
        {
            currentTime = GetCurrentTime();
            Time.timeScale = currentTime;
        }

        if (RaycastShoot.GetIfShot() && WeaponSwitching.GetSelectedWeapon() == 0)
        {
            //int score = EnemyController.GetScore();
            if(EnemyController.GotShot())
            {
                _currentScore += 5;
                IncreaseScore(_currentScore);
            }  
        }

        if (RaycastShoot.GetIfShot() && WeaponSwitching.GetSelectedWeapon() == 1)
        {
            //int score = EnemyController.GetScore();
            if (EnemyController.GotShot())
            {
                _currentScore += 1;
                IncreaseScore(_currentScore);
            }
        }

        Debug.Log("Treasure count if win " + treasureCount);
        if (treasureCount == 5)
        {
            Win();
        }

        //pause menu
        EscPressed();        
    }



    private void Win()
    {
        WinScreenUI.SetActive(true);
        reticle.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void IncreaseScore(int scoreIncrease)
    {
        _currentScore = scoreIncrease;

        _currentScoreTextView.text = "Score: " + _currentScore.ToString();
    }

    //pause menu
    private void EscPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ExitLevel()
    {
        SetHighScore();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score " + _currentScore);
        }
    }

    //time functions
    public static void SetCurrentTime(float time)
    {
        currentTime = time;
        if(currentTime == 0f)
        {
            showed = true;
        }
    }
    public float GetCurrentTime()
    {
        if(currentTime < 1f && !showed)
            StartCoroutine("DisplaySlowDown");
        return currentTime;
    }
    IEnumerator DisplaySlowDown()
    {
        SlowDownUI.SetActive(true);
        showed = true;
        yield return new WaitForSeconds(2f);
        SlowDownUI.SetActive(false);
    }



    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        reticle.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = currentTime;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        reticle.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        SetHighScore();
        SceneManager.LoadScene("Level01");
    }

    public void QuitButton()
    {
        GameIsPaused = false;
        ExitLevel();
    }

    public bool IsPaused()
    {
        return GameIsPaused;
    }

    public void Died()
    {
        reticle.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void AddToScore(int scorePlus)
    {
        if(TreasureChest.DidCollect())
        {
            Debug.Log("Treasure count " + treasureCount);
            treasureCount++;
            _currentScore += scorePlus; 
            IncreaseScore(_currentScore);
        }
        else
        {
            _currentScore += scorePlus;
            IncreaseScore(_currentScore);
        }
            
    }

    public static void SetShowed(bool didShow)
    {
        showed = didShow;
    }

}
