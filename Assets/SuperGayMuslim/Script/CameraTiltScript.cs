using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTiltScript : MonoBehaviour
{
    [SerializeField] private float tiltSpeed = 10f;
    [SerializeField] private float maxHorizontalTilt = 25f;
    [SerializeField] private float maxVerticalTilt = 10f;




    private float finalTiltX = 0f;
    private float finalTiltZ = 0f;

    private void LateUpdate()
    {
        Tilt();

    }

    private void Tilt()
    {
        Vector2 input = GetInput();

        if (input != Vector2.zero)
        {
            float targetTiltX = input.x * maxHorizontalTilt;
            float targetTiltZ = input.y * maxVerticalTilt;
            finalTiltX = Mathf.Lerp(finalTiltX, targetTiltX, tiltSpeed * Time.deltaTime);
            finalTiltZ = Mathf.Lerp(finalTiltZ, targetTiltZ, tiltSpeed * Time.deltaTime);
            
        }
        else
        {
            finalTiltX = Mathf.Lerp(finalTiltX, 0f, tiltSpeed * Time.deltaTime);
            finalTiltZ = Mathf.Lerp(finalTiltZ, 0f, tiltSpeed * Time.deltaTime);
        }

        transform.localRotation = Quaternion.Euler(finalTiltZ, 0f, finalTiltX);
    }

    private Vector2 GetInput()
    {
        float inputX = 0f;
        float inputZ = 0f;

        if (Keyboard.current.dKey.isPressed) { inputX++; }
        else if (Keyboard.current.aKey.isPressed) { inputX--; }
        if (Keyboard.current.sKey.isPressed) { inputZ--; }
        else if (Keyboard.current.wKey.isPressed) { inputZ++; }
        
         
        
        
        
        inputX = Mathf.Clamp(inputX, -1f, 1f);
        inputZ = Mathf.Clamp(inputZ, -1f, 1f);
        return new Vector2(inputX,inputZ);
    }



















}
