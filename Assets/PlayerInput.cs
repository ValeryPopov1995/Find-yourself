using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public enum moveMode { FixedStick, DinamicStick, FloatingStick };
    public moveMode MoveMode = moveMode.FixedStick;
    public enum viewMode { FixedStick, DinamicStick, FloatingStick, Swipe };
    public viewMode ViewMode = viewMode.FixedStick;

    public VariableJoystick MoveStick, ViewStick;

    public static int Sensitivity = 10, MoveSpeed = 10;
    public static Vector3 MoveVector;
    public static Vector2 ViewVector;

    private void Update()
    {
        // move
        MoveVector = transform.forward * MoveStick.Vertical * MoveSpeed +
            transform.right * MoveStick.Horizontal * MoveSpeed;

        // view
        if (ViewMode == viewMode.Swipe)
        {
            ViewVector.x = 0;
            ViewVector.y = 0;
        }
        else
        {
            ViewVector.x = ViewStick.Horizontal * Time.deltaTime * Sensitivity;
            ViewVector.y = ViewStick.Vertical * Time.deltaTime * Sensitivity;
        }
    }
}
