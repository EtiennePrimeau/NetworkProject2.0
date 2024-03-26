using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    private Vector3 m_target;
    private Vector3 m_startPosition;
    private Vector3 m_leftPosition;
    private Vector3 m_rightPosition;
    [SerializeField] private float m_travelDistance;
    [SerializeField] private float m_speed;

    void Start()
    {
        Vector3 travel = new Vector3(m_travelDistance, 0, 0);
        
        m_startPosition = transform.position;
        m_leftPosition = m_startPosition + travel;
        m_rightPosition = m_startPosition - travel;
        m_target = m_leftPosition;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, m_target) < 0.5f)
        {
            if (m_target == m_leftPosition)
            {
                m_target = m_rightPosition;
            }
            else
            {
                m_target = m_leftPosition;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, m_target, m_speed);
    }
}
