using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace dns
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("pls select which u want to do,if u want to QUIT,pls input 'q'...");
                Console.WriteLine("1,get ip by host name...");
                Console.WriteLine("2,ping ip...");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Pls input the HOST name,press the ENTER..,if u want to QUTI,pls input 'q'...");
                        string hostname = Console.ReadLine();
                        if (hostname.ToLower() != "q")
                        {
                             System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostname);//会返回所有地址，包括IPv4和IPv6   
                             foreach (IPAddress ip in addressList)
                            {
                                Console.WriteLine(ip.ToString());
                            }
                        }
                        else
                        {
                            break;
                        }
                       break;
                    case "2":
                       Console.WriteLine("Pls input the ip,if u want to QUIT,pls input 'q'...");
                       string input = Console.ReadLine();
                       if (input.ToLower() != "q")
                       {
                           System.Diagnostics.Process p = new System.Diagnostics.Process();
                           p.StartInfo.FileName = "cmd.exe";
                           p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                           p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                           p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                           p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                           p.StartInfo.CreateNoWindow =false ; //不显示程序窗口   
                           p.Start();//启动程序
                            //向cmd窗口发送输入信息
                           //p.StandardInput.WriteLine("ping " + input);          
                           p.StandardInput.WriteLine("ping " + input);                  
                           p.StandardInput.WriteLine("exit");
                           //p.StandardInput.AutoFlush = true;                           
                           //获取cmd窗口的输出信息
                           string output = p.StandardOutput.ReadToEnd();                        
                           p.WaitForExit();//等待程序执行完退出进程
                           p.Close();
                           Console.WriteLine(output);
                       }
                       else
                           break;
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("can't have u input,pls reinput...");
                        break;
                }             

            }
            
           
        }
    }
}
