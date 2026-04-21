using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerRocket : MonoBehaviour
{
    [Header("Input Actioins")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotationAction;


    [Header("Rocket Variables")]
    [SerializeField] private float thrustForce;
    [SerializeField] private float torque;
    [SerializeField] private float rotationForce;
    [SerializeField] private float maxVelocity;

    [Header("Particles")]
    [SerializeField] private ParticleSystem ThrustParticle;
    [SerializeField] private ParticleSystem leftThrustParticle;
    [SerializeField] private ParticleSystem rightThrustParticle;





    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        
    }

    private void OnEnable()
    {
        EnableInputActions();
    }

    private void FixedUpdate()
    {
        ApplyGravity();

        ProcessThrust();

        ProcessRotation();

        ClampingMaxVelocity();


    }

    private void ClampingMaxVelocity()
    {
        Vector3 lastVelocity = _rb.linearVelocity;

        if (Mathf.Abs(lastVelocity.x) > maxVelocity)
        {

            _rb.linearVelocity = new Vector3(
                maxVelocity * (_rb.linearVelocity.x / Mathf.Abs(lastVelocity.x)),
                _rb.linearVelocity.y,
                _rb.linearVelocity.z);
        }

        if (lastVelocity.y < -maxVelocity)
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, -maxVelocity, _rb.linearVelocity.z);
        }
    }

    private void ApplyGravity()
    {
        Vector3 customGravity = Physics.gravity / 2;
        _rb.AddForce(customGravity, ForceMode.Force);
    }

    private void ProcessRotation()
    {
        float dir = -rotationAction.ReadValue<float>();

        _rb.AddRelativeTorque( dir * transform.forward * torque * Time.deltaTime );
        _rb.AddRelativeForce(-dir * transform.right * rotationForce * Time.deltaTime, ForceMode.Force);

        switch (dir)
        {
            case -1:
                rightThrustParticle.Play(); break;
            case 1:
                leftThrustParticle.Play(); break;
            default:
                rightThrustParticle.Stop();
                leftThrustParticle.Stop();
                break;
        }

        


    }

 

    private void ProcessThrust()
    {
        if (thrust.IsPressed() && _rb.linearVelocity.y < maxVelocity)
        {
            ThrustParticle.Play();
            _rb.AddRelativeForce(thrustForce * Vector3.up * Time.deltaTime);
        }
        else
        {
            ThrustParticle.Stop();
        }

        //Debug.Log(_rb.linearVelocity.magnitude);
        //Debug.Log("func");

    }

    private void EnableInputActions()
    {
        thrust.Enable();
        rotationAction.Enable();
    }


}
