using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections;
namespace IOManage
{
    abstract public class IOManage
    {
        //protected  Dictionary<Tkey, Tvalue>IOInst<Tkey, Tvalue>();//IO索引和IO操作接口
        public delegate T dataComeCallBack<T,Tsender,Tvalue>(Tsender sender, Tvalue value);//泛型委托类型，数据到来时的回调，子类中实例化
        public IOManage()
        {
        } 
        /// <summary>
        /// 获取IO接口列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        virtual public T getIOList<T>()where T:new()
        {
            return new T();
        }
        /// <summary>
        /// 获取IO是否可用
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        virtual public T getIOStatus<T>(T value)
        {
            return value;
        }
        /// <summary>
        /// 绑定数据channel到指定的数据目的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <returns></returns>
        virtual public T bindIOChannel<T,T1>(T channel, T1 dest)
        {
            return channel;
        }
        /// <summary>
        /// 从IO中获取输入
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        virtual public T In<T>(T interfaceName)
        {
            return interfaceName;
        }
        /// <summary>
        /// 向IO输出数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        virtual public T Out<T,T1,T2>(T1 value, T count, T2 interfaceName)
        {
            return count;
        }
    }
    /// <summary>
    /// 端口的操作类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class portDesc<T> where T : new()
    {
        public SerialPort port;
        public T rxBuff;
        public T txBuff; 
        public portDesc(SerialPort port)
        {
            this.port = port;
            rxBuff = new T();
            txBuff = new T();
        }
    }
    class serialPortManage : IOManage
    {
        int BaudRate = 115200;
        public Dictionary<string, portDesc<List<byte>>> IOInst = new Dictionary<string,portDesc<List<byte>>>();
        public event dataComeCallBack<int,SerialPort,int>dcEvent;//新数据到来事件
        /// <summary>
        /// 硬件串口数据到达回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataComeFunction(object sender, SerialDataReceivedEventArgs e)
        {
            //if (e.EventType == System.IO.Ports.SerialData.Eof)//接收完成
            {
                SerialPort port = sender as SerialPort;//发送者端口
                portDesc<List<byte>> desc;//端口操作类
                IOInst.TryGetValue(port.PortName, out desc);
                int readCount = port.BytesToRead;
                byte[]recBuf=new byte[readCount];
                try
                {
                    port.Read(recBuf,0,readCount);
                    foreach(var item in recBuf)
                    {
                        desc.rxBuff.Add(item);
                    }
                    dcEvent(port, desc.rxBuff.Count);//通知有新数据
                }
                catch (Exception)
                {
                    Console.Write("{0}接收出错\n", port.PortName);
                }
            }
        }
        public serialPortManage()
            : base()
        {
            //获取端口列表
            string[] ports = SerialPort.GetPortNames();
                foreach(var eachPort in ports){
                    portDesc<List<byte>> desc = new portDesc<List<byte>>(new SerialPort(eachPort));//实例化端口操作类
                    this.IOInst.Add(eachPort, desc);//添加端口名称和实例
                }
        }
        /// <summary>
        /// 返回端口列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string[] getIOList()
        {
           return SerialPort.GetPortNames();
        }
        /// <summary>
        /// 获取指定IO是否开启的状态
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool getIOStatus(string portName)
        {
            portDesc<List<byte>>portdesc;
            try
            {
                this.IOInst.TryGetValue(portName, out portdesc);
                return portdesc.port.IsOpen;
            }
            catch (Exception)
            {
                Console.Write("没有该串口\n");
                return false;
            }
        }
        /// <summary>
        /// 开启数据通道
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public bool openChannel(string portName, int BaudRate)
        {
            if (getIOStatus(portName)==true)
            {
                return false;
            }
            if (BaudRate >= 0) this.BaudRate = BaudRate;
            portDesc<List<byte>> port;
            try
            {
                IOInst.TryGetValue(portName, out port);
                port.port.BaudRate = BaudRate;
                port.port.RtsEnable = true;
                port.port.NewLine = "\r";
                port.port.DataReceived += dataComeFunction;//注册数据到来事件回调函数
                port.port.Open();
            }
            catch (Exception)
            {
                Console.Write("{0}打开失败\n", portName);
                return false;
            }
            return true;
        }

        public bool closeChannel(string portName)
        {
            if (getIOStatus(portName) == false)
            {
                return true;
            }
            portDesc<List<byte>> port;
            try
            {
                IOInst.TryGetValue(portName, out port);
                port.port.Close();
            }
            catch (Exception)
            {
                Console.Write("{0}关闭失败\n", portName);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 从某个port获取输入数据
        /// </summary>
        /// <param name="portName"></param>
        /// <returns></returns>
        public byte[] In(string portName)
        {
            if (getIOStatus(portName) == false)
            {
                return null;
            }
            portDesc<List<byte>> port;
            int count= 0;
            try
            {
                IOInst.TryGetValue(portName, out port);
                count = port.rxBuff.Count;
                if (count <= 0)
                    return null;
                return port.rxBuff.ToArray();
            }
            catch (Exception)
            {
                Console.Write("{0}错误\n", portName);
            }
            return null;
        }
        /// <summary>
        /// 向指定串口发送数据，返回发送成功字节计数
        /// </summary>
        /// <param name="buff"></param>
        /// <param name="portName"></param>
        /// <returns></returns>
        public int Out(byte[] buff,int count, string portName)
        {
            int sendCount = 0;
            if (getIOStatus(portName) == false)
            {
                return -1;
            }
            portDesc<List<byte>> port;
            try
            {
                IOInst.TryGetValue(portName, out port);
                port.port.Write(buff, 0, count);
                sendCount = count;
            }
            catch (Exception)
            {
                Console.Write("{0}错误\n", portName);
                return -1;
            }
            return sendCount;
        }
    }
}
