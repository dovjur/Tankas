using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnZoneController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;

    [Min(0f)]
    [SerializeField]
    private int count = 10;

    private List<SpawnZone> spawnZones;

    private void Awake()
    {
        spawnZones = FindObjectsOfType<SpawnZone>().ToList();
        Debug.Log(prefabs.Count);
    }
    private void Start()
    {
        CreateAll();
    }
    public void Create()
    {
        if (prefabs.Count == 0)
        {
            return;
        }

        var randomPrefab = prefabs[Random.Range(0, prefabs.Count)];
        Create(randomPrefab);
    }
    private void CreateAll()
    {
        foreach (var prefab in prefabs)
        {
            for (int i = 0; i <= count; i++)
            {
                Create(prefab);
            }
        }
    }

    private void Create(GameObject obj)
    {
        if (spawnZones.Count == 0)
        {
            return;
        }

        var randomSpawnZone = spawnZones[Random.Range(0,spawnZones.Count)];
        randomSpawnZone.Create(obj);
    }
}
