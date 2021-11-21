using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    [Range(0, 180)]
    public float FieldOfView = 80f; //This is setting the field of view for the AI in degrees between 0 and 180

    private float FieldOfViewDot; //Setting the field of view in a range between 0 and 1 -- thus it can be easily compared to the dot product between the AI and the player detectable object

    private void Start()
    {
        //Sweet, I GET THE REMAP FUNCTION AND IT'S PURPOSE -- Man, taking me forever to get up to speed on this stuff . . . but I will get there!
        //Debug.Log(Remap1(FieldOfView, 0f, 90f, 0f, 1f));
        //Debug.Log(Remap2(0f, 90f, 0f, 1f, FieldOfView));

        FieldOfViewDot = 1 - Remap(0f, 90f, 0f, 1f, FieldOfView);
    }

    //Remaps the field of view from degrees to 0 to 1
    //Value = current degrees of field of view, OG Range is 0, 90 (is this later multipled by two? not sure) and then output is 0 to 1f
    private float Remap(float iMin, float iMax, float oMin, float oMax, float v)
    {
        float t = Mathf.InverseLerp(iMin, iMax, v);
        return Mathf.Lerp(oMin, oMax, t);
    }

    //Overriding the parent class HasDetected Function for Eye-specific detection
    protected override bool HasDetected(Detectable detectable)
    {
        //Checks if the player object, i.e. detectable component, is within a detectable radius and isn't currently occluded by any other objects in the scene -- if both are true, then HasDetected will return true
        return IsInVisibleArea(detectable) && IsNotOccluded(detectable);
    }

    private bool IsInVisibleArea(Detectable detectable)
    {
        //Grabs the distance between the player object (detectable) and the AI object for comparison against the visible area
        float distance = Vector2.Distance(detectable.transform.position, this.transform.position);

        //Ok, this next part is going to take some breaking down, not entirely sure what it's doing
        return distance <= Distance && Vector3.Dot(Direction(detectable.transform.position, this.transform.position), this.transform.forward) >= FieldOfViewDot;
    }

    //The annoying bit about this code is it doesn't flow in a logical order, so you have to work backwards as you break it down
    private Vector3 Direction(Vector3 from, Vector3 to)
    {
        return (from - to).normalized;
    }
}
