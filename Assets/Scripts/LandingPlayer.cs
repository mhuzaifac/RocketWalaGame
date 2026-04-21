using UnityEngine;

public class LandingPlayer : MonoBehaviour
{
    [SerializeField] private float maxLandingDot = .9f;
    [SerializeField] private float minLandingVelocity = 20f;
    [SerializeField] private ParticleSystem explosionParticle;



    private Rigidbody rb;


    private void Awake()
    {
        

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Debug.Log(  );
        //Debug.Log(transform.up + " " + Vector3.up);
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Friendly"))
        {
            explosionParticle.Play();
            return;  
        }

        if (collision.gameObject.TryGetComponent(out LandingPlatformScript landingPlatform))
        {
            bool flowControl = ProcessLanding(collision);
            if (!flowControl)
            {
                return;
            }
        }
        
    }

    private bool ProcessLanding(Collision collision)
    {

        float dotProduct = Vector3.Dot(transform.up, Vector3.up);

        if (dotProduct < maxLandingDot)
        {
            Debug.Log("crash");
            return false;
        }

        float velocity = rb.linearVelocity.magnitude * 100f;
        if (velocity < minLandingVelocity)
        {
            Debug.Log("too high speed");
            return false;
        }


        collision.gameObject.GetComponent<LandingPlatformScript>().PlaySuccessParticles();
        rb.freezeRotation = true;
        rb.linearVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        return true;
    }
}
