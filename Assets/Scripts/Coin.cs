using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int value = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollectItem(other);
    }

    public void CollectItem(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinsManager.Instance.AddScore(value);
            Destroy(gameObject);
        }
    }
}
