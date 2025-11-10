using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class GrabScript : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private float extraPullForce;
    private bool grabbed;
    private GameObject grabbedObj;
    private Rigidbody2D grabbedRb;
    private SpringJoint2D grabJoint;
    bool cooldown;
    void Update()
    {
        CheckGrab();
       
    }

    private void CheckGrab()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -3;

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward);
        if (Input.GetMouseButtonDown(0) && hit.collider != null && !grabbed)
        {
            Vector2 grabPoint = new Vector2(hit.collider.transform.position.x - hit.point.x, hit.collider.transform.position.y - hit.point.y);
            Pickup(hit.collider.gameObject, grabPoint);
        }
        else if (grabbed)
        {
            HandleGrab();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            drop();
        }

    }

    private void HandleGrab()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        grabJoint.connectedAnchor = mousePos;
        grabJoint.distance = -1;

        Vector2 dir = mousePos - (Vector2)grabbedObj.transform.position;
        grabbedRb.AddForce(dir.normalized * extraPullForce);
    }

    public void Pickup(GameObject obj, Vector2 grabPoint)
    {
        grabbedObj = obj;
        grabbedRb = obj.GetComponent<Rigidbody2D>();
        grabbed = true;
        grabJoint = obj.AddComponent<SpringJoint2D>();
        grabJoint.enableCollision = true;
        grabJoint.anchor = grabPoint;
        grabJoint.frequency = 3;
        grabJoint.dampingRatio = 1;
        
    }

    public void drop()
    {
        if(grabbed)
        {
            Destroy(grabbedObj.GetComponent<SpringJoint2D>());
            grabbed = false;
        }


    }
    
    private IEnumerator dropcooldown()
    {
        yield return new WaitForSeconds(0.1f);
        cooldown = true;
    }
}
