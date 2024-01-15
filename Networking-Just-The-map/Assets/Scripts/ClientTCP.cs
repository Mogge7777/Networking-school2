using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ClientTCP
{
    private TcpClient socket;
    private NetworkStream stream;
    private byte[] reciveBuffer;

    public const int dataBufferSize = 4096;

    public void Connect(string ip, int port)
    {
        socket = new TcpClient
        {
            ReceiveBufferSize = dataBufferSize,
            SendBufferSize = dataBufferSize

        };
    }
}
