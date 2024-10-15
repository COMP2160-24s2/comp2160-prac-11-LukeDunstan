using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{

    private float maxOrthoZoom = 10;
    private float minOrthoZoom = 2;
    private float maxPerspZoom;
    private float minPerspZoom;

    

    private Actions actions;
    private InputAction scrollAction;
    private int scrollNormalizer = 120;

    // Start is called before the first frame update
    void Awake()
    {
        actions = new Actions();
        scrollAction = actions.camera.zoom;
    }

    void OnEnable()
    {
        scrollAction.Enable();
    }

    void OnDisable()
    {
        scrollAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float zoom = scrollAction.ReadValue<float>() / scrollNormalizer;
        Debug.Log(zoom);

        if (Camera.main.orthographic)
        {
            if (Camera.main.orthographicSize < 2){
                Camera.main.orthographicSize = 0;
            } else if ( Camera.main.orthographicSize > 10){
                Camera.main.orthographicSize = 10;
            }

            Camera.main.orthographicSize += zoom;
        }
        else
        {

            
            Camera.main.fieldOfView += zoom;
        }
    }
}
