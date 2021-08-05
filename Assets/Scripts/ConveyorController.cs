using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{  
    [SerializeField] private float speed;

    public bool active = true;
    private Material conveyorMaterial; 
    private MeshRenderer conveyor;
    private List<Rigidbody> parcelsRB = new List<Rigidbody>();

    void Start()
    {
        conveyor = GetComponent<MeshRenderer>();
        conveyorMaterial = conveyor.materials[1];
         
    } 

    void Update()
    {
        if (active) Move();
        else
        {

            foreach (Rigidbody rb in parcelsRB)
            {
                // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
                rb.velocity = Vector3.zero;
            }
        }
    }
      
    private void Move()
    {
        conveyorMaterial.mainTextureOffset += Vector2.up * Time.deltaTime * speed / 2; 
        if (conveyorMaterial.mainTextureOffset.y >= 1) conveyorMaterial.mainTextureOffset = Vector2.zero;

        foreach (Rigidbody rb in parcelsRB)
        {  
            rb.AddForce(Vector3.forward * Time.deltaTime * speed * 100);
           // rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            if(rb.velocity.z > speed) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed); 
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Parcel") parcelsRB.Add(other.transform.GetComponent<Rigidbody>());  
    }
    private void OnTriggerExit(Collider other)
    { 
        if (other.tag == "Parcel") parcelsRB.Remove(other.transform.GetComponent<Rigidbody>());
    }
}
