using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float destructionDelay = 5f;

    void Start()
    {
        Destroy(gameObject, destructionDelay);
    }
}
