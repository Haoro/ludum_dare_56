using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // How long the camera shake should last
    public float shakeDuration = 0.5f;

    // How strong the shaking is
    public float shakeMagnitude = 0.2f;

    // How quickly the shake effect should fade out
    public float dampingSpeed = 1.0f;

    // Original position of the camera to return to
    private Vector3 initialPosition;
    private float currentShakeDuration = 0f;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // If shaking, keep updating camera position
        if (currentShakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            currentShakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            currentShakeDuration = 0f;
        }
    }

    // Call this method to trigger the camera shake
    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;
    }
}
