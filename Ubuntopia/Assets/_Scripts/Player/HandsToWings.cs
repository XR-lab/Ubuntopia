using UnityEngine;

public class HandsToWings : MonoBehaviour
{
	#region Public Variables _________________________________________________________________________/ Public Variables
	
	
	#endregion
	#region SerializeField Variables _________________________________________________________/ SerializeField Variables

	[SerializeField, Header("item 0 = left, item 1 = right")] 
	private Transform[] _wingPivots = new Transform[2];
	
	#endregion
	#region Private Variables _______________________________________________________________________/ Private Variables

	private Vector3 _baseRotation;
	
	#endregion

	// _________________________________________________________________________________________________________/ Rotate
	public void RotateWings(float rotationStrength)
	{
		for (int i = 0; i < _wingPivots.Length; i++)
		{
			_wingPivots[i].rotation = Quaternion.Euler(new Vector3(0,0,1) * (rotationStrength/2) * (i == 0 ? 1 : -1));
		}
	}
}
