using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustHandler : MonoBehaviour
{
    public ParticleSystem dust;
    private bool isPlayerColliding = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dust"))
        {
            Debug.Log("Dust on");
            isPlayerColliding = true;
            ToggleParticleEffect(isPlayerColliding);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.CompareTag("Dust"))
        {
            Debug.Log("Dust off");
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
