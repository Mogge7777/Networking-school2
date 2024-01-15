using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Packet
{
    //data writing in to the packet
    private List<byte> writableData = new List<byte>();
    
    //when we create data from the server
    private byte[] data;

    //moving through arrey tracking position
    private int readPosition;

    public Packet()
    {
        
    }

    public Packet(byte[] data)
    {
        this.data = data;
    }
    
    public byte GetByte()
    {
        byte value = data[readPosition];
        readPosition += 4;
        return value;
    }
    public byte[] GetBytes(int len)
    {
        //creating new byte arrey of len
        byte[] value = new byte[len];
        
        //copying from the data buffer to the new byte arrey above
        Array.Copy(value, readPosition, value, 0, len );
        
        //changes readposition by how much we red
        readPosition += len;
        
        //returning bytes we read
        return value;
    }
    //get lenght of string (31.34)
    public int GetInt()
    {
        //value and where to start (arguments) 
        int value = BitConverter.ToInt32(data, readPosition);
        readPosition += 4;
        return value;
    }
    //this server will first encode lenght of code/how much we want to read
    public string GetString()
    {
        int length = GetInt();
        string value = Encoding.ASCII.GetString(data, readPosition, length);
        return value;
    }
    public void Add(byte data)
    {
        writableData.Add(data);
    }
    public void Add(byte[] data)
    {
        writableData.AddRange(data);
    }
    public void Add(int data)
    {
        writableData.AddRange(BitConverter.GetBytes(data));
    }
}
public enum PacketID
{
    S_welcome = 1,
    S_spawnPlayer = 2,
    S_playerPosition = 3,
    S_playerRotation = 4,
    S_playerShoot = 5,
    S_playerDisconnected = 6,
    S_playerHealth = 7,
    S_playerDead = 8,
    S_playerRespawned = 9,


    C_spawnPlayer = 126,
    C_welcomeReceived = 127,
    C_playerMovement = 128,
    C_playerShoot = 129,
    C_playerHit = 130,
}
