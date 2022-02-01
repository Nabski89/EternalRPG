using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonDarkness : MonoBehaviour
{
    // Start is called before the first frame update

    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();
        if (controller != null)
        {
            Destroy(gameObject);
        }
    }
}
