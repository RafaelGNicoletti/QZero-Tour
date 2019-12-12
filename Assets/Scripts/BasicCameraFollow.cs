using UnityEngine;
using System.Collections;

// FONTE: Isometric Starter Kit do próprio Unity

public class BasicCameraFollow : MonoBehaviour 
{
    [System.Serializable]
    public class CameraClamp
    {
        public float min, max;
    }

	private Vector3 startingPosition;
    public bool usingClamp = false;
    public Transform followTarget;
	private Vector3 targetPos;
    public CameraClamp clampX;
    public CameraClamp clampY;
	public float moveSpeed;
	
	void Start()
	{
		startingPosition = transform.position;
	}

	void Update () 
	{
		if(followTarget != null)
		{
            if (usingClamp)
            {
                float positionX = Mathf.Clamp(followTarget.position.x, clampX.min, clampX.max);
                float positionY = Mathf.Clamp(followTarget.position.y, clampY.min, clampY.max);
                targetPos = new Vector3(positionX, positionY, transform.position.z);
            }

            else
            {
			    targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
            }
			Vector3 velocity = (targetPos - transform.position) * moveSpeed;
			transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
		}
	}
}

