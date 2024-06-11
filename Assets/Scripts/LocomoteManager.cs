using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class LocomoteManager : MonoBehaviour
{
    public enum MoveStyleType { HeadRelative, HandRelative }
    public enum TurnStyleType { Snap, Continuous }

    [Header("XR")]
    [SerializeField] XROrigin XROrigin;
    [SerializeField] XRBaseController Controller_Left;
    [SerializeField] XRBaseController Controller_Right;

    [Header("Locomotion")]
    [SerializeField] ContinuousMoveProviderBase Provider_ContinuousMove;
    [SerializeField] ContinuousTurnProviderBase Provider_ContinuousTurn;
    [SerializeField] SnapTurnProviderBase Provider_SnapTurn;
    [SerializeField] TeleportationProvider Provider_Teleportation;

    [Header("Property")]
    [SerializeField] MoveStyleType m_LeftHandMoveStyle;

    //public MoveStyleType GetMoveStyle()
    //{
    //    return m_LeftHandMoveStyle;
    //}

    //public void SetMoveStyle(MoveStyleType type)
    //{
    //    m_LeftHandMoveStyle = type;
    //}

    public MoveStyleType MoveStyle
    {
        get { return m_LeftHandMoveStyle; }
        set
        {
            m_LeftHandMoveStyle = value;

            switch(m_LeftHandMoveStyle)
            {
                case MoveStyleType.HeadRelative:
                    Provider_ContinuousMove.forwardSource = XROrigin.Camera.transform;
                    break;
                case MoveStyleType.HandRelative:
                    Provider_ContinuousMove.forwardSource = Controller_Left.transform;
                    break;
            }
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {

    }


}
