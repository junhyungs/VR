using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;

public class RayAttacher : MonoBehaviour
{
    private IXRSelectInteractable _selectIntractable;

    protected void OnEnable()
    {
        _selectIntractable = this.GetComponent<IXRSelectInteractable>();
        if(_selectIntractable as Object == null)
        {
            Debug.LogError("RayAttacher need SelectInteractable");
            return;
        }

        _selectIntractable.selectEntered.AddListener(OnSelectEntered);
        
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!(args.interactorObject is XRRayInteractor))
            return;

        var attachTransform = args.interactorObject.GetAttachTransform(_selectIntractable);
        var originAttachPos = args.interactorObject.GetLocalAttachPoseOnSelect(_selectIntractable);
        attachTransform.SetLocalPose(originAttachPos);
    }

}
