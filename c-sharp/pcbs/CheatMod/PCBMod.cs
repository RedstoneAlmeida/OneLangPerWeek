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
            CareerStatus.State state = CareerStatus.GetState();
                           
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(state.m_cash > 999999)
                {
                    return;
                }
                status.AddCash(999999);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                status.AddKudos(150);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                this.AddReview(status, state, new ReviewModded());
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
               
            }
        }

        public override void OnGUI()
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.cyan;
            style.fontSize = 20;
            style.fontStyle = FontStyle.Bold;
            style.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(Screen.width / 2 - 100, 10f, 200f, 30f),
                "CheatMod Debug\n" +
                "Cash = F | XP = G\n" +
                "Review = V", style);
        }

        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        private void AddReview(CareerStatus status, CareerStatus.State state, IReview job)
        {
            if (!status.UnlockedReviews() && !(job is DummyReview))
            {
                return;
            }
            state.m_reviews.Insert(0, job);
            float num = 0f;
            int num2 = Mathf.Min(state.m_reviews.Count, CareerConstants.s_numberReviewsForStarRating);
            for (int i = 0; i < num2; i++)
            {
                num += state.m_reviews[i].GetStars();
            }
            state.m_starRating = num / (float)num2;
            Achievements.OnStarRating(state.m_starRating);

            PlayerStatus playerStatus = UnityEngine.Object.FindObjectOfType<PlayerStatus>();
            if(playerStatus && playerStatus.m_starRating)
            {
                playerStatus.m_starRating.SetRating(status.GetStarRating());
            }
        }

        private void GenerateJob(JobDesc desc)
        {
            CareerStatus careerStatus = CareerStatus.Get();
            int num = 0;
            Job job;
            for(; ; )
            {
                job = desc.Generate(careerStatus.GetNextJobId());
                if (job.IsValid())
                {
                    break;
                }
                if(num++ == 10)
                {
                    goto Block_2;
                }
            }
            careerStatus.AddJob(job);
            return;
            Block_2:
                ModLogs.Log("Job don't created. 10 tries");
        }
    }
}
