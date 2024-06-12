using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jun_Attacher : MonoBehaviour
{
    private IXRSelectInteractable _selectInteractable;

    protected void OnEnable()
    {
        _selectInteractable = GetComponent<IXRSelectInteractable>();

        if(_selectInteractable as Object == null)
        {
            return;
        }

        _selectInteractable.selectEntered.AddListener(OnSelectEnterd);
    }

    protected void OnDisable()
    {
        _selectInteractable.selectEntered.RemoveListener(OnSelectEnterd);
    }

    private void OnSelectEnterd(SelectEnterEventArgs args)
    {
        if(false == (args.interactorObject is XRRayInteractor))
        {
            return;
        }

        var attachTransform = args.interactorObject.GetAttachTransform(_selectInteractable);
        var originAttachPos = args.interactorObject.GetLocalAttachPoseOnSelect(_selectInteractable);

        attachTransform.SetLocalPose(originAttachPos);
    }
}

