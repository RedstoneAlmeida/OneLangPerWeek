using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCBSModloader;
using PCBS;

namespace PCBMod
{
    class ReviewModded : IReview
    {

        private Random random = new Random();
        String[] reviews = {
            "Best Cases! My Custom PC is VERY FAST!",
            "No have best...",
            "Best Assistence!",
            "Cable Management is better!",
            "The Best PC",
            "I'm Happy using my new PC!",
            "Modded PC, Very Good! Thanks! "
        };

        public int GetAvatarId()
        {
            return 1;
        }

        public int GetDay()
        {
            return random.Next(0, 20);
        }

        public string GetFrom()
        {
            return "cheat_modded@modded.com";
        }

        public string GetReview()
        {
            return reviews[random.Next(0, reviews.Length - 1)];
        }

        public float GetStars()
        {
            return 5;
        }
    }
}
