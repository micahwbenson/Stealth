using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [Range(0, 180)] //So, this is field of view in degrees
    public float FieldOfView;

    private float FieldOfViewDot;

    // Start is called before the first frame update
    void Start()
    {
        FieldOfViewDot = 1 - Remap(FieldOfView * 0.5f, 0, 90, 0, 1f);
    }

    private float Remap(float value, float originalStart, float originalEnd, float targetStart, float targetEnd)
    {
        return targetStart + (value - originalStart) * (targetEnd - targetStart) / (originalEnd - originalStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
