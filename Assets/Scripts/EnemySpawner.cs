using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private float spawnDelay = 0.5f;
    private int waveNumber = 0;

    void Update()
    {
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Ceil(countdown).ToString();
        if (countdown <= 0f)
        {
            waveNumber++;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
