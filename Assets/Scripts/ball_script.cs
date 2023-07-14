using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int height;
    void Update()
    {
        if (transform.position.y < height)
        {
            Destroy(gameObject);
        }
    }
}
