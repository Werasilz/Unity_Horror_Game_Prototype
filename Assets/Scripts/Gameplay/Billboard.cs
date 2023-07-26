using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Quaternion m_quaternion = Quaternion.identity;

    void LateUpdate()
    {
        m_quaternion.eulerAngles = Camera.main.transform.rotation.eulerAngles;
        transform.rotation = m_quaternion;
    }
}