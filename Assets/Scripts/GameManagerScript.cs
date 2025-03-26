using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // death screen settings
    public GameObject gameOverUI;
    public bool isGameOverScreenActive = false;

    // pause settings
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
   
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Unable to use GameObject.Find on gameobjects that are inactive in the scene
        gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
        pauseMenuUI = GameObject.FindGameObjectWithTag("PauseMenuUI");
        player = GameObject.FindGameObjectWithTag("Player");
        */

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time scale is" + Time.timeScale);

        Debug.Log("Game pause" + GameIsPaused);

        
        //when esc is pressed the game will pause
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverUI.activeSelf)
        {
            if (GameIsPaused)
            {
                startEnemies();
                Resume();
                Cursor.visible = false;
                player.GetComponent<AttackNew>().enabled = true;
                player.GetComponent<PlayerControllerNew>().enabled = true;
            }
            else
            {
                stopEnemies();
                Pause();
                Cursor.visible = true;
                player.GetComponent<AttackNew>().enabled = false;
                player.GetComponent<PlayerControllerNew>().enabled = false;
            }
        }
        // Show cursor when the gameoverscreen is active and hide the cursor when the gameoverscreen is inactive
        if (gameOverUI.activeInHierarchy)
        {
            StartCoroutine(DelayedDeathScreen());
            stopEnemies();
        }
        else
        {
            //setTimeScale();
            isGameOverScreenActive = false;
            Cursor.visible = false;
            startEnemies();
        }
    }
    void stopEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            //disables the enemy script
            enemy.GetComponent<Enemy_Whisper>().enabled = false;
        }
    }
    void setTimeScale()
    {
        Time.timeScale = 1f;
    }
    void startEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //reenables the enemy
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy_Whisper>().enabled = true;
        }
    }
    IEnumerator DelayedDeathScreen()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0f;
        isGameOverScreenActive = true;
        Cursor.visible = true;
    }
    //pause screen actions
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //death screen actions
    public void gameOver()
    {
        //turns on gameoverscreen when the player dies
        gameOverUI.SetActive(true);
    }

    //button actions
    public void restart()
    {
        //sends player back to hub
        SceneManager.LoadScene("Hub");
        setTimeScale();
    }

    public void restarttut()
    {
        //sends player back to tutorial
        SceneManager.LoadScene("Tutorial");
        setTimeScale();
    }

    public void mainMenu()
    {
        //sends player back to main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        //closes the game
        Application.Quit();
        Debug.Log("Game has been quit");
    }
}