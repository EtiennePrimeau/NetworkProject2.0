using Mirror;
using UnityEngine;

public class SpawnLocalPlayer : NetworkBehaviour
{
    [SerializeField] private GameObject m_cinematicGo;
    [SerializeField] private GameObject m_localPlayerPrefab;

    [field: Header("RUNNERS")]
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rb;



    private void Start()
    {        
        if (!isLocalPlayer)
        {
            return;
        }

        var go = Instantiate(m_localPlayerPrefab, transform);
        
        var childSM = go.GetComponentInChildren<RunnerSM>();
        childSM.SetAnimator(m_animator);
        childSM.SetRigidbody(m_rb);
        childSM.SetParentGo(gameObject);
        childSM.SetCinematicCamera(m_cinematicGo);

    }
}
