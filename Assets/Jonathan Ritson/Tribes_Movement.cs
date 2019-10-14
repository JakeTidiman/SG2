using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribes_Movement : MonoBehaviour
{
    private Rigidbody RB;
    private float speed = 20;
    private float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;


    // just observation variables
    public float overallspeed;
    public float targetTime;
    private bool timeup;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        RB = GetComponent<Rigidbody>();

        RB.mass = 4;
        RB.drag = 1;
        RB.angularDrag = 0.5f;

        targetTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        overallspeed = RB.velocity.magnitude;

        #region movement

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        RB.AddRelativeForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

        #endregion


        #region camera

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        Camera.main.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);

        #endregion

        #region jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale -= new Vector3(0, 0.2f, 0);
            timeup = true;
        }

        if(timeup == true)
        {
            targetTime += Time.deltaTime;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.localScale += new Vector3(0, 0.2f, 0);
            timeup = false;


            if (targetTime < 0.4f)
            {
                RB.velocity = new Vector3(0, 1, 0);
                targetTime = 0;
            }

            if ((targetTime >= 0.4f) && (targetTime < 0.8f))
            {
                RB.velocity = new Vector3(0, 5, 0);
                targetTime = 0;
            }

            if ((targetTime >= 0.8f) && (targetTime < 1.25f))
            {
                RB.velocity = new Vector3(0, 10, 0);
                targetTime = 0;
            }

            if ((targetTime >= 1.25f) && (targetTime < 1.5f))
            {
                RB.velocity = new Vector3(0, 15, 0);
                targetTime = 0;
            }

            if (targetTime >= 1.5f)
            {
                RB.velocity = new Vector3(0, 20, 0);
                targetTime = 0;
            }
        }

        #endregion

    }
}
