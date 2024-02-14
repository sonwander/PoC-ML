using UnityEngine;
using TensorFlowLite;

public class TensorFlowLiteInference : MonoBehaviour
{
    private Interpreter interpreter;

    void Start()
    {
        LoadModel();
    }

    void Update()
    {
        // Implemente a lógica de inferência aqui
    }

    public void StartInference()
    {
        // Lógica para iniciar a inferência, se necessário
        Debug.Log("Inferência Iniciada");
    }

    public void StopInference()
    {
        // Lógica para parar a inferência, se necessário
        Debug.Log("Inferência Parada");
    }

    void LoadModel()
    {
        // Substitua "Path/To/Your/Model.tflite" pelo caminho real do seu modelo
        string modelPath = "C:\\Users\\Wanderson Silva\\Documents\\ML\\Assets\\Models\\tf-text.tflite";

        // Ler os bytes do arquivo do modelo
        byte[] modelData = System.IO.File.ReadAllBytes(modelPath);

        interpreter = new Interpreter(modelData);
    }

    void OnDestroy()
    {
        if (interpreter != null)
        {
            interpreter.Dispose();
        }
    }
}
