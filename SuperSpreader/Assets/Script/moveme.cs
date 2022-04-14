using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveme : MonoBehaviour
{
public float speed = 2.0f; 
public float xPos;
public float yPos;

 public Vector3 desiredPos;
 public float timer = 0.0f;
 public float timerSpeed =1;
 public float timeToMove =10;
 public float randomyMin = -3f;
public float randomyMax = 28f;
 public float randomxMin = -18f;
  public float randomxMax = 17f;


 void Start()
 {
     yPos = Random.Range(randomyMin, randomyMax);
     xPos = Random.Range(randomxMin, randomxMax);
     desiredPos = new Vector3(xPos, yPos);
     timer = 0.0f;
 }

 void Update()
 {
     timer += Time.deltaTime * timerSpeed;
     if (timer >= timeToMove)
     {
         transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
         
         if (Vector3.Distance(transform.position, desiredPos) <= 0.01f)
         {
             yPos = Random.Range(randomyMin,randomyMax);
             xPos = Random.Range(randomxMin,randomxMax);
             desiredPos = new Vector3(xPos, yPos);
             timer = 0.0f;
             
             timeToMove = 10.0f;
         }
     }
 }
 }
