using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using logHelper;
using IOManage;
using utilHelper;
using System.IO.Ports;
namespace pcPort
{
    public partial class mainDisplay : Form
    {
        serialPortManage ports = new serialPortManage();//port类型
        private string[] portList;
        string activatedPort;//当前激活的串口
        private const string txCountStr = "发送统计:";
        private const string rxCountStr = "接收统计:";
        private Int64 rxCountNum=0;
        private Int64 txCountNum=0;
        private List<byte> rxBuff = new List<byte>();
        private List<byte> txBuff = new List<byte>();
        bool txHex=false, rxHex=false; //16进制模式开关
        bool txCR = false, rxCR = false;//自动换行开关
        /// <summary>
        /// 初始化
        /// </summary>
        public void sourceInit(){
            portList = ports.getIOList();//获取port列表
            comboPortList.DataSource = portList.ToList();//设置数据源
            //面板初始状态
            comboBaudrate.Text = "115200";
            comboPortList.Text = "";
            comboBaudrate.Text = "";
            rx.Text = "";
            tx.Text = "";
            checkBoxHexSend.CheckState = txHex ? CheckState.Checked : CheckState.Unchecked;
            checkBoxHexView.CheckState = rxHex ? CheckState.Checked : CheckState.Unchecked;
            txCount.Text = mainDisplay.txCountStr + txCountNum.ToString();
            rxCount.Text = mainDisplay.rxCountStr + rxCountNum.ToString();
        }
        public mainDisplay()
        {
            InitializeComponent();
            sourceInit();
        }
        /// <summary>
        /// 开关按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOpenClose_Click(object sender, EventArgs e)
        {
            string portName = comboPortList.Text.ToString();
            int baudRate = Convert.ToInt32(comboBaudrate.Text.ToString());
            if (btOpenClose.Text.ToString() == "打开")
            {
                if (ports.openChannel(portName, baudRate) == true)
                {
                    btOpenClose.Text = "关闭";
                    activatedPort = portName;
                    ports.dcEvent += rxCallBack;//注册回调
                }
            }
            else
            {
                if (ports.closeChannel(portName) == true)
                {
                    btOpenClose.Text = "打开";
                }
            }
        }
        /// <summary>
        /// 接收数据的回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private int rxCallBack(object sender, int value)
        {
            SerialPort port = sender as SerialPort;
            int readCount = value;
            portDesc<List<byte>> desc;//端口操作类
            byte[] recBuf = new byte[readCount];
            try{
                ports.IOInst.TryGetValue(port.PortName, out desc);
                desc.rxBuff.CopyTo(recBuf);
                //因为要访问ui资源，所以需要使用invoke方式同步ui。
                this.Invoke((EventHandler)(delegate
                {
                    //追加的形式添加到文本框末端，并滚动到最后。
                    this.rx.AppendText(utilHelper.utilHelper.byte2str(recBuf));
                    this.rxCountNum += readCount;
                    this.rxCount.Text = rxCountStr + rxCountNum.ToString();
                }));
                desc.rxBuff.Clear();
            }
            catch (Exception)
            {

            }
            return readCount;
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btReset_Click(object sender, EventArgs e)
        {
            string portName = comboPortList.Text.ToString();
            int baudRate = Convert.ToInt32(comboBaudrate.Text.ToString());
            if (btOpenClose.Text.ToString() == "关闭")
            {
                if (ports.closeChannel(portName) == true)
                {
                    btOpenClose.Text = "打开";
                }
                else return;
            }
            comboPortList.Text = "";
            comboBaudrate.Text = "";
            rx.Text = "";
            tx.Text = "";
            rxCountNum = 0;
            txCountNum = 0;
            txCount.Text = mainDisplay.txCountStr;
            rxCount.Text = mainDisplay.rxCountStr;
        }
        /// <summary>
        /// 发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            //获取要发送的数据
            string send = tx.Text.ToString().Trim();
            string s = "";
            byte[] buf;
            //根据当前的数据模式处理数据
            if (txHex == true)
            {
                //31 32 33转成123
                s = utilHelper.utilHelper.hex2ascii(send);
                //123转成byte[] 31 32 33
                buf = utilHelper.utilHelper.str2byte(s);
            }
            else//非hex模式，1234
            {
                buf = utilHelper.utilHelper.str2byte(send);
            }
            //拷贝到txBuff
            foreach (var item in buf)
            {
                txBuff.Add(item);
            }
            int sendCount = txBuff.Count;
            try
            {
                sendCount = ports.Out(txBuff.ToArray<byte>(), sendCount, activatedPort);
                if (txCR == true) { ports.Out(new byte[]{0x0d}, 1, activatedPort); }
                txCountNum += sendCount;
                txCount.Text = txCountStr + txCountNum.ToString();
                txBuff.Clear();
            }
            catch (Exception)
            {
                Console.WriteLine("发送失败");
            }
        }
        /// <summary>
        /// 勾选项变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxHexSend_CheckedChanged(object sender, EventArgs e)
        {
            txHex = ((checkBoxHexSend.Checked == true)?true:false);
            string s = tx.Text.ToString().Trim();
            if (txHex == true)//当前数据转成hex
            {
               s = utilHelper.utilHelper.ascii2hex(s);
            }
            else//当前数据转成ascii
            {
                s = utilHelper.utilHelper.hex2ascii(s);
            }
            tx.Text = s;
        }
        /// <summary>
        /// 勾选项变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxHexView_CheckedChanged(object sender, EventArgs e)
        {
            rxHex = ((checkBoxHexView.Checked == true) ? true : false);
            string s = rx.Text.ToString().Trim();
            if (rxHex == true)//当前数据转成hex
            {
                s = utilHelper.utilHelper.ascii2hex(s);
            }
            else//当前数据转成ascii
            {
                s = utilHelper.utilHelper.hex2ascii(s);
            }
            rx.Text = s;
        }

        /// <summary>
        /// tx清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            tx.Text = "";
            txCountNum = 0;
            txCount.Text = txCountStr + txCountNum.ToString();
        }
        /// <summary>
        /// rx清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            rx.Text = "";
            rxCountNum = 0;
            rxCount.Text = rxCountStr + rxCountNum.ToString();
        }
        /// <summary>
        /// rx自动换行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxrxCR_CheckedChanged(object sender, EventArgs e)
        {
            rxCR = ((checkBoxrxCR.Checked == true) ? true : false);
        }
        /// <summary>
        /// tx自动换行按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxtxCR_CheckedChanged(object sender, EventArgs e)
        {
            txCR = ((checkBoxtxCR.Checked == true) ? true : false);
        }

    }
}
