using System;
using System.Collections.Generic;
using System.Text;

namespace ProfaceInfoQuickTransferUtility
{
    class WorkStationPLC
    {
        public string PLCName { get; set; }
        public float EncoderValue { get; set; }
        public short WsId { get; set; }
    }
}
