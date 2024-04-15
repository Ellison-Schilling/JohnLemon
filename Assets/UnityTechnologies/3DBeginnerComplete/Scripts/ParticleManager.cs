using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleManager : MonoBehaviour
{
    public GameObject dustParticlePrefab;
    private GameObject currentDustParticle;

    public void SpawnDustParticle(Vector3 position)
    {
        // If there's no current dust particle, spawn a new one
        if (currentDustParticle == null)
        {
            currentDustParticle = Instantiate(dustParticlePrefab, position, Quaternion.identity);
        }
        else
        {
            // If there's a current dust particle, update its position
            currentDustParticle.transform.position = position;
        }
    }

    public void DestroyDustParticle()
    {
        // Destroy the current dust particle if it exists
        if (currentDustParticle != null)
        {
            Destroy(currentDustParticle);
            currentDustParticle = null;
        }
    }
}