using UnityEngine;

public class CameraMovenment : MonoBehaviour
{
    [Range(.01f, .5f)]
    public float MoveLerp, ViewLerp;
    public Transform StartTarget;
    public static Transform TargetPosition;

    private void Start()
    {
        TargetPosition = StartTarget;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPosition.position, MoveLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, TargetPosition.rotation, ViewLerp);
    }
}
