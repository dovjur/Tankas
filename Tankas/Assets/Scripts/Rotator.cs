using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime, Space.Self);
        transform.Rotate(new Vector3(0,70,0) * Time.deltaTime,Space.World);
    }
}
