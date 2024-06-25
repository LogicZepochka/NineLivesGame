using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    AudioSource dirtStepAudio;
    [SerializeField] private float movingSpeed = 5f;

    private Vector2 direction;
    [SerializeField] private Animator animator;


    private float inactivityTimer = 0f;
    private bool canSit = false;
    private const float inactivityThreshold = 15f;
    [SerializeField] private DialogeWindow _dialogeWindow;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Awake()
    {
        dirtStepAudio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (!_dialogeWindow.IsPlaying )
        {
            if (dirtStepAudio != null)
            {
                if (animator.GetFloat("Speed") > 0)
                {
                    if (!dirtStepAudio.isPlaying)
                    {
                        dirtStepAudio.Play();
                    }
                }
                else
                {
                    dirtStepAudio.Stop();
                }
            }
           


            rb.MovePosition(rb.position + direction * movingSpeed * Time.fixedDeltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.speed = 2;
                movingSpeed = 10;
                if (dirtStepAudio != null)
                {
                    dirtStepAudio.pitch = 1.2f;
                } 
            }
            else
            {
                animator.speed = 1;
                movingSpeed = 5;
                if (dirtStepAudio != null)
                {
                    dirtStepAudio.pitch = 0.4f;
                }
                   
            }

            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);

        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            dirtStepAudio.Stop();
        }


        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            if (canSit)
            {
                canSit = false;
            }
            inactivityTimer = Time.time;
        }
        if ((Time.time - inactivityTimer) > inactivityThreshold)
        {
            canSit = true;
        }
        animator.SetBool("CanSit", canSit);
    }

  



}
