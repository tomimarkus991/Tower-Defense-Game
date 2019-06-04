using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 40f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;
    public float rotateSpeed = 60f;

    void Update()
    {
        // DON'T MOVE with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }
        // Movement
        //if (Input.GetMouseButton(0))
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
        //    transform.Translate(Vector3.left * Time.deltaTime * panSpeed * (Input.mousePosition.x - Screen.width * 0.5f) / (Screen.width * 0.5f), Space.World);
        //    transform.Translate(Vector3.up * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);
        //    transform.Translate(Vector3.down * Time.deltaTime * panSpeed * (Input.mousePosition.y - Screen.height * 0.5f) / (Screen.height * 0.5f), Space.World);
        //}
        //else
        //{
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * panSpeed, Space.Self);
        }

        else if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * Time.deltaTime * panSpeed, Space.Self);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed, Space.Self);
        }

        else if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * panSpeed, Space.Self);
        }

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
        }

        else if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed, Space.World);
        }
        //}

        // ZOOM IN/OUT
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

}
