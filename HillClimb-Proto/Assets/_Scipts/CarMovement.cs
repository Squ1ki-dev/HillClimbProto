using UnityEngine;

[System.Serializable]
public class Axes
{
    public Rigidbody2D Wheel;
    public float m_SpeedMultiplier;
}
public class CarMovement : MonoBehaviour
{
    [SerializeField] private Axes[] axes;

    [SerializeField] private float m_Speed;
    [SerializeField] private float rotation;

    [SerializeField] private Rigidbody2D rb2d;

    public void OnGas() => SetTorque(-m_Speed);

    public void OnBrake() => SetTorque(m_Speed);

    private void SetTorque(float m_Speed)
    {
        foreach(Axes axles in axes)
        {
            axles.Wheel.AddTorque(m_Speed * axles.m_SpeedMultiplier);
        }

        rb2d.AddTorque(rotation * m_Speed);
    }
}