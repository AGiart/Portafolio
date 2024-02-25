using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject torpedoPrefab;

    [SerializeField, Range(0.1F, 1.0F)]
    float fireRate = 0.35F;

    float _fireTimer;

    Vector2 _mousePosition;

    private void Update()
    {
        _fireTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _fireTimer <= 0.0F)
        {
            Fire();
            _fireTimer = fireRate;
        }
    }
    private void Fire()
    {
        Instantiate(torpedoPrefab, firePoint.position, firePoint.rotation);
    }
}
