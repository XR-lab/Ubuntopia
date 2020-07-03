using UnityEngine;
using UnityEngine.SceneManagement;

public class FastAsFuckBoi : MonoBehaviour
{
	#region Public Variables _________________________________________________________________________/ Public Variables
	
	
	#endregion
	#region SerializeField Variables _________________________________________________________/ SerializeField Variables

	[SerializeField] private Transform player;
	
	#endregion
	#region Private Variables _______________________________________________________________________/ Private Variables
	
	
	#endregion

    // _________________________________________________________________________________________________________/ Update
    private void Update()
    {
	    if (Vector3.Distance(transform.position, player.position) <= 5)
	    {
		    SceneManager.LoadScene("EndScreen");
	    }
    }
}

