using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    [Min(0f)]
    [SerializeField]
    private float veloocity = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.velocity = transform.forward * veloocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        CreateExplosionEffect();
    }
    private void CreateExplosionEffect()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
