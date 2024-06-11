using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using Unity.VisualScripting.Dependencies.NCalc;

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
    [SerializeField] TurnStyleType m_RightHandTurnStyle;
    [SerializeField, Range(0.0f, 5.0f)] float m_MoveSpeed;
    [SerializeField] bool isEnableStrafe;
    [SerializeField] bool isUseGravity;
    [SerializeField] bool isEnableFly;
    [SerializeField, Range(0.0f, 180.0f)] float m_TurnSpeed;
    [SerializeField] bool isEnableTurnAround;
    [SerializeField, Range(0.0f, 90.0f)] float m_Snap;

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

    public TurnStyleType TurnStyle
    {
        get { return m_RightHandTurnStyle; }
        set
        {
            m_RightHandTurnStyle = value;

            switch (m_RightHandTurnStyle)
            {
                case TurnStyleType.Snap:
                    Provider_ContinuousTurn.enabled = false;
                    Provider_SnapTurn.enabled = true;
                    break;
                case TurnStyleType.Continuous:
                    Provider_ContinuousTurn.enabled = true;
                    Provider_SnapTurn.enabled = false;
                    break;
            }
        }
    }

    public float MoveSpeed
    {
        get { return m_MoveSpeed; }
        set
        {
            m_MoveSpeed = value;

            Provider_ContinuousMove.moveSpeed = m_MoveSpeed;
        }
    }

    public bool IsEnableStrafe
    {
        get { return isEnableStrafe; }
        set
        {
            isEnableStrafe = value;
            Provider_ContinuousMove.enableStrafe = isEnableStrafe;
        }
    }

    public bool IsUseGravity
    {
        get { return isUseGravity; }
        set
        {
            isUseGravity = value;
            Provider_ContinuousMove.useGravity = isUseGravity;
        }
    }

    public bool IsEnableFly
    {
        get { return isEnableFly; }
        set
        {
            isEnableFly = value;
            Provider_ContinuousMove.enableFly = isEnableFly;
        }
    }

    public float TurnSpeed
    {
        get { return m_TurnSpeed; }
        set
        {
            m_TurnSpeed = value;
            Provider_ContinuousTurn.turnSpeed = m_TurnSpeed;
        }
    }

    public bool EnableTurnAround
    {
        get { return isEnableTurnAround; }
        set
        {
            isEnableTurnAround = value;
            Provider_SnapTurn.enableTurnAround = isEnableTurnAround;    
        }
    }

    public float SnapTurnAmount
    {
        get { return m_Snap; }
        set
        {
            m_Snap = value;
            Provider_SnapTurn.turnAmount = m_Snap;
        }
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        MoveStyle = m_LeftHandMoveStyle;
        TurnStyle = m_RightHandTurnStyle;
        MoveSpeed = m_MoveSpeed;
        IsEnableStrafe = isEnableStrafe;
        IsUseGravity = isUseGravity;
        IsEnableFly = isEnableFly;
        TurnSpeed = m_TurnSpeed;
        EnableTurnAround = isEnableTurnAround;
        SnapTurnAmount = m_Snap;
    }


}
