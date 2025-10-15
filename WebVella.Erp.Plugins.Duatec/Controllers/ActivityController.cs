using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Plugins.Duatec.DataTransfere;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class ActivityController : Controller
    {
        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/a/activities/user-activities")]
        public ActionResult GetUserActivities()
        {
            return Json(GetRecentUserActivities());
        }

        private static List<UserActivityDto> GetRecentUserActivities()
        {
            const string entityName = "user_activity";
            var timeStamp = DateTime.UtcNow;
            var today = new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day, 0, 0, 0, 0, DateTimeKind.Utc);

            var command = new EqlCommand(
                $"SELECT * FROM {entityName} WHERE timestamp >= @today ORDER BY timestamp DESC",
                new EqlParameter("today", today));

            var recentActivities = command.Execute();

            command = new EqlCommand(
                "SELECT id, first_name, last_name FROM user");

            var usersLookup = command.Execute()
                .ToDictionary(r => (Guid)r["id"]);

            var result = new List<UserActivityDto>();

            foreach(var g in recentActivities.GroupBy(r => (Guid)r["user_id"]))
            {
                var user = usersLookup[g.Key];

                EntityRecord? lastEntry = null;

                foreach(var rec in g)
                {
                    if (lastEntry == null)
                        lastEntry = rec;

                    else if ((DateTime)rec["timestamp"] > (DateTime)lastEntry["timestamp"])
                        lastEntry = rec;
                }

                if (lastEntry != null)
                {
                    var lastTimestamp = (DateTime)lastEntry["timestamp"];

                    var duration = (timeStamp - lastTimestamp).TotalMinutes;

                    string timeString;

                    if (duration < 1)
                        timeString = "less than 1 minute ago";

                    else if (duration >= 120)
                        timeString = $"{(int)duration} hour(s) ago";

                    else
                        timeString = $"{(int)duration} minute(s) ago";

                    result.Add(new UserActivityDto()
                    {
                        FirstName = $"{user["first_name"]}",
                        LastName = $"{user["last_name"]}",
                        TimeString = timeString,
                        Page = $"{lastEntry["request_url"]}",
                    });
                }
            }

            return [.. result.OrderBy(ua => ua.FirstName).ThenBy(ua => ua.LastName)];
        }
    }
}
