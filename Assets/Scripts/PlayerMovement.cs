using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public float speed;
    private Rigidbody2D rb;
    private IInputProvider inputProvider;
    private Vector2 playerVelocity;
    private Animator animator;


    private void Awake()
    {
        mainCamera = Camera.main;

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

        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        HandleAnimation();
        HandleRotation();
    }
    private void FixedUpdate()
    {
        Vector2 movementInput = inputProvider.GetInput();
        movementInput.Normalize();
        
        rb.velocity = movementInput * speed * Time.fixedDeltaTime;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerVelocity = rb.velocity;
    }
    private void HandleRotation()
    {
        if (transform.position.x > GetMouseWorldPosition().x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 360, 0, 0);
        }
    }
    private void HandleAnimation()
    {
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    public void StopMovement()
    {
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public Vector2 GetPlayerVelocity()
    {
        return playerVelocity;
    }

    private bool IsControllerConnected()
    {
        return Input.GetJoystickNames().Length > 0;
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        
        return worldPosition;

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