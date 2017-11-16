using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{

    public Vector2 maxOrientation = new Vector2(45, 45);
    public Vector2 mouseSensitivity = Vector2.one;

    private Quaternion initialRotation;
    private Vector2 initialMousePosition;

    void Start()
    {
        initialRotation = gameObject.transform.localRotation;


    }

    void FixedUpdate()
    {
        //touch controls
        if (Input.touchCount > 0)
        {
            //get touch position in screen space (from -1 to +1)
            Vector2 touchPosition = new Vector2(
                (Input.GetTouch(0).position.x / Screen.width) * 2 - 0.5f,
                (Input.GetTouch(0).position.y / Screen.height) * 2 - 0.5f
            );
            //handle different size screens
            float yQuaternion = initialRotation.eulerAngles.y - 0.5f + touchPosition.x;


            //rotate object
            Quaternion newYOrientation = new Quaternion(
                gameObject.transform.rotation.x,
                yQuaternion,
                gameObject.transform.rotation.z,
                gameObject.transform.rotation.w
            );

            gameObject.transform.rotation = newYOrientation;
        }

        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            initialRotation = transform.rotation;
        }

        //mouse controls
        if (Input.GetMouseButton(0))
        {
            //get mouse position relative to initial value (at the start of the click)
            Vector2 mouseRelativePosition = new Vector2(
                Input.mousePosition.x - initialMousePosition.x,
                Input.mousePosition.y - initialMousePosition.y
            );

            Debug.Log("mouse movement: " + mouseRelativePosition.x);

            //mouse position on screen (from 0 to 1)
            Vector2 mouseScreenPosition = new Vector2(
            	(mouseRelativePosition.x / Screen.width),
            	-(mouseRelativePosition.y  / Screen.height)
            );

			//create x and y euler rotations
			float xEuler = (mouseScreenPosition.y * 180 * mouseSensitivity.y);
			float yEuler = (mouseScreenPosition.x * 180 * mouseSensitivity.x);
			
			if(xEuler > maxOrientation.y){
				xEuler = maxOrientation.y;
			}else if(xEuler < -maxOrientation.y){
				xEuler = -maxOrientation.y;
			}

			if(yEuler > maxOrientation.x){
				yEuler = maxOrientation.x;
			}else if(yEuler < -maxOrientation.x){
				yEuler = -maxOrientation.x;
			}

			//apply rotations to the cannon
			Vector3 xRotation = new Vector3(xEuler, 0, 0);
			Vector3 yRotation = new Vector3(0, yEuler, 0);

			transform.rotation = initialRotation;

			transform.Rotate(xRotation, Space.Self);
			transform.Rotate(yRotation, Space.World);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(new Vector3(0, 1, 0), Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(new Vector3(0, -1, 0), Space.World);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Rotate(new Vector3(-1, 0, 0), Space.Self);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Rotate(new Vector3(1, 0, 0), Space.Self);
        }
    }
}
