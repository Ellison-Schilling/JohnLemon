using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rug : MonoBehaviour
{
    public GameObject dustParticleSystem;
    private bool isBeingWalkedOn = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            isBeingWalkedOn = true;
            ActivateDustParticles();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            isBeingWalkedOn = false;
            DeactivateDustParticles();
        }
    }

    private void ActivateDustParticles()
    {
        dustParticleSystem.SetActive(true);
    }

    private void DeactivateDustParticles()
    {
        dustParticleSystem.SetActive(false);
    }
}
