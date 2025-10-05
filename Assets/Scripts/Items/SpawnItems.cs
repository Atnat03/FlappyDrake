using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public GameObject prefab;
        public float luck;
    }

    public List<Item> potentialBonusList = new();

    public Vector2 rangeBetweenTwoItem = new Vector2(3, 5);

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(rangeBetweenTwoItem.x, rangeBetweenTwoItem.y);
            yield return new WaitForSeconds(waitTime);

            SpawnItem();
        }
    }

    public void SpawnItem()
    {
        GameObject itemToSpawn = GetNextItem();
        Vector2 spawnPos = GetNextPosToSpawn();

        Instantiate(itemToSpawn, spawnPos, Quaternion.identity);
    }

    GameObject GetNextItem()
{
    if (potentialBonusList == null || potentialBonusList.Count == 0)
    {
        Debug.LogWarning("Aucun item dans la liste !");
        return null;
    }

    float totalLuck = 0f;
    foreach (var item in potentialBonusList)
    {
        if (item != null && item.prefab != null)
            totalLuck += item.luck;
    }

    if (totalLuck <= 0f)
    {
        Debug.LogWarning("Tous les items ont une luck <= 0 ou des prefabs manquants !");
        return null;
    }

    float randomValue = Random.Range(0f, totalLuck);
    float cumulative = 0f;

    foreach (var item in potentialBonusList)
    {
        if (item == null || item.prefab == null) continue;

        cumulative += item.luck;
        if (randomValue <= cumulative)
        {
            return item.prefab;
        }
    }

    return potentialBonusList[0].prefab;
}


    Vector2 GetNextPosToSpawn()
    {
        float randomY = Random.Range(0.2f, 0.9f);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(
            new Vector3(1f, randomY, Camera.main.nearClipPlane + 5f)
        );

        return new Vector2(transform.position.x, worldPos.y);
    }
}
