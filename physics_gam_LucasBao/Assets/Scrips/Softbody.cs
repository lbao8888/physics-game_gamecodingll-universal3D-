using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]

public class Softbody : MonoBehaviour
{

    //[Range(0, 2f)]
    //public float softness = 1;

    //[Range(0.01f, 1f)]
    //public float damping = 0.1f;
    //public float stiffness = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void CreateSoftBodyPhysics()
    {
        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();
        if (smr != null) return;

        Cloth cloth = gameObject.AddComponent<Cloth>();
        cloth.damping = damping;
        cloth.bendingStiffness = stiffness;

        cloth.coefficients = GenerateClothCoefficents(smr.sharedMesh.vertices.Length);

    }

    private ClothSkinningCoefficient[] GenerateClothCoefficents(int vertexCount)
    {

    }*/

}

