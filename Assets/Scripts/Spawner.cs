using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public float spawnInterval = 1.5f;
    public int maxNPCs = 20; 

    public bool IsSpawning { get; private set; }

    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (IsSpawning) return;
        IsSpawning = true;
        InvokeRepeating(nameof(SpawnNPC), 0f, spawnInterval);
    }

    public void StopSpawning()
    {
        if (!IsSpawning) return;
        IsSpawning = false;
        CancelInvoke(nameof(SpawnNPC));
    }

    void SpawnNPC()
    {
        int currentCount = GameObject.FindGameObjectsWithTag("NPC").Length;

        if (currentCount >= maxNPCs) return; // do not spawn if at cap

        Instantiate(npcPrefab, transform.position, Quaternion.identity);
    }
}
