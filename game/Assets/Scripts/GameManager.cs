using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject soldierPrefab;
    public GameObject tankPrefab;
    public Transform enemySpawn;
    private float spawnInterval = 3f;

    private int points = 0;
    private int wave = 1;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    IEnumerator SpawnEnemiesCoroutine()
    {
        while (true)
        {
            // Wait for 3 seconds
            yield return new WaitForSeconds(spawnInterval);

            // Spawn the prefab
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject prefab = soldierPrefab;

        if (Random.value <= 0.15f) {
            prefab = tankPrefab;
        }

        // Instantiate the prefab at a specific position (you can modify this as needed)
        Instantiate(prefab, enemySpawn.position, Quaternion.identity);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 20;

        // Display Points
        GUI.Label(new Rect(10, 10, 200, 30), "Points: " + points, style);

        // Display Wave
        GUI.Label(new Rect(10, 50, 200, 30), "Wave: " + wave, style);
    }

    public void OnUpgradeButtonClick()
    {
        PauseGame();
        SceneManager.LoadScene("UpgradeMenu", LoadSceneMode.Additive);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
