using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace ServerChat
{
    public class ServerObj
    {
        static TcpListener tcpListener; // сервер для прослуховування
        List<ClientObj> clients = new List<ClientObj>(); // все подключения
        protected internal void AddConnection(ClientObj clientObj)
        {
            clients.Add(clientObj);
        }
        protected internal void RemoveConnection(string id)
        {
            // отримуємо за id закрите підключення
            ClientObj client = clients.FirstOrDefault(c => c.Id ==
           id);

            if (client != null)
                clients.Remove(client);
        }
        // прослуховування вхідних повідомлень
        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ClientObj clientObject = new
                    ClientObj(tcpClient, this);
                    Thread clientThread = new Thread(new
                   ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }
        // трансляція повідомлення підключеним клієнтам
        protected internal void BroadcastMessage(string message, string
       id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length);
                    //передача даних
                }
            }
        }
        // відключення всії клієнтів
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close();
            }
            Environment.Exit(0);
        }
    }
}
