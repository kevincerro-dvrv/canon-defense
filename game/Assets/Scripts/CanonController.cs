using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private readonly float rotationOffsetDegrees = -90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCanon();

        if (Input.GetMouseButtonDown(0)) {
            FireCanon();
        }
    }

    private void MoveCanon()
    {
        // Get mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the angle in radians and convert it to degrees
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

        // Rotate the object towards the mouse
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle + rotationOffsetDegrees);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void FireCanon()
    {
        Debug.Log("Fire");
    }
}
