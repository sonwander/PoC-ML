using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    private ForegroundService foregroundService;
    private TensorFlowLiteInference tensorflowLiteInference;

    // Eventos Unity para associar ao botão
    public UnityEvent onStartServiceClicked;
    public UnityEvent onStopServiceClicked;

    void Start()
    {
        foregroundService = new ForegroundService();
        tensorflowLiteInference = GetComponent<TensorFlowLiteInference>();
    }

    public void StartServiceButton()
    {
        foregroundService.StartService();
        onStartServiceClicked.Invoke(); // Invocar o evento associado ao botão de iniciar serviço

        // Adapte isso conforme necessário para chamar métodos do seu script de inferência
        if (tensorflowLiteInference != null)
        {
            tensorflowLiteInference.StartInference();
        }
    }

    public void StopServiceButton()
    {
        foregroundService.StopService();
        onStopServiceClicked.Invoke(); // Invocar o evento associado ao botão de parar serviço

        // Adapte isso conforme necessário para chamar métodos do seu script de inferência
        if (tensorflowLiteInference != null)
        {
            tensorflowLiteInference.StopInference();
        }
    }
}
