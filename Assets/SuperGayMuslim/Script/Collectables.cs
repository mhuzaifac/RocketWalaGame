using UnityEngine;

public class Collectables : MonoBehaviour
{









    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.TryGetComponent(out Ball ball))
        {
            GameManager.Instance.IncreaseScore();
            DestroySelf();
        }
    }


    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
