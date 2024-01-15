using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
   public static Client instance;

   public string ip = "127.0.0.1";
   public int port = 25565;
   public int Id = 0;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else if (instance != this)
      {
         Destroy(this);
      }
   }
   
}
