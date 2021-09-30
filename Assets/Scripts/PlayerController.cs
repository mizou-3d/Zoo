using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float playerSpeed = 0.1f;
    float x_sensi= 3;
    float y_sensi = 3;
    public new GameObject camera;
    public Vector3 cameraAngle;
    GameController gameController;
    bool ganbareru;
    //float ganbaruTime = 5f;
    //public Image ganbaru_gauge;
    public Animator playerAnimator;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isPlaying)
        {
            moveCon();
            cameraCon();
        }

        /*if (!ganbareru)
        {
            ganbaruTime += Time.deltaTime;
            ganbaru_gauge.fillAmount += 0.2f * Time.deltaTime;
            if(ganbaruTime >= 5)
            {
                ganbareru = true;
                ganbaruTime = 5f;
            }
        }*/

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PickTrash") || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Feed"))
        {
            playerSpeed = 0;
        }
        else
        {
            playerSpeed = 0.1f;
        }
    }

    void moveCon()
    {
        playerAnimator.SetBool("is_Running", false);
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if(velocity.magnitude > 0.1f)
        {
            playerAnimator.SetFloat("Speed", velocity.magnitude);
        }
        else
        {
            playerAnimator.SetFloat("Speed", 0f);
        }

        Transform trans = transform;
        transform.position = trans.position;
        trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * playerSpeed;
        trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * playerSpeed;
        if (Input.GetKey(KeyCode.LeftShift)/* && ganbareru*/)
        {
            playerAnimator.SetBool("is_Running", true);
            /*ganbaruTime -= Time.deltaTime;
            ganbaru_gauge.fillAmount -= 0.2f * Time.deltaTime;
            if(ganbaruTime <= 0)
            {
                ganbareru = false;
            }*/
            trans.position += trans.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * playerSpeed*2;
            trans.position += trans.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal") * playerSpeed*2;
        }
        /*if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ganbareru = false;
        }*/
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

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "Trash")
            {
                playerAnimator.SetTrigger("PickTrash");
                gameController.PlusTrash();
                Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "FeedArea")
            {
                playerAnimator.SetTrigger("Feed");
                gameController.PlusFood();
                Destroy(other.gameObject);
            }

        }
    }
}
