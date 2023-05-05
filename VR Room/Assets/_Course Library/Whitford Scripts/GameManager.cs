using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float towerHealth;
    public GameObject spawnManager;
    public GameObject startButton;
    public GameObject pauseButton;
    public GameObject restartButton;
    public TextMeshProUGUI healthUI;

    // Start is called before the first frame update
    void Start()
    {
        towerHealth = 25;

    }

    public void StartGame()
    {
      
        spawnManager.GetComponent<SpawnManager>().StartSpawn();
        startButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        spawnManager.GetComponent<SpawnManager>().ToggleWaves();
    }

    // Update is called once per frame
    void Update()
    {
        if (towerHealth <= 0)
        {
            spawnManager.GetComponent<SpawnManager>().ToggleWaves();
            towerHealth = 0;
            bool noSpawnWaves = spawnManager.GetComponent<SpawnManager>().spawnWaves = false;
            pauseButton.SetActive(false);
            restartButton.SetActive(true);
        }

        healthUI.text = "Tower Health: " + towerHealth;
    }

}
