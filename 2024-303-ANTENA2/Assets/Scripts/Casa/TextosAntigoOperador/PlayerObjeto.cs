using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProximityDetector : MonoBehaviour
{
    public float horizontalRange; // adjust this value to change the horizontal detection range
    public float verticalRange; // adjust this value to change the vertical detection range
    private GameObject boneco; // the object to detect proximity to
    [SerializeField] private GameObject textBox;
    [SerializeField] private TextBoxAnimation textBoxAnimation;
    [SerializeField] private GameObject textoInteracao;
    public EscritosSO escritoNoMovel;
    [SerializeField] private DocumentosEncontrados documentosEncontrados;
    [SerializeField] private Button btnSim;
    [SerializeField] private Button btnFecha;
    bool existeDoc;
    private bool isInteracting = false;

    void Awake() {
        boneco = GameObject.Find("boneco");
    }

    void Start() {
        if(GameHandler.Dia != 0) {
            if (escritoNoMovel.escritosDocs[GameHandler.Dia - 1].escrito != null) {
                existeDoc = true;
            }
            else {
                existeDoc = false;
            }
        }
        else {
            existeDoc = false;
        }
    }

    private void Update() {
        float horizontalDistance = Mathf.Abs(transform.position.x - boneco.transform.position.x);
        float verticalDistance = Mathf.Abs(transform.position.y - boneco.transform.position.y);
        
        if (existeDoc) {
            if (horizontalDistance <= horizontalRange && verticalDistance <= verticalRange) {
                textoInteracao.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E)) {

                    Debug.Log("E key was released.");

                    textoInteracao.SetActive(false);
                    textBox.SetActive(true);

                    textBoxAnimation.StartTyping();

                    if (btnSim != null && documentosEncontrados != null) {
                        btnSim.onClick.AddListener(() => documentosEncontrados.AbreDoc());
                        btnFecha.onClick.AddListener(() => documentosEncontrados.FechaDoc());
                    }
                    else {
                        Debug.LogError("One or both of btnSim and documentosEncontrados are null!");
                    }           
                    isInteracting = true;                            
                }
            }
            else {
                textoInteracao.SetActive(false);
                isInteracting = false;
                if (btnSim != null) {
                    btnSim.onClick.RemoveListener(() => documentosEncontrados.AbreDoc());
                    btnFecha.onClick.RemoveListener(() => documentosEncontrados.FechaDoc());
                }
            }
        }
    }
}