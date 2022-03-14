using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public Collider2D cat;
    public LoadNew suc;
    public string b;

    void OnTriggerEnter2D(Collider2D cat)
    {
        suc.LoadScene(b);

    }
}
