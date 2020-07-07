using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] private List<GameObject> _collectible;
    private int _amountCollected = 0;

    [SerializeField] private float minDistance;
    private string sfxName = "Egg";
    
    // References.
    [SerializeField, Tooltip("Drag AudioManager here (from scene hierarchy).")]
    private AudioManager _audioManager;

    private void FixedUpdate()
    {
        if (_amountCollected < _collectible.Count)
        {
            if (Vector3.Distance(this.gameObject.transform.position, _collectible[_amountCollected].transform.position) <= minDistance)
            {
                _collectible[_amountCollected].GetComponent<CollecEgg>().Collected();
                _amountCollected++;
                // Play pickup sfx.
                _audioManager.Play(sfxName);
            }
        }
    }    
}