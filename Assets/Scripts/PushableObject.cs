using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public float pushForce = 10f;
    public LayerMask pushLayerMask;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool isPushed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void FixedUpdate() // Update -> FixedUpdate (Физику происчитываем тута, меньше вызовов)
    {
        if (isPushed)
        {
            ReturnToInitialPosition();
        }
    }

    void ReturnToInitialPosition()
    {
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, initialPosition, Time.deltaTime * pushForce);
        rb.MovePosition(targetPosition);

        if (Vector2.Distance(transform.position, initialPosition) < 0.01f)
        {
            isPushed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            isPushed = true;
        }
    }
}
