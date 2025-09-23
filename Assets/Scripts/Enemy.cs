using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHp = 2;
    protected int hp;

    protected Animator animator;
    protected Rigidbody2D enemyRb;

    void Awake()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    public virtual void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(1);
        }
    }

    protected abstract void Death();
    protected abstract void Attack(GameObject target);
}
