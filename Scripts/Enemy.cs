using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Collider2D cat;
    public float speed;
    public Transform[] points;
    private int randompoints;
    public RectTransform HealthImage; 
    public int DecreaseCount = 0; 
    public int HealthCount = 165; 



    void Start()
    {
        
        randompoints = Random.Range(0, points.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[randompoints].position, speed * Time.deltaTime);
     

        if (Vector2.Distance(transform.position, points[randompoints].position) < 0.2f)
        {
            randompoints = Random.Range(0, points.Length);
            transform.position = Vector2.MoveTowards(transform.position, points[randompoints].position, speed * Time.deltaTime);
            
        }
        
        //if (HealthCount < 100)
        //{
        //HealthCount++;
        //}
            
        UpdateUi();

        
    }

    void OnTriggerEnter2D(Collider2D cat)
    {
        if (cat)
        {
            DecreaseCount = 20;
            if (HealthCount <= 0)
                return;

            // Reduce health 
            HealthCount -= DecreaseCount;

        }
    }

    private void UpdateUi()
    {
        // Calculate percentage from 0 to 1 and setup
        HealthImage.sizeDelta = new Vector2(HealthCount - DecreaseCount, HealthImage.sizeDelta.y);
    }
}
