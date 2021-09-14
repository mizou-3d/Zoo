using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 0.1f;
    float x_sensi= 3;
    float y_sensi = 3;
    public new GameObject camera;
    public Vector3 cameraAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCon();
        cameraCon();
    }

    void moveCon()
    {
        Transform trans = transform;
        transform.position = trans.position;
        trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * playerSpeed;
        trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * playerSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * playerSpeed*2;
            trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * playerSpeed*2;
        }
    }

    void cameraCon()
    {
        float x_Rot = Input.GetAxis("Mouse X");
        float y_Rot = Input.GetAxis("Mouse Y");
        x_Rot *= x_sensi;
        y_Rot *= y_sensi;
        this.transform.Rotate(0, x_Rot, 0);
        camera.transform.Rotate(-y_Rot, 0, 0);
        cameraAngle = camera.transform.localEulerAngles;
        if(cameraAngle.x < 280 && cameraAngle.x > 180)
        {
            cameraAngle.x = 280;
        }
        if(cameraAngle.x > 45 && cameraAngle.x < 180)
        {
            cameraAngle.x = 45;
        }
        cameraAngle.y = 0;
        cameraAngle.z = 0;
        camera.transform.localEulerAngles = cameraAngle;
    }
    
}
