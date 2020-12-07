using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    public Animator camAnim;

    public void CameraShake()
    {
        camAnim.SetTrigger("shake");
    }

    public void ShakeCamera2()
    {
        camAnim.SetTrigger("shake2");
    }

    public void ShakeCamera3()
    {
        camAnim.SetTrigger("shake3");
    }
}
