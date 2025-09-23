using UnityEngine;

public class Bee : Enemy
{
    void Start()
    {
        maxHp = 3;
        hp = maxHp;
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
}
