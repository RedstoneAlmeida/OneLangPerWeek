using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCBSModloader;
using UnityEngine;
using Random = System.Random;

namespace PCBMod
{
    public class PCBMod : Mod
    {
        public override string ID { get { return "FirstPCMod"; } }

        public override string Version { get { return "0.1"; } }

        public override string Author { get { return "Me"; } }

        private static PCBMod singletonInstance;

        public static PCBMod Instance
        {
            get
            {
                singletonInstance = singletonInstance != null ? singletonInstance : new PCBMod();
                return singletonInstance;
            }
        }

        private GUIStyle style = new GUIStyle();

        private String[] lines = new String[]{};

        public override void OnInit()
        {
            CareerConstants.s_siliconLotteryPercentage = 90;
        }

        public override void Update()
        {

            CareerStatus status = CareerStatus.Get();
                           
            if (Input.GetKeyDown(KeyCode.F))
            {
                CareerStatus.GetState().m_cash = 999999;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                status.AddKudos(150);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                WorkshopController controller = WorkshopController.Get();
                Transform f = controller.playerTransform.transform;
                f.position = new Vector3(288.9f + NextFloat(new Random()), 12 + NextFloat(new Random()), 298.1f + NextFloat(new Random()));
                controller.SetPlayerPos(f);
            }
        }

        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
    }
}
