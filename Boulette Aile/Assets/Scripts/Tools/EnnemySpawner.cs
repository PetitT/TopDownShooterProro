using LowTeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject ennemyPrefab;
    public List<Transform> spawns;
    public float respawnTimer;

    private List<EnnemyData> ennemies = new List<EnnemyData>();

    private void Start()
    {
        for (int i = 0; i < spawns.Count; i++)
        {
            Transform spawn = spawns[i];
            GameObject newEnnemy = Pool.instance.GetItemFromPool(ennemyPrefab, spawn.position, Quaternion.identity);
            ennemies.Add(new EnnemyData() { ennemy = newEnnemy, spawn = spawn });
        }
    }

    private void Update()
    {
        foreach (var ennemy in ennemies)
        {
            if (!ennemy.ennemy.activeSelf)
            {
                if (!ennemy.isRespawning)
                {
                    StartCoroutine(Respawn(ennemy));
                }
            }
        }
    }

    private IEnumerator Respawn(EnnemyData data)
    {
        data.isRespawning = true;
        yield return new WaitForSeconds(respawnTimer);
        data.isRespawning = false;
        data.ennemy.SetActive(true);
        data.ennemy.transform.position = data.spawn.position;
    }
}

public class EnnemyData
{
    public GameObject ennemy;
    public Transform spawn;
    public bool isRespawning = false;
}