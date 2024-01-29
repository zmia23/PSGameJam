using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float threshold;

    private IPointerProvider pointerProvider;

    private void Awake()
    {
        // Initialize the pointer provider
        if (IsControllerConnected())
        {
            pointerProvider = new ControllerPointerProvider();
        }
        else
        {
            pointerProvider = new MousePointerProvider();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pointerPos = pointerProvider.GetPointerPosition(cam);

        Vector3 targetPos = player.position + pointerPos / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, player.position.x - threshold, player.position.x + threshold);
        targetPos.y = Mathf.Clamp(targetPos.y, player.position.y - threshold, player.position.y + threshold);

        transform.position = targetPos;
    }

    private bool IsControllerConnected()
    {
        return Input.GetJoystickNames().Length > 0;
    }
}

// Interface for pointer provider
public interface IPointerProvider
{
    Vector3 GetPointerPosition(Camera cam);
}

// Implementation for mouse pointer provider
public class MousePointerProvider : IPointerProvider
{
    public Vector3 GetPointerPosition(Camera cam)
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
}

// Implementation for controller pointer provider
public class ControllerPointerProvider : IPointerProvider
{
    public Vector3 GetPointerPosition(Camera cam)
    {
        float horizontalInput = Input.GetAxisRaw("ControllerHorizontal");
        float verticalInput = Input.GetAxisRaw("ControllerVertical");

        Vector3 pointerPos = new Vector3(horizontalInput, verticalInput, 0f);

        return cam.ScreenToWorldPoint(pointerPos);
    }
}
