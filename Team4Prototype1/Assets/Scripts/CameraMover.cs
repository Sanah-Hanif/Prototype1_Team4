using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float horizontalSpeed, verticalSpeed;
    private float _horizontalMovement, _verticalMovement;

    public float upperX, lowerX, upperY, lowerY;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement += horizontalSpeed * Input.GetAxis("Mouse X");
        _verticalMovement -= verticalSpeed * Input.GetAxis("Mouse Y");

        _horizontalMovement = Mathf.Clamp(_horizontalMovement, lowerX, upperX);
        //the rotation range
        _verticalMovement = Mathf.Clamp(_verticalMovement, lowerY, upperY);
        //the rotation range

        transform.eulerAngles = new Vector3(_verticalMovement, _horizontalMovement, 0.0f);

        if (Input.GetButtonDown("Fire1"))
        {
            WhatchaPointingAt();
        }
    }

    void WhatchaPointingAt()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
        {
            Item it = GameObject.Find("Object Manager").GetComponent<ObjectManager>().FindItemWithGivenObject(hit.transform.gameObject);
            if (it != null)
            {
                print(it.GetName());
            }
        }
    }
}
