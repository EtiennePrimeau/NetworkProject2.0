using Mirror;
//using System.Diagnostics;
//using System.Diagnostics;
using UnityEngine;

public class NetworkGamePlayer : NetworkBehaviour
{
    public static int s_index = 0;
    private int m_index;

    [SyncVar]
    private string m_displayName = "Loading...";

    private NetworkManagerCustom manager;
    private NetworkManagerCustom Manager
    {
        get
        {
            if (manager != null) { return manager; }
            return manager = NetworkManager.singleton as NetworkManagerCustom;
        }
    }
    private void Awake()
    {
        Manager.GamePlayers.Add(this);    // removed for Phase1
    }
    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
    }

    public override void OnStopClient()
    {
        Manager.GamePlayers.Remove(this); // removed for Phase1
    }

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.m_displayName = displayName;
    }


    public string GetDisplayName()
    {
        return m_displayName;
    }
    

    public int GetIndex()
    {
        return m_index;
    }
}
