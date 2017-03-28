//https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
//https://github.com/uadnan/StringSimilarity
//by uadnan
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Quizer
{
    class StringSimilarity
    {
        
        public static double CalculateSimilarity(string source_cal, string target_cal)
        {
            int ComputeLevenshteinDistance(string source, string target)
            {
                
                if ((source == null) || (target == null)) return 0;
                if ((source.Length == 0) || (target.Length == 0)) return 0;
                if (source == target) return source.Length;

                int sourceWordCount = source.Length;
                int targetWordCount = target.Length;

                // Step 1
                if (sourceWordCount == 0)
                    return targetWordCount;

                if (targetWordCount == 0)
                    return sourceWordCount;

                int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

                // Step 2
                for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
                for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

                for (int i = 1; i <= sourceWordCount; i++)
                {
                    for (int j = 1; j <= targetWordCount; j++)
                    {
                        // Step 3
                        int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                        // Step 4
                        distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                    }
                }

                return distance[sourceWordCount, targetWordCount];
            }
            if ((source_cal == null) || (target_cal == null)) return 0.0;
            if ((source_cal.Length == 0) || (target_cal.Length == 0)) return 0.0;
            if (source_cal == target_cal) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source_cal, target_cal);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source_cal.Length, target_cal.Length)));
        }
    }
}