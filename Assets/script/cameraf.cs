using UnityEngine;

public class cameraf : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(0f, 1f, -4f);
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}