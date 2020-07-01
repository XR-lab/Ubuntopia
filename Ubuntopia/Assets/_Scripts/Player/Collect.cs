using UnityEngine;

public class Collect : MonoBehaviour
{
    [SerializeField] private MistReducer _mist;
    
    public void Collected()
    {
        //Enter follow uo code on collection here(Cutscene/other code)
        _mist.MistDown();
        GameObject.Destroy(this.gameObject);
    }
}
