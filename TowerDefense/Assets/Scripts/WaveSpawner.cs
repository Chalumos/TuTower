using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform ennemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetwenWaves = 5f;

    private float countdown = 2f;

    [SerializeField]
    private Text WavesCountdownTimer;

    private int waveIndex = 0;
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpanWave());
            countdown = timeBetwenWaves;
        }

        countdown -= Time.deltaTime;
        WavesCountdownTimer.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpanWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnnemy()
    {
        Instantiate(ennemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
