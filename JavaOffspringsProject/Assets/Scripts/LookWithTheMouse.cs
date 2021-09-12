using UnityEngine;
using UnityEngine.EventSystems;

public class LookWithTheMouse : MonoBehaviour
{
    public Transform rotatePlayersBody;
    private float mouseControl;
    private float xAxisRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        //Speed of mouse
        mouseControl = 20;
        //Rotation of the mouse
        xAxisRotation = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        // to check if we hovering the UI ( for the inventory)
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        //"Mouse X" in project settings , edit ->project set->input manager
        float mouseXaxis = Input.GetAxis("Mouse X") * mouseControl * Time.deltaTime;
        float mouseYaxis = Input.GetAxis("Mouse Y") * mouseControl * Time.deltaTime;

        //rotate players body in vector3.up based on mouse X
        rotatePlayersBody.Rotate(Vector3.up * mouseXaxis);

        //Rotation based on mouse Y
        xAxisRotation -= mouseYaxis;
        //Clamping the rotation between 90 degrees
        xAxisRotation = Mathf.Clamp(xAxisRotation, -90f, 90f);
        
        //Aplly the rotation
        transform.localRotation = Quaternion.Euler(xAxisRotation, 0f, 0f);
    }
}
