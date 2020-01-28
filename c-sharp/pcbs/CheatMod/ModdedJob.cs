using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCBSModloader;

namespace PCBMod
{
    class ModdedJob
    {

        private bool initialized = false;

        public int percentage = 40;

        public void OnInit()
        {
            this.initialized = true;
        }

        public bool IsInitialized()
        {
            return this.initialized;
        }

        public bool GeneratePreviewJob(CareerStatus status, CareerStatus.State state)
        {
            bool flag = status.GetStarRating() >= 5f || UnityEngine.Random.Range(0, 100) > 50;
            int num = LevelProgression.GetZeroIndexedLevel(state.m_kudos) + 1;
            int minKudos = (!flag) ? state.m_kudos : LevelProgression.GetThreshold(num);
            int maxKudos = (!flag) ? state.m_kudos : LevelProgression.GetThreshold(num + 1);
            float minStarRating = (!flag) ? (status.GetStarRating() + 0.1f) : 0f;
            float maxStarRating = (!flag) ? (status.GetStarRating() + 1f) : 0f;
            bool includeStory = false;
            bool expandRatingSearch = false;
            Job job = status.m_career.GenerateJob(minKudos, maxKudos, minStarRating, maxStarRating, includeStory, state.m_completedJobs, status.GetCurrentJobDesc(), state.m_generatedJobs, expandRatingSearch);
            if (job != null)
            {
                ModLogs.Log("Budget from " + job.GetDesc().m_from + " value $" + job.m_budget);
                job.m_budget = job.m_budget + ((job.m_budget * percentage) / 100);
                status.AddJob(job);
                return true;
            }
            return false;
        }

        public bool GenerateJob(CareerStatus status, CareerStatus.State state)
        {
            bool includeStory = true;
            bool expandRatingSearch = true;
            Job job = status.m_career.GenerateJob(state.m_kudos, state.m_kudos, status.GetStarRating(), status.GetStarRating(), includeStory, state.m_completedJobs, status.GetCurrentJobDesc(), state.m_generatedJobs, expandRatingSearch);
            if (job != null)
            {
                ModLogs.Log("Budget from " + job.GetDesc().m_from + " value $" + job.m_budget);
                job.m_budget = job.m_budget + ((job.m_budget * percentage) / 100);
                status.AddJob(job);
                return true;
            }
            return false;
        }

    }
}
