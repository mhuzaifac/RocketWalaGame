using UnityEngine;

public class StartingPlatformScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerPos;



    private void Start()
    {
        player.transform.position = transform.position;
    }

}
