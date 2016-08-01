using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Web;
using System.Configuration;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace CognitiveSoftware.TeamFoundation.Integration
{
    /// <summary>
    /// The DataManager class is responsible for managing, handling, and/or retrieving usefull
    /// and commonly used information.  The class is primarily responsible for retrieving
    /// objects from the team foundation server.
    /// </summary>
    internal sealed class DataManager
    {
        /// <summary>
        /// A private constructure prevents the class from being instantiated
        /// </summary>
        private DataManager() { }


        /// <summary>
        /// Gets the handle to the development project
        /// </summary>
        internal static Project DevelopmentProject
        {
            get
            {

                // because it can take a bit of time to connect to the team foundation server, we are caching
                // our connection to the project.  If the project is not in the cache
                // we create a new connection and then cache it.
                Project project = HttpContext.Current.Cache["Project"] as Project;
                if (project == null)
                {
                    // Use the custom configuration manager to get the connection information
                    // for the team foundation server.  This information allows application
                    // to instantiate a  connection to the project data store.
                    TeamFoundationConfigurationManager config = TeamFoundationConfigurationManager.GetConfigurationManager();
                    System.Net.NetworkCredential account = new System.Net.NetworkCredential(config.UserName,config.Password,config.Domain);
                    Microsoft.TeamFoundation.Client.TeamFoundationServer server = new Microsoft.TeamFoundation.Client.TeamFoundationServer(config.ServerName,account);
                    server.Authenticate();
                    WorkItemStore store = new WorkItemStore(server);
                    project = store.Projects[config.Project];
                    // cache the project; 30 minutes should be sufficient.  We're using a low priority cache because if the connection
                    // gets dropped due to resource constraints, we can just create a new one.
                    HttpContext.Current.Cache.Add("Project", project, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), CacheItemPriority.Low, null);
                }
                return project;
            }

        }

        /// <summary>
        /// Gets a new "Bug" work item
        /// </summary>
        /// <example>
        /// <code>
        /// WorkItem newBug = new WorkItem(DataManager.BugType);
        /// newBug.Title = "Sample bug";
        /// newBug.Fields["Symptom"].Value = "System crashes when I click 'GO!'";
        /// newBug.Fields["Severity"].Value = "High";
        /// newBug.Fields["Steps to Reproduce"].Value = "Click 'GO!'"
        /// newBug.Save();
        /// </code>
        /// </example>
        internal static WorkItemType BugType
        {
            get
            {
                
                return DevelopmentProject.WorkItemTypes["Bug"];
            }
        }

        /// <summary>
        /// Gets a new "Change Request" work item.
        /// </summary>
        /// <example>
        /// <code>
        /// WorkItem newRequest = new WorkItem(DataManager.ChangeRequestType);
        /// newRequest.Title = "Sample Change Request";
        /// newRequest.Description = "Change for the sake of change is fun";
        /// newRequest.Fields["Justification"].Value = "Attempting to make developers' lives difficult";
        /// newRequest.Save();
        /// </code>
        /// </example>
        internal static WorkItemType ChangeRequestType
        {
            get
            {
                return DevelopmentProject.WorkItemTypes["Change Request"];
            }
        }
    }
}
