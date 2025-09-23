using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    float lastShoot;
    Rigidbody2D rb;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Time.time > lastShoot + 0.25f)
        {
            lastShoot = Time.time;
            animator.SetTrigger("Attack");
            Shoot();
        }
    }

        private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        Vector3 spawnPosition = transform.position + direction * 0.5f;
        ArrowPool.Instance.RequestArrow(spawnPosition, direction);
    }
}
