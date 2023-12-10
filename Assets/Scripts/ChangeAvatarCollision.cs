using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class ChangeAvatarCollision : MonoBehaviour
{
    [SerializeField] private RealtimeAvatarManager avatarManager;

    public GameObject avatar;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {

            //get avatar manager component from player
            avatarManager = other.transform.root.GetComponent<RealtimeAvatarManager>();

            avatarManager.localAvatarPrefab = avatar;
        }
    }
}
