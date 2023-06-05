using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject arrow;
    public GameObject crossbow;
    public GameObject gameManager;
    public Transform towerPos;
    public TextMeshProUGUI waveUI;
    private AudioSource spawnManager;
    public AudioClip newWave;
    private float spawnRange = 35f;
    private float spawnPos = 90f;
    private Vector3 arrowSpawnPos;
    public int enemyCount = 3;
    public int waveNumber = 1;
    public bool spawnWaves;

    private void Start()
    {
        spawnManager = GetComponent<AudioSource>();
    }

    public void StartSpawn()
    {
        spawnWaves = true;
        GenerateSpawnPosition();
        SpawnEnemyWave(waveNumber);
    }

    public void ToggleWaves()
    {
        if (spawnWaves == false)
        {
            spawnWaves = true;
        }
        else
        {
            spawnWaves = false;
        }
    }

    void Update()
    {   
        if(spawnWaves) {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                GenerateSpawnPosition();
                SpawnEnemyWave(waveNumber);
            }
        }

        waveUI.text = "Wave: " + waveNumber;
    }

    public void SpawnEnemyWave(int enemiesToSpawn = 3)
    {
        spawnManager.PlayOneShot(newWave, 1);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //GameObject enemySpawnPos = (GameObject)Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            //enemySpawnPos.transform.LookAt(towerPos);
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.LookRotation(towerPos.position));
            //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        int direction = Random.Range(1, 5);

        switch (direction)
        {
            case 1:
                //North
                return new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnPos);
            case 2:
                //East
                return new Vector3(spawnPos, 0, Random.Range(-spawnRange, spawnRange));
            case 3:
                //South
                return new Vector3(Random.Range(-spawnRange, spawnRange), 0, -spawnPos);
            case 4:
                //West
                return new Vector3(-spawnPos, 0, Random.Range(-spawnRange, spawnRange));
            default:
                return new Vector3();
        }

    }
    public void ShootCrossbow()
    {
        arrowSpawnPos = crossbow.transform.position;
        GameObject temp= Instantiate(arrow, GameObject.Find("Crossbow").GetComponent<Transform>());
        temp.transform.SetParent(null);
    }
}

