using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public float shootVelocity = 30;
    public GameObject bulletPrefab;

    public Transform pipeTransform;

	public AudioSource shotSound;

    void Start()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("No bullet set! Put a bullet prefab to cannon shoot script!");
        }
    }
    void Update()
    {
        //input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("painoit välilyöntiä!");

            if (bulletPrefab == null)
            {

                //create bullet
                GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                ball.tag = "Bullet";
                ball.transform.position = gameObject.transform.position;

                //give bullet velocity
                Rigidbody rb = ball.AddComponent<Rigidbody>();
                rb.AddForce(gameObject.transform.up * shootVelocity, ForceMode.Impulse);
            }else{
                GameObject bullet = GameObject.Instantiate(bulletPrefab, pipeTransform.position, pipeTransform.rotation);
				var rb = bullet.GetComponent<Rigidbody> ();

				if (shotSound) {
					//Give bullet a sound
					shotSound.Play ();
				}

                //give bullet velocity
				rb.AddForce(pipeTransform.forward * shootVelocity * rb.mass, ForceMode.Impulse);
            }
        }
    }
}