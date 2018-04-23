using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.2f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;

	bool isShaking;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		isShaking = false;
	}

	void Start()
	{
		shakeDuration = 0f;
		shakeAmount = 0.2f;
	}

	void Update()
	{
		if (!isShaking)
		{
			originalPos = camTransform.localPosition;
		}

		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
			isShaking = true;
		}
		else
		{
			shakeDuration = 0f;
			isShaking = false;
		}
	}
}
