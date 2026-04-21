using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraFollowSpeed = 5f;
    [SerializeField] private float cameraRotationSpeed = 1.0f;
    [SerializeField] private Vector3 followOffset = new Vector3(0f,.72f, -3.07f);

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 playerPreviousPosition;




    private void Start()
    {
        playerPreviousPosition = playerTransform.position;
        //followOffset = transform.position - playerPreviousPosition;

        targetPosition = playerTransform.position + followOffset;
        transform.LookAt(targetPosition);
    }





    private void LateUpdate()
    {

        FollowTarget();


    }

    private void FollowTarget()
    {
        Vector3 playerCurrentPosition = playerTransform.position;
        Vector3 direction = playerCurrentPosition - playerPreviousPosition;
        playerPreviousPosition = playerTransform.position;
        direction.Normalize();
        if (direction != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(direction);        
            targetPosition = playerCurrentPosition + targetRotation * followOffset;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraRotationSpeed * Time.deltaTime);
    }


   





}
