using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform explosionParent;
    BoxCollider boxCollider;

    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        if (GetComponent<BoxCollider>() == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        //Change B
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity, explosionParent);                
        Destroy(gameObject);
    }
}
