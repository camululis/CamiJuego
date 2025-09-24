using UnityEngine;
using System.Collections;

public class Bee : Enemy
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoots;

    void Start()
    {
        maxHp = 3;
        hp = maxHp;
        StartCoroutine(Shoot());
    }

    protected override void Death()
    {
        animator.SetBool("isDead", true);
        float clipLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, clipLength);
        Debug.Log("Bee murio");
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
    }

    protected override void Attack(GameObject target)
    {
        HealthManager playerHealth = target.GetComponent<HealthManager>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(3);
            Debug.Log("Bee ataco al player");
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShoots);
            Projectile projectile = FindFirstObjectByType<ProjectilePool>().RequestProjectile(transform.position, Vector3.left);
            if (projectile == null)
            {
                Debug.Log("no hay mas proyectiles");
            }
        }
    }
}
