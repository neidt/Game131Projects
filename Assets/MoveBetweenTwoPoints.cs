using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{

    public Vector3 startPosition;
    public Vector3 endPosition;
    public bool isMovingToStart = true;
    public float speed = 4.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float moveMagnitude = speed * Time.deltaTime;
        if (startPosition != endPosition)
        {
            while (moveMagnitude > 0)
            {
                moveMagnitude = ResolveMovement(moveMagnitude);
            }
        }
    }

    private float ResolveMovement(float moveMagnitude)
    {
        Vector3 currentTarget = isMovingToStart ? startPosition : endPosition;
        Vector3 toCurrentTarget = currentTarget - transform.position;
        float targetDelta = Vector3.Distance(currentTarget, transform.position);
        if (moveMagnitude < targetDelta)
        {
            transform.position += toCurrentTarget.normalized * moveMagnitude;
            return 0;
        }
        else
        {
            transform.position = currentTarget;
            isMovingToStart = !isMovingToStart;
            return moveMagnitude - toCurrentTarget.magnitude;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPosition, endPosition);
    }
}
