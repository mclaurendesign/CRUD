using System;
//using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Collections.Generic;
using BusinessLogicLayer;

namespace DataAccessLayer
{
    /// <summary>
    /// Data Access Layer for interacting with Microsoft
    /// Access
    /// </summary>
    public class SqlDataAccessLayer
    {
        private static readonly string _connectionString = string.Empty;

        /// <summary>
        /// Selects all projects from the database
        /// </summary>
        public List<Projects> ProjectSelectAll()
        {
            // Create Projects collection
            List<Projects> colProject = new List<Projects>();

            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT projectID, projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView FROM projectTable";

            // Execute command
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colProject.Add(new Projects(
                        (int)reader["projectID"],
                        (string)reader["projectName"],
                        (string)reader["client"],
                        (string)reader["service"],
                        (string)reader["description"],
                        (string)reader["url"],
                        (string)reader["projectType"],
                        (string)reader["tools"],
                        (string)reader["industry"],
                        (string)reader["strategy"],
                        (string)reader["solution"],
                        (bool)reader["publicView"]));
                }
            }
            return colProject;
        }

        /// <summary>
        /// Selects all projects from the database by type
        /// </summary>
        public List<Projects> SelectType(string projectType, bool publicView)
        {
            // Create Projects collection
            List<Projects> colProject = new List<Projects>();

            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT projectID, projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView FROM [projectTable] WHERE (([projectType]=@projectType) AND ([publicView]= @publicView)) ";
        
            // Add parameters
            cmd.Parameters.AddWithValue("@projectType", projectType);
            cmd.Parameters.AddWithValue("@publicView", publicView);
       
            // Execute command
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colProject.Add(new Projects(
                         (int)reader["projectID"],
                         (string)reader["projectName"],
                         (string)reader["client"],
                         (string)reader["service"],
                         (string)reader["description"],
                         (string)reader["url"],
                         (string)reader["projectType"],
                         (string)reader["tools"],
                         (string)reader["industry"],
                         (string)reader["strategy"],
                         (string)reader["solution"],
                         (bool)reader["publicView"]));
                }
            }
            return colProject;
        }

        /// <summary>
        /// Selects all projects from the database by type
        /// </summary>
        public List<Projects> SelectIndustry(string industry)
        {
            // Create Projects collection
            List<Projects> colProject = new List<Projects>();

            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT projectID, projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView FROM projectTable WHERE industry=@industry";

            // Add parameters
            cmd.Parameters.AddWithValue("@industry", industry);
       
            // Execute command
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colProject.Add(new Projects(
                         (int)reader["projectID"],
                         (string)reader["projectName"],
                         (string)reader["client"],
                         (string)reader["service"],
                         (string)reader["description"],
                         (string)reader["url"],
                         (string)reader["projectType"],
                         (string)reader["tools"],
                         (string)reader["industry"],
                         (string)reader["strategy"],
                         (string)reader["solution"],
                         (bool)reader["publicView"]));
                }
            }
            return colProject;
        }

       

        /// <summary>
        /// Inserts a new project into the database
        /// </summary>
        /// <param name="newProject">Projects</param>
        public void ProjectInsert(Projects newProject)
        {
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO project (projectID, projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView  ) VALUES (@projectID, @projectName, @client, @service, @description, @url, @projectType, @tools, @industry, @strategy, @solution, @publicView )";

            // Add parameters
            cmd.Parameters.AddWithValue("@projectID", newProject.projectID);
            cmd.Parameters.AddWithValue("@projectName", newProject.projectName);
            cmd.Parameters.AddWithValue("@client", newProject.client);
            cmd.Parameters.AddWithValue("@service", newProject.service);
            cmd.Parameters.AddWithValue("@description", newProject.description);
            cmd.Parameters.AddWithValue("@url", newProject.url);
            cmd.Parameters.AddWithValue("@projectType", newProject.projectType);
            cmd.Parameters.AddWithValue("@tools", newProject.tools);
            cmd.Parameters.AddWithValue("@industry", newProject.industry);
            cmd.Parameters.AddWithValue("@stategy", newProject.strategy);
            cmd.Parameters.AddWithValue("@solution", newProject.solution);
            cmd.Parameters.AddWithValue("@publicView", newProject.publicView);
            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates an existing project in the database
        /// </summary>
        /// <param name="projectToUpdate">rentalToUpdate</param>
        public void ProjectUpdate(Projects projectToUpdate)
        {
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE [projectTable] SET [projectName]=@projectName, [client] =@client, [service]=@service, [desctiption]=@description, [url]=@url, [projectType]=@projectType, [tools]=@tools, [industry]=@industry, [strategy]=@strategy, [solution]=@solution, [publicView]=@publicView WHERE [projectID]=@projectID";

            // Add parameters
            cmd.Parameters.AddWithValue("@projectID", projectToUpdate.projectID);
            cmd.Parameters.AddWithValue("@projectName", projectToUpdate.projectName);
            cmd.Parameters.AddWithValue("@client", projectToUpdate.client);
            cmd.Parameters.AddWithValue("@service", projectToUpdate.service);
            cmd.Parameters.AddWithValue("@description", projectToUpdate.description);
            cmd.Parameters.AddWithValue("@url", projectToUpdate.url);
            cmd.Parameters.AddWithValue("@projectType", projectToUpdate.projectType);
            cmd.Parameters.AddWithValue("@tools", projectToUpdate.tools);
            cmd.Parameters.AddWithValue("@industry", projectToUpdate.industry);
            cmd.Parameters.AddWithValue("@stategy", projectToUpdate.strategy);
            cmd.Parameters.AddWithValue("@solution", projectToUpdate.solution);
            cmd.Parameters.AddWithValue("@publicView", projectToUpdate.publicView);
            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Deletes an existing rental in the database
        /// </summary>
        /// <param name="id">Projects Id</param>
        public void ProjectDelete(int projectID)
        {
            // Create connection
            OleDbConnection con = new OleDbConnection(_connectionString);

            // Create command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE * FROM [projectTable] WHERE ([projectID] = @projectID)";
            // Add parameters
            cmd.Parameters.AddWithValue("@projectID", projectID);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Initialize the data access layer by
        /// loading the database connection string from 
        /// the Web.Config file
        /// </summary>
        static SqlDataAccessLayer()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("No connection string configured in Web.Config file");
        }
    }
}