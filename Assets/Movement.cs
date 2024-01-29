using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private IInputProvider inputProvider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Initialize the input provider
        if (IsControllerConnected())
        {
            inputProvider = new ControllerInputProvider();
        }
        else
        {
            inputProvider = new KeyboardInputProvider();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = inputProvider.GetInput();
        movementInput.Normalize();
        
        rb.velocity = movementInput * speed * Time.fixedDeltaTime;
    }

    private bool IsControllerConnected()
    {
        return Input.GetJoystickNames().Length > 0;
    }
}

// Interface for input provider
public interface IInputProvider
{
    Vector2 GetInput();
}

// Implementation for keyboard input provider
public class KeyboardInputProvider : IInputProvider
{
    public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}

// Implementation for controller input provider
public class ControllerInputProvider : IInputProvider
{
    public Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("ControllerHorizontal"), Input.GetAxisRaw("ControllerVertical"));
    }
}