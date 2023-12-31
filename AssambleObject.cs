﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AssambleObject : MonoBehaviour
{

    private Transform mMark;

    private Transform tMark;

    public Transform TAssambleObject;
    public GameObject aa;
    public GameObject bb;

    // Use this for initialization
    void Start()
    {
        mMark = this.transform.Find("LocationMark");
        if (mMark == null)
        {
            Debug.LogError("本地对象未找到位置标志");
        }

        tMark = TAssambleObject.Find("LocationMark");
        if (tMark == null)
        {
            Debug.LogError("目标对象未找到位置标志");
        }

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(aa.transform.position, bb.transform.position);
        if (distance<0.05)
        {
            MoveToTarget();
        }
    }


    
    private void MoveToTarget()
    {

        Vector3 RotateAix = Vector3.Cross(mMark.transform.forward, tMark.transform.forward);
        float angle = Vector3.Angle(mMark.transform.forward, tMark.transform.forward);
        mMark.transform.parent.Rotate(RotateAix, angle, Space.World);
        
        
          //第一步
        float Angle = Vector3.Angle(tMark.transform.up, mMark.transform.up);
        mMark.transform.parent.Rotate(tMark.transform.forward, Angle, Space.World);
          //第二步
        Vector3 moveVector = tMark.transform.position - mMark.transform.position;
        mMark.transform.parent.transform.Translate(moveVector, Space.World);
            
        
        
    }
}
