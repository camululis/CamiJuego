using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = FindFirstObjectByType<HealthManager>().transform;
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        rb.linearVelocity = directionToPlayer * speed;
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
}
