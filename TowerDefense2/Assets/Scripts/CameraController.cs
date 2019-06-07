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
    public float rotateAngleX = -53f;

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false; // this pole vaja, aga siis selgem millest räägitakse
            return;
        }

        // DON'T MOVE with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }

        //if (Input.GetKey("w"))
        //{
        //    //transform.Translate(Vector3.forward * Time.deltaTime * panSpeed, Space.Self);
        //    transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        //}

        //if (Input.GetKey("s"))
        //{
        //    //transform.Translate(Vector3.back * Time.deltaTime * panSpeed, Space.Self);
        //    transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        //}

        //if (Input.GetKey("d"))
        //{
        //    //transform.Translate(Vector3.right * Time.deltaTime * panSpeed, Space.Self);
        //    transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        //}

        //if (Input.GetKey("a"))
        //{
        //    //transform.Translate(Vector3.left * Time.deltaTime * panSpeed, Space.Self);
        //    transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        //}

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * panSpeed, Space.Self);          
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * panSpeed, Space.Self);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * panSpeed, Space.Self);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * panSpeed, Space.Self);
        }

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
        }

        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed, Space.World);
        }

        // ZOOM IN/OUT
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

}
