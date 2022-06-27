using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class MessageHandler : MonoBehaviour
{
    //Массив джоинтов скелета, на которые необходимо передавать данные
    [SerializeField]
    public GameObject[] Keypoints;

    //Переменная-поток для развертывания сервера
    Thread mThread;
    //Ip адрес сервера
    public string connectionIP = "127.0.0.1";
    //Порт сервера
    public int connectionPort = 25001;
    IPAddress localAdd;
    //Листенер необходим для считывания сообщений
    TcpListener listener;
    TcpClient client;
    //Переменная для удобного хранения обработанных точек
    List<Vector3> receivedPos = new List<Vector3>();

    private float[] zCoor = new float[12];

    bool running;

    private void Update()
    {
        for (int i = 0; i < receivedPos.Count; i++)
        {
            Keypoints[i].SendMessage("Handler", receivedPos[i]);
            //Keypoints[i].position = receivedPos[i]/10;
            //zCoor[i] = Keypoints[i].position.z;
        }
    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();

        for (int i = 0; i < 12; i++)
        {
            zCoor[i] = Keypoints[i].transform.position.z;
        }
    }

    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();

        client = listener.AcceptTcpClient();

        running = true;
        while (running)
        {
            SendAndReceiveData();
        }
        listener.Stop();
    }

    void SendAndReceiveData()
    {
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        //Получение информации от хоста
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize); //Получение информации в байтах от Python
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead); //Конвертирование байтовых данных в string формат

        if (dataReceived != null)
        {
            //Использование данных
            receivedPos = StringToVectors(dataReceived); //Присвоение полученных данных в переменную хранящую позиции

            //Отправка данных хосту
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Hey I got your message Python! Do You see this massage?"); //Конвертирование string в байтовых формат
            nwStream.Write(myWriteBuffer, 0, myWriteBuffer.Length); //Отправка байтовых сообщений Python
        }
    }

    public List<Vector3> StringToVectors(string sVector)
    {
        // Очистка от лишних символов
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // Разделение данных
        string[] sArray = sVector.Split('/');


        List<Vector3> result = new List<Vector3>();

        for (int i = 0; i < 23; i+=2)
        {
            var subV = new Vector3(float.Parse(sArray[i + 1]), float.Parse(sArray[i]), zCoor[i/2]);
            result.Add(subV);
        }


        return result;
    }
}