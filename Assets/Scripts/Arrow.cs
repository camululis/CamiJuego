using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D arrowRb;
    [SerializeField] private Animator arrowAnimator;
    private Vector3 Direction;

    private void OnEnable()
    {
        if (arrowRb != null)
        {
            arrowRb.linearVelocity = Vector2.zero;   
        }
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (arrowRb != null)
        {
            arrowRb.linearVelocity = Direction * speed;
        }
    }

    private void DestroyArrow()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            DestroyArrow();
        }
    }
}
