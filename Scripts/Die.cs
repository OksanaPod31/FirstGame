using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public Collider2D cat;
    public LoadNew kek;
    public Enemy bla;
    public string a;
   

    // Update is called once per frame
    void Update()
    {
        if (bla.HealthCount <= 0)
        {
            kek.LoadScene(a);
        }
    }

    void OnTriggerEnter2D(Collider2D cat)
    {
        kek.LoadScene(a);
    }
}
