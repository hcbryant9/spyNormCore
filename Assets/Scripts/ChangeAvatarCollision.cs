using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class ChangeAvatarCollision : MonoBehaviour
{
    public RealtimeAvatarManager avatarManager;
    public GameObject avatar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            //register avatar?
            //change the local avatar prefab
            avatarManager.localAvatarPrefab = avatar;
        }
    }
}
