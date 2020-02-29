using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private ScoreManager scoreManager;

    private Vector3 newDestination;
    private Vector3 previousDestination;
    private Vector3 cameraOffset = new Vector3 (0, 3, -10);
    private float progress;

    // Start is called before the first frame update
    void Start()
    {
        newDestination = transform.position;
        previousDestination = newDestination;
    }

    // Update is called once per frame
    void Update()
    {
        if (newDestination != previousDestination)
        {
            progress += Time.deltaTime / moveSpeed;
            transform.position = Vector3.Lerp(previousDestination, newDestination, progress);

            if (progress >= 1)
            {
                previousDestination = newDestination;
                transform.position = newDestination;
            }
        }
    }

    public void MoveCamera(Vector3 destination)
    {
        newDestination = destination + cameraOffset;
        if (progress < 1)
        {
            progress = (transform.position.y - previousDestination.y) / (newDestination.y - previousDestination.y);
        }
        else
        {            
            progress = 0;
        }
    }
}
