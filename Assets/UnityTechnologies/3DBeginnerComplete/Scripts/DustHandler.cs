using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustHandler : MonoBehaviour
{
    public ParticleSystem dust;
    private bool isPlayerColliding = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rug"))
        {
            isPlayerColliding = true;
            ToggleParticleEffect(isPlayerColliding);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Rug"))
        {
            isPlayerColliding = false;
            ToggleParticleEffect(isPlayerColliding);
        }
    }

    private void ToggleParticleEffect(bool isActive)
    {
        if (dust != null)
        {
            if (isActive)
            {
                dust.Play();
            }
            else
            {
                dust.Stop();
            }
        }
    }
}
