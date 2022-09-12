using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f ;
    private Rigidbody playerRb;
    private float zbound= 8;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      MovePlayer ();
      ConstraintPlayerPosition ();

      


     // Move player on arrow key input
     void MovePlayer ()
     {
       float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      playerRb.AddForce(Vector3.forward * speed *  verticalInput);
      playerRb.AddForce(Vector3.right * speed *  horizontalInput);
     }

    
     // Prevent the player from exceeding boundaries
     void ConstraintPlayerPosition(){
    if(transform.position.z < -zbound )
      {
          new Vector3(transform.position.x , transform.position.y , -zbound);
      }
    
      if(transform.position.z > zbound)
      {
        new Vector3(transform.position.x , transform.position.y , zbound);
      }
     }
}

private void OnCollisionEnter (Collision collision)
{
if (collision.gameObject.CompareTag("Enemy"))
{
    Debug.Log("Player has collided with enemy");
}
}
 
 private void OnTriggerEnter(Collider other){
    if(other.gameObject.CompareTag("Powerups"))
    {
        Destroy(other.gameObject);
    }
 }
}