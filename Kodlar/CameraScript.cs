using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraScript : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera camera1,camera2;

    void Start()
    {
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }


    public void endOfGame()
    {
        camera1.gameObject.SetActive(false);
        camera2.gameObject.SetActive(true);
    }
}
