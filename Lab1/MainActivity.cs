using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab1
{
	[Activity(Label = "Lab1", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button button;
		TextView textViewDev;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button>(Resource.Id.myButton);
			textViewDev = FindViewById<TextView>(Resource.Id.textViewDev);

			button.Click += Button_Click;
		}

		async void Button_Click(object sender, System.EventArgs e)
		{
			textViewDev.Hint = "Insertar nombre";
			string myDevice = Android.Provider.Settings.Secure
									 .GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
			XamarinDiplomado.ServiceHelper helper = new XamarinDiplomado.ServiceHelper();
			await helper.InsertarEntidad("icalderond@outlook.com", "lab1", myDevice);
			button.Text = "Gracias por completar lab1";
		}
	}
}

