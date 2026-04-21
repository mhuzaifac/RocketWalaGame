using UnityEngine;

public class FanScript : MonoBehaviour
{

    [SerializeField] private float forceAmount;

    private void Awake()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        other.gameObject.TryGetComponent(out Rigidbody rb);
        rb.AddForce(forceAmount * transform.right * -1);
    }

}
