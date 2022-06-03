using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectableController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> collectables;

    [Min(0)]
    [SerializeField]
    private int count = 3;

    [SerializeField]
    private Vector3 size = new Vector3(16f, 0f, 16f);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateCollectables();
    }

    private void CreateCollectables()
    {
        for (int i = 0; i < count; i++)
        {
            foreach (var collectable in collectables)
            {
                CreateCollectable(collectable);
            }
        }
    }

    private void CreateCollectable(GameObject collectable)
    {
        Instantiate(collectable,GetRandomPosition(),collectable.transform.rotation, gameObject.transform);
    }

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(Random.Range(0,size.x), Random.Range(0,size.y), Random.Range(0, size.z));
        return transform.position + volumePosition - size / 2;
    }

    public void CreateCollebtable()
    {
        var randomCollectable = collectables.OrderBy(collectables => Random.value).FirstOrDefault();
        if (randomCollectable == null)
        {
            return;
        }
        CreateCollectable(randomCollectable);
    }


}
