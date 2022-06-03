using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> wallModules;

    [SerializeField]
    private List<GameObject> modules;

    [Range(0f, 1f)]
    public float fillPreentage = 0.5f;

    [Range(1, 10)]
    [SerializeField]
    private int smoothingIterations = 2;

    [Min(0)]
    [SerializeField]
    private int moduleSize = 10;

    [Range(0,32)]
    [SerializeField]
    private int mapSize = 10;

    public List<GameObject> WallModules => wallModules;
    public List<GameObject> Modules => modules;
    public float FillPercentage => fillPreentage;
    public int SmoothingIterations => smoothingIterations;
    public int ModuleSize => moduleSize;
    public int MapSize => mapSize;
}
