using UnityEngine;
using System.Collections.Generic;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int poolSize = 10;
    
    private List<Projectile> projectileList = new List<Projectile>();

    void Start()
    {
        AddProjectilesToPool(poolSize);
    }

    private void AddProjectilesToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject projectileObj = Instantiate(projectilePrefab);
            projectileObj.SetActive(false);

            Projectile projectile = projectileObj.GetComponent<Projectile>();
            projectileList.Add(projectile);

            projectile.transform.parent = transform;
        }
    }

    public Projectile RequestProjectile(Vector3 spawnPosition, Vector3 direction)
    {
        foreach (Projectile projectile in projectileList)
        {
            if (!projectile.gameObject.activeSelf)
            {
                PrepareProjectile(projectile, spawnPosition, direction);
                return projectile;
            }
        }
        return null;
    }

    private void PrepareProjectile(Projectile projectile, Vector3 spawnPosition, Vector3 direction)
    {
        projectile.transform.position = spawnPosition;
        projectile.gameObject.SetActive(true);
    }
}
