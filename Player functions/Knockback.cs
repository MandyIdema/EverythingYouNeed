using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    //Put this on your player character

    [SerializeField]
    private float knockbackStrength;

    private void OnTriggerEnter(Collider collision)
    {
        //tag can be changed to whatever you want, make sure the tag in the inspector correspond with the code!
        if (collision.gameObject.tag == "Enemy" // Change to whatever tag you want)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = this.transform.position - collision.transform.position;
                direction.z = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
            }
        }
    }
}
