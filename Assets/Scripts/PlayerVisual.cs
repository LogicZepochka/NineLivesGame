using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer rbSprite;
    private float inputHorizontal;
    private const string IS_RUNNING = "isRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }
}
