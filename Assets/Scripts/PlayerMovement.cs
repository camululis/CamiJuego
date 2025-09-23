using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] private LayerMask floor;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    float movement;
    bool isGrounded = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        transform.Translate(movement * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.5f, floor))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (movement < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (movement > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (movement != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = Vector2.up * 3.5f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            animator.SetBool("isDead", true);
            SceneManager.LoadScene("Defeat");
        }
    }
}