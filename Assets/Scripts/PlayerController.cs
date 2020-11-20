using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public enum moveMode { FixedStick, DinamicStick, FloatingStick };
    public moveMode MoveMode = moveMode.FixedStick;
    public enum viewMode { FixedStick, DinamicStick, FloatingStick, Swipe };
    public viewMode ViewMode = viewMode.FixedStick;

    public VariableJoystick MoveStick, ViewStick;

    public int Sensitivity = 100, MoveSpeed = 10, JumpForce;
    public Transform CameraTarget;
    public LayerMask JumpLayer;

    bool isTouched = false;
    float yRotation;
    static Vector3 MoveVector;
    static Vector2 ViewVector, StartSwipe;
    Rigidbody rb;
    CapsuleCollider capsule;
    Touch tch;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        #region moving
        rb.velocity = transform.forward * MoveStick.Vertical * MoveSpeed +
            transform.right * MoveStick.Horizontal * MoveSpeed + 
            rb.velocity.y * transform.up;
        #endregion
        #region viewing
        if (ViewMode == viewMode.Swipe && isTouched)
        {
            tch = Input.GetTouch(Input.touchCount - 1);
            //if (Input.touchCount == 1 && Input.GetTouch(0).rawPosition.x > Screen.width / 2)
            //{
            //    tch = Input.GetTouch(0);
            //    StartSwipe = tch.rawPosition;
            //}
            //else if (Input.touchCount == 2)
            //{
            //    if (Input.GetTouch(0).rawPosition.x > Screen.width / 2) tch = Input.GetTouch(0);
            //    else if (Input.GetTouch(1).rawPosition.x > Screen.width / 2) tch = Input.GetTouch(1);
            //}

            if (tch.phase == TouchPhase.Began)
            {
                StartSwipe = tch.rawPosition;
            }
            else if (tch.phase == TouchPhase.Moved)
            {
                ViewVector.x = tch.position.x - StartSwipe.x;
                ViewVector.y = tch.position.y - StartSwipe.y;

                ViewVector.x *= Time.deltaTime * Sensitivity / 10;
                ViewVector.y *= Time.deltaTime * Sensitivity / 10;

                StartSwipe = tch.position;
            }
            else ViewVector = Vector2.zero;
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
        #endregion

        
    }

    public void SetSwipeTouched(bool state)
    {
        isTouched = state;
    }

    public void Jump()
    {
        if (Physics.CheckSphere(transform.position - Vector3.up, .1f, JumpLayer.value))
        {
            rb.AddForce(Vector3.up * JumpForce);
            Debug.Log("jump");
        }
    }
}
