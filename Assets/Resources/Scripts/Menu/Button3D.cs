using UnityEngine;
using UnityEngine.SceneManagement;

public class Button3D : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.name == "Tap")
        {
            SceneManager.LoadScene("TapToExplodeWater");
        }
        else if (gameObject.name == "Two")
        {
            SceneManager.LoadScene("TwoObjWater");
        }
        else if (gameObject.name == "Three")
        {
            SceneManager.LoadScene("BulletWater");
        }
    }

}
