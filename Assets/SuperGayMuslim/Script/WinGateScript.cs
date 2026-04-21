using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGateScript : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
