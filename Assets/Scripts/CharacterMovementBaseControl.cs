using UnityEngine;
using System.Collections;

public class CharacterMovementBaseControl : MonoBehaviour
{
    private CharacterMovementModel m_MovementModel;

    void Awake()
    {
        m_MovementModel = GetComponent<CharacterMovementModel>();
    }

    protected void SetDirection(Vector3 direction)
    {
        m_MovementModel.SetDirection(direction);
    }

    protected void Jump() {
        m_MovementModel.Jump();
    }
}