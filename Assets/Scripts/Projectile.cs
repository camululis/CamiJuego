using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;

    void OnEnable()
    {
        player = FindFirstObjectByType<HealthManager>().transform;
        rb = GetComponent<Rigidbody2D>();
        LaunchProjectile();
        StartCoroutine(DestroyProjectile());
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void LaunchProjectile()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.linearVelocity = directionToPlayer * speed; 
    }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(3);
            gameObject.SetActive(false);
        }
    }
}
