using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOutroScene : MonoBehaviour {
  // References.
  [SerializeField, Header("Drag Harish here (from scene hierarchy).")]
  private Movement _movement;

  private void Start() {
    // Subscribe to event.
    _movement.Arrived += SwitchScene;
  }

  // Unsubscribe from event.
  private void OnDestroy() {
    _movement.Arrived -= SwitchScene;
  }

  // If the waypoint we arrive at (from movement) is equal to this game object, switch scene.
  private void SwitchScene(GameObject obj) {
    if (obj == gameObject) {
      SceneManager.LoadSceneAsync("OutroScene");
    }
  }
}
