using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace BusinessLogicLayer
{
        /// <summary>
    /// Represents a rental and all the methods
    /// for selecting, inserting, and updating a rental
    /// </summary>
    public class Projects
    {

        // Initialize all fields to be selected, inserted, updated or deleted
        private int _projectID = 0;
        private string _projectName = String.Empty;
        private string _client = String.Empty;
        private string _service = String.Empty;
        private string _description = String.Empty;
        private string _url = String.Empty;
        private string _projectType = String.Empty;
        private string _tools = String.Empty;
        private string _industry = String.Empty;
        private string _strategy = String.Empty;
        private string _solution = String.Empty;
        private bool _publicView = false;

        /// <summary>
        /// Projects Unique Identifier
        /// </summary>
        public int projectID
        {
            get { return _projectID; }
        }

        /// <summary>
        /// Project Name
        /// </summary>
        public string projectName
        {
            get { return _projectName; }
        }

         /// <summary>
        /// Client Name
        /// </summary>
        public string client
        {
            get { return _client; }
        }

         /// <summary>
        /// Service Provided
        /// </summary>
        public string service
        {
            get { return _service; }
        }
        /// <summary>
        /// description
        /// </summary>
        public string description
        {
            get { return _description; }
        }

         /// <summary>
        /// URL address
        /// </summary>
        public string url
        {
            get { return _url; }
        }
        /// <summary>
        /// Project Type
        /// </summary>
        public string projectType
        {
            get { return _projectType; }
        }

         /// <summary>
        /// Tools used
        /// </summary>
        public string tools
        {
            get { return _tools; }
        }

        /// <summary>
        /// Project
        /// </summary>
        public string industry
        {
            get { return _industry; }
        }

        /// <summary>
        /// Strategy
        /// </summary>
        public string strategy
        {
            get { return _strategy; }
        }

        /// <summary>
        /// Solution
        /// </summary>
        public string solution
        {
            get { return _solution; }
        }

        /// <summary>
        /// publicView
        /// </summary>
        public bool publicView
        {
            get { return _publicView; }
        }

        /// <summary>
        /// Selects all projects
        /// </summary>
        /// <returns></returns>
        public static List<Projects> SelectAll()
        {
            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            return dataAccessLayer.ProjectSelectAll();
        }

        /// <summary>
        /// Retrieves all projects by project type
        /// </summary>
        /// <returns></returns>
        public static List<Projects> SelectByType(string projectType, bool publicView)
        {
            if (projectType == String.Empty)
                throw new ArgumentException("Project Type is required", "projectType");
                     
            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            return dataAccessLayer.SelectType(projectType, publicView);
        }

        /// <summary>
        /// Retrieves all projects by project industry
        /// </summary>
        /// <returns></returns>
        public static List<Projects> SelectByIndustry(string industry)
        {
            //if (projectID < 1)
            //    throw new ArgumentException("Projects Id must be greater than 0", "projID");

            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            return dataAccessLayer.SelectIndustry(industry);
        }
        

        /// <summary>
        /// Updates a particular rental
        /// </summary>
        /// <param name="projectID">Projects Id</param>
        /// 
        public static void Update(int projectID, string projectName, string client, string service, string description, string url, string projectType, string tools, string industry, string strategy, string solution, bool publicView)
        {
            if (projectID < 1)
                throw new ArgumentException("Project Id must be greater than 0", "Id");

            Projects projectToUpdate = new Projects (projectID, projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView);
            projectToUpdate.Save();
        }

        /// <summary>
        /// Inserts a new rental
        /// </summary>
        /// <param name="projectName">Project Name</param>
        public static void Insert(string projectName, string client, string service, string description, string url, string projectType, string tools, string industry, string strategy, string solution, bool publicView)
        {
            Projects newProject = new Projects(projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView);
            newProject.Save();
        }

        /// <summary>
        /// Deletes an existing rental
        /// </summary>
        /// <param name="id">Projects Id</param>
        public static void Delete(int projectID)
        {
            if (projectID < 1)
                throw new ArgumentException("Projects Id must be greater than 0", "projectID");

            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            dataAccessLayer.ProjectDelete(projectID);
        }

        /// <summary>
        /// Validates rental information before saving rental
        /// properties to the database
        /// </summary>
        private void Save()
        {
            //if (String.IsNullOrEmpty(_mls))
            //    throw new ArgumentException("Projects listing number not supplied", "mls");
            ////if (_mls.Length > 50)
            //    //throw new ArgumentException("Product Name must be less than 50 characters", "name");
            //if (String.IsNullOrEmpty(_bedrooms))
            //    throw new ArgumentException("Bedrooms not supplied", "bedrooms");
            //if (String.IsNullOrEmpty(_rentalProgram))
            //    throw new ArgumentException("Projects program not supplied", "rentalProgram");
            //if (String.IsNullOrEmpty(_location))
            //    throw new ArgumentException("Projects location not supplied", "location");
            //if (String.IsNullOrEmpty(_description))
            //    throw new ArgumentException("Projects description not supplied", "description");
            //if (String.IsNullOrEmpty(_zip))
            //    throw new ArgumentException("Projects descritpion not supplied", "zip");
            //// ADD EXCEPTION FOR RENT NOT NUMERIC

            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            if (_projectID > 0)
                dataAccessLayer.ProjectUpdate(this);
            else
                dataAccessLayer.ProjectInsert(this);
        }

        /// <summary>
        /// Initializes Projects
        /// </summary>
        /// <param name="mls">Projects MLS Listing Number</param>
        /// <param name="rent">Projects Amount</param>
        /// <param name="description">Projects Description</param>
        public Projects(string projectName, string client, string service, string description, string url, string projectType, string tools, string industry, string strategy, string solution, bool publicView)
            : this(0, projectName, client, service, description, url, projectType, tools, industry, strategy, solution, publicView) { }

        /// <summary>
        /// Initializes Projects
        /// </summary>
        /// <param name="id">Projects Id</param>
        /// <param name="mls">Projects Listing Number/MLS</param>
        /// <param name="bedrooms">Projects Bedrooms</param>
        /// <param name="rentalProgram">Projects Program</param>
        /// <param name="rent">Projects Amount</param>
        /// <param name="location">Projects Location</param>
        /// <param name="description">Projects Description</param>
        /// <param name="zip">Projects Zip</param>
        public Projects(int projectID, string projectName, string client, string service, string description, string url, string projectType, string tools, string industry, string strategy, string solution, bool publicView)
        {
            _projectID = projectID;
            _projectName = projectName;
            _client = client;
            _service = service;
            _description = description;
            _url = url;
            _projectType = projectType;
            _tools = tools;
            _industry = industry;
            _strategy = strategy;
            _solution = solution;
            _publicView = publicView;
        }
    }
}