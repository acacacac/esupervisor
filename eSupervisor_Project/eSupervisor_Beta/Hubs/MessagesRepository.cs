using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using eSupervisor_Beta.Models;

namespace eSupervisor_Beta.Hubs
{
    public class MessagesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        eSupervisorEntities db = new eSupervisorEntities();

        public IEnumerable<messageContainer> GetAllMessages(int receiverID)
        {
            var messages = new List<messageContainer>();
            int senderID = (int)HttpContext.Current.Session["userid"];
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [_content], [senderID], [time] FROM [dbo].[message] WHERE ([senderID] = " + senderID + 
                                                    " AND [receiverID] = " + receiverID + ") OR ([senderID] = " + receiverID + 
                                                    " AND [receiverID] = " + senderID + ")", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);


                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user u = db.users.Find((int)reader["senderID"]);
                        string sender = u.firstName + " " + u.lastName;
                        messages.Add(item: new messageContainer { content = (string)reader["_content"], senderID = (int)reader["senderID"], senderName = sender, time=Convert.ToDateTime(reader["time"]) });
                    }
                }

            }
            return messages;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MessagesHub.SendMessages();
            }
        }
    }
}