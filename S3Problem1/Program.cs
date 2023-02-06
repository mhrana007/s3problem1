using System;

namespace S3Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sample Input 1
            DateTime startTime = DateTime.Parse("2019-08-31 08:59:13 am");
            DateTime endTime = DateTime.Parse("2019-08-31 09:00:39 am");

            // Sample Input 2
            //DateTime startTime = DateTime.Parse("2019-09-29 10:59:55 pm");
            //DateTime endTime = DateTime.Parse("2019-09-29 11:00:09 pm");

            // Sample Input 3
            //DateTime startTime = DateTime.Parse("2019-09-29 11:59:47 pm");
            //DateTime endTime = DateTime.Parse("2019-09-30 12:00:15 am");

            var totalCharge = 0;
            while (startTime <= endTime)
            {
                var diffInSeconds = (endTime - startTime).TotalSeconds;
                var restSeconds = diffInSeconds >= 20 ? 20 : diffInSeconds;
                DateTime slotEnd = startTime.AddSeconds(restSeconds);
               // string hourMessage = "(overlap)";
                bool isPeakHour = true;
                if (startTime.Hour >= 9 && 0 < slotEnd.Hour && slotEnd.Hour < 23) //9.00.00 am to 10.59.59 pm -> Peak Hour
                {
                    isPeakHour = true;
                    //hourMessage = "";
                }
                else if ((startTime.Hour >= 23 && slotEnd.Hour < 12) || (startTime.Hour >= 0 && slotEnd.Hour < 9)) //12.00.00 am to 8.59.59 am -> Off-peak Hour
                {
                    isPeakHour = false;
                    //hourMessage = "(Off-Peak)";
                }
                var addedSeconds = restSeconds < 20 ? restSeconds + 1 : 20;
                Console.WriteLine($"{startTime.ToString()} + {addedSeconds} second ({slotEnd.ToString()}); = {(isPeakHour ? "30" : "20")} paisa ");
                //Console.WriteLine($"{startTime.ToString()} + {addedSeconds} second ({slotEnd.ToString()}); = {(isPeakHour ? "30" : "20")} paisa { hourMessage} ");

                startTime = slotEnd.AddSeconds(1);
                totalCharge += isPeakHour ? 30 : 20;
            }
            Console.WriteLine($"{(float)totalCharge / 100} taka");
            Console.ReadKey();
        }        
    }
}
