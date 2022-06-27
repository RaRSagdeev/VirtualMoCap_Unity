using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

public class JsonDeserializer : MonoBehaviour
{
    // Словарь, необходимый для записи данных с файла
    public Dictionary<string, List<Dictionary<string, float>>> data = new Dictionary<string, List<Dictionary<string,float>>>();

    // Список ключей словаря
    public string[] names = {
        "left shoulder", "right shoulder", "left elbow", "right elbow", "left wrist", "right wrist", 
        "left hip", "right hip", "left knee", "right knee", "left ankle", "right ankle" };

    // Переменная-путь к файлу
    public string FilePath;
    public string Json;

    // Start is called before the first frame update
    void Start()
    {
        // Настройка пути до файла Json
        FilePath = Path.Combine(Environment.CurrentDirectory, "Assets\\data_file.json");
        Json = File.ReadAllText(FilePath);
        //Десериализация файла
        Newtonsoft.Json.Linq.JObject json_data = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(Json);
        //Запуск алгоритма считывания и записи координат точек
        AddJoints(json_data);
    }

    // Update is called once per frame
    void Update()
    {
        Newtonsoft.Json.Linq.JObject json_data = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(Json);
        ChangeJoints(json_data);

        Debug.Log(data["nose"][0]["x"]);
    }

    void AddJoints(Newtonsoft.Json.Linq.JObject json_data)
    {
        foreach (var name in names)
        {
            Dictionary<string, float> coord = new Dictionary<string, float>();
            List<Dictionary<string, float>> coordinates = new List<Dictionary<string, float>>();
            coord.Add("x", (float)json_data[name][0]["x"]);
            coord.Add("y", (float)json_data[name][1]["y"]);
            coordinates.Add(coord);
            data.Add(name, coordinates);
        }
    }

    void ChangeJoints(Newtonsoft.Json.Linq.JObject json_data)
    {
        foreach (var name in names)
        {
            Dictionary<string, float> coord = new Dictionary<string, float>();
            List<Dictionary<string, float>> coordinates = new List<Dictionary<string, float>>();
            coord.Add("x", (float)json_data[name][0]["x"]);
            coord.Add("y", (float)json_data[name][1]["y"]);
            coordinates.Add(coord);
            data[name] = coordinates;
        }
    }
}