using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    public float horizontalRange; // adjust this value to change the horizontal detection range
    public float verticalRange; // adjust this value to change the vertical detection range
    private GameObject boneco; // the object to detect proximity to
    [SerializeField] private GameObject textBox;
    [SerializeField] TextBoxAnimation textBoxAnimation;

    void Awake() {
        boneco = GameObject.Find("boneco");
    }

    private void Update()
    {
        float horizontalDistance = Mathf.Abs(transform.position.x - boneco.transform.position.x);
        float verticalDistance = Mathf.Abs(transform.position.y - boneco.transform.position.y);

        //Debug.Log("Horizontal Distance: " + horizontalDistance);
        //Debug.Log("Vertical Distance: " + verticalDistance);
        
        if (horizontalDistance <= horizontalRange && verticalDistance <= verticalRange) {
            // object is near the target object
            //Debug.Log("Object is near!");
            if(Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("E key was released.");
                textBox.SetActive(true);
                textBoxAnimation.StartTyping();
            }
            // add your code here to handle the proximity detection
        }
    }
}