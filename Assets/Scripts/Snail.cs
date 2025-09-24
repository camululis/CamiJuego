using UnityEngine;

public class Snail : Enemy
{
    void Start()
    {
        maxHp = 2;
        hp = maxHp;
    }

    protected override void Death()
    {
        animator.SetBool("isDead", true);
        float clipLength = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, clipLength);
        Debug.Log("Snail murio");
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        Debug.Log("Snail tomo dmg");
    }

    protected override void Attack(GameObject target)
    {
        HealthManager playerHealth = target.GetComponent<HealthManager>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(3);
            Debug.Log("Snail ataco");
        }
    }
}

