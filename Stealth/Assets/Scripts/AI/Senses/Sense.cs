using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sense : MonoBehaviour
{
    public Detectable Detectable;
    public float Distance;

    protected bool IsSensing;

    public bool IsDetectionContinuous = true;

    //Need to double back around and make sure I understand how these work again . . .
    public UnityAction<Detectable> OnDetect;
    public UnityAction<Detectable> OnLost;

    private void Detect(Detectable detectable)
    {
        IsSensing = true;
        OnDetect?.Invoke(detectable);
    }

    private void Lost(Detectable detectable)
    {
        IsSensing = false;
        OnLost?.Invoke(detectable);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSensing)
        {
            if (!HasDetected(Detectable))
            {
                Lost(Detectable);
                return;
            }

            if(IsDetectionContinuous)
            {
                Detect(Detectable);
            }
        }
        else
        {
            if (!HasDetected(Detectable))
                return;

            Detect(Detectable);
        }
    }

    //This function is replaced by the children class of Ears and Eyes as needed . . .
    protected virtual bool HasDetected(Detectable detectable) => false;
}
