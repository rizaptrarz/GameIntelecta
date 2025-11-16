using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmFollowCursor : MonoBehaviour
{
    [SerializeField] private Transform armTransform;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z - armTransform.position.z);
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = worldMousePosition - armTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        armTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
