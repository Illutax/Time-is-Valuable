using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class CharacterMovementModel : MonoBehaviour
{
    public float MoveSpeed = 15f;
    public float JumpForce = 50f;
    //public float TurnSpeed = 5;
    public Transform CenterOfFeet;

    [SerializeField]
    private bool m_IsInAir;
    private Vector3 m_MovementDirection;
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_IsInAir = true;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (m_IsInAir) {
            return;
        }

        if (GetDirection() != Vector3.zero) {
            UpdateMovement();
        }
    }
    
    void OnCollisionEnter(Collision collision) {
        if (m_IsInAir) {
            foreach (ContactPoint contact in collision.contacts) {
                if (contact.otherCollider.tag == "Ground") {
                    m_IsInAir = false;
                    return;
                }
            }
        }
    }

    void UpdateMovement()
    {
        m_MovementDirection.Normalize();

        // This is experimental for smoother turning
        //m_Rigidbody.velocity = m_MovementDirection * Mathf.Lerp( m_Rigidbody.velocity.magnitude, m_MovementDirection.magnitude * Speed, TurnSpeed );
        m_Rigidbody.velocity = m_Rigidbody.velocity * MoveSpeed;
        //transform.position += m_MovementDirection * Speed * Time.deltaTime;
    }

    public void Jump() {
        if (m_IsInAir)
            return;

        m_Rigidbody.AddForce(Vector3.up * JumpForce);
        m_IsInAir = true;
    }

    public void SetDirection(Vector3 direction)
    {
        m_MovementDirection = new Vector3( direction.x, 0, direction.z );
    }

    public Vector3 GetDirection()
    {
        return m_MovementDirection;
    }

    public bool IsMoving()
    {
        return m_MovementDirection != Vector3.zero;
    }
}