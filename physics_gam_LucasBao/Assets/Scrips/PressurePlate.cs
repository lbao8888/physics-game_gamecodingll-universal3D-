using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{

    public float weightThreshold = 5f;

    public bool lockOnActivate = false;

    public UnityEvent onActivated;
    public UnityEvent onDeactivated;
    
    public Transform plate;

    public float pressDepth = 0.05f;

    float currentWeight = 0f;
    bool isActivated = false;
    bool isLocked = false;
    Vector3 plateResetPos;
    Vector3 plateePressedPos;

    HashSet<PhysicsObjects> objectsOnPlate = new HashSet<PhysicsObjects>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(plate != null)
        {
            plateResetPos = plate.localPosition;
            plateePressedPos = plateResetPos + Vector3.down * pressDepth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PhysicsObjects physOb = other.GetComponent<PhysicsObjects>();
        if (physOb == null) return;

        if (physOb.isHeld) return;

        currentWeight += physOb.puzzleWeight;
        Debug.Log($"{other.gameObject.name} entered plate. total weight: {currentWeight}");
         
    }

    private void OnTriggerExit(Collider other)
    {
        if(isLocked) return;
        PhysicObjects physicsObj = other.GetComponent<PhysicsObjects>();
        if (physicsObj == null) return;

        if (objectsOnPlate.Remove(physicsObj))
        {
            currentWeight -= physicsObj.puzzleWeight;
            currentWeight = Mathf.Max(0f,currentWeight);
            CheckActivation();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
    void CheckActivation()
    {
        if(!isActivated && currentWeight >= weightThreshold)
        {
            isActivated = true;
            is(lockOnActivate) isLocked = true;

            onActivated.Invoke();
            Debug.Log("Pressure plate is activated");

            if(plate != null)
            {
                plate.localPosition = platePressedPos;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
