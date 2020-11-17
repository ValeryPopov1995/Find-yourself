using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Character settings")]
    public float MoveSpeed = 10f, JumpForce = 10f, Sensitivity = 120f;
    public VariableJoystick JoystickMove, JoystickView;
    public Transform CamEmpty;

    bool isGround = false;
    float xmouse, ymouse;
    Vector3 moveVector;
    float yRotation;
    bool swipeTouched = false;

    void Update()
    {
        #region rotation
        transform.Rotate(Vector3.up * xmouse);
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        CamEmpty.localRotation = Quaternion.Euler(yRotation, 0, 0);
        #endregion

        #region moving result
        moveVector = transform.forward * JoystickMove.Vertical * MoveSpeed +
            transform.right * JoystickMove.Horizontal * MoveSpeed;
        // rigid body velosity
        #endregion
    }

    public void SetSwipeTouched(bool state)
    {
        swipeTouched = state;
    }
}
