using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderBlendAnim : MonoBehaviour
{
    Animation blendAnim;
    SkinnedMeshRenderer skinnedMesh;
    private void Start()
    {
        blendAnim = transform.GetComponent<Animation>();
        skinnedMesh = transform.GetComponent<SkinnedMeshRenderer>();
    }

   public void MouthOn()
    {
        blendAnim.Play("cylinderAnimBlend");
    }
    
}
