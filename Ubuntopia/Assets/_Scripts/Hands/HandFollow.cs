using UnityEngine;

public class HandFollow : MonoBehaviour
{

    [SerializeField] private GameObject _handModel;
    [SerializeField] private Transform _horseTransform;
    private int enterCount = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "HarishColliders")
        {
            enterCount++;
            if (enterCount == 1)
            {
                _handModel.transform.parent = other.transform;
            }
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.tag == "HarishColliders")
        {
            enterCount--;
            if (enterCount == 0)
            {
                _handModel.transform.parent = transform;
                _handModel.transform.localPosition = new Vector3();
                _handModel.transform.localRotation = new Quaternion();
            }
        }
    }
}
