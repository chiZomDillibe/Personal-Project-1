using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{   
    public float speed = 5.0f;
    public Rigidbody objectRb;
    private float zDestroy = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        objectRb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);
        if(transform.position.z < -zDestroy)
        {
            Destroy(gameObject);
        }
    }
    
private void OnCollisionEnter (Collision collision)
{
if (collision.gameObject.CompareTag("Enemy"))
{
    Debug.Log("Player has collided with enemy");
}
}
 
 private void onTriggerEnter(Collider other){
    if(other.gameObject.CompareTag("Powerup"))
    {
        Destroy(other.gameObject);
    }
 }



}
