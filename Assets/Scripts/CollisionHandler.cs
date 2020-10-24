using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Death explosion effects prefab on player ship")][SerializeField] GameObject deathExplosionFX;
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 2f;

    private void OnTriggerEnter(Collider other)
    {        
        SendMessage("PlayerDeath");
        deathExplosionFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void ReloadScene() //String referenced in CollisionHandler.cs in OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
