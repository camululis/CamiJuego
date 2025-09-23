using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    [SerializeField] private Image healthBar;
    [SerializeField] private int maxHp = 15;
    [SerializeField] private int hp;

    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        hp = maxHp;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        healthBar.fillAmount = hp / 15f;
        animator.SetTrigger("Hurt");
    }

    void Update()
    {
        if (hp <= 0)
        {
            hp = 0;
            animator.SetBool("isDead", true);

            if (OnPlayerDeath != null)
            {
                OnPlayerDeath.Invoke();
            }
        }        
    }
}
