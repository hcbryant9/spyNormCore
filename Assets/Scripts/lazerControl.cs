using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class lazerControl : MonoBehaviour
{
    public Transform launchPoint;
    public string bulletName;
    public float firePower = 1000;

    public void FireWeapon()
    {
        GameObject bullet = Realtime.Instantiate(bulletName, launchPoint.position, launchPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(launchPoint.forward*firePower);
    }
}
