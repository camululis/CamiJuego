using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private Transform player;

    private bool isFacingLeft = true;

    void Update()
    {
        bool isPlayerLeft = transform.position.x > player.transform.position.x;
        Flip(isPlayerLeft);
    }

    private void Flip(bool isPlayerLeft)
    {
        if((isFacingLeft && !isPlayerLeft) || (!isFacingLeft && isPlayerLeft))
        {
            isFacingLeft = !isFacingLeft;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
