using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Attacher : MonoBehaviour
{
    private IXRSelectInteractable m_selectInteractable;

    protected void OnEnable()
    {
        m_selectInteractable = this.GetComponent<IXRSelectInteractable>();

        if(m_selectInteractable as Object == null)
        {
            Debug.LogError("Attacher Need SelectInteractable");
            return;
        }

        m_selectInteractable.selectEntered.AddListener(OnSelectEntered);

    }

    protected void OnDisable()
    {
        if(m_selectInteractable as Object != null)
        {
            m_selectInteractable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(false == (args.interactableObject is XRRayInteractor))
        {
            return;
        }

        var attachTransform = args.interactorObject.GetAttachTransform(m_selectInteractable);
        var originAttachPos = args.interactorObject.GetLocalAttachPoseOnSelect(m_selectInteractable);

        attachTransform.SetLocalPose(originAttachPos);
    }
}
