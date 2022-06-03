using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
[System.Serializable]
public class IntUnityEvent : UnityEvent<int>
{
}

public class CollectableTrigger : MonoBehaviour
{
    [SerializeField]
    private string medicalPillTag= "MedicalPill";

    [SerializeField]
    private string ammoTag = "Ammo";

    [SerializeField, Min(0)]
    private int pillValue = 1;

    [SerializeField, Min(0)]
    private int ammoValue = 2;

    [Header("Events")]
    [SerializeField]
    private IntUnityEvent onCollectLives;

    [SerializeField]
    private IntUnityEvent onCollectAmmo;

    private CollectableController collectableController;
    private Player player;

    private void Awake()
    {
        collectableController = FindObjectOfType<CollectableController>();
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        var colected = false;
        if (IsMedicalPill(otherGameObject))
        {
            //player.AddLives(pillValue);
            onCollectLives.Invoke(pillValue);
            colected = true;
        }
        if(IsAmmo(otherGameObject))
        {
            //player.AddAmmo(ammoValue);
            onCollectAmmo.Invoke(ammoValue);
            colected = true;
        }
        if(colected)
        {
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            collectableController.CreateCollebtable();
        }
    }

    private bool IsMedicalPill(GameObject obj)
    {
        return obj.CompareTag(medicalPillTag);
    }

    private bool IsAmmo(GameObject obj)
    {
        return obj.CompareTag(ammoTag);
    }
}
