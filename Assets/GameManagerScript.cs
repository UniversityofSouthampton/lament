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
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //when esc is pressed the game will pause
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverUI.activeSelf)
        {
            if (GameIsPaused)
            {
                Resume();
                Cursor.visible = false;
                player.GetComponent<AttackNew>().enabled = true;
            }
            else
            {
                Pause();
                Cursor.visible = true;
                player.GetComponent<AttackNew>().enabled = false;
            }
        }
        // Show cursor when the gameoverscreen is active and hide the cursor when the gameoverscreen is inactive
        if (gameOverUI.activeInHierarchy)
        {
            StartCoroutine(DelayedDeathScreen());

            //finds all gameobjects under the tag enemy
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                //disables the enemy script when the player dies
                enemy.GetComponent<Enemy_Whisper>().enabled = false;
            }
        }
        else
        {
            Time.timeScale = 1f;
            isGameOverScreenActive = false;
            Cursor.visible = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //reables the enemy script when the player respawns
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy_Whisper>().enabled = true;
            }
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Hub");
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