using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CheckMousePointer();
        }
        
    }

    public void CheckMousePointer()
    {
        Vector3 worldSpaceDir= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.5f));

        Vector3 Direction = worldSpaceDir - Camera.main.transform.position;
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Direction, out hit, 100f))
        {
            CheckHit(hit);
        }
    }

    public void CheckHit(RaycastHit hit)
    {
        Debug.Log(hit.collider.gameObject.transform.position.y);
        Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 0.5f);
        Jump(hit);
        DestroyCube(hit);
    }

    public void Jump(RaycastHit hit)
    {
        if (hit.rigidbody != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            hit.rigidbody.AddForce(0f,500f, 0f); 
        }
    }

    public void DestroyCube(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag== "cube")
        {
            //Destroy(hit.collider.gameObject);
            hit.collider.gameObject.SetActive(false); 
                   
        }
    }
}
