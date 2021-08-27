using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProEasyDotNet;

namespace ProfaceInfoQuickTransferUtility
{
    public partial class FrmMain : Form
    {
        //GLOBALS
        private List<WorkStationPLC> workStationModelList = new List<WorkStationPLC>();
        private List<string> gWorkstationNames = new List<string>() { "GANG_RIP_201", "BAKER2_202", "IRONWOOD_SANDER_203", "TAPING_204", "COMPACT_205", "MOLDER_206", "FINISHING_207", "CNC_208", "DSB_211", "PLANER_212", "PRESSING_213" };

        public FrmMain()
        {
            InitializeComponent();

        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }
        public void SetTextBox(String text)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () { SetTextBox(text); });
                return;
            }
           rtbConsole.Text += text+"\n";
        }

        private void GetProfaceWords(WorkStationPLC plc)
        {
            try
            {
                int Return_Result = 0;
                string ErrorMessage = "";
               float[] encoderValues = new float[1];
               short[] wsIDs = new short[1];

                IntPtr intPtr1 = ProEasy.CreateProServerHandle();


                //TODO: Set value to whatever encoder address word value is
                Return_Result = ProEasy.ReadDeviceFloatM(intPtr1, plc.PLCName + ".#INTERNAL", "ENCODER_CALIBRATION", out encoderValues, 1);
                if (Return_Result != 0)
                {
                    ProEasy.EasyLoadErrorMessageEx(Return_Result, out ErrorMessage);
                    SetTextBox("Read " + plc.PLCName + " Error:" + ErrorMessage);
                }
                else
                {
                    plc.EncoderValue = encoderValues[0];
                }
                //Todo: Set value to whatever WorkstationID is
                //Return_Result = ProEasy.ReadDeviceStrM(intPtr1, plc.PLCName + ".#INTERNAL", "", out myStringBuilder, 100);
                Return_Result =
                    ProEasy.ReadDevice16M(intPtr1, plc.PLCName + ".#INTERNAL", "WORKSTATION_ID", out wsIDs, 1);
                if (Return_Result != 0)
                {
                    ProEasy.EasyLoadErrorMessageEx(Return_Result, out ErrorMessage);
                    SetTextBox("Read " + plc.PLCName + " Error:" + ErrorMessage);
                }
                else
                {
                    plc.WsId = wsIDs[0];
                }


                // kill pointer
                ProEasy.DeleteProServerHandle(intPtr1);

            }
            catch (Exception ex)
            {
                SetTextBox("GetProfaceWords Error:" + ex.Message);

            }
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var workstation in gWorkstationNames)
                {
                    workStationModelList.Add(new WorkStationPLC() {PLCName = workstation});
                }

                foreach (var workStation in workStationModelList)
                {
                    GetProfaceWords(workStation);
                    SetTextBox(workStation.PLCName + " " + workStation.WsId + " " + workStation.EncoderValue);
                }

                btnLoadSettings.Enabled = true;

            }
            catch(Exception ex)
            {
                SetTextBox("Error trying to load settings: ");
                SetTextBox(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (workStationModelList.Count > 0)
            {
                try
                {
                    foreach (WorkStationPLC workStation in workStationModelList)
                    {
                        SetProfaceWords(workStation);
                    }

                }
                catch
                {
                    SetTextBox("Error setting Proface words");
                }
            }
            else SetTextBox("There are no PLCs configured to send data to.");

        }

        private void SetProfaceWords(WorkStationPLC workStation)
        {
            try
            {
                int Return_Result = 0;
                string ErrorMessage = "";
                IntPtr intPtr1 = ProEasy.CreateProServerHandle();

                
                short[] wsIDs = new short[]{workStation.WsId};
                float[] encoderFloats = new float[] {workStation.EncoderValue};

                Return_Result = ProEasy.WriteDeviceFloatM(intPtr1, workStation.PLCName + ".#INTERNAL", "ENCODER_CALIBRATION", encoderFloats, 1);
                if (Return_Result != 0)
                {
                    ProEasy.EasyLoadErrorMessageEx(Return_Result, out ErrorMessage); 
                    SetTextBox("WriteDevice32 Error:" + ErrorMessage);
                }
                else
                {
                    SetTextBox($"Successfully sent calibration to {workStation.PLCName} ");
                }

                Return_Result = ProEasy.WriteDevice16M(intPtr1, workStation.PLCName+".#INTERNAL", "TotalPartCount", wsIDs, 1);
                if (Return_Result != 0)
                {
                    ProEasy.EasyLoadErrorMessageEx(Return_Result, out ErrorMessage);
                    SetTextBox("WriteDevice32 Error:" + ErrorMessage);
                }
                else
                {
                   SetTextBox($"Successfully set Workstation_ID at {workStation.PLCName}");
                }
                ProEasy.DeleteProServerHandle(intPtr1);
            }
            catch (Exception ex)
            {
                SetTextBox("SetProfaceWords Error:" + ex.Message);

            }
        }
    }
}
