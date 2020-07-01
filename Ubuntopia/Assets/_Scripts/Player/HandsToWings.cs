using UnityEngine;

public class HandsToWings : MonoBehaviour
{
	#region SerializeField Variables _________________________________________________________/ SerializeField Variables

	[SerializeField, Header("item 0 = left, item 1 = right")] 
	private Transform[] _wingPivots = new Transform[2];
	
	#endregion

	// _________________________________________________________________________________________________________/ Rotate
	public void RotateWings(float rotationStrength)
	{
		for (int i = 0; i < _wingPivots.Length; i++)
		{
			_wingPivots[i].localEulerAngles = Vector3.forward * (-rotationStrength*100);
		}
	}
}
