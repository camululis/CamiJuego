using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private int poolSize = 5;
    //List
    private List<Arrow> arrowList = new List<Arrow>();

    private static ArrowPool instance;
    public static ArrowPool Instance { get { return instance; } }

    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Pool
    void Start()
    {
        AddArrowsToPool(poolSize);
    }

    private void AddArrowsToPool(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject arrowObj = Instantiate(arrowPrefab);
            arrowObj.SetActive(false);
            Arrow arrow = arrowObj.GetComponent<Arrow>();
            arrowList.Add(arrow);
            arrowObj.transform.parent = transform;
        }
    }

    public Arrow RequestArrow(Vector3 spawnPosition, Vector3 direction)
    {
        foreach (Arrow arrow in arrowList)
        {
            if (!arrow.gameObject.activeSelf)
            {
                PrepareArrow(arrow, spawnPosition, direction);
                return arrow;
            }
        }
        AddArrowsToPool(1);
        return RequestArrow(spawnPosition, direction);
    }

    private void PrepareArrow(Arrow arrow, Vector3 spawnPosition, Vector3 direction)
    {
        arrow.transform.position = spawnPosition;
        arrow.gameObject.SetActive(true);
        arrow.SetDirection(direction);
    }
}
