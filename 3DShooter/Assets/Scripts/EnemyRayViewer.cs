using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayViewer : MonoBehaviour
{
    private float weaponRange = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the origin point of the line
        Vector3 lineOrigin = transform.forward;
        //draw the line
        Debug.DrawRay(lineOrigin, transform.forward * weaponRange, Color.green);
    }
}
