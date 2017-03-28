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
    [Activity(Label = "Started", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Started : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Quiz_Page);
            int score = 0;
            TextView QA = FindViewById<TextView>(Resource.Id.QA);
            EditText Input = FindViewById<EditText>(Resource.Id.Input);
            Button Send = FindViewById<Button>(Resource.Id.send);
            
            TextView Score = FindViewById<TextView>(Resource.Id.Points);
            Quiz_Hooker Quiz = new Quiz_Hooker();
            List<String> QA_List = Quiz.QSplitA();

            QA.Text = QA_List[0];
            List<String> ans = QA_List;
            ans.RemoveAt(0);
            Boolean Correct;
            Send.Click += (sender, e) =>
            {
                Correct = false;
                foreach (String EachString in ans)
                {
                    if ((StringSimilarity.CalculateSimilarity(Input.Text.ToLower(), EachString.ToLower()) * 100) >= 90)
                    {
                        
                        Correct = true;
                    }
                    if ((StringSimilarity.CalculateSimilarity(Input.Text.ToLower(), EachString.ToLower()) * 100) < 90)
                    {
                        
                        
                    }
                }
                //<This line is for debugging!> double StringSim_Break = StringSimilarity.CalculateSimilarity(Input.Text.ToLower(), ans.ToLower());
                if (Correct == true) { score = score + 1;
                    Toast.MakeText(this, "\\(´∀`)/", ToastLength.Long).Show(); }
                if (Correct == false) { score = score - 1;
                    Toast.MakeText(this, "O<(⋟﹏⋞)>O", ToastLength.Long).Show();
                }
                Score.Text = score + " Pt";
                
                Quiz_Hooker Quiz2 = new Quiz_Hooker();
                QA_List = Quiz2.QSplitA();
                Input.Text = "";
                QA.Text = QA_List[0];
                ans = QA_List;
                ans.RemoveAt(0);

            };

            // Create your application here
        }
    }
}