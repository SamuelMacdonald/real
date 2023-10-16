using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camrafollow : MonoBehaviour
{
    public Transform followTransform;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(followTransform.position.x + 0.3f, followTransform.position.y + 0.2f, this.transform.position.z);
    }
}
