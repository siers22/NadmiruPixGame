﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    public Transform obj_1;
    public Transform obj_2;
    public float distantion;
    public float maxDistance = 4;

    void Update()
    {
        distantion = Vector3.Distance(obj_1.position, obj_2.position);
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (distantion < maxDistance)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
           
        }
    }
}