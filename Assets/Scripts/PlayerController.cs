using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public enum moveMode { FixedStick, DinamicStick, FloatingStick };
    public moveMode MoveMode = moveMode.FixedStick;
    public enum viewMode { FixedStick, DinamicStick, FloatingStick, Swipe };
    public viewMode ViewMode = viewMode.FixedStick;
    public GameObject EventTriggerSwipeArea;

    public VariableJoystick MoveStick, ViewStick;

    public int Sensitivity = 100, MoveSpeed = 10;
    public Transform CameraTarget;

    bool isGround = false;
    bool swipeTouched = false;
    float yRotation;
    public static Vector3 MoveVector;
    public static Vector2 ViewVector;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // move
        rb.velocity = transform.forward * MoveStick.Vertical * MoveSpeed +
            transform.right * MoveStick.Horizontal * MoveSpeed + 
            rb.velocity.y * transform.up;

        // view
        if (ViewMode == viewMode.Swipe)
        {
            /*if (tch.phase == TouchPhase.Began) swipeStartPos = tch.rawPosition;
            else if (tch.phase == TouchPhase.Moved)
            {
                xmouse = tch.position.x - swipeStartPos.x;
                ymouse = tch.position.y - swipeStartPos.y;

                xmouse *= Time.deltaTime * Sensitivity / 10;
                ymouse *= Time.deltaTime * Sensitivity / 10;

                swipeStartPos = tch.position;
            }
            else
            {
                xmouse = 0f;
                ymouse = 0f;
            }*/
        }
        else
        {
            ViewVector.x = ViewStick.Horizontal * Time.deltaTime * Sensitivity;
            ViewVector.y = ViewStick.Vertical * Time.deltaTime * Sensitivity;
        }
        transform.Rotate(Vector3.up * ViewVector.x);
        yRotation -= ViewVector.y;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        CameraTarget.localRotation = Quaternion.Euler(yRotation, 0, 0);
    }

    public void SetSwipeTouched(bool state)
    {
        swipeTouched = state;
    }
}
