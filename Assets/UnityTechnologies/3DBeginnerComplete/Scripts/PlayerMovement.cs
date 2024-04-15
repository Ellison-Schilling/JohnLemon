using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    
    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    Vector3 center_screen;
    Vector3 to_mouse;
    float desired_Angle;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        
        MoveAction.Enable();
    }

    void FixedUpdate ()
    {
        /* The character is always in the center of the screen.
         * By comparing the position of the mouse to the center of the screen a vector describing the 
         * position of the mouse to the character can be created.
         * 
         * To find the angle created by this vector compared to the angle of the world
         * we take the dot product of the vector and a reference vector that is 0 degrees from the world angle
         * , divide it by the product of the two vectors magnitudes and running this through arccos.
         * 
         * We will use the vector created by subtracting the center of the screen vector from the mouse position vector
         * and call this vector a.
         * a = [ x
         *       y 
         *       (z = 0) ]
         * The refrence vector will be i.
         * i = [ 0
         *       1
         *       0 ]
         * so the dot product of these vectors will always come to be y.
         * i's magnitude is obviously 1.
         * if we normalize a then its magnitude will also be 1.
         * this means arccos(a*i/||a||*||i||) can be simplified to arccos(y)
         */
        center_screen.Set((Screen.width/2), (Screen.height/2), 0);
        to_mouse = Input.mousePosition - center_screen;
        to_mouse.Normalize();
        desired_Angle = (float) Math.Acos(to_mouse.y);

        // Converts radian angle to degrees and tracks which half it is on.
        desired_Angle = (180f / (float) Math.PI) * desired_Angle;
        if (to_mouse.x < 0) 
        { 
            desired_Angle = desired_Angle * -1; 
        }

        //
        //Debug.Log(desired_Angle);
        m_Rotation.eulerAngles = new Vector3(0f, desired_Angle, 0f);

        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }
}