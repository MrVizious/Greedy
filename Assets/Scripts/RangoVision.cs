using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoVision : MonoBehaviour
{
    public Guardian parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Guardian>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            parent.objetivo = collision.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.objetivo = null;
        }
    }
}
