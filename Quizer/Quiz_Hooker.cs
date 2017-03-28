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
using System.IO;
using System.Net;

namespace Quizer
{
    class Quiz_Hooker
    {
       String Quiz_Get()
        {
           
            
           // try {
                var Quiz_Raw_In_Memory = new MemoryStream(new WebClient().DownloadData("https://www.dropbox.com/s/pgmqnqlqi9a7ogt/QuizAnswer_List.%E2%99%A5?dl=1"));
            // }
            // catch(Exception e) {
            StreamReader Read = new StreamReader(Quiz_Raw_In_Memory);
            
           // }
            String Quiz_Raw = Read.ReadToEnd().ToString(); 
            
            return (Quiz_Raw);
        }
       List<String> QA_Line() {
            String[] Raw = Quiz_Get().ToString().Split(System.Environment.NewLine.ToCharArray());
            List<String> Raw_Split_List = Raw.ToList<String>();
            return (Raw_Split_List);
        }
        String Quiz_randommizer()
        {

            Random ran = new Random();
            int raned = ran.Next(0, QA_Line().Count);
            return (QA_Line()[raned]);
        }
        public List<String> QSplitA()
        {
            return (Quiz_randommizer().Split('•').ToList<String>());
            
        }

    }
}