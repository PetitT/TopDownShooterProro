using LowTeeGames;
using LowTeeGames.HelperClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLoot : MonoBehaviour
{
    public Vector2Int lootProbability;
    public List<GameObject> loots;

    public void Loot()
    {
        int random = UnityEngine.Random.Range(0, lootProbability.y);
        if (random < lootProbability.x)
        {
            GameObject newLoot = RandomHelper.GetRandomInCollection(loots);
            GameObject loot = Pool.instance.GetItemFromPool(newLoot, transform.position, Quaternion.identity);
            TransformHelper.ModifyY(loot, 0);
        }
    }
}
