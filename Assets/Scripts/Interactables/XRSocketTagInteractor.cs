using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    public string targetTag1;
    public string targetTag2;
    public string targetTag3;
    public string noTargetTag;

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && (interactable.transform.tag == targetTag1 || interactable.transform.tag == noTargetTag || interactable.transform.tag == targetTag2 || interactable.transform.tag == targetTag3);
    }

    

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return base.CanSelect(interactable) && (interactable.transform.tag == targetTag1 || interactable.transform.tag == noTargetTag || interactable.transform.tag == targetTag2 || interactable.transform.tag == targetTag3);
    }

}
