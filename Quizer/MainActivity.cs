using Android.App;
using Android.Widget;
using Android.OS;

namespace Quizer
{
    [Activity(Label = "Quizer", MainLauncher = true, Icon = "@drawable/icon",ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle); 
            SetContentView(Resource.Layout.Main);
            
            Button start_button = FindViewById<Button>(Resource.Id.startbutton);
            start_button.Click += (sender, e) =>
            {
               
            var intent = new Android.Content.Intent(this, typeof(Started));
                StartActivity(intent);
                
            };
            // Set our view from the "main" layout resource

        }
        
}
}

