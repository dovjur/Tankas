using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class AntiTankMineTrigger : MonoBehaviour
{
    [SerializeField]
    private string antiTankMineTag = "ATMine";

    [SerializeField, Min(0f)]
    private float minExplosionForce = 3f;

    [SerializeField, Min(0f)]
    private float maxExplosionForce = 5f;

    [Header("Events")]
    [SerializeField]
    private UnityEvent onTriggerMine;

    [Header("Effects")]
    [SerializeField]
    private GameObject explosionPrefab;

    private AntiTankMineController antiTankMineController;
    private Rigidbody rb;
    private Player player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
        antiTankMineController = FindObjectOfType<AntiTankMineController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var otherGameObject = collision.gameObject;
        if (IsAntiTankMine(otherGameObject))
        {
            CreateExplosionEffect(otherGameObject.transform.position);
            AddExplosionForce();
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            onTriggerMine.Invoke();
            //player.TakeDemage();
            //antiTankMineController.CreateMine();
        }
    }

    private bool IsAntiTankMine(GameObject obj)
    {
        return obj.CompareTag(antiTankMineTag);
    }

    private void AddExplosionForce()
    {
        var force = Random.Range(minExplosionForce,maxExplosionForce);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        Instantiate(explosionPrefab,position, Quaternion.identity);
    }
}
