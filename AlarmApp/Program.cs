using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlarmApp
{
	class Program
	{
		public static void Main(string[] args)
		{
			Alaram a1 = new Alaram();

			bool tryAgain = false;

			while (! tryAgain)
			{


				DateTime timeNow = DateTime.UtcNow.ToLocalTime();

				Console.WriteLine("Current time => {0}:{1}:{2}", timeNow.TimeOfDay.Hours.ToString(), timeNow.TimeOfDay.Minutes.ToString(), timeNow.TimeOfDay.Seconds.ToString());


				DateTime alaramTime = a1.getAlaramTime(timeNow);


				if (timeNow.CompareTo(alaramTime) == 1)
				{
					Console.Clear();
					Console.WriteLine("Cant ring alarm for past try again");
					continue;
				}


				Console.WriteLine("Alarm will ring at => {0}h:{1}m:{2}s", alaramTime.TimeOfDay.Hours.ToString(), alaramTime.TimeOfDay.Minutes.ToString(), alaramTime.TimeOfDay.Seconds.ToString());
				//Console.WriteLine('\n');




				while (true)
				{
					timeNow = DateTime.UtcNow.ToLocalTime();

					if (timeNow.Hour == alaramTime.Hour && timeNow.Minute == alaramTime.Minute)
					{
						Console.Clear();
						Console.WriteLine("Time now: {0}", timeNow);
						a1.ringBell(28);
						break;
					}
				}


				Console.Write("To set alaram again press Y:> ");
				char descision = Console.ReadKey(true).KeyChar;


				Console.WriteLine(descision);

				if (descision == 'y' || descision == 'Y')
				{
					continue;

				}
				else
				{
					tryAgain = true;
				}



			}



			Console.WriteLine("Bye");
			a1.pauseTime(10000);




		}
	}
}

public class Alaram
{
	public void ringBell(int cnt)
	{
		for (int i = 0; i < cnt; i++)
		{
			Console.Beep(2500, 200);
			//Console.Write(' ');
		}
	}


	public DateTime getAlaramTime(DateTime timeNow)
	{


		Console.Write("Enter Hours[in 24H format]: ");
		int hours = Convert.ToInt32(Console.ReadLine());

		Console.Write("Enter Minutes: ");
		int mins = Convert.ToInt32(Console.ReadLine());

		//Console.Write("Enter Seconds: ");
		//int secs = Convert.ToInt32(Console.ReadLine());
		int secs = 0;

		DateTime alaramTime = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, hours, mins, secs);

		return alaramTime;
	}

	public void pauseTime(int time)
	{
		for (int i = 0; i < time*100; i++) ;
	}
}
