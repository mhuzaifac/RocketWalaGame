using UnityEngine;

public class LandingPlatformScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem successParticle;


    public void PlaySuccessParticles()
    {
        successParticle.Play();
    }


    

}
