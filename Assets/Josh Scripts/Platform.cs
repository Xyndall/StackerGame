using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Platform : MonoBehaviour
{
    public GameManger manager = null;

    public enum direction { X, Z};
    public direction dir = direction.X;
    public float speed = 2;

    Vector3 pos = Vector3.zero;

    public void myDir(int value)
    {
        //return direction passed through function (Takes values 0 and 1)
        dir = (direction)value;
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;

        if(dir == direction.X)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            speed = 0;
        }

        
        

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("hit");
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        
            Destroy(gameObject);
        
        
    }


    
}
