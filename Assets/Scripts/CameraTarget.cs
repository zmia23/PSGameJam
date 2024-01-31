using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float followSpeed = 5f;
    [SerializeField] float maxDistanceFromPlayer = 5f;

    private Camera mainCamera;
    private Transform crosshair;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;

        // Find the crosshair GameObject in the scene
        crosshair = GameObject.Find("Crosshair").transform;
        if (crosshair == null)
        {
            Debug.LogError("Crosshair GameObject not found in the scene!");
        }
    }

    private void Update()
    {
        if (crosshair == null)
        {
            return;
        }

        // Get the mouse position and convert it to world space
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        // Update the position of the crosshair
        crosshair.position = mousePosition;

        // Calculate the direction from the player to the crosshair
        Vector3 directionToCrosshair = crosshair.position - player.position;
       
        // Calculate the target position for the camera, clamped within a certain distance from the player
        Vector3 targetPosition = player.position + Vector3.ClampMagnitude(directionToCrosshair, maxDistanceFromPlayer);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
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
